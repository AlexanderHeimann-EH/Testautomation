// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NE107Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The dashboard elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The dashboard elements.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class NE107Elements
// ReSharper restore InconsistentNaming
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly NE107ElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NE107Elements"/> class.
        /// </summary>
        public NE107Elements()
        {
            this.repository = NE107ElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the apply button
        /// </summary>
        public Element ApplyButton
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ButtonApplyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the Simulation diagnostic events array list(combo box).
        /// </summary>
        public Element ArrayListSimulationDiagnosticEvents
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Simulation.ArrayListSimulationEventInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the cancel button
        /// </summary>
        public Element CancelButton
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ButtonCancelInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the simulation combo box.
        /// </summary>
        public Text SimulationComboBox
        {
            get
            {
                Text text;
                RepoItemInfo textInfo = this.repository.Simulation.SimulationComboBoxInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + textInfo.AbsolutePath, DefaultValues.iTimeoutLong, out text);
                return text;
            }
        }

        /// <summary>
        /// Gets combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                List list = this.repository.Simulation.ListSimulationEvent;
                return list.Items;
            }
        }

        /// <summary>
        /// Gets the tab control of the NE107 embedded module.
        /// </summary>
// ReSharper disable InconsistentNaming
        public Element TabControlNE107
// ReSharper restore InconsistentNaming
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.TabControlInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// The event.
        /// </summary>
        /// <param name="pathToDiagnosticEventRadioButton">
        /// The path To Diagnostic Event Radio Button.
        /// </param>
        /// <returns>
        /// The <see cref="RadioButton"/>.
        /// </returns>
        public RadioButton EventRadioButton(string pathToDiagnosticEventRadioButton)
        {
            string[] seperator = { "//" };
            string[] pathParts = pathToDiagnosticEventRadioButton.Split(seperator, StringSplitOptions.None);
            if (pathParts.Length < 2)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Path to diagnostic event radio button [{0}] contains to less information.", pathToDiagnosticEventRadioButton));
                return null;
            }

            string diagnosticEvent = pathParts[0];
            string diagnosticCategory = pathParts[1];

            Element eventElement;
            RepoItemInfo eventElementInfo = this.repository.EventElementInfo;
            RxPath modifiedPath = new RxPath(eventElementInfo.AbsolutePath.ToString().Replace("REPLACEACCESSIBLENAME", diagnosticEvent));
            Host.Local.TryFindSingle(this.mdiClientPath + modifiedPath, DefaultValues.iTimeoutLong, out eventElement);

            if (eventElement != null)
            {
                string controlNameOfEventElement = eventElement.GetAttributeValueText("Controlname");
                controlNameOfEventElement = controlNameOfEventElement.Replace("Label_", "Value_");
                controlNameOfEventElement += "." + diagnosticCategory;

                RadioButton eventRadioButton;
                RepoItemInfo eventRadioButtonInfo = this.repository.EventRadioButtonInfo;
                RxPath modifiedRadioButtonPath = new RxPath(eventRadioButtonInfo.AbsolutePath.ToString().Replace("REPLACECONTROLNAME", controlNameOfEventElement));
                Host.Local.TryFindSingle(this.mdiClientPath + modifiedRadioButtonPath, DefaultValues.iTimeoutLong, out eventRadioButton);

                if (eventRadioButton != null)
                {
                    eventRadioButton.MoveTo(500);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Event radio button on category [{0}] was found.", diagnosticCategory));
                    return eventRadioButton;    
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Event radio button on category [{0}] was not found.", diagnosticCategory));
                return null;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic event [{0}] was not found.", diagnosticEvent));
            return null;
        }

        /// <summary>
        /// The active event radio button.
        /// </summary>
        /// <param name="diagnosticEvent">
        /// The diagnostic event.
        /// </param>
        /// <returns>
        /// The <see cref="RadioButton"/>.
        /// </returns>
        public Element ActiveEventRadioButton(string diagnosticEvent)
        {
            Element eventElement;
            RepoItemInfo eventElementInfo = this.repository.EventElementInfo;
            RxPath modifiedPath = new RxPath(eventElementInfo.AbsolutePath.ToString().Replace("REPLACEACCESSIBLENAME", diagnosticEvent));
            Host.Local.TryFindSingle(this.mdiClientPath + modifiedPath, DefaultValues.iTimeoutLong, out eventElement);

            if (eventElement != null)
            {
                string controlNameOfEventElement = eventElement.GetAttributeValueText("Controlname");
                controlNameOfEventElement = controlNameOfEventElement.Replace("Label_", "Value_");

                Element activeEventElement;
                RepoItemInfo activeEventElementsInfo = this.repository.ActiveEventRadioButtonInfo;
                RxPath modifiedElementPath = new RxPath(activeEventElementsInfo.AbsolutePath.ToString().Replace("REPLACECONTROLNAME", controlNameOfEventElement));
                Host.Local.TryFindSingle(this.mdiClientPath + modifiedElementPath, DefaultValues.iTimeoutLong, out activeEventElement);

                if (activeEventElement != null)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Active radio button for event [{0}] found.", diagnosticEvent));
                    return activeEventElement;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Radio buttons were not found."));
                return null;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Event was not found on GUI."));
            return null;
        }

        /// <summary>
        /// The event label.
        /// </summary>
        /// <param name="diagnosticEvent">
        /// The diagnostic event.
        /// </param>
        /// <returns>
        /// The <see cref="Element"/>.
        /// </returns>
        public Element EventLabel(string diagnosticEvent)
        {
            Element eventElement;
            RepoItemInfo eventElementInfo = this.repository.EventElementInfo;
            RxPath modifiedPath = new RxPath(eventElementInfo.AbsolutePath.ToString().Replace("REPLACEACCESSIBLENAME", diagnosticEvent));
            Host.Local.TryFindSingle(this.mdiClientPath + modifiedPath, DefaultValues.iTimeoutLong, out eventElement);
            return eventElement;
        }

        #endregion
    }
}