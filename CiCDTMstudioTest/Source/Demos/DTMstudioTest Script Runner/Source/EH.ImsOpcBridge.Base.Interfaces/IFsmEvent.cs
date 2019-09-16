// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFsmEvent.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of an finite state machine event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    /// <summary>
    /// Interface of an finite state machine event.
    /// </summary>
    public interface IFsmEvent
    {
        #region Public Properties

        /// <summary>
        /// Gets the human readable message describing the event
        /// </summary>
        string Message { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Abstract method containing the code to be executed when the event is handled
        /// by the finite state machine. This method has to be implemented by all concrete events.
        /// </summary>
        /// <param name="fsmState">Actual state of the finite state machine at the point of the execution.</param>
        void Execute(IFsmState fsmState);

        #endregion
    }
}
