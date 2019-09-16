// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetHostApplicationLanguage.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The GetHostApplicationLanguage interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// The GetHostApplicationLanguage interface.
    /// </summary>
    public interface IGetHostApplicationLanguage
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets language from registry
        /// </summary>
        /// <returns>
        /// The language.
        /// </returns>
        string Run();

        #endregion
    }
}