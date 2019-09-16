// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsDtmDisconnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.StatusArea.Statusbar.Validation

{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDtmDisconnected.
    /// </summary>
    public class IsDTMDisconnected : IIsDTMDisconnected
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determines whether DTM is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        public bool Run()
        {
            bool result = true;
            string state = new StatusbarElements().ConnectionState;
            if (state == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                result = false;
            }
            else if (state.Equals("Going Online") == false)
            {
               result = false;               
            }

            return result;
        }

        #endregion
    }
}