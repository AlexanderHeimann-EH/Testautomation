// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCriticalError.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// The get critical error.
    /// </summary>
    public class GetCriticalError : IGetCriticalError
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public List<string> Run()
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");
            List<string> listOfCriticalError = new List<string>();
            listOfCriticalError.Add(string.Empty);
            return listOfCriticalError;
        }
    }
}
