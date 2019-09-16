using System;
using System.Linq;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Xml.Linq;

    using Common.Tools;

    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// 
    /// </summary>
    public class IsModuleReady
    {
        /// <summary>
        /// Determines whether module is ready
        /// </summary>
        /// <returns><c>true</c> if ready, <c>false</c> otherwise.</returns>
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
                    var deviceHeaderParameter = deviceHeader?.Elements("FloatValueItem");
                    var navigationItemsList = listPageList?.Elements("ListNavigationItem");                    

                    if ((deviceHeaderParameter != null && deviceHeaderParameter.Any()) && (navigationItemsList != null && navigationItemsList.Any()))
                    {
                        var watch = new Stopwatch();
                        watch.Start();
                        while (watch.ElapsedMilliseconds < 5000)
                        {
                            //do nothing  
                        }

                        watch.Stop();

                        result = true;
                    }
                }

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is ready.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not ready.");
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
