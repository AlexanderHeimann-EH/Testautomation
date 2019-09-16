﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of ICloseConfiguration for
//   PROFIdtm DPV1 Communication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of ICloseConfiguration for PROFIdtm DPV1 Communication
    /// </summary>
    public class OpenConfiguration : IOpenConfiguration
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
            if (CommonHostApplicationLayerLoader.CommonFlows.OpenFunction.Run("Configuration"))
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration is open");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration could not be opened");
            return false;
        }
    }
}
