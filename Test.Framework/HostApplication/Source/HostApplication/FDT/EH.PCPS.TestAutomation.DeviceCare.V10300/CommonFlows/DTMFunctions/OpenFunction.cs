// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="OpenFunction.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of OpenFunction.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
// ReSharper restore CheckNamespace
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.Functions;

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
            return Functions.OpenFdtDefinedFunction(functionName);
        }
    }
}
