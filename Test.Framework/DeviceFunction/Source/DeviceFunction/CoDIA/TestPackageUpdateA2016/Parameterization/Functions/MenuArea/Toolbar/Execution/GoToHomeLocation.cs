// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoToHomeLocation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GoToHomeLocation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.MenuArea.Toolbar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    /// Class GoToHomeLocation.
    /// </summary>
    public class GoToHomeLocation : IGoToHomeLocation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clicks the go to home location button.
        /// </summary>
        /// <returns><c>true</c> if button clicked, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = true;

            Button homeLocation = new ToolbarElements().HomeButton;
            if (homeLocation == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Go to home location button is null.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking go to home location button.");
                homeLocation.Click();
            }

            return result;
        }

        #endregion
    }
}