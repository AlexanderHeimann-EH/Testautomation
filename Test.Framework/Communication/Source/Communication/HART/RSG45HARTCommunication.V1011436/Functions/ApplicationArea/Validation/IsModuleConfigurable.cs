using System;
using System.Collections.Generic;
using System.Reflection;

using Ranorex;
using Ranorex.Core;

using EH.PCPS.TestAutomation.Common.Tools;
using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.Functions.ApplicationArea.Validation
{
    /// <summary>
    /// Checks if the module is offline
    /// </summary>
    public class IsModuleConfigurable
    {
        /// <summary>
        /// Checks if the module configurable (offline)
        /// by determining if the IP address text is enabled
        /// </summary>
        /// <returns>
        ///     <br>True: if module is configurable (offline)</br>
        ///     <br>False: if module is not configurable (online) or an error occurred</br>
        /// </returns>
        public bool Run(bool suppressLogging)
        {
            Text cb = new RSG45HARTCommunication.V1011436.GUI.RSG45HARTCommRepoElements().IPAddress;

            if (!cb.Enabled)
            {
                return false;
            }
            else
            {
                if (!suppressLogging)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is configurable");
                }
                return true;
            }
        }
    }
}
