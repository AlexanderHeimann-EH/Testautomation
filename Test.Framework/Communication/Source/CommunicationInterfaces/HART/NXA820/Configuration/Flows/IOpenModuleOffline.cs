//------------------------------------------------------------------------------
// <copyright file="IOpenModuleOffline.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Flows
{
    /// <summary>
    /// The OpenModuleOffline interface.
    /// </summary>
    public interface IOpenModuleOffline
    {
        /// <summary>
        ///  Open module via frame menu within a default time
        /// </summary>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        /// <br>False: if an error occurred</br>
        /// </returns>
        bool Run();
    }
}