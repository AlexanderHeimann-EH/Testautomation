// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlTestEnvironment.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Description of ControlTestEnvironment.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData;
    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;

    /// <summary>
    /// The control test environment.
    /// </summary>
    public partial class ControlTestEnvironment : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTestEnvironment"/> class.
        /// </summary>
        public ControlTestEnvironment()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTestEnvironment"/> class.
        /// </summary>
        /// <param name="selectableItems">
        /// The selectable items.
        /// </param>
        public ControlTestEnvironment(SelectableConfiguration selectableItems)
        {
            SelectableItems = selectableItems;

            this.InitializeComponent();
            this.InitializeTestEnvironmentControls();
        }

        /// <summary>
        /// Gets or sets the test environment.
        /// </summary>
        private static TestEnvironment TestEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the selectable items.
        /// </summary>
        private static SelectableConfiguration SelectableItems { get; set; }

        /// <summary>
        /// The set test environment data.
        /// </summary>
        /// <param name="testEnvironment">
        /// The test environment.
        /// </param>
        public void SetTestEnvironmentData(TestEnvironment testEnvironment)
        {
            TestEnvironment = testEnvironment;

            this.comboBoxOperatingSystemBitVersion.Text  = TestEnvironment.OperatingSystem.Category;
            this.comboBoxOperatingSystemName.Text = TestEnvironment.OperatingSystem.Assembly;

            this.comboBoxHostApplicationType.Text = TestEnvironment.HostApplication.Category;
            this.comboBoxHostApplicationNameVersion.Text = TestEnvironment.HostApplication.Assembly;

            this.comboBoxCommunicationProtocol.Text = TestEnvironment.Communication.Category;
            this.comboBoxCommunicationDeviceType.Text = TestEnvironment.Communication.Assembly;

            this.comboBoxDeviceFunctionPlatform.Text = TestEnvironment.DeviceFunction.Category;
            this.comboBoxDeviceFunctionPackage.Text = TestEnvironment.DeviceFunction.Assembly;
        }

        /// <summary>
        /// The get test environment data.
        /// </summary>
        /// <returns>
        /// The <see cref="TestEnvironment"/>.
        /// </returns>
        public TestEnvironment GetTestEnvironmentData()
        {
            TestEnvironment.OperatingSystem.Category = this.comboBoxOperatingSystemBitVersion.Text;
            TestEnvironment.OperatingSystem.Assembly = this.comboBoxOperatingSystemName.Text;

            TestEnvironment.HostApplication.Category = this.comboBoxHostApplicationType.Text;
            TestEnvironment.HostApplication.Assembly = this.comboBoxHostApplicationNameVersion.Text;

            TestEnvironment.Communication.Category = this.comboBoxCommunicationProtocol.Text;
            TestEnvironment.Communication.Assembly = this.comboBoxCommunicationDeviceType.Text;

            TestEnvironment.DeviceFunction.Category = this.comboBoxDeviceFunctionPlatform.Text;
            TestEnvironment.DeviceFunction.Assembly = this.comboBoxDeviceFunctionPackage.Text;
            
            return TestEnvironment;
        }

        /// <summary>
        /// The initialize test environment controls.
        /// </summary>
        private void InitializeTestEnvironmentControls()
        {
            this.InitializeComboBoxOperatingSystemCategory();
            this.InitializeComboBoxHostApplicationCategory();
            this.InitializeComboBoxCommunicationCategory();
            this.InitializeComboBoxDeviceFunctionCategory();
        }

        #region initializer for gui controls that represents categories

        /// <summary>
        /// The initialize combo box operating system category.
        /// </summary>
        private void InitializeComboBoxOperatingSystemCategory()
        {
            foreach (var item in SelectableItems.OperatingSystemItems.Items)
            {
                this.comboBoxOperatingSystemBitVersion.Items.Add(item.Category);
            }

            if (this.comboBoxOperatingSystemBitVersion.Items.Count > 0)
            {
                this.comboBoxOperatingSystemBitVersion.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The initialize combo box host application category.
        /// </summary>
        private void InitializeComboBoxHostApplicationCategory()
        {
            List<CategoryAndItems> list = SelectableItems.HostApplicationItems.Items;

            foreach (var item in list)
            {
                this.comboBoxHostApplicationType.Items.Add(item.Category);
            }

            if (this.comboBoxHostApplicationType.Items.Count > 0)
            {
                this.comboBoxHostApplicationType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The initialize combo box communication category.
        /// </summary>
        private void InitializeComboBoxCommunicationCategory()
        {
            List<CategoryAndItems> list = SelectableItems.CommunicationItems.Items;

            foreach (var item in list)
            {
                this.comboBoxCommunicationProtocol.Items.Add(item.Category);
            }

            if (this.comboBoxCommunicationProtocol.Items.Count > 0)
            {
                this.comboBoxCommunicationProtocol.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The initialize combo box device function category.
        /// </summary>
        private void InitializeComboBoxDeviceFunctionCategory()
        {
            List<CategoryAndItems> list = SelectableItems.DeviceFunctionsItems.Items;

            foreach (var item in list)
            {
                this.comboBoxDeviceFunctionPlatform.Items.Add(item.Category);
            }

            if (this.comboBoxDeviceFunctionPlatform.Items.Count > 0)
            {
                this.comboBoxDeviceFunctionPlatform.SelectedIndex = 0;
            }
        }
        #endregion

        #region event handler for changes in selection

        /// <summary>
        /// The combo box operating system bit version_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxOperatingSystemBitVersionSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateComboBoxOperatingSystemNameVersion();
        }

        /// <summary>
        /// The combo box host application type_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxHostApplicationTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateComboBoxHostApplicationNameVersion();
        }

        /// <summary>
        /// The combo box communication protocol_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxCommunicationProtocolSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateComboBoxCommunicationNameVersion();
        }

        /// <summary>
        /// The combo box device function platform_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxDeviceFunctionPlatformSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateComboBoxDeviceFunctionPackage();
        }

        #endregion

        #region update functions for controls

        /// <summary>
        /// The update combo box operating system name version.
        /// </summary>
        private void UpdateComboBoxOperatingSystemNameVersion()
        {
            this.comboBoxOperatingSystemName.Items.Clear();
            string selectedEntry = this.comboBoxOperatingSystemBitVersion.Text;
            foreach (var categoryItem in SelectableItems.OperatingSystemItems.Items)
            {
                if (categoryItem.Category.Equals(selectedEntry))
                {
                    foreach (var nameItem in categoryItem.Items)
                    {
                        this.comboBoxOperatingSystemName.Items.Add(nameItem);
                    }

                    this.comboBoxOperatingSystemName.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// The update combo box host application name version.
        /// </summary>
        private void UpdateComboBoxHostApplicationNameVersion()
        {
            this.comboBoxHostApplicationNameVersion.Items.Clear();
            string selectedEntry = this.comboBoxHostApplicationType.Text;
            foreach (var categoryItem in SelectableItems.HostApplicationItems.Items)
            {
                if (categoryItem.Category.Equals(selectedEntry))
                {
                    foreach (var nameItem in categoryItem.Items)
                    {
                        this.comboBoxHostApplicationNameVersion.Items.Add(nameItem);
                    }

                    this.comboBoxHostApplicationNameVersion.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// The update combo box communication name version.
        /// </summary>
        private void UpdateComboBoxCommunicationNameVersion()
        {
            this.comboBoxCommunicationDeviceType.Items.Clear();
            string selectedEntry = this.comboBoxCommunicationProtocol.Text;
            foreach (var categoryItem in SelectableItems.CommunicationItems.Items)
            {
                if (categoryItem.Category.Equals(selectedEntry))
                {
                    foreach (var nameItem in categoryItem.Items)
                    {
                        this.comboBoxCommunicationDeviceType.Items.Add(nameItem);
                    }

                    this.comboBoxCommunicationDeviceType.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// The update combo box device function package.
        /// </summary>
        private void UpdateComboBoxDeviceFunctionPackage()
        {
            this.comboBoxDeviceFunctionPackage.Items.Clear();
            string selectedEntry = this.comboBoxDeviceFunctionPlatform.Text;
            foreach (var categoryItem in SelectableItems.DeviceFunctionsItems.Items)
            {
                if (categoryItem.Category.Equals(selectedEntry))
                {
                    foreach (var nameItem in categoryItem.Items)
                    {
                        this.comboBoxDeviceFunctionPackage.Items.Add(nameItem);
                    }

                    this.comboBoxDeviceFunctionPackage.SelectedIndex = 0;
                }
            }
        }

        #endregion
    }
}
