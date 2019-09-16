//------------------------------------------------------------------------------
// <copyright file="IOpenFunction.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//-------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    /// Opens a device function via menu
    /// </summary>
    public interface IOpenFunction
    {
        /// <summary>
        /// Starts execution
        /// </summary>
        /// <param name="functionToOpen">
        /// Function which will be opened
        /// </param>
        /// <returns>
        /// true if the function is opened
        /// false if an error occurred
        /// </returns>
        bool ViaMenu(string functionToOpen);
    }
}