// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The message type enumeration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI
{
    /// <summary>
    /// The message type enumeration.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The message exclamation.
        /// </summary>
        MessageExclamation, 

        /// <summary>
        /// The message information.
        /// </summary>
        MessageInformation, 

        /// <summary>
        /// The message question.
        /// </summary>
        MessageQuestion, 

        /// <summary>
        /// The message stop.
        /// </summary>
        MessageStop, 

        /// <summary>
        /// The message asterix.
        /// </summary>
        MessageAsterix, 

        /// <summary>
        /// The message error.
        /// </summary>
        MessageError, 

        /// <summary>
        /// The message hand.
        /// </summary>
        MessageHand, 

        /// <summary>
        /// The message none.
        /// </summary>
        MessageNone, 

        /// <summary>
        /// The message warning.
        /// </summary>
        MessageWarning
    }
}
