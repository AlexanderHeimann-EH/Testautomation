// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsmEventQueueNative.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Event queue of a finite state machine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Fsm
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Event queue of a finite state machine.
    /// </summary>
    public class FsmEventQueueNative : IFsmEventQueueNative
    {
        #region Constants and Fields

        /// <summary>
        /// Event queue for events of high priority
        /// </summary>
        private readonly LinkedList<IFsmEvent> eventListHighPriority = new LinkedList<IFsmEvent>();

        /// <summary>
        /// Event queue for events of low priority
        /// </summary>
        private readonly LinkedList<IFsmEvent> eventListLowPriority = new LinkedList<IFsmEvent>();

        /// <summary>
        /// Event which is set whenever there is an event ready to get
        /// </summary>
        private readonly AutoResetEvent queueEvent = new AutoResetEvent(false);

        /// <summary>
        /// Disposed flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Flag signaling whether the queue is about to be shut down
        /// </summary>
        private bool shutdown;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="FsmEventQueueNative"/> class.
        /// </summary>
        ~FsmEventQueueNative()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the event queue is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (this.eventListLowPriority.Count == 0) && (this.eventListHighPriority.Count == 0);
            }
        }

        /// <summary>
        /// Gets the number of events in the event queue
        /// </summary>
        public int NumberOfEvents
        {
            get
            {
                return this.eventListLowPriority.Count + this.eventListHighPriority.Count;
            }
        }

        /// <summary>
        /// Gets the event which is set whenever there is an event ready to get
        /// </summary>
        public AutoResetEvent QueueEvent
        {
            get
            {
                return this.queueEvent;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the queue is about to be shut down
        /// </summary>
        /// <value><c>true</c> if shutdown; otherwise, <c>false</c>.</value>
        public bool Shutdown
        {
            get
            {
                return this.shutdown;
            }

            set
            {
                this.shutdown = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Empties the event queue
        /// </summary>
        public void EmptyQueue()
        {
            lock (this.eventListLowPriority)
            {
                this.shutdown = true;
                this.eventListLowPriority.Clear();
                this.eventListHighPriority.Clear();
            }
        }

        /// <summary>
        /// Gets the next event to be handled from the event queue.
        /// </summary>
        /// <returns>Next FsmEvent to be handled</returns>
        public IFsmEvent NextEventGet()
        {
            lock (this.eventListLowPriority)
            {
                if ((!this.shutdown) && (!this.IsEmpty))
                {
                    var fsmEventNode = this.eventListHighPriority.First;

                    if (fsmEventNode == null)
                    {
                        fsmEventNode = this.eventListLowPriority.First;

                        if (fsmEventNode == null)
                        {
                            return null;
                        }

                        this.eventListLowPriority.Remove(fsmEventNode);
                    }
                    else
                    {
                        this.eventListHighPriority.Remove(fsmEventNode);
                    }

                    if (!this.IsEmpty)
                    {
                        this.queueEvent.Set();
                    }

                    return fsmEventNode.Value;
                }

                if (!this.IsEmpty)
                {
                    this.queueEvent.Set();
                }

                return null;
            }
        }

        /// <summary>
        /// Adds an FsmEvent to the event queue. This method adds the event
        /// with normal priority.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the event queue.</param>
        public void PutEvent(IFsmEvent fsmEvent)
        {
            this.PutEvent(fsmEvent, false);
        }

        /// <summary>
        /// Adds an FsmEvent to the event queue. This method adds the event
        /// with normal or high Priority according the Flag highPriority set to true or false.
        /// FsmEvents of high priority are inserted at the beginning of the event queue.
        /// </summary>
        /// <param name="fsmEvent">FsmTimer event to be added to the event queue.</param>
        /// <param name="highPriority">True if FsmEvent has to be added with high priority. False if it has to be added with normal priority.</param>
        public void PutEvent(IFsmEvent fsmEvent, bool highPriority)
        {
            lock (this.eventListLowPriority)
            {
                if (!this.shutdown)
                {
                    if (highPriority)
                    {
                        this.eventListHighPriority.AddLast(fsmEvent);
                    }
                    else
                    {
                        this.eventListLowPriority.AddLast(fsmEvent);
                    }

                    this.queueEvent.Set(); // a new event is in the queue
                }
                else
                {
                    this.queueEvent.Set(); // let the other waiting threads run ...
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    this.queueEvent.Dispose();
                }

                this.EmptyQueue();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        #endregion
    }
}
