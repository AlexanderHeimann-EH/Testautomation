// -----------------------------------------------------------------------
// <copyright file="CheckDeviceTypeName.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.AboutBox.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Flows;

    /// <summary>
    /// Checks the device type shown in the AboutBox
    /// </summary>
    public class CheckDeviceTypeName : ICheckDeviceTypeName
    {
        /// <summary>
        /// Gets the device type name from the device type information box and checks if it is valid.
        /// </summary>
        /// <returns>
        /// True: if the device type name is valid; False: if otherwise
        /// </returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking device type name...");

            bool result;

            string deviceTypeName = DeviceFunctionLoader.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Execution.GetDeviceTypeInformation.Name();
            if (deviceTypeName == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device type name is empty, please check the preconditions.");
                result = false;
            }
            else
            {
                result = DeviceFunctionLoader.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Validation.IsDeviceTypeNameCorrect.Run(deviceTypeName);
                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked device type name. It matches the pattern");
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked device type name. It does not match the pattern");
                }
            }

            return result;
        }
    }
}
