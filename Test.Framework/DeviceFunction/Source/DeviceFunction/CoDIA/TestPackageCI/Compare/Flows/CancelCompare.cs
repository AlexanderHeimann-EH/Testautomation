// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelCompare.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CancelCompare.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Compare.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.Compare.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Compare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class CancelCompare.
    /// </summary>
    public class CancelCompare : ICancelCompare
    {
        #region Public Methods and Operators

        /// <summary>
        /// Starts compare, then cancels it after a specified time
        /// </summary>
        /// <param name="timeToWaitUntilCancelInMilliseconds">
        /// The time to wait until the comparison is canceled in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if compare is canceled successfully, <c>false</c> otherwise.
        /// </returns>
        public bool Run(int timeToWaitUntilCancelInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            // Try to start the comparison
            if ((new Action()).StartCompare() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare could not be started.");
                result = false;
            }
            else
            {
                watch.Start();

                while (watch.ElapsedMilliseconds < timeToWaitUntilCancelInMilliseconds)
                {
                    if ((new ComparisonProgress()).IsComparing() == false)
                    {
                        result = false;
                    }
                }

                watch.Stop();

                if (result == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparison finished. The time to wait until canceling is too long");
                }
                else
                {
                    if (new Action().CancelCompare() == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare could not be canceled.");
                        result = false;
                    }
                    else
                    {
                        Button compareButton = new GUI.ApplicationArea.MainView.ActionElements().ButtonCompare;
                        Button cancelButton = new GUI.ApplicationArea.MainView.ActionElements().ButtonCancel;
                        Element modeSelection = new GUI.ApplicationArea.MainView.SelectionElements().ElementModeSelection;
                        
                        if (compareButton == null || cancelButton == null || modeSelection == null)
                        {
                            result = false;
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button Compare, Cancel or ModeSelection is null");
                        }
                        else
                        {
                            string mode = modeSelection.GetAttributeValueText("Text");
                            if (mode != string.Empty || cancelButton.Enabled || compareButton.Enabled)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare was canceled but did not abort.");
                                result = false;
                            }
                            else
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare was canceled successfully.");
                            }
                        }                        
                    }
                }
            }

            return result;
        }

        #endregion
    }
}