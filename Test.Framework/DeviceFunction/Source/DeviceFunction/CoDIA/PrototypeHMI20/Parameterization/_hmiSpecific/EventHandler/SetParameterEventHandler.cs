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
    public class SetParameterEventHandler : DisplayContentEventHandler
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SetParameterEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public SetParameterEventHandler(TddAppComController controller)
            : base(controller)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayContentEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="nodePath">The node path.</param>
        /// <param name="value"></param>
        public SetParameterEventHandler(TddAppComController controller, string nodePath, string value)
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
                bool result = false;
                var xml = XDocument.Parse(this.RemoveHtmlTagsFromString());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var listPageList = listPage?.Element("List");
                    var listItemWeAreLookingFor = listPageList?.Elements("ListItem").Where(e => e.Attribute("id")?.Value == this.NodePath);

                    if (listItemWeAreLookingFor != null && listItemWeAreLookingFor.Any())
                    {
                        foreach (var item in listItemWeAreLookingFor)
                        {
                            var parameter = item.Element("ListColumn")?.Descendants();
                            if (parameter != null && parameter.Any())
                            {
                                foreach (var param in parameter)
                                {
                                    var attribute = param.Attribute("displayedText");
                                    if (attribute != null)
                                    {
                                        result = attribute.Value.Equals(this.Value);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Parameter {0} has expected value {1}", this.NodePath, this.Value));
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Parameter {0} was not set to expected value {1}", this.NodePath, this.Value));
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