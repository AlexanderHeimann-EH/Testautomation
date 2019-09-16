//------------------------------------------------------------------------------
// <copyright file="NewCurve.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.Dialogs;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Flow: Empty diagram for new Curves at module Envelope Curve
    /// </summary>
    public class NewCurve : INewCurve
    {
        /// <summary>
        ///     Reset Envelope Curve diagram and curve data to initial state. Discard available
        ///     curves by default.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu()
        {
            return this.RunViaMenu(true);
        }

        /// <summary>
        ///     Reset Envelope Curve diagram and curve data to initial state.
        /// </summary>
        /// <param name="discardUnsaved">True to discard unsaved curves, false to cancel action</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(bool discardUnsaved)
        {
            // if function call worked fine
            if ((new RunNewCurve()).ViaMenu())
            {
                // if no message box regarding to unknown files came up
                Button discardCurves = (new DiscardCurvesElements()).BtnOk;
                if (discardCurves == null)
                {
                    return true;
                }

                // if curves should be discarded
                if (discardUnsaved)
                {
                    // discard curves
                    if (discardCurves.Enabled)
                    {
                        discardCurves.Click(DefaultValues.locDefaultLocation);

                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Available curves are not saved. Diagram is cleared.");

                        Element text = (new DiagramElements()).CurveDataNumber;
                        while (text.GetAttributeValueText("WindowText") != "0/0")
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for curve number to be actualized");
                        }

                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to discard is not accessable.");
                    return false;
                } // if discarding should be canceled
                // cancel discard curves
                Button cancelDiscard = (new DiscardCurvesElements()).BtnCancel;
                if (cancelDiscard != null && cancelDiscard.Enabled)
                {
                    cancelDiscard.Click(DefaultValues.locDefaultLocation);
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Unsaved curves remain available. Diagram is not cleared.");
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to cancel discard is not accessable.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function was not Executiond.");
            return false;
        }
    }
}