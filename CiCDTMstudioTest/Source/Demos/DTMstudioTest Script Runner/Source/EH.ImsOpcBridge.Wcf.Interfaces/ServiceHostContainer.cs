// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceHostContainer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ServiceHostContainer
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Wcf.Interfaces
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    /// <summary>
    /// Class ServiceHostContainer
    /// </summary>
    public class ServiceHostContainer
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostContainer"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <param name="classType">Type of the class.</param>
        public ServiceHostContainer(Uri baseAddress, Type interfaceType, Type classType)
        {
            // Do some initialization.
            this.ServiceHost = null;

            this.BaseAddress = baseAddress;
            this.InterfaceType = interfaceType;
            this.ClassType = classType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the base address.
        /// </summary>
        /// <value>The base address.</value>
        private Uri BaseAddress { get; set; }

        /// <summary>
        /// Gets or sets the type of the class.
        /// </summary>
        /// <value>The type of the class.</value>
        private Type ClassType { get; set; }

        /// <summary>
        /// Gets or sets the type of the interface.
        /// </summary>
        /// <value>The type of the interface.</value>
        private Type InterfaceType { get; set; }

        /// <summary>
        /// Gets or sets the service host.
        /// </summary>
        /// <value>The service host.</value>
        private ServiceHost ServiceHost { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            try
            {
                // Starts only once.
                if (this.ServiceHost != null)
                {
                    return;
                }

                // Create a WSHttpBinding and set its property values. 
                WSHttpBinding binding = new WSHttpBinding();
                binding.Name = "EhImsOpcBridgeBinding";
                binding.MaxReceivedMessageSize = 2147483647;

                // binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                binding.Security.Mode = SecurityMode.Message;
                binding.ReliableSession.Enabled = false;
                binding.TransactionFlow = false;

                // Create a ServiceHost for the requested type 
                // and provide it with a base address. 
                this.ServiceHost = new ServiceHost(this.ClassType, this.BaseAddress);
                this.ServiceHost.AddServiceEndpoint(this.InterfaceType, binding, this.BaseAddress);

                var sb = this.ServiceHost.Description.Behaviors[0] as ServiceBehaviorAttribute;
                if (sb != null)
                {
                    sb.MaxItemsInObjectGraph = 2147483647;
                }

                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = this.ServiceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

                // If not, add one
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                }

                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                this.ServiceHost.Description.Behaviors.Add(smb);

                // Add MEX endpoint
                this.ServiceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                // Open the ServiceHostBase to create listeners 
                // and start listening for messages. 
                this.ServiceHost.Open();
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                this.ServiceHost = null;
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            try
            {
                // Stops only once.
                if (this.ServiceHost == null)
                {
                    return;
                }

                // Close the ServiceHost to shutdown the service. 
                this.ServiceHost.Close();
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                this.ServiceHost = null;
            }
        }

        #endregion
    }
}