// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame Dialogs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Execution;

    /// <summary>
    ///     Contains interfaces to access frame Dialogs
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
        private static readonly string PathToDll;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Execution"/> class. 
        ///     Connect interfaces to DLL version related implementation
        /// </summary>
        static Execution()
        {
            try
            {
                ExecutionDirectory = Configuration.OperatingSystem;
                PathToDll = Configuration.OperatingSystemNamespace + ".Functions.Dialogs.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the open file browser.
        /// </summary>
        /// <value>The open file browser.</value>
        public static IOpenFileBrowser OpenFileBrowser
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, PathToDll + ".OpenFileBrowser") as IOpenFileBrowser;
            }
        }

        /// <summary>
        /// Gets the save as file browser.
        /// </summary>
        /// <value>The save as file browser.</value>
        public static ISaveAsFileBrowser SaveAsFileBrowser
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, PathToDll + ".SaveAsFileBrowser") as ISaveAsFileBrowser;
            }
        }

        #endregion
    }
}