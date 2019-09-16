// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsmEvent.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System.Globalization;

    /// <summary>
    /// Abstract base class for an finite state machine event.
    /// </summary>
    public abstract class FsmEvent : IFsmEvent
    {
        #region Public Properties

        /// <summary>
        /// Gets the human readable message describing the event
        /// </summary>
        public virtual string Message
        {
            get
            {
                // ReSharper disable LocalizableElement
                return string.Format(CultureInfo.InvariantCulture, @"== {0} ==", this.GetType().Name);
                // ReSharper restore LocalizableElement
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Abstract method containing the code to be executed when the event is handled
        /// by the finite state machine. This method has to be implemented by all concrete events.
        /// </summary>
        /// <param name="fsmState">
        /// Actual state of the finite state machine at the point of the execution.
        /// </param>
        public abstract void Execute(IFsmState fsmState);

        #endregion
    }
}
