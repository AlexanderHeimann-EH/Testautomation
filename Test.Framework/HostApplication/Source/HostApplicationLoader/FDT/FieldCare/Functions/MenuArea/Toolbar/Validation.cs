// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation;

    /// <summary>
    ///     Contains interfaces to access frame application area
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
        private static readonly string NamespaceForFrames;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Validation"/> class.
        /// </summary>
        static Validation()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.MenuArea.Toolbar.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the is connected.
        /// </summary>
        public static IIsConnected IsConnected
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsConnected") as IIsConnected;
            }
        }

        /// <summary>
        /// Gets the is disconnected.
        /// </summary>
        public static IIsDisconnected IsDisconnected
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsDisconnected") as IIsDisconnected;
            }
        }

        /// <summary>
        /// Gets the wait until frame connected.
        /// </summary>
        public static IWaitUntilFrameConnected WaitUntilFrameConnected
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".WaitUntilFrameConnected") as IWaitUntilFrameConnected;
            }
        }

        /// <summary>
        /// Gets the wait until frame disconnected.
        /// </summary>
        public static IWaitUntilFrameDisconnected WaitUntilFrameDisconnected
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".WaitUntilFrameDisconnected") as IWaitUntilFrameDisconnected;
            }
        }

        #endregion
    }
}