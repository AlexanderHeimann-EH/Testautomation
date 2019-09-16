// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckSetupVersion.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Checks the setup version shown in the AboutBox
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.AboutBox.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.AboutBox.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Checks the setup version shown in the AboutBox
    /// </summary>
    public class CheckSetupVersion : ICheckSetupVersion
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the setup version from the setup information box and checks if it is valid.
        /// </summary>
        /// <returns>
        /// True: if the setup version is valid; False: if otherwise
        /// </returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking setup version...");

            bool result;

            string setupVersion = Execution.GetSetupInformation.Version();
            if (setupVersion == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The setup version information is empty, please check the preconditions.");
                result = false;
            }
            else
            {
                result = Validation.IsSetupVersionCorrect.Run(setupVersion);
                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked setup version. It matches the pattern");
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked setup version. It does not match the pattern");
                }
            }

            return result;
        }

        #endregion
    }
}