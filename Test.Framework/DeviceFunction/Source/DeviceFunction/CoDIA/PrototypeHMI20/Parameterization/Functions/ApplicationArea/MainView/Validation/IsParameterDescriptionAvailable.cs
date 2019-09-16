namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsParameterDescriptionAvailable.
    /// </summary>
    public class IsParameterDescriptionAvailable : IIsParameterDescriptionAvailable
    {
        /// <summary>
        /// Checks whether a help text for a parameter is available in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter id.</param>
        /// <returns><c>true</c> if help available, <c>false</c> otherwise.</returns>
        public bool Run(string parameterId)
        {
            try
            {
                string parameterName = string.Empty;
                string[] separator = { "//" };
                string[] pathParts = parameterId.Split(separator, StringSplitOptions.None);
                if (pathParts.Length > 0)
                {
                    parameterName = pathParts[pathParts.Length - 1];
                }

                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var helpPage = displayContent?.Element("HelpPage");
                    var helpPageList = helpPage?.Element("List");
                    var parameterWeAreLookingFor = helpPageList?.Elements().Where(e => e.Attribute("id")?.Value == parameterName);

                    if (parameterWeAreLookingFor != null && parameterWeAreLookingFor.Any())
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "' is available.");
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "' is not available.");
                    }
                }

                return result;
            }
            catch (System.Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

    }
}
