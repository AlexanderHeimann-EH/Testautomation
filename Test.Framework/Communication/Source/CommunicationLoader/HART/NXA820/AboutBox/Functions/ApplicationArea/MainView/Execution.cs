// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The execution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationLoader.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// The execution.
    /// </summary>
    public class Execution
    {
        #region Static Fields

        /// <summary>
        /// The execution directory
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace for hart comm
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
                ExecutionDirectory = Configuration.Communication;
                NamespaceForHartComm = Configuration.CommunicationNamespace + ".AboutBox.Functions.ApplicationArea.MainView.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the copy to clipboard.
        /// </summary>
        /// <value>The copy to clipboard.</value>
        public static ICopyToClipboard CopyToClipboard
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForHartComm + ".CopyToClipboard") as ICopyToClipboard;
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