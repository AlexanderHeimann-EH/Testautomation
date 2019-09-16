// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatSettingsParameterNotInvalid.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckThatSettingsParameterNotInvalid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class CheckThatSettingsParameterNotInvalid.
    /// </summary>
    public class CheckThatSettingsParameterNotInvalid
    {
        #region Public Methods and Operators

        /////// <summary>
        /////// Opens settings tap and verifies that no parameter is invalid
        /////// </summary>
        /////// <returns><c>true</c> if all parameter valid, <c>false</c> otherwise.</returns>
        ////public bool Run()
        ////{
        ////    try
        ////    {
        ////        bool result = true;
        ////        if (new Functions.ApplicationArea.MainView.Execution.SelectTab().Run(2) == false)
        ////        {
        ////            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed switching to settings tab.");
        ////        }
        ////        else
        ////        {
        ////            Container cachedContainer;

        ////            string guiHelpString = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        ////            const string ContainerPath = @"/container[@controlname='DtmFormBase']/container[@controlname='linearizationFormSplitter']/container[@controlname='panel2']/?/?/container[@controlname='tabPageSettingsRef']/container[@controlname='SettingsPageGeneralContainerViewModel|GeneralGroupSettingsPageViewModel']/element[@controlname='ControlContainer']";
        ////            const string ParameterLabel = "descendant::element[@controlname~'Label']/text";

        ////            Host.Local.TryFindSingle(guiHelpString + ContainerPath, DefaultValues.iTimeoutDefault, out cachedContainer);

        ////            IList<Text> labelList = cachedContainer.Find<Text>(ParameterLabel);
        ////            foreach (Text text in labelList)
        ////            {
        ////                Parameter param = new Application().GetParameterStateFast(text.TextValue);
        ////                if (param.ParameterState.ToString() == "Invalid")
        ////                {
        ////                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' is invalid.");
        ////                    result = false;
        ////                }
        ////                else
        ////                {
        ////                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' has status: " + param.ParameterState);
        ////                }
        ////            }
        ////        }

        ////        return result;
        ////    }
        ////    catch (Exception exception)
        ////    {
        ////        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        ////        return false;
        ////    }
        ////}

        /// <summary>
        /// Opens settings tap and verifies that no parameter is invalid
        /// </summary>
        /// <returns><c>true</c> if all parameter valid, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            try
            {
                bool result = true;
                if (new Functions.ApplicationArea.MainView.Execution.SelectTab().Run(2) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed switching to settings tab.");
                }
                else
                {
                    Element parameterContainer;

                    string guiHelpString = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
                    const string ContainerPath = @"/container[@controlname='DtmFormBase']/container[@controlname='linearizationFormSplitter']/container[@controlname='panel2']/?/?/container[@controlname='tabPageSettingsRef']/container[@controlname='SettingsPageGeneralContainerViewModel|GeneralGroupSettingsPageViewModel']/element[@controlname='ControlContainer']";
                    const string ParameterLabel = "descendant::element[@controlname~'Label']/text";

                    Host.Local.TryFindSingle(guiHelpString + ContainerPath, DefaultValues.iTimeoutDefault, out parameterContainer);

                    IList<Element> parameterLabelList = parameterContainer.Find(ParameterLabel);
                    foreach (Element label in parameterLabelList)
                    {
                        Parameter param = new GetSettingsParameterStateFast().Run(label.GetAttributeValueText("Text"));
                        if (param.ParameterState.ToString() == "Invalid")
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' is invalid.");
                            result = false;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' has status: " + param.ParameterState);
                        }
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        #endregion
    }
}