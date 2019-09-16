//------------------------------------------------------------------------------
// <copyright file="PrinterAndProgress.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.CreateDocumentation.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Description of Navigation.
    /// </summary>
    public class PrinterAndProgress : IPrinterAndProgress
    {
        /// <summary>
        ///     Returns shown MainProgressBarState
        /// </summary>
        /// <returns>
        ///     <br>String: If call worked fine</br>
        ///     <br>Empty String: If an error occurred</br>
        /// </returns>
        public string GetMainProgressBarState()
        {
            string state = (new PrinterAndProgressElements()).MainProgressText;
            return state;
        }

        /// <summary>
        ///     Returns shown SubProgressBarState
        /// </summary>
        /// <returns>
        ///     <br>String: If call worked fine</br>
        ///     <br>Empty String: If an error occurred</br>
        /// </returns>
        public string GetSubProgressBarState()
        {
            try
            {
                Text text = (new PrinterAndProgressElements()).SubProgressText;
                if (text != null)
                {
                    Mouse.MoveTo(text, 500);
                    return text.TextValue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
                return string.Empty;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }
    }
}