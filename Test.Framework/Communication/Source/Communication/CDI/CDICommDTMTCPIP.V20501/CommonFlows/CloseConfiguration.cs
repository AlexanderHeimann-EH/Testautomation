// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of ICloseConfiguration for
//   CDI Communication FXA291
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of ICloseConfiguration for
    /// CDI Communication FXA291
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
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration is closed");
                return true;
            }
            
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration could not be closed");
            return false;
        }
    }
}
