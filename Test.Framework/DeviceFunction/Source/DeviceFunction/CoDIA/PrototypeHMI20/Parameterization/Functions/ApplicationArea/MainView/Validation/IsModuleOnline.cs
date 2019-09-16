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
    /// 
    /// </summary>
    public class IsModuleOnline : IIsModuleOnline
    {
        /// <summary>
        /// Determines whether module is online
        /// </summary>
        /// <returns><c>true</c> if online, <c>false</c> otherwise.</returns>
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
                    var listPageList = listPage?.Element("List");
                    var deviceHeader = listPageList?.Element("DeviceHeaderDTM");
                    var paramWeAreLookingFor = deviceHeader?.Elements("FloatValueItem").Where(e => e.Attribute("id")?.Value == "CommunicationInformation.ConnectionState");

                    if (paramWeAreLookingFor != null && paramWeAreLookingFor.Any())
                    {
                        foreach (var item in paramWeAreLookingFor)
                        {
                            var xAttribute = item.Element("FloatValue")?.Attribute("displayedText");
                            if (xAttribute != null)
                            {
                                result = xAttribute.Value.Equals("online");
                            }
                        }
                    }
                }

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is online.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is offline");
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
