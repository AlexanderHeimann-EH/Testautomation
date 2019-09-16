// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisconnectSoftwareUnderTest.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DisconnectSoftwareUnderTest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

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
            return AppComController.Disconnect();
        }

        #endregion
    }
}