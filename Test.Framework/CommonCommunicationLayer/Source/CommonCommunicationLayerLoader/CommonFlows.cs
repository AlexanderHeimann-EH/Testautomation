// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:
 * Last: Effner, Christian
 * Reason: Optimierung des Loaders
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonCommunicationLayerLoader
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// The common flows.
    /// </summary>
    public class CommonFlows
    {
        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace communication.
        /// </summary>
        private static readonly string NamespaceCommunication;

        /// <summary>
        /// Initializes static members of the <see cref="CommonFlows"/> class. 
        /// Connect interfaces to assembly version related implementation
        /// </summary>
        static CommonFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.Communication;
                NamespaceCommunication = Configuration.CommunicationNamespace + ".CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Gets the close configuration.
        /// </summary>
        public static ICloseConfiguration CloseConfiguration
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCommunication + ".CloseConfiguration") as ICloseConfiguration;
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
        public static IOpenConfiguration OpenConfiguration
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCommunication + ".OpenConfiguration") as IOpenConfiguration;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                
            }
        }

        /// <summary>
        /// Gets the configure communication.
        /// </summary>
        public static IConfigureCommunication ConfigureCommunication
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCommunication + ".ConfigureCommunication") as IConfigureCommunication;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        // Add here more interfaces
    }
}