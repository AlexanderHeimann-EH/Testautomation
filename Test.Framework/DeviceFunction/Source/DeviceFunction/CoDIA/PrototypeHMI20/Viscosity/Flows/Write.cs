// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Functions.MenuArea.Toolbar.Validation;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.StatusArea.Usermessages.Validation;

    /// <summary>
    /// Provides methods for writing coefficients to device
    /// </summary>
    public class Write : IWrite
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

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (new IsWriteFinished().Run() == false)
            {
                if (stopwatch.ElapsedMilliseconds > Common.DefaultValues.iTimeoutModules)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Writing not finished in time [{0}] (timeout: [{1}].", stopwatch.ElapsedMilliseconds, Common.DefaultValues.iTimeoutModules));
                    return false;
                }
            }

            stopwatch.Stop();           

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
                    if (Validation.CheckUserNotificationMessages.ContainsString("Warning") == false)
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