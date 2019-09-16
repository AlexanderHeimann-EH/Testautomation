// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlTestInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Description of ControlTestInformation.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;

    /// <summary>
    /// The control test information.
    /// </summary>
    public partial class ControlTestInformation : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTestInformation"/> class.
        /// </summary>
        public ControlTestInformation()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the test information.
        /// </summary>
        private static TestInformation TestInformation { get; set; }

        /// <summary>
        /// The set test information data.
        /// </summary>
        /// <param name="testInformation">
        /// The test information.
        /// </param>
        public void SetTestInformationData(TestInformation testInformation)
        {
            TestInformation = testInformation;
            this.textBoxCompany.Text = TestInformation.Company;
            this.textBoxDeviceId.Text = TestInformation.DeviceId;
            this.textBoxDeviceSerialNumber.Text = TestInformation.DeviceSerialNumber;
            this.textBoxDeviceTypeName.Text = TestInformation.DeviceType;
            this.textBoxNameOfTester.Text = TestInformation.NameOfTester;
        }

        /// <summary>
        /// The get test information data.
        /// </summary>
        /// <returns>
        /// The <see cref="TestInformation"/>.
        /// </returns>
        public TestInformation GetTestInformationData()
        {
            TestInformation.DateOfTest = this.dateTimePickerDateOfTest.Value;
            TestInformation.Company = this.textBoxCompany.Text;
            TestInformation.DeviceId = this.textBoxDeviceId.Text;
            TestInformation.DeviceSerialNumber = this.textBoxDeviceSerialNumber.Text;
            TestInformation.DeviceType = this.textBoxDeviceTypeName.Text;
            TestInformation.NameOfTester = this.textBoxNameOfTester.Text;
            return TestInformation;
        }
    }
}
