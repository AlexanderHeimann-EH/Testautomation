// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCoefficientsFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class SetCoefficientsFromDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class SetCoefficientsFromDevice.
    /// </summary>
    public class SetCoefficientsFromDevice : ISetCoefficientsFromDevice
    {
        #region Public Methods and Operators

        /// <summary>
        /// Sets coefficients from device
        /// </summary>
        /// <param name="a0">
        /// The a0 coefficient.
        /// </param>
        /// <param name="a1">
        /// The a1 coefficient.
        /// </param>
        /// <param name="a2">
        /// The a2 coefficient.
        /// </param>
        /// <param name="a3">
        /// The a3 coefficient.
        /// </param>
        /// <param name="a4">
        /// The a4 coefficient.
        /// </param>
        /// <param name="b1">
        /// The b1 coefficient.
        /// </param>
        /// <param name="b2">
        /// The b2 coefficient.
        /// </param>
        /// <param name="b3">
        /// The b3 coefficient.
        /// </param>
        /// <returns>
        /// <c>true</c> if coefficients have been set correctly, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string a0, string a1, string a2, string a3, string a4, string b1, string b2, string b3)
        {
            const double Accuracy = 0.001;
            string[] expectedCoefficients = { a0, a1, a2, a3, a4, b1, b2, b3 };

            // Set every coefficient from device
            Execution.CoefficientsOverview.FromDeviceA0 = a0;
            Execution.CoefficientsOverview.FromDeviceA1 = a1;
            Execution.CoefficientsOverview.FromDeviceA2 = a2;
            Execution.CoefficientsOverview.FromDeviceA3 = a3;
            Execution.CoefficientsOverview.FromDeviceA4 = a4;
            Execution.CoefficientsOverview.FromDeviceB1 = b1;
            Execution.CoefficientsOverview.FromDeviceB2 = b2;
            Execution.CoefficientsOverview.FromDeviceB3 = b3;

            // Check whether the values have been set correctly
            bool result = Execution.CoefficientsOverview.CompareCoefficientsFromDevice(Accuracy, expectedCoefficients);
            if (result == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "One or more coefficients from device have not been set correctly.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients from device have been set correctly.");
            }

            return result;
        }

        #endregion
    }
}