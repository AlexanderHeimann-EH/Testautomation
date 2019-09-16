// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFsmEventQueueNative.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of the event queue of a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Threading;

    /// <summary>
    /// Interface of the event queue of a finite state machine.
    /// </summary>
    public interface IFsmEventQueueNative : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the event queue is empty
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets the number of events in the event queue
        /// </summary>
        int NumberOfEvents { get; }

        /// <summary>
        /// Gets the event which is set whenever there is an event ready to get
        /// </summary>
        AutoResetEvent QueueEvent { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the queue is about to be shut down
        /// </summary>
        /// <value><c>true</c> if shutdown; otherwise, <c>false</c>.</value>
        bool Shutdown { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Empties the event queue
        /// </summary>
        void EmptyQueue();

        /// <summary>
        /// Gets the next event to be handled from the event queue.
        /// </summary>
        /// <returns>Next FsmEvent to be handled</returns>
        IFsmEvent NextEventGet();

        /// <summary>
        /// Adds an FsmEvent to the event queue. This method adds the event
        /// with normal priority.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the event queue.</param>
        void PutEvent(IFsmEvent fsmEvent);

        /// <summary>
        /// Adds an FsmEvent to the event queue. This method adds the event
        /// with normal or high Priority according the Flag highPriority set to true or false.
        /// FsmEvents of high priority are inserted at the beginning of the event queue.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the event queue.</param>
        /// <param name="highPriority">True if FsmEvent has to be added with high priority. False if it has to be added with normal priority.</param>
        void PutEvent(IFsmEvent fsmEvent, bool highPriority);

        #endregion
    }
}
