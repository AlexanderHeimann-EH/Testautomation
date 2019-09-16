// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The execution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.NXA820.Configuration.Functions.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// The execution.
    /// </summary>
    public class Validation
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
        /// Initializes static members of the <see cref="Validation"/> class.
        /// </summary>
        static Validation()
        {
            try
            {
                ExecutionDirectory = Configuration.Communication;
                NamespaceForHartComm = Configuration.CommunicationNamespace + ".Configuration.Functions.ApplicationArea.MainView.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the is module ready.
        /// </summary>
        /// <value>The is module ready.</value>
        public static IIsModuleReady IsModuleReady
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".IsModuleReady") as IIsModuleReady;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public static IModuleName ModuleName
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".ModuleName") as IModuleName;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the module opening and closing.
        /// </summary>
        /// <value>The module opening and closing.</value>
        public static IModuleOpeningAndClosing ModuleOpeningAndClosing
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".ModuleOpeningAndClosing") as IModuleOpeningAndClosing;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the wait until module offline is ready.
        /// </summary>
        /// <value>The wait until module offline is ready.</value>
        public static IWaitUntilModuleOfflineIsReady WaitUntilModuleOfflineIsReady
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".WaitUntilModuleOfflineIsReady") as IWaitUntilModuleOfflineIsReady;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the wait until module online is ready.
        /// </summary>
        /// <value>The wait until module online is ready.</value>
        public static IWaitUntilModuleOnlineIsReady WaitUntilModuleOnlineIsReady
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".WaitUntilModuleOnlineIsReady") as IWaitUntilModuleOnlineIsReady;
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