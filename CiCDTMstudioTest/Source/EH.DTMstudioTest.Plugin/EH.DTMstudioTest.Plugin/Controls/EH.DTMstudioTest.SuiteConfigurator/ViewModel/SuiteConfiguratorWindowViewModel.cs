// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuiteConfiguratorWindowViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.SuiteConfigurator.ViewModel
{
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    ///     The script configurator window view model.
    /// </summary>
    public class SuiteConfiguratorWindowViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuiteConfiguratorWindowViewModel"/> class.
        /// </summary>
        public SuiteConfiguratorWindowViewModel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}