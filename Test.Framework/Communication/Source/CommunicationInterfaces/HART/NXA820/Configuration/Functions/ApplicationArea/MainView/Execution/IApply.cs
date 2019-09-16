// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApply.cs" company="Process Solutions">
//  Endress+Hauser 
// </copyright>
// <summary>
//   Defines the IApply type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    /// The Apply interface.
    /// </summary>
    public interface IApply
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Run();
    }
}