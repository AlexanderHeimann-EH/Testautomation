//------------------------------------------------------------------------------
// <copyright file="WaitUntilPrintingIsFinished.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.CreateDocumentation.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.CreateDocumentation.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.CreateDocumentation.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Description of WaitUntilPrintingIsFinished.
    /// </summary>
    public class WaitUntilPrintingIsFinished : IWaitUntilPrintingIsFinished
    {
        /// <summary>
        /// The is printing finished.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsPrintingFinished()
        {
            Cell rootState = (new TreeElements()).RootState;
            if (rootState != null)
            {
                if (string.CompareOrdinal(rootState.Text, CreateDocumentationStateStrings.PrintingFinishedEN) == 0)
                {
                    Button button = (new ActionElements()).SaveAs;
                    return button != null && button.Enabled;
                }
                else
                {
                    Button button = (new ActionElements()).SaveAs;
                    if (button != null)
                    {
                        return button.Enabled;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Button ActionAreaElements.SaveAs is not accessable.");
                    return false;
                }
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                "DeviceFunction.Modules.CreateDocumentation.Validation.IsPrintingFinished",
                "Cell TreeAreaElements.RootState is not accessable.");
            EH.PCPS.TestAutomation.Common.Tools.Log.Screenshot();
            return false;
        }
        
        /// <summary>
        ///     Waits until printing is finished
        /// </summary>
        /// <param name="timeOutInMilliseconds">time within action must be finished</param>
        /// <returns>
        ///     <br>True: if printing is finished in time</br>
        ///     <br>False: if printing is not finished in time</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (!this.IsPrintingFinished())
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module needs to much time to print: >" + DefaultValues.GeneralTimeout + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();
            if (result)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing finished.");
            }

            return result;
        }
    }
}