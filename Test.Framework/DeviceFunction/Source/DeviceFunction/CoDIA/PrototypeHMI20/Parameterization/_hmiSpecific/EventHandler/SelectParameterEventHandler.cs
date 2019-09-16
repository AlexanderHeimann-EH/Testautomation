namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.EventHandler
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class SetParameterEventHandler.
    /// </summary>
    /// <seealso cref="DisplayContentEventHandler" />
    public class SelectParameterEventHandler : DisplayContentEventHandler
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SetParameterEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public SelectParameterEventHandler(TddAppComController controller)
            : base(controller)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayContentEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="nodePath">The node path.</param>
        /// <param name="value"></param>
        public SelectParameterEventHandler(TddAppComController controller, string nodePath, string value)
            : base(controller, nodePath, value)
        {

        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Verifies an display content update for a parameter has occurred.
        /// </summary>
        /// <returns><c>true</c> if update occurred, <c>false</c> otherwise.</returns>
        public override bool Verify()
        {
            try
            {
                bool result = true;
                var xml = XDocument.Parse(this.RemoveHtmlTagsFromString());
                if (xml.Document != null)
                {
                    if (this.IsItemMissingInNavigation(xml) || this.IsItemAvailableInWorkingArea(xml) || this.IsItemActive(xml))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigation update recognized.");
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigation area not updated.");
                        result = false;
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Xml document is null.");
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    

        /// <summary>
        /// Determines whether [is item missing in navigation] [the specified XML].
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns><c>true</c> if [is item missing in navigation] [the specified XML]; otherwise, <c>false</c>.</returns>
        private bool IsItemMissingInNavigation(XDocument xml)
        {
            bool result = true;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListNavigationItem").Where(e => e.Attribute("id")?.Value == this.NodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {this.NodePath} exists in navigation area.");
                result = false;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {this.NodePath} does not exist in navigation area.");
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is item available in working area] [the specified XML].
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns><c>true</c> if [is item available in working area] [the specified XML]; otherwise, <c>false</c>.</returns>
        private bool IsItemAvailableInWorkingArea(XDocument xml)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListItem").Where(e => e.Attribute("id")?.Value == this.NodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {this.NodePath} exists in working area.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {this.NodePath} does not exist in working area.");
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is item active] [the specified XML].
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns><c>true</c> if [is item active] [the specified XML]; otherwise, <c>false</c>.</returns>
        private bool IsItemActive(XDocument xml)
        {
            bool result = false;
            var displayContent = xml.Element("DisplayContent");
            var listPage = displayContent?.Element("ListPage");
            var listPageList = listPage?.Element("List");
            var listItemWeAreLookingFor = listPageList?.Elements("ListNavigationItem").Where(e => e.Attribute("id")?.Value == this.NodePath);

            if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
            {
                foreach (var item in listItemWeAreLookingFor)
                {
                    var symbols = item.Elements("Symbol");
                    if (symbols.Any())
                    {
                        result = true;
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), $"Item {this.NodePath} is set to active.");
                    }
                }
            }

            return result;
        }



        #endregion
    }
}