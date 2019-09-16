//------------------------------------------------------------------------------
// <copyright file="OpenAdditionalFunction.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    ///     Provides methods for opening additional device functions
    /// </summary>
    public class OpenAdditionalFunction : MarshalByRefObject, IOpenAdditionalFunction
    {
        /// <summary>
        ///      Opens specified additional device function
        /// </summary>
        /// <param name="deviceFunctionName">Additional device function to open</param>
        /// <returns>true: if module opened; false: if an error occurred</returns>
        public bool Run(string deviceFunctionName)
        {
            bool result = false;            
            
            // Try to open module
            if (
                HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenAdditionalModule.ViaMenu(
                    deviceFunctionName))
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module opening started");
                result = true;
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not opened.");
            }

            return result;
        }
    }
}
