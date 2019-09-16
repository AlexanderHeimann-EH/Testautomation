// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Timer manager class, which handles a set of timers.
    /// </summary>
    public class TimerHandler : ITimerHandler
    {
        #region Constants and Fields

        /// <summary>
        /// Dictionary containing all timers of the timer handler by name as key
        /// </summary>
        private readonly Dictionary<string, ITimer> timerInfos = new Dictionary<string, ITimer>();

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="TimerHandler"/> class.
        /// Destructor
        /// </summary>
        ~TimerHandler()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Event, which is fired whenever a timer of the timer handler is started, stopped,
        /// elapses, fires a tick or is killed.
        /// </summary>
        public event EventHandler<TimerEventArgs> TimerEvent;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the collection of the names of all timers the timer handler contains
        /// </summary>
        public Dictionary<string, ITimer>.KeyCollection Names
        {
            get
            {
                return this.timerInfos.Keys;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns whether the timer handler contains a timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if the timer handler contains a timer with the specified name. False if it doesn't.</returns>
        public bool ContainsTimer(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            return this.timerInfos.ContainsKey(upperName);
        }

        /// <summary>
        /// Creates a new timer.
        /// </summary>
        /// <param name="name">Name of the timer to create.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool CreateTimer(string name, TimeSpan timeSpan, PropertyCollection properties, bool autoStart)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            if (!this.timerInfos.ContainsKey(upperName))
            {
                var newTimer = new Timer(this, upperName);

                this.timerInfos.Add(upperName, newTimer);
            }

            return this.SetTimer(upperName, timeSpan, properties, autoStart);
        }

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
        /// Get property collection for elapsing timer of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>Property collection holding data, which the consumer wants to analyze when the timer elapses.</returns>
        public PropertyCollection GetTimerElapseProperties(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            return this.timerInfos[upperName].ElapseProperties;
        }

        /// <summary>
        /// Get property collection for ticks of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>Property collection holding data, which the consumer wants to analyze when the timer tick is fired.</returns>
        public PropertyCollection GetTimerTickProperties(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            return this.timerInfos[upperName].TickProperties;
        }

        /// <summary>
        /// Returns whether the timer with the corresponding name is running.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True, if the timer is running. False, if it is not running.</returns>
        public bool IsTimerRunning(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].IsTimerRunning;
            }

            return retValue;
        }

        /// <summary>
        /// Kills the timer with the corresponding name. This methods stops the thread handling the timer events.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool KillTimer(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = true;

            if (this.timerInfos.ContainsKey(upperName))
            {
                var timerInfo = this.timerInfos[upperName];
                retValue = timerInfo.KillTimer();
                if (retValue)
                {
                    this.timerInfos.Remove(upperName);
                    timerInfo.Dispose();
                }
            }

            return retValue;
        }

        /// <summary>
        /// Sets the values of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to set.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool SetTimer(string name, TimeSpan timeSpan, PropertyCollection properties, bool autoStart)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].SetTimer(timeSpan, properties, autoStart);
            }

            return retValue;
        }

        /// <summary>
        /// Sets the ticker of the timer with the corresponding name. A ticker usually fires
        /// in a periodical way before a timer elapses.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <param name="timeSpan">Timespan by which the ticker should fire.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the ticker fires.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool SetTimerTicker(string name, TimeSpan timeSpan, PropertyCollection properties)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].SetTicker(timeSpan, properties);
            }

            return retValue;
        }

        /// <summary>
        /// Starts the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to start.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StartTimer(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].StartTimer();
            }

            return retValue;
        }

        /// <summary>
        /// Set the timespan by which the timer with the corresponding name should elapse
        /// and starts the timer.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StartTimer(string name, TimeSpan timeSpan)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].StartTimer(timeSpan);
            }

            return retValue;
        }

        /// <summary>
        /// Stops the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to stop.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StopTimer(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].StopTimer();
            }

            return retValue;
        }

        /// <summary>
        /// Stops the ticker of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        public bool StopTimerTicker(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(@"name");
            }

            var upperName = name.ToUpperInvariant();
            var retValue = false;

            if (this.timerInfos.ContainsKey(upperName))
            {
                retValue = this.timerInfos[upperName].StopTicker();
            }

            return retValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is firing the TimerEvent.
        /// </summary>
        /// <param name="hint">Hint containing information about the timer and the type of event fired.</param>
        internal void OnTimerEvent(TimerHint hint)
        {
            var timerEvent = this.TimerEvent;

            if (timerEvent != null)
            {
                EventHandlerStopTimer stopTimerDelegate = null;

                if (this.timerInfos.ContainsKey(hint.Name))
                {
                    stopTimerDelegate = this.timerInfos[hint.Name].StopTimer;
                }

                var timerEventArgs = new TimerEventArgs(hint, stopTimerDelegate);

                timerEvent(this, timerEventArgs);
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
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                foreach (var key in this.timerInfos.Keys)
                {
                    this.timerInfos[key].Dispose();
                }

                this.timerInfos.Clear();
            }

            this.disposed = true;
        }

        #endregion
    }
}
