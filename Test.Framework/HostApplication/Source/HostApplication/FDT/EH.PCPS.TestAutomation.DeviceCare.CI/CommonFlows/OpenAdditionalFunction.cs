// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="OpenAdditionalFunction.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of OpenAdditionalFunction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
// ReSharper restore CheckNamespace
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;

    /// <summary>
    /// Description of OpenAdditionalFunction.
    /// </summary>
    public class OpenAdditionalFunction : CommonHostApplicationLayerInterfaces.CommonFlows.IOpenAdditionalFunction
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string functionName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            return AdditionalFunctions.OpenAdditionalFunction(functionName);
        }
    }
}
