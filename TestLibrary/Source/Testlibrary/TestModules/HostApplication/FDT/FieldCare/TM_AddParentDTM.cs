// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_AddParentDtm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.11.2010
 * Time: 2:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.HostApplication.FDT.FieldCare
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar;

    /// <summary>
    /// Adds a Communication DTM to project (Host)
    /// </summary>
    public class TM_AddParentDtm
    {
        /// <summary>
        /// Execute test module
        /// </summary>
        /// <param name="communicationDtm">Name of Communication DTM</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Run(string communicationDtm)
        {
            // Frame.LoadImplementation();
            bool isPassed = true;

            isPassed &= HostApplicationLoader.FDT.FieldCare.SpecificFlows.FocusNetworkView.Run();
            isPassed &= Execution.OpenAddDevice.ViaMenu();
            isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.AddDevice.Execution.AddDevice.SelectDevice(communicationDtm);
            isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.AddDevice.Execution.AddDevice.Confirm();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CommDTM [" + communicationDtm + "] is added successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CommDTM [" + communicationDtm + "] is not added to project.");
            }

            return isPassed;
        }
    }
}