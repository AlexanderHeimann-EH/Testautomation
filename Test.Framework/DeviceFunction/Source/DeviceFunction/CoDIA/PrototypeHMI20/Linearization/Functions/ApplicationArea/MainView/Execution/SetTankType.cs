// -----------------------------------------------------------------------
// <copyright file="SetTankType.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core;

    /// <summary>
    /// Provides functionality to set the tank type
    /// </summary>
    public class SetTankType : ISetTankType
    {
        /// <summary>
        /// Sets the tank type 
        /// </summary>
        /// <param name="type">Tank type which will be set</param>
        /// <returns>True: if the tank type was set; False: if otherwise</returns>
        public bool Run(string type)
        {
            bool result;
            Element tankType = new GUI.ApplicationArea.MainView.TankTabElements().TankFormSelectionCombobox;
            if (tankType == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The combobox [Type] is not accessible");
                result = false;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The tank type will be set to: " + type + ".");
                result = new EditParameter().SetParameterValue(tankType, type);
            }

            return result;
        }
    }
}
