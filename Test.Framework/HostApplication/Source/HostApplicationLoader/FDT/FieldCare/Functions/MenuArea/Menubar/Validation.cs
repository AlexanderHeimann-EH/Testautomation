// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Validation;

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
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.MenuArea.Menubar.Validation";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the get additional function modules.
        /// </summary>
        public static IGetAdditionalFunctionModules GetAdditionalFunctionModules
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".GetAdditionalFunctionModules") as IGetAdditionalFunctionModules;
            }
        }

        /// <summary>
        /// Gets the is module available at menu.
        /// </summary>
        public static IIsModuleAvailableAtMenu IsModuleAvailableAtMenu
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsModuleAvailableAtMenu") as IIsModuleAvailableAtMenu;
            }
        }

        /// <summary>
        /// Gets the is module enabled at menu.
        /// </summary>
        public static IIsModuleEnabledAtMenu IsModuleEnabledAtMenu
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".IsModuleEnabledAtMenu") as IIsModuleEnabledAtMenu;
            }
        }

        #endregion
    }
}