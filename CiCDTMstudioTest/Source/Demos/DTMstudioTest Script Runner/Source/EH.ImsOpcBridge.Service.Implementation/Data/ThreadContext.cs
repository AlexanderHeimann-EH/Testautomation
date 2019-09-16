// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThreadContext.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements a thread context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.Data
{
    using System.Threading;

    /// <summary>
    /// Class ThreadContext
    /// </summary>
    public class ThreadContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadContext"/> class.
        /// </summary>
        /// <param name="threadTerminationRequestEvent">The thread termination request event.</param>
        /// <param name="threadTerminationResponseEvent">The thread termination response event.</param>
        public ThreadContext(ManualResetEvent threadTerminationRequestEvent, ManualResetEvent threadTerminationResponseEvent)
        {
            this.ThreadTerminationRequestEvent = threadTerminationRequestEvent;
            this.ThreadTerminationResponseEvent = threadTerminationResponseEvent;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the thread termination request event.
        /// </summary>
        /// <value>The thread termination request event.</value>
        public ManualResetEvent ThreadTerminationRequestEvent { get; private set; }

        /// <summary>
        /// Gets the thread termination response event.
        /// </summary>
        /// <value>The thread termination response event.</value>
        public ManualResetEvent ThreadTerminationResponseEvent { get; private set; }

        #endregion
    }
}