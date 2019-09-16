// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptExplorerWindowViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptExplorer.ViewModel
{
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    ///     The script configurator window view model.
    /// </summary>
    public class ScriptExplorerWindowViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptExplorerWindowViewModel"/> class.
        /// </summary>
        public ScriptExplorerWindowViewModel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}