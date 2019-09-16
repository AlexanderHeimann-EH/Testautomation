// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseFunction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Description of CloseFunction.
    /// </summary>
    public class CloseFunction : ICloseFunction
    {
        /// <summary>
        /// Closes any DTM function by its name and validates if the action was successful
        /// </summary>
        /// <param name="functionName">The name of the DTM function</param>
        /// <returns>True if the action was successful</returns>
        public bool Run(string functionName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            return DtmFunctions.CloseDtmFunction(functionName);
        }
    }
}          