// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateNetwork.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CreateNetwork.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V20901.SpecificFlows
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;
    using Ranorex.Core;

    using Button = Ranorex.Button;
   
    /// <summary>
    /// Class CreateNetwork.
    /// </summary>
    public class CreateNetwork : ICreateNetwork
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates network (scan for device) via menu. Waits for the action to finish and reports the result.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// Timeout for the scanning progress in milliseconds.
        /// </param>
        /// <param name="networkTag">
        /// The network Tag for the device.
        /// </param>
        /// <returns>
        /// <c>true</c> if scanning finished successfully, <c>false</c> otherwise.
        /// </returns>
        public bool Run(int timeoutInMilliseconds, string networkTag)
        {
            bool result = true;
            var watch = new Stopwatch();

            new Functions.MenuArea.Toolbar.Execution.RunCreateNetwork().ViaIcon();

            Element scanningInProgress = new ScanningElements().ScanningInProgressDialog;
            Element scanningResult = new ScanningElements().ScanningResultDialog;
            watch.Start();

            // Wait until the scanning in progress dialog is visible
            while (scanningInProgress == null && watch.ElapsedMilliseconds < 10000)
            {
                scanningInProgress = new ScanningElements().ScanningInProgressDialog;
            }

            // Wait until scanning is finished
            while (scanningInProgress != null && watch.ElapsedMilliseconds < timeoutInMilliseconds && scanningResult == null)
            {
                scanningInProgress = new ScanningElements().ScanningInProgressDialog;
                scanningResult = new ScanningElements().ScanningResultDialog;
            }

            watch.Stop();
            if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
            {
                // Scanning took too long
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scanning timed out. It took " + watch.ElapsedMilliseconds + " milliseconds. Timeout after: " + timeoutInMilliseconds + " milliseconds.");
                result = false;
            }
            else if (new ScanningElements().ScanningResultDialog != null)
            {
                // Scanning result dialog is open -> Quality != 1.Take a screen and close dialog via ok button
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dtm quality level is not '1'. Please check the connected device.");
                Log.Screenshot(new ScanningElements().ScanningResultDialog);
                result = false;
                Button ok = new ScanningElements().OkButton;
                if (ok != null && ok.Enabled)
                {
                    ok.Click();
                }
            }
            else
            {
                // Scanning finished, check whether it was successful or it failed                
                if (new Functions.Dialogs.DtmMessages.Validation.ScanDtmMessages().Contains("Finished scanning."))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scanning finished.");
                    if (DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation.ModuleOpeningAndClosing.IsOnlineModuleAlreadyOpened())
                    {
                        DeviceFunctionLoader.CoDIA.Parameterization.Flows.CloseModuleOnline.Run();
                    }

                    this.SetNetworkTag(networkTag);
                }
                else
                {
                    var messages = new DtmMessages().GetAllDtmMessages;
                    foreach (var message in messages)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), message);
                    }

                    result = false;
                }
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the network tag. This works only after a scan.
        /// </summary>
        /// <param name="networkTag">
        /// The network tag.
        /// </param>
        private void SetNetworkTag(string networkTag)
        {
            Element element = (new NetworkViewElements()).Area;
            if (networkTag == string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Network tag must not be an empty string.");
            }
            else if (element != null)
            {
                Mouse.Click(element);
                Keyboard.Press(Keys.Down);
                Keyboard.Press(Keys.F2);
                Keyboard.Press(networkTag);
                Keyboard.Press(Keys.Enter);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting network tag to: '" + networkTag + "'.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to set network tag");
            }
        }

        #endregion
    }
}