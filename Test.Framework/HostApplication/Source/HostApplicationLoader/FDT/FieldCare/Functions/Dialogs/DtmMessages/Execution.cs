// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.DtmMessages
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.DtmMessages.Execution;

    /// <summary>
    ///     Contains interfaces to access frame application area
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
        private static readonly string NamespaceForFrames;

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
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.Dialogs.DtmMessages.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the DTM messages.
        /// </summary>
        public static IDtmMessages DtmMessages
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".DtmMessages") as IDtmMessages;
            }
        }

        #endregion
    }
}