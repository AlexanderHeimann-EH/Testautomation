// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The execution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.StatusArea.Statusbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.StatusArea.Statusbar.Validation;

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
                NamespaceForHartComm = Configuration.CommunicationNamespace + ".ChangeDtmAddress.Functions.StatusArea.Statusbar.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the is DTM connected.
        /// </summary>
        /// <value>The is DTM connected.</value>
        public static IIsDtmConnected IsDtmConnected
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".IsDtmConnected") as IIsDtmConnected;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the is DTM disconnected.
        /// </summary>
        /// <value>The is DTM disconnected.</value>
        public static IIsDtmDisconnected IsDtmDisconnected
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".IsDtmDisconnected") as IIsDtmDisconnected;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the wait until DTM is connected.
        /// </summary>
        /// <value>The wait until DTM is connected.</value>
        public static IWaitUntilDtmIsConnected WaitUntilDtmIsConnected
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".WaitUntilDtmIsConnected") as IWaitUntilDtmIsConnected;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the wait until DTM is disconnected.
        /// </summary>
        /// <value>The wait until DTM is disconnected.</value>
        public static IWaitUntilDtmIsDisconnected WaitUntilDtmIsDisconnected
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".WaitUntilDtmIsDisconnected") as IWaitUntilDtmIsDisconnected;
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