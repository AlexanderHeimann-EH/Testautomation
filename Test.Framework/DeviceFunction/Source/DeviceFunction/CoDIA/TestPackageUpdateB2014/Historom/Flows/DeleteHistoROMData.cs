//------------------------------------------------------------------------------
// <copyright file="DeleteHistoROMData.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.MenuArea.Toolbar.Execution;

    using Ranorex;

    /// <summary>
    ///     Provides methods for deleting HISTOROM data
    /// </summary>
    public class DeleteHistoROMData : IDeleteHistoROMData
    {
        /// <summary>
        ///     Deletes HISTOROM data via new button then opens tab table/statistic and checks if event list/text fields is/are empty
        /// </summary>
        /// <returns>
        ///     true: if all data has been erased
        ///     false: if data has not been erased or an error occurred
        /// </returns>
        public bool Run()
        {
            if (new OpenNew().ViaIcon())
            {
                if (new CheckGUIAfterOpeningOrDeleting().Run() == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not all data has been deleted");
                    return false;
                }
            }
            else
            {
                // failed to click new button				
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to click new button");
                return false;
            }

            // all data has been erased
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HistoROM data has been erased successfully");
            return true;
        }
    }
}