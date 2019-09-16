namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsHeaderVisible.
    /// </summary>
    public class IsHeaderVisible : IIsHeaderVisible
    {
        /// <summary>
        /// Validates, whether device header is visible in current display content.
        /// </summary>                
        /// <returns><c>true</c> if parameter is available, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            try
            {                
                var result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    
                    var displayContent = xml.Element("DisplayContent");
                    var helpPage = displayContent?.Element("ListPage");
                    var helpPageList = helpPage?.Element("List");
                    var deviceHeader = helpPageList?.Element("DeviceHeaderDTM");
                    var deviceHeaderAttribute = deviceHeader?.Attribute("isOnScreen");

                    if (deviceHeaderAttribute == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device header attribute is null.");
                    }
                    else if (deviceHeaderAttribute.Value.Equals("true"))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device Header is visible.");
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device Header is not visible.");
                    }
                }               

                return result;
            }
            catch (System.Exception e)
            {

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IsHeaderVisible.Run threw an exception:" + e.Message);
                return false;
            }
        }
    }
}