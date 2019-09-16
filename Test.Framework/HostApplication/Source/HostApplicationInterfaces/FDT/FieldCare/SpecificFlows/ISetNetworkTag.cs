// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISetNetworkTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The SetNetworkTag interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    /// The SetNetworkTag interface.
    /// </summary>
    public interface ISetNetworkTag
    {
        #region Public Methods and Operators

        /// <summary>
        /// Sets the network tag. This works only after a scan.
        /// </summary>
        /// <param name="networkTag">
        /// The network tag.
        /// </param>
        /// <returns>
        /// True if tag has been set, false otherwise.
        /// </returns>
        bool Run(string networkTag);

        #endregion
    }
}