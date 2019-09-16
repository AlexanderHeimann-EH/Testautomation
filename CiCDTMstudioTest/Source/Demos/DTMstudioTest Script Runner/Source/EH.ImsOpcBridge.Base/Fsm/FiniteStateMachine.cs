// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachine.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Abstract base class for a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// Abstract base class for a finite state machine.
    /// </summary>
    public abstract class FiniteStateMachine : IFiniteStateMachine
    {
        #region Constants and Fields

        /// <summary>
        /// Reference to logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Event queue, receiving events to be processed.
        /// </summary>
        private readonly IFsmEventQueueNative eventQueue = new FsmEventQueueNative();

        /// <summary>
        /// Report error reference.
        /// </summary>
        private readonly IReportError reportError;

        /// <summary>
        /// Dictionary containing instances of all valid states of the finite state machine using
        /// the full name of the type of the state as keys
        /// </summary>
        private readonly Dictionary<string, IFsmState> states = new Dictionary<string, IFsmState>();

        /// <summary>
        /// Event, which will be set when thread is started successfully
        /// </summary>
        private readonly AutoResetEvent threadStartedEvent = new AutoResetEvent(false);

        /// <summary>
        /// The timer handler manages timers. It can be used to create, start,
        /// stop and kill different timers.
        /// </summary>
        private readonly ITimerHandler timerHandler = new TimerHandler();

        /// <summary>
        /// Current state of the finite state machine
        /// </summary>
        private IFsmState currentState;

        /// <summary>
        /// Disposed flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Event handler thread sequentially processing events in the event queue.
        /// </summary>
        private Thread eventHandlerThread;

        /// <summary>
        /// Returns whether the event handler thread is running.
        /// </summary>
        private bool isEventHandlerThreadRunning;

        /// <summary>
        /// Determines whether finite state machine should report errors.
        /// </summary>
        private bool reportErrorEnabled = true;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiniteStateMachine"/> class.
        /// Constructor
        /// </summary>
        /// <param name="reportError">The report error.</param>
        protected FiniteStateMachine(IReportError reportError)
        {
            this.reportError = reportError;
            this.timerHandler.TimerEvent += this.TimerEvent;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FiniteStateMachine"/> class.
        /// Destructor
        /// </summary>
        ~FiniteStateMachine()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Event, which is fired whenever the handling of an incoming event has failed.
        /// </summary>
        public event EventHandler<EventHandlingFailedEventArgs> EventHandlingFailedEvent;

        /// <summary>
        /// Event, which is fired whenever there's information about a progress.
        /// </summary>
        public event EventHandler<ProgressStepUpdateEventArgs> ProgressStepUpdate;

        /// <summary>
        /// Event, which is fired whenever the current state of the state machine has changed.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChangedEvent;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the current state of the finite state machine
        /// </summary>
        public IFsmState CurrentState
        {
            get
            {
                return this.currentState;
            }
        }

        /// <summary>
        /// Gets the type of the current state of the finite state machine
        /// </summary>
        public Type CurrentStateType
        {
            get
            {
                return this.currentState.GetType();
            }
        }

        /// <summary>
        /// Gets or sets the thread priority of the event handler thread
        /// </summary>
        /// <value>The event handler thread priority.</value>
        public ThreadPriority EventHandlerThreadPriority
        {
            get
            {
                return this.eventHandlerThread.Priority;
            }

            set
            {
                this.eventHandlerThread.Priority = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the event handler thread is running.
        /// </summary>
        public bool IsEventHandlerThreadRunning
        {
            get
            {
                return this.isEventHandlerThreadRunning;
            }
        }

        /// <summary>
        /// Gets the number of states registered.
        /// </summary>
        public int NumberOfStates
        {
            get
            {
                return this.states.Count;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this finite state machine should report errors.
        /// </summary>
        /// <value><c>true</c> if [report error enabled]; otherwise, <c>false</c>.</value>
        public bool ReportErrorEnabled
        {
            get
            {
                return this.reportErrorEnabled;
            }

            set
            {
                this.reportErrorEnabled = value;
            }
        }

        /// <summary>
        /// Gets the timer handler manages timers. It can be used to create, start,
        /// stop and kill different timers.
        /// </summary>
        public ITimerHandler TimerHandler
        {
            get
            {
                return this.timerHandler;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the event queue, receiving events to be processed.
        /// </summary>
        internal IFsmEventQueueNative EventQueue
        {
            get
            {
                return this.eventQueue;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the actual state to the corresponding state
        /// </summary>
        /// <param name="nextStateType">Type of the state to be used as a new current state of the state machine.</param>
        /// <exception cref="BaseException">
        /// Thrown if type of the state to be set new current state has not been registered and therefore is not a valid state of the state machine.
        /// </exception>
        public virtual void ChangeState(Type nextStateType)
        {
            if (nextStateType == null)
            {
                return;
            }

            if (nextStateType.FullName == null)
            {
                return;
            }

            lock (this.states)
            {
                if (this.IsCurrentState(nextStateType))
                {
                    return;
                }

                if (Logger.IsDebugEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.ChangingStateOfFiniteStateMachineTo_, nextStateType.FullName);
                    Logger.Debug(message);
                }

                if (this.states.ContainsKey(nextStateType.FullName))
                {
                    var nextState = this.states[nextStateType.FullName];

                    var args = new StateChangedEventArgs(this.currentState, nextState);

                    this.currentState = nextState;
                    this.OnStateChangedEvent(this, args);

                    return;
                }

                foreach (var statePair in this.states)
                {
                    var nextState = statePair.Value;

                    if (nextState.IsOfType(nextStateType))
                    {
                        var args = new StateChangedEventArgs(this.currentState, nextState);

                        this.currentState = nextState;
                        this.OnStateChangedEvent(this, args);

                        return;
                    }
                }

                if (Logger.IsErrorEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.ChangingStateOfFiniteStateMachineToState_Failed, nextStateType.FullName);
                    Logger.Debug(message);
                }

                throw new BaseException(string.Format(CultureInfo.InvariantCulture, Resources.State_NotFound, nextStateType.FullName));
            }
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
        /// Call this method after the instantiation of the finite state machine.
        /// This method calls RegisterAllStates() and InitQueue().
        /// </summary>
        public void Initialize()
        {
            this.RegisterAllStates();

            if (this.currentState == null)
            {
                throw new BaseException(Resources.StateOfTheFiniteStateMachineHasNotBeenInitialized);
            }

            this.InitQueue();
        }

        /// <summary>
        /// Checks whether the corresponding state is the current state or one of its subclasses.
        /// </summary>
        /// <param name="stateToCompare">Type of the state to be checked whether it's the current state or one of its subclasses of the state machine.</param>
        /// <returns>True if stateToCompare is the current state or one of its subclasses. False if it is not.</returns>
        public virtual bool IsCurrentState(Type stateToCompare)
        {
            if (this.currentState == null)
            {
                return stateToCompare == null;
            }

            return this.currentState.IsOfType(stateToCompare);
        }

        /// <summary>
        /// Receives an FsmTimerEvent and adds it to the incoming event queue to be processed by
        /// the event handler thread of the finite state machine. This method receives the event
        /// with normal priority.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the incoming event queue.</param>
        public virtual void ReceiveEvent(IFsmEvent fsmEvent)
        {
            if (fsmEvent == null)
            {
                throw new ArgumentNullException(@"fsmEvent");
            }

            this.ReceiveEvent(fsmEvent, false);
        }

        /// <summary>
        /// Receives an FsmTimerEvent and adds it to the incoming event queue to be processed by
        /// the event handler thread of the finite state machine. This method receives the event
        /// with normal or high Priority according the Flag highPriority set to true or false.
        /// FsmEvents of high priority are inserted at the beginning of the event queue.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the incoming event queue.</param>
        /// <param name="highPriority">True if FsmEvent has to be handled with high priority. False if it has to be handled with normal priority.</param>
        public virtual void ReceiveEvent(IFsmEvent fsmEvent, bool highPriority)
        {
            if (fsmEvent == null)
            {
                throw new ArgumentNullException(@"fsmEvent");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineReceivesEvent_, fsmEvent.Message);
                Logger.Debug(message);
            }

            if (fsmEvent == null)
            {
                throw new ArgumentNullException(@"fsmEvent");
            }

            this.eventQueue.PutEvent(fsmEvent, highPriority);
        }

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        /// <param name="ex">Exception occurred.</param>
        public void ReportError(string description, Exception ex)
        {
            if ((this.reportError != null) && this.reportErrorEnabled)
            {
                this.reportError.ReportError(description, ex);
            }
        }

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        public void ReportError(string description)
        {
            if ((this.reportError != null) && this.reportErrorEnabled)
            {
                this.reportError.ReportError(description);
            }
        }

        /// <summary>
        /// Sends an event to a foreign finite state machine
        /// </summary>
        /// <param name="fsmReceiver">FsmStateMachine to receive the event</param>
        /// <param name="fsmEvent">FsmEvent to be sent</param>
        public virtual void SendEvent(IFiniteStateMachine fsmReceiver, IFsmEvent fsmEvent)
        {
            if (fsmReceiver == null)
            {
                throw new ArgumentNullException(@"fsmReceiver");
            }

            if (fsmEvent == null)
            {
                throw new ArgumentNullException(@"fsmEvent");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineSendsEvent_To_, fsmEvent.Message, fsmReceiver);
                Logger.Debug(message);
            }

            fsmReceiver.ReceiveEvent(fsmEvent);
        }

        /// <summary>
        /// Shuts the event handler thread down, stopping the processing of events in the
        /// event queue of the finite state machine.
        /// </summary>
        public virtual void ShutdownQueueThread()
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(Resources.ShuttingDownTheFiniteMachineQueueThread);
            }

            if (this.isEventHandlerThreadRunning)
            {
                var thread = this.eventHandlerThread;

                this.eventQueue.Shutdown = true;
                this.isEventHandlerThreadRunning = false;

                this.eventQueue.QueueEvent.Set();

                thread.Join();
                this.eventHandlerThread = null;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is firing the EventHandlingFailedEvent.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args">Arguments of the event.</param>
        internal virtual void OnEventHandlingFailedEvent(object sender, EventHandlingFailedEventArgs args)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineFailedHandlingAnEventState_Event_, args.CurrentState.Name, args.FsmEvent.Message);
                Logger.Debug(message);
            }

            var eventHandlingFailedEvent = this.EventHandlingFailedEvent;

            if (eventHandlingFailedEvent != null)
            {
                eventHandlingFailedEvent(this, args);
            }
        }

        /// <summary>
        /// This method is firing the ProgressStepUpdate.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args">Arguments of the event.</param>
        internal virtual void OnProgressStepUpdateEvent(object sender, ProgressStepUpdateEventArgs args)
        {
            var progressStepUpdate = this.ProgressStepUpdate;

            if (progressStepUpdate != null)
            {
                progressStepUpdate(this, args);
            }
        }

        /// <summary>
        /// This method is firing the StateChangedEvent.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args">Arguments of the event.</param>
        internal virtual void OnStateChangedEvent(object sender, StateChangedEventArgs args)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineChangedStateFrom_to_, args.OldState, args.NewState);
                Logger.Debug(message);
            }

            var stateChangedEvent = this.StateChangedEvent;

            if (stateChangedEvent != null)
            {
                stateChangedEvent(this, args);
            }
        }

        /// <summary>
        /// Initializes the event queue of the finite state machine and starts the
        /// event handler thread processing incoming events of the finite state machine.
        /// </summary>
        protected virtual void InitQueue()
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(Resources.FiniteStateMachineInitializesItsQueue);
            }

            if (this.eventHandlerThread == null)
            {
                this.threadStartedEvent.Reset();

                this.isEventHandlerThreadRunning = true;

                // create and start the queue thread
                this.eventHandlerThread = new Thread(this.QueueThread);
                this.eventHandlerThread.Start(this);

                // wait for started
                this.threadStartedEvent.WaitOne();
            }
        }

        /// <summary>
        /// Sets the initial state of the state machine to the corresponding state type.
        /// </summary>
        /// <param name="initialState">Type of the initial state to be set</param>
        protected virtual void InitState(Type initialState)
        {
            if (initialState == null)
            {
                throw new ArgumentNullException(@"initialState");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineSetsTheInitialStateTo_, initialState.FullName);
                Logger.Debug(message);
            }

            this.ChangeState(initialState);
        }

        /// <summary>
        /// Internal dispose.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected virtual void InternalDispose(bool disposing)
        {
        }

        /// <summary>
        /// Processes a FsmEvent by calling Execute(currentState) on the FsmEvent.
        /// </summary>
        /// <param name="fsmEvent">FsmEvent to be executed.</param>
        protected virtual void ProcessEvent(IFsmEvent fsmEvent)
        {
            if (fsmEvent == null)
            {
                throw new ArgumentNullException(@"fsmEvent");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineProcessesAnEventCurrentState_Event_, this.CurrentStateType.FullName, fsmEvent.Message);
                Logger.Debug(message);
            }

            fsmEvent.Execute(this.currentState);
        }

        /// <summary>
        /// Abstract method to be implemented by all concrete finite state machine. This method
        /// should register all available states using RegisterState() and set the initial state
        /// using InitState().
        /// </summary>
        protected abstract void RegisterAllStates();

        /// <summary>
        /// Registers a FsmState of the finite state machine.
        /// </summary>
        /// <param name="fsmState">FsmState to be registered.</param>
        protected virtual void RegisterState(IFsmState fsmState)
        {
            if (fsmState == null)
            {
                throw new ArgumentNullException(@"fsmState");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineRegistersTheState_, fsmState);
                Logger.Debug(message);
            }

            lock (this.states)
            {
                this.states.Add(fsmState.Name, fsmState);
            }
        }

        /// <summary>
        /// Event handler for a timer event. This method is creating a FsmTimerEvent and adds it to
        /// the incoming event queue to be processed by the event handler thread of the finite state
        /// machine
        /// </summary>
        /// <param name="sender">Sender of the timer event.</param>
        /// <param name="e">Timer event arguments.</param>
        protected virtual void TimerEvent(object sender, TimerEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.FiniteStateMachineReceivesATimerEventSender_Arguments_, sender, e.Message);
                Logger.Debug(message);
            }

            switch (e.Hint.EventType)
            {
                case TimerEventType.Elapsed:
                case TimerEventType.Tick:
                    FsmEvent fsmTimerEvent = new FsmTimerEvent(e);
                    this.ReceiveEvent(fsmTimerEvent);
                    break;
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
                this.InternalDispose(disposing);

                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    this.threadStartedEvent.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                this.ShutdownQueueThread();
                this.timerHandler.TimerEvent -= this.TimerEvent;
                this.timerHandler.Dispose();
                this.eventQueue.Dispose();
            }

            this.disposed = true;
        }

        /// <summary>
        /// Thread procedure of the event handler thread processing incoming events of the
        /// finite state machine.
        /// </summary>
        /// <param name="param">Thread parameter.</param>
        [STAThread]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed. Suppression is OK here.")]
        private void QueueThread(object param)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(Resources.FiniteStateMachineIsStartingItsQueueThread);
            }

            var fsm = param as FiniteStateMachine;

            if (fsm == null)
            {
                throw new ArgumentNullException(@"param"); // illegal parameter
            }

            fsm.threadStartedEvent.Set();

            while (fsm.IsEventHandlerThreadRunning)
            {
                var fsmEvent = fsm.EventQueue.NextEventGet();

                if (fsmEvent != null)
                {
                    try
                    {
                        fsm.ProcessEvent(fsmEvent);
                    }
                    catch (Exception ex)
                    {
                        var args = new EventHandlingFailedEventArgs(fsm.CurrentState, fsmEvent, ex);
                        this.OnEventHandlingFailedEvent(this, args);
                    }
                }
                else
                {
                    fsm.EventQueue.QueueEvent.WaitOne();
                }
            }

            fsm.isEventHandlerThreadRunning = false;
            fsm.eventHandlerThread = null;
        }

        #endregion
    }
}
