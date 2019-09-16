using System;
using System.Linq;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;
    using System.Xml.Linq;

    using Common.Tools;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsWizardButtonClickable.
    /// </summary>
    public class IsWizardButtonClickable : IIsWizardButtonClickable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonId"></param>
        /// <returns></returns>
        public bool Run(string buttonId)
        {
            try
            {
                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var listPageWizardButtons = listPage?.Element("WizardButtons");
                    var buttonWeAreLookingFor = listPageWizardButtons?.Elements("WizardButton").Where(e => e.Attribute("id")?.Value == buttonId);

                    if (buttonWeAreLookingFor != null && buttonWeAreLookingFor.Any())
                    {
                        foreach (var button in buttonWeAreLookingFor)
                        {
                            var isSelectableAttribute = button.Attribute("isSelectable");
                            if (isSelectableAttribute != null)
                            {
                                result = isSelectableAttribute.Value.Equals("true");
                            }
                        }
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
