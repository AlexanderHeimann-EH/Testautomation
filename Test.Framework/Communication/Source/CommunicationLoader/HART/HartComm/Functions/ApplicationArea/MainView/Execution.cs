// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   contains interfaces to access frame Flows
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.HartComm.Functions.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.HartComm.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     contains interfaces to access frame Flows
    /// </summary>
    public class Execution
    {
        #region Static Fields

        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace communication.
        /// </summary>
        private static readonly string NamespaceForHartComm;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Execution"/> class. 
        /// </summary>
        static Execution()
        {
            try
            {
                ExecutionDirectory = Common.Configurator.BO.Configuration.Communication;
                NamespaceForHartComm = Common.Configurator.BO.Configuration.CommunicationNamespace + ".Functions.ApplicationArea.MainView.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public static IConfiguration Configuration
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".Configuration") as IConfiguration;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the confirm address.
        /// </summary>
        /// <value>The confirm address.</value>
        public static IConfirmAddress ConfirmAddress
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".ConfirmAddress") as IConfirmAddress;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open configuration.
        /// </summary>
        /// <value>The open configuration.</value>
        public static IOpenConfiguration OpenConfiguration
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".OpenConfiguration") as IOpenConfiguration;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        #endregion
    }
}