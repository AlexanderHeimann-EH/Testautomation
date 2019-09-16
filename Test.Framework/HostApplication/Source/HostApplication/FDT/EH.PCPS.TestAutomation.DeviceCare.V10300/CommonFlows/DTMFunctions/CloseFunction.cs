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

// ReSharper disable CheckNamespace
namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
// ReSharper restore CheckNamespace
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.Functions;

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
            return Functions.CloseModule(functionName);
        }
    }
}          