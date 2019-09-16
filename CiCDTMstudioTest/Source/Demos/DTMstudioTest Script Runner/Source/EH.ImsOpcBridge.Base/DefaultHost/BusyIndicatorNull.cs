// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusyIndicatorNull.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Busy indicator, which can be used to show, that the application is busy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.DefaultHost
{
    using System;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI;

    /// <summary>
    /// Busy indicator, which can be used to show, that the application is busy.
    /// </summary>
    public class BusyIndicatorNull : IBusyIndicator
    {
        #region Constants and Fields

        /// <summary>
        /// The UI host.
        /// </summary>
        private readonly IUIHost host;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The progress item.
        /// </summary>
        private IProgressItem progressItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusyIndicatorNull"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        public BusyIndicatorNull(IUIHost host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(@"host");
            }
            
            this.host = host;
            this.host.DoEvents();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BusyIndicatorNull"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="BusyIndicatorNull"/> is reclaimed by garbage collection.
        /// </summary>
        ~BusyIndicatorNull()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the progress item.
        /// </summary>
        /// <value>The progress item.</value>
        public IProgressItem ProgressItem
        {
            get
            {
                return this.progressItem;
            }

            set
            {
                if (this.progressItem != null)
                {
                    this.progressItem.Changed -= this.ProgressItemChanged;
                    this.progressItem.Dispose();
                }

                this.progressItem = value;

                if (value != null)
                {
                    value.Changed += this.ProgressItemChanged;
                }
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
                }

                this.ProgressItem = null;
                this.host.DoEvents();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Handles the changes of the progress item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.ProgressEventArgs"/> instance containing the event data.</param>
        private void ProgressItemChanged(object sender, ProgressEventArgs e)
        {
            this.host.DoEvents();
        }

        #endregion
    }
}
