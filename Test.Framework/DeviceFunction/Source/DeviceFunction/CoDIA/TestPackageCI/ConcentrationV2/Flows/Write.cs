// --------------------------------------------------------------------------------------------------------------------
// <copyright file="write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.StatusArea.Usermessages;

    /// <summary>
    ///     provides methods for writing coefficients to device
    /// </summary>
    public class Write : IWrite
    {
        #region Public Methods and Operators

        /// <summary>
        ///     writes coefficients to device/offline parameterization, waits until "write finished" user notification message is displayed and write button is enabled again
        /// </summary>
        /// <returns>
        ///     true: if coefficients were written
        ///     false: if an error occurred
        /// </returns>
        public bool Run()
        {
            bool isWriting = false;
            var watch = new Stopwatch();
            if (new RunWrite().ViaIcon() == false)
            {
                return false;
            }

            isWriting = true;
            
            watch.Start();
            while (isWriting)
            {
                string actualInfo = new UserMessagesElements().UserNotification;
                string actualInfoLowerCase = actualInfo.ToLower();
                bool isSuccess = actualInfoLowerCase.Contains("success");
                bool isFinished = new IsWriteFinished().Run();

                if (watch.ElapsedMilliseconds > DefaultValues.iTimeoutLong)
                {
                    if (isFinished == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button [Write] is not enabled.");
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing did not finish within " + DefaultValues.iTimeoutLong + " milliseconds");
                    return false;
                }
                
                if (isSuccess)
                {
                    if (isFinished)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing finished.");
                        isWriting = false;
                    }
                }               
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing coefficients finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutLong + " milliseconds)");
            return true;
        }

        #endregion
    }
}