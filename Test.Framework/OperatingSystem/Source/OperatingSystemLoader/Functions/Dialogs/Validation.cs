// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access validations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Validation;

    /// <summary>
    ///     Contains interfaces to access validations
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
        private static readonly string PathToDll;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Validation"/> class. 
        ///     Connect interfaces to dll-version related implementation
        /// </summary>
        static Validation()
        {
            try
            {
                ExecutionDirectory = Configuration.OperatingSystem;
                PathToDll = Configuration.OperatingSystemNamespace + ".Functions.Dialogs.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the is open dialog open.
        /// </summary>
        public static IIsOpenDialogOpen IsOpenDialogOpen
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, PathToDll + ".IsOpenDialogOpen") as IIsOpenDialogOpen;
            }
        }

        /// <summary>
        /// Gets the is save as dialog open.
        /// </summary>
        public static IIsSaveAsDialogOpen IsSaveAsDialogOpen
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, PathToDll + ".IsSaveAsDialogOpen") as IIsSaveAsDialogOpen;
            }
        }

        #endregion
    }
}