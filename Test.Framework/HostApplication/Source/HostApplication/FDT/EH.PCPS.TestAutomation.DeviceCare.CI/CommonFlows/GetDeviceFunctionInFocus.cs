// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDeviceFunctionInFocus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution;

    /// <summary>
    /// The get device function in focus.
    /// </summary>
    public class GetDeviceFunctionInFocus : IGetDeviceFunctionInFocus
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
            DtmFunctions.SelectDtmFunctions(functionName);
            return false;
        }
    }
}
