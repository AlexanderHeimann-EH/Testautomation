using System;
using System.Reflection;

using EH.PCPS.TestAutomation.Common;
using EH.PCPS.TestAutomation.Common.Tools;
using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.CommonFlows
{
    /// <summary>
    /// Implementation of ICloseConfiguration for
    /// RSG45 HART Communication
    /// </summary>
    public class CloseConfiguration : ICloseConfiguration
    {
        /// <summary>
        /// Opens the configuration page of a communication DTM
        /// </summary>
        /// <returns>
        /// <br>True: if action was successful</br>
        /// <br>False: if action successful or an error occurred</br>
        /// </returns>
        public bool Run()
        {
            if (CommonHostApplicationLayerLoader.CommonFlows.CloseFunction.Run("Configuration"))
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration is closed");
                return true;
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration could not be closed");
                return false;
            }
        }
    }
}
