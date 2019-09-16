// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisconnectSoftwareUnderTest.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DisconnectSoftwareUnderTest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class DisconnectSoftwareUnderTest.
    /// </summary>
    class DisconnectSoftwareUnderTest : IDisconnectSoftwareUnderTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns><c>true</c> if disconnected, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not available with standard Parameterization. Use HMI instead.");
            return false; 
        }

        #endregion
    }
}