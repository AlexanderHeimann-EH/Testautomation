// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

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
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.ApplicationArea.MainView.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the get module area control.
        /// </summary>
        public static IGetModuleAreaControl GetModuleAreaControl
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".GetModuleAreaControl") as IGetModuleAreaControl;
            }
        }

        /// <summary>
        /// Gets the get number of opened modules.
        /// </summary>
        public static IGetNumberOfOpenedModules GetNumberOfOpenedModules
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".GetNumberOfOpenedModules") as IGetNumberOfOpenedModules;
            }
        }

        /// <summary>
        /// Gets the get opened modules.
        /// </summary>
        public static IGetOpenedModules GetOpenedModules
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".GetOpenedModules") as IGetOpenedModules;
            }
        }

        /// <summary>
        /// Gets the is frame available.
        /// </summary>
        public static IIsFrameAvailable IsFrameAvailable
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsFrameAvailable") as IIsFrameAvailable;
            }
        }

        /// <summary>
        /// Gets the is module already opened.
        /// </summary>
        public static IIsModuleAlreadyOpened IsModuleAlreadyOpened
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsModuleAlreadyOpened") as IIsModuleAlreadyOpened;
            }
        }

        /// <summary>
        /// Gets the wait until frame closed.
        /// </summary>
        public static IWaitUntilFrameClosed WaitUntilFrameClosed
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".WaitUntilFrameClosed") as IWaitUntilFrameClosed;
            }
        }

        #endregion
    }
}