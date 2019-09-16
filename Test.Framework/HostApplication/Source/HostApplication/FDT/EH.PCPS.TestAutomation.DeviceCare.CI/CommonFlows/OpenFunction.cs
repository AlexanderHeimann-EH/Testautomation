// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="OpenFunction.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of OpenFunction.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The open function.
    /// </summary>
    public class OpenFunction : IOpenFunction
    {
        /// <summary>
        /// Opens a FDT specified DTM function by its name and validates if the action was successful
        /// </summary>
        /// <param name="functionName">The name of the DTM function</param>
        /// <returns>True if the action was successful</returns>
        public bool Run(string functionName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            return DtmFunctions.OpenDtmFunction(functionName);
        }
    }
}
