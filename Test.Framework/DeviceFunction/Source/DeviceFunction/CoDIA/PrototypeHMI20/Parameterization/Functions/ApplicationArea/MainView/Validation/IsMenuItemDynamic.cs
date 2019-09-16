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
    /// Class IsMenuItemDynamic.
    /// </summary>
    public class IsMenuItemDynamic : IIsMenuItemDynamic
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether a menu item is dynamic
        /// </summary>
        /// <param name="menuItemId">The menu item identifier.</param>
        /// <returns><c>true</c> if menu item is dynamic, <c>false</c> otherwise.</returns>
        public bool Run(string menuItemId)
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
                    var menuItemWeAreLookingFor = listPageList?.Elements("ListNavigationItem").Where(e => e.Attribute("id")?.Value == menuItemId);

                    if (menuItemWeAreLookingFor != null && menuItemWeAreLookingFor.Any())
                    {
                        foreach (var menuItem in menuItemWeAreLookingFor)
                        {
                            var isDynamicAttribute = menuItem.Attribute("isDynamic");
                            if (isDynamicAttribute != null)
                            {
                                result = isDynamicAttribute.Value.Equals("true");
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

        #endregion
    }
}