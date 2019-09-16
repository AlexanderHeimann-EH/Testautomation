// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_ConnectDisconnectSeveralTimesViaIcon.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 13.10.2011
 * Time: 9:55 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.HostApplication.FDT.FieldCare
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.StatusArea.Statusbar;

    using Ranorex;

    /// <summary>
    /// Connects and disconnects in a row for several times
    /// </summary>
    public class TM_ConnectDisconnectSeveralTimesViaIcon
    {
        /// <summary>
        /// Execute test module
        /// </summary>
        /// <param name="numberOfLoops">Number of loops to connect AND disconnect</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Run(int numberOfLoops)
        {
            bool isPassed = true;

            isPassed &= TM_ConnectCurrentDeviceViaIcon.Run();
            for (int counter = 0; counter < numberOfLoops; counter++)
            {
                Mouse.Click();
                Thread.Sleep(500);
                Debug.Print("Click " + counter);
            }

            if (Validation.IsDtmConnected.Run())
            {
                isPassed &= TM_ConnectCurrentDeviceViaIcon.Run();
            }

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