// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_DisconnectCurrentDeviceViaMenu.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 30.04.2011
 * Time: 10:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.HostApplication.FDT.FieldCare
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar;

    /// <summary>
    /// TM_DisconnectCurrentDevice connects currently selected device.
    /// </summary>
    public class TM_DisconnectCurrentDeviceViaMenu
    {
        /// <summary>
        ///     Execute test module
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Run()
        {
            return Run(DefaultValues.iTimeoutLong);
        }

        /// <summary>
        /// Execute test module
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be done successfully</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Run(int timeOutInMilliseconds)
        {
            bool isPassed = true;
            isPassed &= Execution.RunDisconnect.ViaMenu();
            isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation.WaitUntilFrameDisconnected.Run(timeOutInMilliseconds);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Executed successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Executed with errors.");
            }

            return isPassed;
        }
    }
}