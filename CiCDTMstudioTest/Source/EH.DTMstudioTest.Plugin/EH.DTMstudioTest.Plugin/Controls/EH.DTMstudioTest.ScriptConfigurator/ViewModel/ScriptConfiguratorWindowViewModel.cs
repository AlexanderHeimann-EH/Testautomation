// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptConfiguratorWindowViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptConfigurator.ViewModel
{
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    ///     The script configurator window view model.
    /// </summary>
    public class ScriptConfiguratorWindowViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptConfiguratorWindowViewModel"/> class.
        /// </summary>
        public ScriptConfiguratorWindowViewModel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}