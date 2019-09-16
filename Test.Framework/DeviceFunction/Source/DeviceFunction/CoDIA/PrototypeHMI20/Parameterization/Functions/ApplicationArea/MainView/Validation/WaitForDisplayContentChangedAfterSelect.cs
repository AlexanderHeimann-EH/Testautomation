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
    /// Class WaitForDisplayContentChangedAfterSelect.
    /// </summary>
    public class WaitForDisplayContentChangedAfterSelect : IWaitForDisplayContentChangedAfterSelect
    {
        #region Public Methods and Operators

        /// <summary>
        /// Waits for display content change after selecting an item
        /// </summary>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds.</param>
        /// <param name="nodePath">The node path.</param>
        /// <returns><c>true</c> if content changed, <c>false</c> otherwise.</returns>
        public bool Run(int timeoutInMilliseconds, string nodePath)
        {
            try
            {
                bool result = true;

                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    while (!this.IsItemAvailableAsParentMenu(xml, nodePath) && !this.IsItemAvailableInWorkingArea(xml, nodePath) && !this.IsItemActive(xml, nodePath))
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
        /// Determines whether [is item active] [the specified XML].
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="nodePath"></param>
        /// <returns><c>true</c> if [is item active] [the specified XML]; otherwise, <c>false</c>.</returns>
        private bool IsItemActive(XDocument xml, string nodePath)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListNavigationItem").Where(e => e.Attribute("id")?.Value == nodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                foreach (var item in listItemWeAreLookingFor)
                {
                    var xAttribute = item.Attribute("isSelected");
                    if (xAttribute != null)
                    {
                        if (xAttribute.Value.Equals("true"))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {nodePath} is selected.");
                            result = true;
							break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is item available in working area] [the specified XML].
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="nodePath"></param>
        /// <returns><c>true</c> if [is item available in working area] [the specified XML]; otherwise, <c>false</c>.</returns>
        private bool IsItemAvailableInWorkingArea(XDocument xml, string nodePath)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListItem").Where(e => e.Attribute("id")?.Value == nodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {nodePath} exists in working area.");
            }

            return result;
        }

        /// <summary>
        /// Determines whether an item is set as parent menu id (full text) in navgiation area. This way, you know that you reached a deeper level in navigation area.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="nodePath"></param>
        /// <returns><c>true</c> if item is set as parent menu id; otherwise, <c>false</c>.</returns>
        private bool IsItemAvailableAsParentMenu(XDocument xml, string nodePath)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listNavigationItems = listPageList?.Elements("ListNavigationItem");

            if (listNavigationItems != null && listNavigationItems.Any())
            {
                // jedes element daraufhin untersuchen ob fulltext = nodepath
                foreach (var item in listNavigationItems)
                {
                    var xAttribute = item.Attribute("parentMenu");
                    if (xAttribute != null)
                    {
                        if (xAttribute.Value == nodePath)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {nodePath} is set as parent menu id.");
                            result = true;
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