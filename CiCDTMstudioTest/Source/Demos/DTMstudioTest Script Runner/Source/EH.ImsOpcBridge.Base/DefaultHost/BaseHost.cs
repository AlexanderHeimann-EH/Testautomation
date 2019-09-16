// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseHost.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.DefaultHost
{
    using System;
    using EH.ImsOpcBridge.Registry;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    using Microsoft.Win32;

    /// <summary>
    /// The default implementation for callbacks from ImsOpcBridge to the hosting application.
    /// </summary>
    public class BaseHost : IBaseHost
    {
        #region Fields

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The progress handler.
        /// </summary>
        private IProgressHandler progressHandler;

        /// <summary>
        /// The service
        /// </summary>
        private IService service;

        /// <summary>
        /// The task handler.
        /// </summary>
        private ITaskHandler taskHandler;

        /// <summary>
        /// The handler for user interface callbacks to the hosting application.
        /// </summary>
        private IUIHost userInterface;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHost" /> class.
        /// </summary>
        public BaseHost()
        {
            // ReSharper disable LocalizableElement
            this.ApplicationName = @"UnknownApplication";
            this.Manufacturer = @"Endress+Hauser";

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseHost" /> class. Releases unmanaged resources and performs other cleanup operations before the <see cref="BaseHost" /> is reclaimed by garbage collection.
        /// </summary>
        ~BaseHost()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the application, which is hosting the ImsOpcBridge
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the host is a service.
        /// </summary>
        /// <value><c>true</c> if this instance is service; otherwise, <c>false</c>.</value>
        public bool IsService { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer of the application, which is hosting the ImsOpcBridge
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the progress handler.
        /// </summary>
        /// <value>The progress handler.</value>
        public IProgressHandler ProgressHandler
        {
            get
            {
                return this.progressHandler ?? (this.progressHandler = new ProgressHandler());
            }

            set
            {
                this.progressHandler = value;
            }
        }

        /// <summary>
        /// Gets or sets the service reference. Set this reference, when the host is a windows service.
        /// </summary>
        /// <value>The service reference.</value>
        public IService Service
        {
            get
            {
                return this.service;
            }

            set
            {
                this.IsService = true;
                this.service = value;
            }
        }

        /// <summary>
        /// Gets or sets the task handler.
        /// </summary>
        /// <value>The task handler.</value>
        public ITaskHandler TaskHandler
        {
            get
            {
                return this.taskHandler ?? (this.taskHandler = new TaskHandler(this.ProgressHandler));
            }

            set
            {
                this.taskHandler = value;
            }
        }

        /// <summary>
        /// Gets or sets the handler for user interface callbacks to the hosting application.
        /// </summary>
        /// <value>The handler for user interface callbacks to the hosting application.</value>
        public IUIHost UserInterface
        {
            get
            {
                return this.userInterface ?? (this.userInterface = new UIHost(this));
            }

            set
            {
                this.userInterface = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a registry monitor.
        /// </summary>
        /// <param name="registryHive">The registry Hive.</param>
        /// <param name="subkey">The sub Key.</param>
        /// <returns>The registry monitor.</returns>
        public virtual IRegistryMonitor CreateRegistryMonitor(RegistryHive registryHive, string subkey)
        {
            return new RegistryMonitor(registryHive, subkey);
        }

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
        /// Dispose(bool disposing) executes in two distinct scenarios. If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed. If disposing equals false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly by a user's code. If equals to false, method is called by the runtime from inside a finalizer.</param>
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
