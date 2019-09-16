// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetCriticalError.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class IGetCriticalError.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    /// Class IGetCriticalError.
    /// </summary>
    public interface IGetCriticalError
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        List<string> Run();
    }
}