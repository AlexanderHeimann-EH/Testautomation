// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of ICloseConfiguration for
//   FF H1 Communication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.CommonFlows
{
    using System.Reflection;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Implementation of ICloseConfiguration for
    /// FF H1 Communication
    /// </summary>
    public class CloseConfiguration : CommonCommunicationLayerInterfaces.CommonFlows.ICloseConfiguration
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
            var clickOk = new SpecificFlows.ClickButtonOk();

            if (clickOk.Run())
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration tab was successfully closed");
            }
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not close configuration dialog because the button to close it is not visible");
            return false;
        }
    }
}
