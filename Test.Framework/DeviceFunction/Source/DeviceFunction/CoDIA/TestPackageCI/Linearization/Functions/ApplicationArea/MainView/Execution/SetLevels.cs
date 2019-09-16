// -----------------------------------------------------------------------
// <copyright file="SetLevels.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core;

    /// <summary>
    /// Provides functionality for configuring the Levels radio button
    /// </summary>
    public class SetLevels : ISetLevels
    {
        /// <summary>
        /// Configures the Levels radio button
        /// </summary>
        /// <param name="index">
        /// The index which will be selected
        /// </param>
        /// <returns>
        /// True: if radio button is configured; False: if otherwise
        /// </returns>
        public bool Run(int index)
        {
            bool result = true;
            Element levelsRadioButton = new GUI.ApplicationArea.MainView.TankTabElements().LevelsRadioButton;
            if (levelsRadioButton == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The radio button [Levels]is not accessible");
                result = false;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Levels will be set to index: " + index + " .");
                levelsRadioButton.SetAttributeValue("SelectedIndex", index);
            }

            return result;
        }

        /// <summary>
        /// Configures the Levels radio button
        /// </summary>
        /// <param name="level">
        /// The level which will be selected
        /// </param>
        /// <returns>
        /// True: if radio button is configured; False: if otherwise
        /// </returns>
        public bool Run(string level)
        {
            bool result;
            string tmp = level.ToLower();
            if (tmp == "automatic")
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Levels will be set to " + level + " .");
                result = this.Run(0);
            }
            else
            {
                if (tmp == "user defined")
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Levels will be set to " + level + " .");
                    result = this.Run(1);
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The level: " + level + " is unknown");
                    result = false;
                }
            }

            return result;
        }
    }
}
