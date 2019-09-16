// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceLauncher.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   This class implements start/stop of all activities in the service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation
{
    using System;
    using System.Threading;
    using System.Windows;

    using EH.ImsOpcBridge.Common.Utils;
    using EH.ImsOpcBridge.Service.Implementation.BO;
    using EH.ImsOpcBridge.Service.Implementation.Data;
    using EH.ImsOpcBridge.Service.Implementation.Logging;
    using EH.ImsOpcBridge.Service.Implementation.Wcf;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    /// <summary>
    /// Class ServiceLauncher
    /// </summary>
    public class ServiceLauncher
    {
        #region Constants

        /// <summary>
        /// The service URI
        /// </summary>
        private const string DefaultServiceUri = @"http://localhost:8090/ServiceModel/EH/ImsOpcBridge/Service";

        /// <summary>
        /// The service URI key
        /// </summary>
        private const string ServiceUriKey = @"ServiceUri";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLauncher"/> class.
        /// </summary>
        public ServiceLauncher()
        {
            // Instantiates all activities.
            string serviceUri;
            Utils.ReadAppSettings(ServiceUriKey, DefaultServiceUri, out serviceUri);
            this.ServiceHostContainer = new ServiceHostContainer(new Uri(serviceUri), typeof(ICommServer), typeof(CommServer));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the service host container.
        /// </summary>
        /// <value>The service host container.</value>
        private ServiceHostContainer ServiceHostContainer { get; set; }

        /// <summary>
        /// Gets or sets the thread context.
        /// </summary>
        /// <value>The thread context.</value>
        private ThreadContext ThreadContext { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            try
            {
                // Service host.
                this.ServiceHostContainer.Start();

                // Main thread.
                this.ThreadContext = new ThreadContext(new ManualResetEvent(false), new ManualResetEvent(false));
                ThreadPool.QueueUserWorkItem(ThreadPoolCallback, this.ThreadContext);
            }
            catch (Exception exception)
            {
                Logger.FatalException(this, "Error starting the WCF Service.", exception);
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            try
            {
                // Ask main thread to terminate execution.
                this.ThreadContext.ThreadTerminationRequestEvent.Set();

                // Wait some second...
                if (!this.ThreadContext.ThreadTerminationResponseEvent.WaitOne(TimeSpan.FromSeconds(5)))
                {
                    // The thread hasn't stopped properly, timeout occurred.
                    // Just log it.
                }

                // Service host.
                this.ServiceHostContainer.Stop();
            }
            catch (Exception exception)
            {
                Logger.FatalException(this, "Error stopping the WCF Service.", exception);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Threads the pool callback.
        /// </summary>
        /// <param name="threadContext">The thread context.</param>
        private static void ThreadPoolCallback(object threadContext)
        {
            var taskScheduler = new TaskScheduler();
            taskScheduler.Run((ThreadContext)threadContext);
        }

        #endregion
    }
}