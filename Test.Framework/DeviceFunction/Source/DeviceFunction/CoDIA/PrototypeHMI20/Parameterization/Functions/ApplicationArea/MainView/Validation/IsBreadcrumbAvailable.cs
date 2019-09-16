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
    /// Class IsBreadcrumbAvailable.
    /// </summary>
    public class IsBreadcrumbAvailable : IIsBreadcrumbAvailable
    {
        /// <summary>
        /// Determines whether a specific bread crumb is available in current display content        
        /// </summary>
        /// <param name="breadcrumbId">The bread crumb identifier.</param>
        /// <returns><c>true</c> if bread crumb is available, <c>false</c> otherwise.</returns>
        public bool Run(string breadcrumbId)
        {
            var result = false;

            if (AppComController.GetDisplayContent().Contains(breadcrumbId))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Bread crumb '" + breadcrumbId + "' is available.");
                result = true;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Bread crumb '" + breadcrumbId + "' is not available.");
            }


            return result;
        }

        /// <summary>
        /// Determines whether a bread crumb exists in current display content
        /// </summary>
        /// <returns><c>true</c> if bread crumb exists, <c>false</c> otherwise.</returns>
        public bool Run()
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
                    var chaptersWeAreLookingFor = chapters?.Elements("Chapter");

                    if (chaptersWeAreLookingFor != null && chaptersWeAreLookingFor.Any())
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A bread crumb exists in current display content.");
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No bread crumb available in current display content.");
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
