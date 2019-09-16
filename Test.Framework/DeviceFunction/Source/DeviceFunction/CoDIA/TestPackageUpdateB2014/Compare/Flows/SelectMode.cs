// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectMode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides functionality to select mode before comparison
    /// </summary>
    public class SelectMode : ISelectMode
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects Compare mode with specified index(starting at 0)
        /// </summary>
        /// <param name="index">
        /// Compare mode index from combo box
        /// </param>
        /// <returns>
        /// true if test module passed, false if an error occurred
        /// </returns>
        public bool Run(int index)
        {
            bool isPassed = true;

            isPassed &= (new Selection()).SelectMode(index);

            if (isPassed)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Mode changed successfully");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Changing mode failed");
            return false;
        }

        /// <summary>
        /// Selects Compare mode by specified string
        /// </summary>
        /// <param name="mode">
        /// Compare mode string from combo box
        /// </param>
        /// <returns>
        /// true if test module passed, false if an error occurred
        /// </returns>
        public bool Run(string mode)
        {
            bool isPassed = true;

            isPassed &= (new Selection()).SelectMode(mode);

            if (isPassed)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Mode changed successfully");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Changing mode failed");
            return false;
        }

        #endregion
    }
}