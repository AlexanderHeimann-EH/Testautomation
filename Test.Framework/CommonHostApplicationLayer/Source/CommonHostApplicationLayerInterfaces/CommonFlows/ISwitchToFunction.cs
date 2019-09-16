// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISwitchToFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for adding a device
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// Provides methods for switch between functions
    /// </summary>
    public interface ISwitchToFunction
    {
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="functionToSelect">
        /// The function to select.
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        bool Run(string functionToSelect);

        #endregion
    }
}