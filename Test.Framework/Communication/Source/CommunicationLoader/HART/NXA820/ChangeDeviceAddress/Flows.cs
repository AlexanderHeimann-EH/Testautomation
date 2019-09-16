// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Flows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame functions
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.NXA820.ChangeDeviceAddress
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Flows;

    /// <summary>
    ///     Contains interfaces to access frame functions
    /// </summary>
    public class Flows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace for communication.
        /// </summary>
        private static readonly string NamespaceForCommunication;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Flows"/> class.
        /// </summary>
        static Flows()
        {
            try
            {
                ExecutionDirectory = Configuration.Communication;
                NamespaceForCommunication = Configuration.CommunicationNamespace + ".ChangeDeviceAddress.Flows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the change device address.
        /// </summary>
        /// <value>The change device address.</value>
        public static IChangeDeviceAddress ChangeDeviceAddress
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForCommunication + ".ChangeDeviceAddress") as IChangeDeviceAddress;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the close module.
        /// </summary>
        /// <value>The close module.</value>
        public static ICloseModule CloseModule
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForCommunication + ".CloseModule") as ICloseModule;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open module offline.
        /// </summary>
        /// <value>The open module offline.</value>
        public static IOpenModuleOffline OpenModuleOffline
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForCommunication + ".OpenModuleOffline") as IOpenModuleOffline;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open module online.
        /// </summary>
        /// <value>The open module online.</value>
        public static IOpenModuleOnline OpenModuleOnline
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForCommunication + ".OpenModuleOnline") as IOpenModuleOnline;
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