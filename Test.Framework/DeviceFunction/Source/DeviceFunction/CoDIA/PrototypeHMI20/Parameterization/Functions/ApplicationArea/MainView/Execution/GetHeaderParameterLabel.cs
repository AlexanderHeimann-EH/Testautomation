using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetHeaderParameterLabel.
    /// </summary>
    public class GetHeaderParameterLabel : IGetHeaderParameterLabel
    {
        /// <summary>
        /// Gets the label of a header parameter in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>The parameter value.</returns>
        public string Run(string parameterId)
        {
            try
            {
                var result = string.Empty;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var listPageList = listPage?.Element("List");
                    var standardHeaderParams = listPageList?.Elements("DeviceHeaderDTM")?.Elements("FloatValueItem").Where(e => e.Attribute("id")?.Value == parameterId);

                    if (standardHeaderParams != null && standardHeaderParams.Any())
                    {
                        foreach (var param in standardHeaderParams)
                        {
                            var floatValue = param.Element("FloatValue");
                            if (floatValue != null)
                            {
                                var fullText = floatValue.Attribute("fullText");
                                if (fullText != null)
                                {
                                    result = fullText.Value;
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter " + parameterId + " is not available in current display content.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }
    }
}
