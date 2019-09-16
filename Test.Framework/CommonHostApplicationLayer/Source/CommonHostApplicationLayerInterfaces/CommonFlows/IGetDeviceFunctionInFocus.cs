// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetDeviceFunctionInFocus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// The GetDeviceFunctionInFocus interface.
    /// </summary>
    public interface IGetDeviceFunctionInFocus
    {
        /// <summary>
        /// Deletes a saved project
        ///  </summary> <param name="projectName">Name of the project to delete</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(string projectName);
    }
}
