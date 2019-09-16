﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Flows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame functions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.NXA820.AboutBox
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Flows;

    /// <summary>
    ///     Contains interfaces to access frame functions
    /// </summary>
    public class Flows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace for communication
        /// </summary>
        private static readonly string NamespaceForCommunication;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Flows"/> class. 
        ///     Connect interfaces to DLL version related implementation
        /// </summary>
        static Flows()
        {
            try
            {
                ExecutionDirectory = Configuration.Communication;
                NamespaceForCommunication = Configuration.CommunicationNamespace + ".AboutBox.Flows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

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

        #endregion
    }
}