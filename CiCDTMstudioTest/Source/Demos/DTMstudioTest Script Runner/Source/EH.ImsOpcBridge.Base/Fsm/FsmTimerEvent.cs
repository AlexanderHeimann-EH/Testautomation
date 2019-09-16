// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsmTimerEvent.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   FsmEvent class, which is sent to finite state machines at the point of timer events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;
    using System.Text;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Properties;

    /// <summary>
    /// FsmEvent class, which is sent to finite state machines at the point of timer events.
    /// </summary>
    public class FsmTimerEvent : FsmEvent
    {
        #region Constants and Fields

        /// <summary>
        /// Arguments of the timer event holding information about the timer.
        /// </summary>
        private readonly TimerEventArgs timerArgs;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsmTimerEvent"/> class.
        /// Constructor
        /// </summary>
        /// <param name="timerArgs">The <see cref="EH.ImsOpcBridge.EventArguments.TimerEventArgs"/> instance containing the event data.</param>
        public FsmTimerEvent(TimerEventArgs timerArgs)
        {
            this.timerArgs = timerArgs;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Human readable message describing the timer event.
        /// </summary>
        public override string Message
        {
            get
            {
                var message = new StringBuilder();

                message.Append(base.Message);
                message.Append(Resources.TimerArguments);
                message.Append(this.timerArgs.Message);

                return message.ToString();
            }
        }

        /// <summary>
        /// Gets the arguments of the timer event holding information about the timer.
        /// </summary>
        public TimerEventArgs TimerArgs
        {
            get
            {
                return this.timerArgs;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the timer event on the corresponding state of the finite state machine.
        /// </summary>
        /// <param name="fsmState">Actual state of the finite state machine, the event should execute on.</param>
        public override void Execute(IFsmState fsmState)
        {
            if (fsmState == null)
            {
                throw new ArgumentNullException(@"fsmState");
            }
            
            fsmState.OnTimerEvent(this.timerArgs);
        }

        #endregion
    }
}
