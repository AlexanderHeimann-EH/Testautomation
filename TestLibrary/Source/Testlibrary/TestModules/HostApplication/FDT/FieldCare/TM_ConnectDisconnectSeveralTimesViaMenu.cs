// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_ConnectDisconnectSeveralTimesViaMenu.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///  Connects and disconnects in a row for several times
    /// </summary>
    public class TM_ConnectDisconnectSeveralTimesViaMenu
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
            // Loader.Frame.LoadImplementation();
            bool isPassed = true;

            for (int counter = 0; counter < numberOfLoops; counter++)
            {
                isPassed &= TM_ConnectCurrentDeviceViaMenu.Run();
                isPassed &= TM_DisconnectCurrentDeviceViaMenu.Run();
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