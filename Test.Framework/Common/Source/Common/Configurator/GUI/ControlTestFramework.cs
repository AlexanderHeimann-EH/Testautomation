//------------------------------------------------------------------------------
// <copyright file="ControlTestFramework.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of ControlTestFramework.cs.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    using System;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;

    /// <summary>
    /// The control test framework.
    /// </summary>
    public partial class ControlTestFramework : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTestFramework"/> class.
        /// </summary>
        public ControlTestFramework()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the test framework data.
        /// </summary>
        private static TestFramework TestFrameworkData { get; set; }
        
        /// <summary>
        /// The set test framework data.
        /// </summary>
        /// <param name="testFrameworkData">
        /// The test framework data.
        /// </param>
        public void SetTestFrameworkData(TestFramework testFrameworkData)
        {
            TestFrameworkData = testFrameworkData;
            // this.textBoxPathToConfiguration.Text = TestFrameworkData.PathToConfigurationXml;
            this.textBoxPathToAssemblies.Text = TestFrameworkData.PathToAssemblies;
        }

        /// <summary>
        /// The get test framework data.
        /// </summary>
        /// <returns>
        /// The <see cref="TestFramework"/>.
        /// </returns>
        public TestFramework GetTestFrameworkData()
        {
            // TestFrameworkData.PathToConfigurationXml    = this.textBoxPathToConfiguration.Text;
            TestFrameworkData.PathToAssemblies          = this.textBoxPathToAssemblies.Text;
            return TestFrameworkData;
        }

        /// <summary>
        /// The button folder browser configuration_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void buttonFolderBrowserConfiguration_Click(object sender, EventArgs e)
        {
            string oldPath = this.textBoxPathToConfiguration.Text;
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select Path to Configuration.xml";

            if (oldPath != string.Empty)
            {
                folderBrowser.SelectedPath = oldPath;
            }
            else
            {
                folderBrowser.SelectedPath = @"C:\";
            }

            DialogResult objResult = folderBrowser.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                this.textBoxPathToConfiguration.Text = folderBrowser.SelectedPath + @"\Configuration.xml";
            }
            else
            {
                this.textBoxPathToConfiguration.Text = oldPath;
            }
        }

        /// <summary>
        /// The button folder browser assemblies_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void buttonFolderBrowserAssemblies_Click(object sender, EventArgs e)
        {
            string oldPath = this.textBoxPathToAssemblies.Text;
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select Path to Assemblies";

            if (oldPath != string.Empty)
            {
                folderBrowser.SelectedPath = oldPath;
            }
            else
            {
                folderBrowser.SelectedPath = @"C:\";
            }

            DialogResult objResult = folderBrowser.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                this.textBoxPathToAssemblies.Text = folderBrowser.SelectedPath;
            }
            else
            {
                this.textBoxPathToAssemblies.Text = oldPath;
            }
        }
    }
}
