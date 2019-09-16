// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFsmState.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of a state of a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of a state of a finite state machine.
    /// </summary>
    public interface IFsmState
    {
        #region Public Properties

        /// <summary>
        /// Gets the name of the state. This value equals the full name of the states type.
        /// </summary>
        string Name { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the state of the finite state machine, the state is belonging to.
        /// </summary>
        /// <param name="nextState">Type of the next state to be set.</param>
        void ChangeState(Type nextState);

        /// <summary>
        /// Checks whether this state is of the specified .
        /// </summary>
        /// <param name="stateToCompare">The state to compare.</param>
        /// <returns>The is of type.</returns>
        bool IsOfType(Type stateToCompare);

        /// <summary>
        /// Event handler for timer events.
        /// </summary>
        /// <param name="e">Arguments holding information about the timer event.</param>
        void OnTimerEvent(TimerEventArgs e);

        #endregion
    }
}
