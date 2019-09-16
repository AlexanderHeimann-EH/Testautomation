// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetNamurStatusFromHeader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetNamurStatusFromHeader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class GetNamurStatusFromHeader.
    /// </summary>
    public class GetNamurStatusFromHeader : IGetNamurStatusFromHeader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current Namur-Status from the identification area of the DTM.
        /// </summary>
        /// <returns>Current Namur-Status. E.g. 'OK', 'Function check (C)'.</returns>
        public string Run()
        {
            try
            {
                string result = string.Empty;
                string guiHelpString = CommonFlows.GetDtmContainerPath.Run();

                string pathToHeaderElements = guiHelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']/container[@controlname='ZeroLayoutContainer']/container/?/?/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']/container[@controltypename='SpanLayoutPanel']/container[@controltypename='EddSingleColumnLayoutPanel']/element";

                IList<Element> allEditorVariables = new List<Element>();
                IList<Element> targetEditorVariables = new List<Element>();

                // Get all elements from header
                IList<Element> headerElements = Host.Local.Find(pathToHeaderElements);
                                
                if (headerElements.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No first column header elements found. List is empty.");
                }
                else
                {
                    foreach (var listItem in headerElements)
                    {
                        // Get all editor variables from header elements
                        if (listItem.GetAttributeValueText("controlname").Contains("Editor"))
                        {
                            allEditorVariables.Add(listItem);
                        }
                    }

                    if (allEditorVariables.Count == 0)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No editor variable elements found. List is empty.");
                    }
                    else
                    {
                        foreach (var target in allEditorVariables)
                        {
                            // Get all editor variables from the left side only (1st column)
                            if (target.ScreenLocation.X == allEditorVariables[0].ScreenLocation.X)
                            {
                                targetEditorVariables.Add(target);
                            }
                        }

                        if (targetEditorVariables.Count == 0)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No target editor variable elements found. List is empty.");
                        }
                        else
                        {
                            // Last editor variable in target list is Namur status
                            Element namurStatus = targetEditorVariables[targetEditorVariables.Count - 1];
                            result = namurStatus.GetAttributeValueText("controltext");
                        }

                        if (result == null)
                        {
                            result = string.Empty;
                        }
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return "Namur status not available";
            }
        }

        #endregion
    }
}