namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class WaitForDisplayContentChangedAfterSet.
    /// </summary>
    public class WaitForDisplayContentChangedAfterSet : IWaitForDisplayContentChangedAfterSet
    {
        #region Public Methods and Operators

        /// <summary>
        /// Waits for display content change after changing a parameter
        /// </summary>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds.</param>
        /// <param name="nodePath">The node path.</param>
        /// <param name="value"></param>
        /// <returns><c>true</c> if content changed, <c>false</c> otherwise.</returns>
        public bool Run(int timeoutInMilliseconds, string nodePath, string value)
        {
            try
            {
                bool result = true;

                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    while (!this.IsSet(xml, nodePath, value))
                    {
                        if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No update of display content recognized.");
                            result = false;
                            break;
                        }

                        if ((watch.ElapsedMilliseconds / 1000) % 2 == 0)
                        {
                            xml = XDocument.Parse(AppComController.GetDisplayContent());
                        }
                    }

                    watch.Stop();
                }
                else
                {
                    result = false;
                }

                return result;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                return false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified parameter is set correctly.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="nodePath">The node path.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified parameter is set; otherwise, <c>false</c>.</returns>
        private bool IsSet(XDocument xml, string nodePath, string value)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListItem").Where(e => e.Attribute("id")?.Value == nodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                foreach (var item in listItemWeAreLookingFor)
                {
                    var parameter = item.Element("ListColumn")?.Descendants();
                    if (parameter != null && parameter.Any())
                    {
                        foreach (var param in parameter)
                        {
                            if (param.Name != "Text")
                            {
                                var attribute = param.Attribute("displayedText");
                                if (attribute != null)
                                {
                                    result = attribute.Value.Equals(value);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}