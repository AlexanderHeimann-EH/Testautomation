// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadCurveFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow: Load Curve-File at module Envelope Curve
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Flow: Load Curve-File at module Envelope Curve
    /// </summary>
    public class LoadCurveFile : ILoadCurveFile
    {
        #region Public Methods and Operators

        /// <summary>
        /// Save curve(s) with default file name in report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "EnvelopeCurveData.curves";
            return this.RunViaMenu(fileName);
        }

        /// <summary>
        /// Load curves, with handling for unknown curves and already available curves.
        ///     Discard available curves by default.
        /// </summary>
        /// <param name="filename">
        /// File to open
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string filename)
        {
            return this.RunViaMenu(filename, true);
        }

        /// <summary>
        /// Load curves, with handling for unknown curves and already available curves.
        /// </summary>
        /// <param name="filename">
        /// File to open
        /// </param>
        /// <param name="discardUnsaved">
        /// True to discard curves, false to cancel action
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string filename, bool discardUnsaved)
        {
            // if filename is empty
            if (filename.Length > 0)
            {
                // if function call worked fine
                if ((new OpenLoadCurve()).ViaMenu())
                {
                    // if((new FileBrowser()).OpenFileViaFilename(filename))
                    if (Execution.OpenFileBrowser.Load(filename))
                    {
                        Button discardCurves = (new DiscardCurvesElements()).BtnOk;

                        // if no message box regarding unknown files or 
                        // discard already available curves, came up
                        if (discardCurves == null)
                        {
                            return true;
                        }

                        {
                            // if curves should be discarded
                            if (discardUnsaved)
                            {
                                // discard curves
                                if (discardCurves.Enabled)
                                {
                                    discardCurves.Click(DefaultValues.locDefaultLocation);
                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Available curves are not saved. Curves are loaded.");
                                    return true;
                                }

                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to discard is not accessable.");
                                return false;
                            }

                            // if discarding should be canceled
                            // cancel discard curves
                            Button cancelDiscard = (new DiscardCurvesElements()).BtnCancel;
                            if (cancelDiscard != null && cancelDiscard.Enabled)
                            {
                                cancelDiscard.Click(DefaultValues.locDefaultLocation);
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Available curves are not saved. Curves are not loaded.");
                                return true;
                            }

                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to cancel discard is not accessable.");
                            return false;
                        }
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Filename is invalid");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu is not accessable.");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Filename is not available.");
            return false;
        }

        #endregion
    }
}