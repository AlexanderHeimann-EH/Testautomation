// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 25.02.2014
 * Time: 14:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    ///     Provides methods for closing device functions
    /// </summary>
    public class CloseFunction : MarshalByRefObject, ICloseFunction
    {
        // /// <summary>
        // ///     Closes a device function
        // /// </summary>
        // /// <param name="deviceFunctionName">Device function which will be closed</param>
        // /// <returns>true: if device function is closed; false: if an error occurred</returns>
        // public bool Run(string deviceFunctionName)
        // {
        //    switch (deviceFunctionName)
        //    {
        //        case "Online Parameterize":
        //            {
        //                return Flows.CloseModuleOnline.Run();
        //            }

        // case "Offline Parameterize":
        //            {
        //                return Flows.CloseModuleOffline.Run();
        //            }

        // default:
        //            {
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing device funtion: " + deviceFunctionName + " is not supported");
        //                return false;
        //            }
        //    }
        // }

        /// <summary>
        ///     Closes a  function
        /// </summary>
        /// <param name="moduleToClose">Function which will be closed</param>
        /// <returns>true: if function is closed; false: if an error occurred</returns>
        public bool Run(string moduleToClose)
        {
            if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.CloseAdditionalModule.ViaWindow(moduleToClose))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Executed with errors.");
            return false;
        }
    }
}
