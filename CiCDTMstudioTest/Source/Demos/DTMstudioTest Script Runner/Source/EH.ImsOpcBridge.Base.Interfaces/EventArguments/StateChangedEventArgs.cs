// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateChangedEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Argument class for StateChanged event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// Argument class for StateChanged event.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// The new State
        /// </summary>
        private readonly IFsmState newState;

        /// <summary>
        /// The old State
        /// </summary>
        private readonly IFsmState oldState;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="oldState">The old state.</param>
        /// <param name="newState">The new state.</param>
        public StateChangedEventArgs(IFsmState oldState, IFsmState newState)
        {
            this.oldState = oldState;
            this.newState = newState;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the new State
        /// </summary>
        public IFsmState NewState
        {
            get
            {
                return this.newState;
            }
        }

        /// <summary>
        /// Gets the old State
        /// </summary>
        public IFsmState OldState
        {
            get
            {
                return this.oldState;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks whether the corresponding state is the new state or one of its subclasses.
        /// </summary>
        /// <param name="stateToCompare">Type of the state to be checked whether it's the new state or one of its subclasses of the state machine.</param>
        /// <returns>True if stateToCompare is the new state or one of its subclasses. False if it is not.</returns>
        public bool IsNewState(Type stateToCompare)
        {
            if (this.newState == null)
            {
                return stateToCompare == null;
            }

            return this.newState.IsOfType(stateToCompare);
        }

        /// <summary>
        /// Checks whether the corresponding state is the old state or one of its subclasses.
        /// </summary>
        /// <param name="stateToCompare">Type of the state to be checked whether it's the old state or one of its subclasses of the state machine.</param>
        /// <returns>True if stateToCompare is the old state or one of its subclasses. False if it is not.</returns>
        public bool IsOldState(Type stateToCompare)
        {
            if (this.oldState == null)
            {
                return stateToCompare == null;
            }

            return this.oldState.IsOfType(stateToCompare);
        }

        #endregion
    }
}
