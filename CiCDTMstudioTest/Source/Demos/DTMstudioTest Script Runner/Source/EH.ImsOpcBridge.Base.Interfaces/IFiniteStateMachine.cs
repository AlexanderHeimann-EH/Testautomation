// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFiniteStateMachine.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Threading;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;

    /// <summary>
    /// Interface of a finite state machine.
    /// </summary>
    public interface IFiniteStateMachine : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Event, which is fired whenever the handling of an incoming event has failed.
        /// </summary>
        event EventHandler<EventHandlingFailedEventArgs> EventHandlingFailedEvent;

        /// <summary>
        /// Event, which is fired whenever there's information about a progress.
        /// </summary>
        event EventHandler<ProgressStepUpdateEventArgs> ProgressStepUpdate;

        /// <summary>
        /// Event, which is fired whenever the current state of the state machine has changed.
        /// </summary>
        event EventHandler<StateChangedEventArgs> StateChangedEvent;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the current state of the finite state machine
        /// </summary>
        IFsmState CurrentState { get; }

        /// <summary>
        /// Gets the type of the current state of the finite state machine
        /// </summary>
        Type CurrentStateType { get; }

        /// <summary>
        /// Gets or sets the thread priority of the event handler thread
        /// </summary>
        /// <value>The event handler thread priority.</value>
        ThreadPriority EventHandlerThreadPriority { get; set; }

        /// <summary>
        /// Gets a value indicating whether the event handler thread is running.
        /// </summary>
        bool IsEventHandlerThreadRunning { get; }

        /// <summary>
        /// Gets the number of states registered.
        /// </summary>
        int NumberOfStates { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this finite state machine should report errors.
        /// </summary>
        /// <value><c>true</c> if [report error enabled]; otherwise, <c>false</c>.</value>
        bool ReportErrorEnabled { get; set; }

        /// <summary>
        /// Gets the timer handler manages timers. It can be used to create, start,
        /// stop and kill different timers.
        /// </summary>
        ITimerHandler TimerHandler { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the actual state to the corresponding state
        /// </summary>
        /// <param name="nextStateType">Type of the state to be used as a new current state of the state machine.</param>
        /// <exception cref="BaseException">
        /// Thrown if type of the state to be set new current state has not been registered and therefore is not a valid state of the state machine.
        /// </exception>
        void ChangeState(Type nextStateType);

        /// <summary>
        /// Call this method after the instantiation of the finite state machine.
        /// This method calls RegisterAllStates() and InitQueue().
        /// </summary>
        void Initialize();

        /// <summary>
        /// Checks whether the corresponding state is the current state or one of its subclasses.
        /// </summary>
        /// <param name="stateToCompare">Type of the state to be checked whether it's the current state or one of its subclasses of the state machine.</param>
        /// <returns>True if stateToCompare is the current state or one of its subclasses. False if it is not.</returns>
        bool IsCurrentState(Type stateToCompare);

        /// <summary>
        /// Receives an FsmTimerEvent and adds it to the incoming event queue to be processed by
        /// the event handler thread of the finite state machine. This method receives the event
        /// with normal priority.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the incoming event queue.</param>
        void ReceiveEvent(IFsmEvent fsmEvent);

        /// <summary>
        /// Receives an FsmTimerEvent and adds it to the incoming event queue to be processed by
        /// the event handler thread of the finite state machine. This method receives the event
        /// with normal or high Priority according the Flag highPriority set to true or false.
        /// FsmEvents of high priority are inserted at the beginning of the event queue.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the incoming event queue.</param>
        /// <param name="highPriority">True if FsmEvent has to be handled with high priority. False if it has to be handled with normal priority.</param>
        void ReceiveEvent(IFsmEvent fsmEvent, bool highPriority);

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        /// <param name="ex">Exception occurred.</param>
        void ReportError(string description, Exception ex);

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        void ReportError(string description);

        /// <summary>
        /// Sends an event to a foreign finite state machine
        /// </summary>
        /// <param name="fsmReceiver">FsmStateMachine to receive the event</param>
        /// <param name="fsmEvent">FsmEvent to be sent</param>
        void SendEvent(IFiniteStateMachine fsmReceiver, IFsmEvent fsmEvent);

        /// <summary>
        /// Shuts the event handler thread down, stopping the processing of events in the
        /// event queue of the finite state machine.
        /// </summary>
        void ShutdownQueueThread();

        #endregion
    }
}
