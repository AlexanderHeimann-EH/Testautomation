namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Linq;
    using System.Xml.Linq;

    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetStatusIconState.
    /// </summary>
    public class GetStatusIconState : IGetStatusIconState
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current state from the status icon within the device header
        /// </summary>
        /// <param name="statusIconId">The status icon identifier.</param>
        /// <returns>Current state</returns>
        public string Run(string statusIconId)
        {
            string result = string.Empty;

            var xml = XDocument.Parse(AppComController.GetDisplayContent());
            if (xml.Document != null)
            {
                var displayContent = xml.Element("DisplayContent");
                var listPage = displayContent?.Element("ListPage");
                var listPageList = listPage?.Element("List");
                var itemWeAreLookingFor = listPageList?.Elements("DeviceHeaderDTM")?.Elements("FloatValueItem").Where(e => e.Attribute("id")?.Value == statusIconId);

                if (itemWeAreLookingFor != null && itemWeAreLookingFor.Any())
                {
                    foreach (var item in itemWeAreLookingFor)
                    {
                        var displayedText = item.Element("FloatValue")?.Attribute("displayedText");
                        if (displayedText != null)
                        {
                            result = displayedText.Value;
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}