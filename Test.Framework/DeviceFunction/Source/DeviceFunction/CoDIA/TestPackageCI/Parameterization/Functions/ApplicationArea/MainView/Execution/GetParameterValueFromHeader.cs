// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameterValueFromHeader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The get parameter value from header.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The get parameter value from header.
    /// </summary>
    public class GetParameterValueFromHeader : IGetParameterValueFromHeader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the value (as string) from a parameter within the header area.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name (internal parameter name)
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Run(string parameterName)
        {
            var result = string.Empty;

            string guiHelpString = CommonFlows.GetDtmContainerPath.Run();

            string pathToHeaderElements = guiHelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']/container[@controlname='ZeroLayoutContainer']/container/?/?/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']/container[@controltypename='SpanLayoutPanel']/container[@controltypename='EddSingleColumnLayoutPanel']/element";

            // Get all elements from header
            IList<Element> headerElements = Host.Local.Find(pathToHeaderElements);
            IList<Element> allEditorVariables = new List<Element>();

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
                        if (target.GetAttributeValueText("controlname").Contains(parameterName))
                        {
                            result = target.GetAttributeValueText("controltext");
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found parameter '" + parameterName + "'. Its value is: '" + result + "'.");
                            break;
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}