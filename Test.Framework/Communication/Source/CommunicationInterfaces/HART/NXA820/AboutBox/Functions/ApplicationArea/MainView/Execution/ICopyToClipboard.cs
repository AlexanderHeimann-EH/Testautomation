//------------------------------------------------------------------------------
// <copyright file="ICopyToClipboard.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    /// The CopyToClipboard interface.
    /// </summary>
    public interface ICopyToClipboard
    {
        /// <summary>
        /// Starts execution
        /// </summary>
        /// <returns>
        /// true if the button is found and clicked
        /// false if an error occurred
        /// </returns>
        bool Run();
    }
}