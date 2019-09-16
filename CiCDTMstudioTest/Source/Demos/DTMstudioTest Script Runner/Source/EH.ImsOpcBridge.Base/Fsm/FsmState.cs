// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsmState.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Abstract base class of a state of a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Abstract base class of a state of a finite state machine.
    /// </summary>
    public abstract class FsmState : IFsmState
    {
        #region Constants and Fields

        /// <summary>
        /// Reference to finite state machine the state belongs to.
        /// </summary>
        private readonly IFiniteStateMachine finiteStateMachine;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsmState"/> class.
        /// </summary>
        /// <param name="finiteStateMachine">
        /// The finite state machine.
        /// </param>
        protected FsmState(IFiniteStateMachine finiteStateMachine)
        {
            this.finiteStateMachine = finiteStateMachine;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the name of the state. This value equals the full name of the states type.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the reference to finite state machine the state belongs to.
        /// </summary>
        protected IFiniteStateMachine FiniteStateMachine
        {
            get
            {
                return this.finiteStateMachine;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the state of the finite state machine, the state is belonging to.
        /// </summary>
        /// <param name="nextState">
        /// Type of the next state to be set.
        /// </param>
        public void ChangeState(Type nextState)
        {
            this.finiteStateMachine.ChangeState(nextState);
        }

        /// <summary>
        /// Checks whether this state is of the specified .
        /// </summary>
        /// <param name="stateToCompare">
        /// The state to compare.
        /// </param>
        /// <returns>
        /// The is of type.
        /// </returns>
        public virtual bool IsOfType(Type stateToCompare)
        {
            if (stateToCompare == null)
            {
                throw new ArgumentNullException(@"stateToCompare");
            }

            if (stateToCompare.FullName == this.GetType().FullName)
            {
                return true;
            }

            return this.GetType().IsSubclassOf(stateToCompare);
        }

        /// <summary>
        /// Event handler for timer events.
        /// </summary>
        /// <param name="e">
        /// Arguments holding information about the timer event.
        /// </param>
        public abstract void OnTimerEvent(TimerEventArgs e);

        #endregion
    }
}
