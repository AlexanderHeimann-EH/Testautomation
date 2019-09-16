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
    public class OpenConfiguration : IOpenConfiguration
    {
        /// <summary>
        /// Closes the configuration page of a communication DTM
        /// </summary>
        /// <returns>
        /// <br>True: if action was successful</br>
        /// <br>False: if action successful or an error occurred</br>
        /// </returns>
        public bool Run()
        {
            if (CommonHostApplicationLayerLoader.CommonFlows.OpenFunction.Run("Configuration"))
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration is open");
                return true;
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration could not be opened");
                return false;
            }
        }
    }
}
