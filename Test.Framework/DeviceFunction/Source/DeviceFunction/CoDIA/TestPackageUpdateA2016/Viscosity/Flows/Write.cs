// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.StatusArea.Usermessages.Validation;

    /// <summary>
    /// Provides methods for writing coefficients to device
    /// </summary>
    public class Write : MarshalByRefObject, IWrite
    {
        #region Public Methods and Operators

        /// <summary>
        /// Writes coefficients to device
        /// </summary>
        /// <returns>true: if writing finished successfully; false: if an error occurred</returns>
        public bool Run()
        {
            if (Execution.RunWrite.ViaIcon() == false)
            {
                return false;
            }

            if (Validation.CheckUserNotificationMessages.ContainsString("written sucessfully") == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing coefficients failed");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing coefficients succeeded");
            return true;
        }

        /// <summary>
        /// Writes coefficients to device OR verifies the correct behavior in case of the software option not activated
        /// </summary>
        /// <param name="isSoftwareOptionEnabled">default is true; Only use 'false' if the software option 'Viscosity' is not activated.</param>
        /// <returns><c>true</c> if writing succeeded or correct warning message is shown, <c>false</c> otherwise.</returns>
        public bool Run(bool isSoftwareOptionEnabled)
        {
            bool result;
            if (isSoftwareOptionEnabled)
            {
                result = this.Run();
            }
            else
            {
                if (Execution.RunWrite.ViaIcon() == false)
                {
                    result = false;
                }
                else
                {
                    if (Validation.CheckUserNotificationMessages.ContainsString("Functional package \"Viscosity\" not enabled") == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The message: 'Functional package \"Viscosity\" not enabled. Please contact your local \"Endress+Hauser\" organisation.' is not shown.");
                        result = false;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing not possible as expected. Functional package Viscosity is not available.");
                        result = true;
                    }                    
                }
            }

            return result;
        }

        #endregion
    }
}