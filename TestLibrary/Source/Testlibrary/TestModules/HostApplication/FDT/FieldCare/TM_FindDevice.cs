// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_FindDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 10.11.2010
 * Time: 2:08 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.HostApplication.FDT.FieldCare
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of Find Device.
    /// </summary>
    public class TM_FindDevice
    {
        /// <summary>
        /// Runs the specified device name.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        public static bool Run(string deviceName)
        {
            bool isPassed = true;

            isPassed &= HostApplicationLoader.FDT.FieldCare.SpecificFlows.FocusNetworkView.Run();
            isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenFindDevice.ViaMenu();
            isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.FindDevice.Execution.FindDevice.Find(deviceName);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device [" + deviceName + "] is found");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device [" + deviceName + "] is not found.");
            }

            return isPassed;
        }
    }
}