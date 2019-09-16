using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsBreadcrumbVisible.
    /// </summary>
    public class IsBreadcrumbVisible : IIsBreadcrumbVisible
    {
        /// <summary>
        /// Determines whether a bread crumb exists in current display content
        /// </summary>
        /// <returns><c>true</c> if bread crumb exists, <c>false</c> otherwise.</returns>
        public bool Run(string breadCrumbId)
        {
            try
            {
                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var chapters = listPage?.Element("Chapters");
                    var chapterWeAreLookingFor = chapters?.Elements("Chapter").Where(e => e.Attribute("id")?.Value == breadCrumbId);

                    if (chapterWeAreLookingFor != null && chapterWeAreLookingFor.Any())
                    {
                        foreach (var chapter in chapterWeAreLookingFor)
                        {
                            var attribute = chapter.Attribute("isOnScreen");
                            if (attribute != null)
                            {
                                result = attribute.Value.Equals("true");
                            }
                        }
                    }

                    if (result)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Bread crumb " + breadCrumbId + " is visible in current display content.");
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Bread crumb " + breadCrumbId + " is not visible in current display content.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}
