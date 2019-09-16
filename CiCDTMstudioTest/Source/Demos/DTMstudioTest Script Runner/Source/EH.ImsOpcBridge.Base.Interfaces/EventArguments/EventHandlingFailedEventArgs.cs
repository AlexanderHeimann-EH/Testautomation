// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventHandlingFailedEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Argument class for EventHandlingFailed event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// Argument class for EventHandlingFailed event.
    /// </summary>
    public class EventHandlingFailedEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Current state of the state machine
        /// </summary>
        private readonly IFsmState currentState;

        /// <summary>
        /// Handled event, which lead to an exception
        /// </summary>
        private readonly IFsmEvent fsmEvent;

        /// <summary>
        /// Occurred exception
        /// </summary>
        private readonly Exception occurredException;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlingFailedEventArgs"/> class.
        /// </summary>
        /// <param name="currentState">State of the current.</param>
        /// <param name="fsmEvent">The FSM event.</param>
        /// <param name="occurredException">The occurred exception.</param>
        public EventHandlingFailedEventArgs(IFsmState currentState, IFsmEvent fsmEvent, Exception occurredException)
        {
            this.currentState = currentState;
            this.fsmEvent = fsmEvent;
            this.occurredException = occurredException;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the current state of the state machine
        /// </summary>
        public IFsmState CurrentState
        {
            get
            {
                return this.currentState;
            }
        }

        /// <summary>
        /// Gets the handled event, which lead to an exception
        /// </summary>
        public IFsmEvent FsmEvent
        {
            get
            {
                return this.fsmEvent;
            }
        }

        /// <summary>
        /// Gets the occurred exception
        /// </summary>
        public Exception OccurredException
        {
            get
            {
                return this.occurredException;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks whether the corresponding state is the current state or one of its subclasses.
        /// </summary>
        /// <param name="stateToCompare">Type of the state to be checked whether it's the current state or one of its subclasses of the state machine.</param>
        /// <returns>True if stateToCompare is the current state or one of its subclasses. False if it is not.</returns>
        public bool IsCurrentState(Type stateToCompare)
        {
            if (this.currentState == null)
            {
                return stateToCompare == null;
            }

            return this.currentState.IsOfType(stateToCompare);
        }

        #endregion
    }
}
