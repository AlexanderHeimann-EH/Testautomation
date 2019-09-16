// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Timer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   This class represents and manages a specific timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;

    /// <summary>
    /// This class represents and manages a specific timer.
    /// </summary>
    public class Timer : ITimer
    {
        #region Constants and Fields

        /// <summary>
        /// Name of the timer.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Reference to the timer manager, which handles a set of timers.
        /// </summary>
        private readonly TimerHandler timerHandler;

        /// <summary>
        /// Event, which is set when the thread of the timer started successfully
        /// </summary>
        private readonly AutoResetEvent timerThreadStartedEvent = new AutoResetEvent(false);

        /// <summary>
        /// Event, which is set to wake up the sleeping timer thread
        /// </summary>
        private readonly AutoResetEvent wakeTimerThreadEvent = new AutoResetEvent(false);

        /// <summary>
        /// Disposed flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Flag signaling that the timer should shut down.
        /// </summary>
        private bool shutdown = true;

        /// <summary>
        /// Timespan by which timer elapses
        /// </summary>
        private TimeSpan timeSpan = new TimeSpan(0, 0, 1);

        /// <summary>
        /// Timer thread
        /// </summary>
        private Thread timerThread;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// Constructor
        /// </summary>
        /// <param name="timerHandler">The timer handler.</param>
        /// <param name="name">The name.</param>
        public Timer(TimerHandler timerHandler, string name)
        {
            this.ElapseProperties = new PropertyCollection();
            this.TickTimeSpan = new TimeSpan(0, 0, 0);
            this.TickProperties = new PropertyCollection();
            this.name = name;
            this.timerHandler = timerHandler;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Timer"/> class.
        /// Destructor
        /// </summary>
        ~Timer()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the property collection for elapsing timer.
        /// </summary>
        /// <value>The elapse properties.</value>
        public PropertyCollection ElapseProperties { get; private set; }

        /// <summary>
        /// Gets or sets the time when timer will elapse.
        /// </summary>
        /// <value>The end time.</value>
        public DateTime EndTime { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the timer is running.
        /// </summary>
        /// <value><c>true</c> if this instance is timer running; otherwise, <c>false</c>.</value>
        public bool IsTimerRunning { get; protected set; }

        /// <summary>
        /// Gets or sets the time when timer has been started.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; protected set; }

        /// <summary>
        /// Gets the property collection for timer ticks.
        /// </summary>
        public PropertyCollection TickProperties { get; private set; }

        /// <summary>
        /// Gets or sets the timespan by which the timer tick fires. Set this to 0 to switch off timer ticks.
        /// </summary>
        /// <value>The tick time span.</value>
        public TimeSpan TickTimeSpan { get; protected set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Kills the timer. This methods stops the thread handling the timer events.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public bool KillTimer()
        {
            lock (this)
            {
                if (this.timerThread != null)
                {
                    this.IsTimerRunning = false;
                    this.shutdown = true;

                    this.wakeTimerThreadEvent.Set();

                    this.timerThread.Join();
                    this.timerThread = null;

                    if (this.timerHandler != null)
                    {
                        var now = DateTime.Now;
                        var remainingPeriod = this.EndTime - now;
                        var newHint = new TimerHint(remainingPeriod, TimerEventType.Killed, this.name, this.ElapseProperties);

                        try
                        {
                            this.timerHandler.OnTimerEvent(newHint);
                        }
                        catch (BaseException)
                        {
                        }
                    }
                }
            }

            return this.timerThread == null;
        }

        /// <summary>
        /// Sets the timer.
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool SetTimer(TimeSpan timeSpanToSet, PropertyCollection properties, bool autoStart)
        {
            if (autoStart)
            {
                this.StopTimer();

                // set the elapse properties
                this.ElapseProperties = properties;

                return this.StartTimer(timeSpanToSet);
            }

            // set the elapse properties
            this.ElapseProperties = properties;
            this.timeSpan = timeSpanToSet;

            return true;
        }

        /// <summary>
        /// Sets the ticker of a timer. A ticker usually fires in a periodical way before a timer elapses.
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the ticker should fire.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the ticker fires.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool SetTicker(TimeSpan timeSpanToSet, PropertyCollection properties)
        {
            if (timeSpanToSet.TotalMilliseconds > short.MaxValue)
            {
                return false;
            }

            if (this.IsTimerRunning)
            {
                return false;
            }

            this.TickTimeSpan = timeSpanToSet;
            this.TickProperties = properties;

            return true;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StartTimer()
        {
            return this.StartTimer(this.timeSpan);
        }

        /// <summary>
        /// Set the timespan by which the timer should elapse and starts the timer
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the timer should elapse.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public bool StartTimer(TimeSpan timeSpanToSet)
        {
            if (this.IsTimerRunning)
            {
                return false;
            }

            lock (this)
            {
                this.timeSpan = timeSpanToSet;

                // set new start/end time
                this.StartTime = DateTime.Now;
                this.EndTime = this.StartTime + this.timeSpan;

                // let the timer run !!!!
                this.IsTimerRunning = true;
                this.shutdown = false;

                if (this.timerThread == null)
                {
                    this.wakeTimerThreadEvent.Reset();
                    this.timerThreadStartedEvent.Reset();

                    // create and start the timer thread
                    this.timerThread = new Thread(this.TimerThread);
                    this.timerThread.Start(this);

                    // wait for started
                    this.timerThreadStartedEvent.WaitOne();
                }
                else
                {
                    // restart timer
                    this.wakeTimerThreadEvent.Set();
                }

                if (this.timerHandler != null)
                {
                    var newHint = new TimerHint(this.timeSpan, TimerEventType.Started, this.name, this.ElapseProperties);
                    this.timerHandler.OnTimerEvent(newHint);
                }
            }

            return this.IsTimerRunning;
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        public bool StopTimer()
        {
            lock (this)
            {
                if (this.IsTimerRunning)
                {
                    this.IsTimerRunning = false;
                    if (this.timerThread != null)
                    {
                        this.wakeTimerThreadEvent.Set();

                        // remark: stopping the timer does not cause the timer thread to leave the loop.
                        if (this.timerHandler != null)
                        {
                            var now = DateTime.Now;
                            var remainingPeriod = this.EndTime - now;
                            var newHint = new TimerHint(remainingPeriod, TimerEventType.Stopped, this.name, this.ElapseProperties);

                            try
                            {
                                this.timerHandler.OnTimerEvent(newHint);
                            }
                            catch (BaseException)
                            {
                            }
                        }
                    }
                }
            }

            return this.IsTimerRunning == false;
        }

        /// <summary>
        /// Stops the ticker of the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StopTicker()
        {
            this.TickTimeSpan = new TimeSpan(0);
            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called by the timer thread whenever the timer elapses.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        protected void Elapse()
        {
            if (this.timerHandler != null)
            {
                var newHint = new TimerHint(new TimeSpan(0), TimerEventType.Elapsed, this.name, this.ElapseProperties);

                try
                {
                    this.timerHandler.OnTimerEvent(newHint);
                }
                catch (BaseException)
                {
                }
            }
        }

        /// <summary>
        /// This method is called by the timer thread whenever the ticker of the timer fires.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        protected void Tick()
        {
            if (this.timerHandler != null)
            {
                var now = DateTime.Now;
                var remainingPeriod = this.EndTime - now;
                var newHint = new TimerHint(remainingPeriod, TimerEventType.Tick, this.name, this.TickProperties);

                try
                {
                    this.timerHandler.OnTimerEvent(newHint);
                }
                catch (BaseException)
                {
                }
            }
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    this.timerThreadStartedEvent.Dispose();
                    this.wakeTimerThreadEvent.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                this.KillTimer();
            }

            this.disposed = true;
        }

        /// <summary>
        /// Method of the thread, which handles the timer and ticker events.
        /// </summary>
        /// <param name="param">An object that contains data to be used by the method the thread executes.</param>
        private void TimerThread(object param)
        {
            var timerInfo = param as Timer;

            if (timerInfo == null)
            {
                throw new ArgumentNullException(@"param"); // illegal parameter
            }

            try
            {
                // check whether to wait for tick period or for timer elapse
                var now = DateTime.Now;
                var timeToEnd = timerInfo.EndTime - now;
                var timeToTick = timerInfo.TickTimeSpan;

                timerInfo.timerThreadStartedEvent.Set();

                while (!timerInfo.shutdown)
                {
                    if ((timeToEnd.TotalSeconds <= 0) || !timerInfo.IsTimerRunning)
                    {
                        if (timerInfo.IsTimerRunning)
                        {
                            // elapse
                            timerInfo.Elapse();
                            timerInfo.IsTimerRunning = false;
                        }

                        // wait for a long time
                        timerInfo.wakeTimerThreadEvent.WaitOne();

                        if (!timerInfo.shutdown)
                        {
                            // restart timer
                            now = DateTime.Now;
                            timeToEnd = timerInfo.EndTime - now;
                            timeToTick = timerInfo.TickTimeSpan;
                        }
                    }
                    else
                    {
                        // wait
                        double waitingTime;

                        if ((timerInfo.TickTimeSpan.TotalSeconds > 0) && (timeToEnd > timeToTick))
                        {
                            waitingTime = timerInfo.TickTimeSpan.TotalMilliseconds; // wait time until tick
                        }
                        else
                        {
                            // wait time until end, maximal 60 seconds
                            if (timeToEnd.TotalSeconds > 60)
                            {
                                waitingTime = 60000; // wait 60 seconds
                            }
                            else
                            {
                                waitingTime = timeToEnd.TotalMilliseconds; // wait remaining seconds
                            }
                        }

                        // wait
                        timerInfo.wakeTimerThreadEvent.WaitOne((short)waitingTime, false);

                        // calculate new times
                        now = DateTime.Now;
                        timeToEnd = timerInfo.EndTime - now;
                        timeToTick = timerInfo.TickTimeSpan;

                        if ((timerInfo.TickTimeSpan.TotalSeconds > 0) && (timeToEnd.TotalSeconds > 0) && timerInfo.IsTimerRunning)
                        {
                            timerInfo.Tick();
                        }
                    }
                }
            }
            catch (BaseException)
            {
            }

            // show Thread stopped
            timerInfo.IsTimerRunning = false;
        }

        #endregion
    }
}
