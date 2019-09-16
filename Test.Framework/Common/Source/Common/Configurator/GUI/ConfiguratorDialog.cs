// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfiguratorDialog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Description of ConfiguratorDialog.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData;
    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;

    /// <summary>
    /// The configurator dialog.
    /// </summary>
    public partial class ConfiguratorDialog : Form
    {
        #region Fields

        /// <summary>
        /// The path to configuration file.
        /// </summary>
        private static string pathToConfigurationFile;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguratorDialog"/> class.
        /// </summary>
        /// <param name="pathToConfig">
        /// The path To Config.
        /// </param>
        public ConfiguratorDialog(string pathToConfig)
        {
            this.InitializeComponent();
            Console.WriteLine("Document found: " + File.Exists(pathToConfig));
            this.Initialize(pathToConfig);
        }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        public static SelectedConfiguration SelectedConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the selectable items.
        /// </summary>
        private static SelectableConfiguration SelectableConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the control test framework.
        /// </summary>
        private ControlTestFramework ControlTestFramework { get; set; }

        /// <summary>
        /// Gets or sets the control test environment.
        /// </summary>
        private ControlTestEnvironment ControlTestEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the control test information.
        /// </summary>
        private ControlTestInformation ControlTestInformation { get; set; }

        /// <summary>
        /// The save configurator dialog data.
        /// </summary>
        public static void SaveConfiguratorDialogData()
        {
            if (pathToConfigurationFile == string.Empty)
            {
                pathToConfigurationFile = Directory.GetCurrentDirectory() + @"\ConfigData\Configuration.xml";
            }

            XmlFileHandler.WriteDataToXml(SelectedConfiguration, pathToConfigurationFile);
        }
        
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="configFile">
        /// The config File.
        /// </param>
        public void Initialize(string configFile)
        {
            pathToConfigurationFile = configFile;
            Configuration.Initialize(pathToConfigurationFile);
            SelectedConfiguration = Configuration.SelectedConfiguration;
            SelectableConfiguration = Configuration.SelectableConfiguration;
            this.ControlTestInformation = new ControlTestInformation();
            this.ControlTestEnvironment = new ControlTestEnvironment(SelectableConfiguration);
            this.ControlTestFramework = new ControlTestFramework();
            this.tabPageAdditionalInformation.Controls.Add(this.ControlTestInformation);
            this.tabPageTestEnvironment.Controls.Add(this.ControlTestEnvironment);
            this.tabPageTestFramework.Controls.Add(this.ControlTestFramework);
            this.SetConfiguratorDialogData();
        }

        /// <summary>
        /// The set configurator dialog data.
        /// </summary>
        public void SetConfiguratorDialogData()
        {
            this.ControlTestFramework.SetTestFrameworkData(SelectedConfiguration.TestFramework);
            this.ControlTestEnvironment.SetTestEnvironmentData(SelectedConfiguration.TestEnvironment);
            this.ControlTestInformation.SetTestInformationData(SelectedConfiguration.TestInformation);
        }

        /// <summary>
        /// The get configurator dialog data.
        /// </summary>
        public void GetConfiguratorDialogData()
        {
            SelectedConfiguration.TestFramework = this.ControlTestFramework.GetTestFrameworkData();
            SelectedConfiguration.TestEnvironment = this.ControlTestEnvironment.GetTestEnvironmentData();
            SelectedConfiguration.TestInformation = this.ControlTestInformation.GetTestInformationData();
        }

        /// <summary>
        /// The button start_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonStartClick(object sender, EventArgs e)
        {
            this.SaveData();  
            this.Close();
        }

        /// <summary>
        /// The button apply_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonApplyClick(object sender, EventArgs e)
        {
            this.SaveData();
        }

        /// <summary>
        /// The save data.
        /// </summary>
        private void SaveData()
        {
            this.GetConfiguratorDialogData();
            SaveConfiguratorDialogData();

            // Update configuration data
            Configuration.SelectedConfiguration = XmlFileHandler.ReadDataFromXml(pathToConfigurationFile);
        }

        /// <summary>
        /// The button cancel_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
