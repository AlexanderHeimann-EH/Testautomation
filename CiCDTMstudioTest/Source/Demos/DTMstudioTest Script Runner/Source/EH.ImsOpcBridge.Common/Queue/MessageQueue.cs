// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageQueue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements a message queue. This is the only class that support synchronization because of multithreaded access.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Queue
{
    using System.Collections.Generic;

    /// <summary>
    /// Class MessageQueue
    /// </summary>
    public sealed class MessageQueue
    {
        #region Static Fields

        /// <summary>
        /// The singleton sync root
        /// </summary>        
        private static readonly object SingletonSyncRoot = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile MessageQueue instance;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Prevents a default instance of the <see cref="MessageQueue"/> class from being created.
        /// </summary>
        private MessageQueue()
        {
            this.SyncRoot = new object();
            this.InternalQueue = new Queue<Message>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static MessageQueue Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SingletonSyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MessageQueue();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the internal queue.
        /// </summary>
        /// <value>The internal queue.</value>
        private Queue<Message> InternalQueue { get; set; }

        /// <summary>
        /// Gets or sets the sync root.
        /// </summary>
        /// <value>The sync root.</value>
        private object SyncRoot { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Enqueues the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Enqueue(Message message)
        {
            lock (this.SyncRoot)
            {
                this.InternalQueue.Enqueue(message);
            }
        }

        /// <summary>
        /// Tries to dequeue a message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>True if at least a message has been found.</returns>
        public bool TryDequeue(out Message message)
        {
            lock (this.SyncRoot)
            {
                if (this.InternalQueue.Count > 0)
                {
                    message = this.InternalQueue.Dequeue();
                    return true;
                }

                message = null;
                return false;
            }
        }

        /// <summary>
        /// Tries to dequeue all message.
        /// </summary>
        /// <param name="messages">The collection of messages.</param>
        /// <returns>True if at least a message has been found.</returns>
        public bool TryDequeueAll(out Message[] messages)
        {
            lock (this.SyncRoot)
            {
                if (this.InternalQueue.Count > 0)
                {
                    messages = new Message[this.InternalQueue.Count];
                    this.InternalQueue.CopyTo(messages, 0);
                    this.InternalQueue.Clear();
                    return true;
                }

                messages = null;
                return false;
            }
        }

        #endregion
    }
}