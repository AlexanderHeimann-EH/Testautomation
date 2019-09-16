// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetStartVolume.cs" company="Endress+Hauser Process Solutions AG">
//   E+H PCPS AG
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core;

    /// <summary>
    /// Provides functionality for configuring the Start Volume radio button
    /// </summary>
    public class SetStartVolume : ISetStartVolume
    {
        /// <summary>
        /// Configures the Start Volume radio button
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
            Element startVolumeRadioButton = new GUI.ApplicationArea.MainView.TankTabElements().StartVolumeRadioButton;
            if (startVolumeRadioButton == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The radio button [Start Volume]is not accessible");
                result = false;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start Volume will be set to index: " + index + " .");
                startVolumeRadioButton.SetAttributeValue("SelectedIndex", index);
            }

            return result;
        }

        /// <summary>
        /// Configures the Start Volume radio button
        /// </summary>
        /// <param name="startVolume">
        /// The level which will be selected
        /// </param>
        /// <returns>
        /// True: if radio button is configured; False: if otherwise
        /// </returns>
        public bool Run(string startVolume)
        {
            bool result;
            string tmp = startVolume.ToLower();
            if (tmp == "calculated")
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start Volume will be set to " + startVolume + " .");
                result = this.Run(0);
            }
            else
            {
                if (tmp == "zero")
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start Volume will be set to " + startVolume + " .");
                    result = this.Run(1);
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start Volume: " + startVolume + " is unknown");
                    result = false;
                }
            }

            return result;
        }
    }
}
