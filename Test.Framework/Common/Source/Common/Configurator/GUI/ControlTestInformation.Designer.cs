namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    partial class ControlTestInformation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNameOfTester = new System.Windows.Forms.Label();
            this.labelDateOfTest = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelDeviceSerialNumber = new System.Windows.Forms.Label();
            this.labelDeviceId = new System.Windows.Forms.Label();
            this.groupBoxDeviceSpecific = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceTypeName = new System.Windows.Forms.TextBox();
            this.labelDeviceType = new System.Windows.Forms.Label();
            this.textBoxDeviceSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxDeviceId = new System.Windows.Forms.TextBox();
            this.groupBoxTestSpecifc = new System.Windows.Forms.GroupBox();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.textBoxNameOfTester = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateOfTest = new System.Windows.Forms.DateTimePicker();
            this.groupBoxDeviceSpecific.SuspendLayout();
            this.groupBoxTestSpecifc.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNameOfTester
            // 
            this.labelNameOfTester.AutoSize = true;
            this.labelNameOfTester.Location = new System.Drawing.Point(6, 48);
            this.labelNameOfTester.Name = "labelNameOfTester";
            this.labelNameOfTester.Size = new System.Drawing.Size(35, 13);
            this.labelNameOfTester.TabIndex = 0;
            this.labelNameOfTester.Text = "Name";
            // 
            // labelDateOfTest
            // 
            this.labelDateOfTest.AutoSize = true;
            this.labelDateOfTest.Location = new System.Drawing.Point(6, 22);
            this.labelDateOfTest.Name = "labelDateOfTest";
            this.labelDateOfTest.Size = new System.Drawing.Size(30, 13);
            this.labelDateOfTest.TabIndex = 1;
            this.labelDateOfTest.Text = "Date";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(6, 74);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(51, 13);
            this.labelCompany.TabIndex = 2;
            this.labelCompany.Text = "Company";
            // 
            // labelDeviceSerialNumber
            // 
            this.labelDeviceSerialNumber.AutoSize = true;
            this.labelDeviceSerialNumber.Location = new System.Drawing.Point(6, 74);
            this.labelDeviceSerialNumber.Name = "labelDeviceSerialNumber";
            this.labelDeviceSerialNumber.Size = new System.Drawing.Size(71, 13);
            this.labelDeviceSerialNumber.TabIndex = 3;
            this.labelDeviceSerialNumber.Text = "Serial number";
            // 
            // labelDeviceId
            // 
            this.labelDeviceId.AutoSize = true;
            this.labelDeviceId.Location = new System.Drawing.Point(6, 48);
            this.labelDeviceId.Name = "labelDeviceId";
            this.labelDeviceId.Size = new System.Drawing.Size(18, 13);
            this.labelDeviceId.TabIndex = 4;
            this.labelDeviceId.Text = "ID";
            // 
            // groupBoxDeviceSpecific
            // 
            this.groupBoxDeviceSpecific.Controls.Add(this.textBoxDeviceTypeName);
            this.groupBoxDeviceSpecific.Controls.Add(this.labelDeviceType);
            this.groupBoxDeviceSpecific.Controls.Add(this.textBoxDeviceSerialNumber);
            this.groupBoxDeviceSpecific.Controls.Add(this.textBoxDeviceId);
            this.groupBoxDeviceSpecific.Controls.Add(this.labelDeviceId);
            this.groupBoxDeviceSpecific.Controls.Add(this.labelDeviceSerialNumber);
            this.groupBoxDeviceSpecific.Location = new System.Drawing.Point(3, 107);
            this.groupBoxDeviceSpecific.Name = "groupBoxDeviceSpecific";
            this.groupBoxDeviceSpecific.Size = new System.Drawing.Size(547, 98);
            this.groupBoxDeviceSpecific.TabIndex = 1;
            this.groupBoxDeviceSpecific.TabStop = false;
            this.groupBoxDeviceSpecific.Text = "Device specific";
            // 
            // textBoxDeviceTypeName
            // 
            this.textBoxDeviceTypeName.Location = new System.Drawing.Point(94, 19);
            this.textBoxDeviceTypeName.Name = "textBoxDeviceTypeName";
            this.textBoxDeviceTypeName.Size = new System.Drawing.Size(447, 20);
            this.textBoxDeviceTypeName.TabIndex = 3;
            this.textBoxDeviceTypeName.Text = "<please enter the device type>";
            // 
            // labelDeviceType
            // 
            this.labelDeviceType.AutoSize = true;
            this.labelDeviceType.Location = new System.Drawing.Point(6, 22);
            this.labelDeviceType.Name = "labelDeviceType";
            this.labelDeviceType.Size = new System.Drawing.Size(64, 13);
            this.labelDeviceType.TabIndex = 7;
            this.labelDeviceType.Text = "Device type";
            // 
            // textBoxDeviceSerialNumber
            // 
            this.textBoxDeviceSerialNumber.Location = new System.Drawing.Point(94, 71);
            this.textBoxDeviceSerialNumber.Name = "textBoxDeviceSerialNumber";
            this.textBoxDeviceSerialNumber.Size = new System.Drawing.Size(447, 20);
            this.textBoxDeviceSerialNumber.TabIndex = 5;
            this.textBoxDeviceSerialNumber.Text = "<please enter the serial number, if available>";
            // 
            // textBoxDeviceId
            // 
            this.textBoxDeviceId.Location = new System.Drawing.Point(94, 45);
            this.textBoxDeviceId.Name = "textBoxDeviceId";
            this.textBoxDeviceId.Size = new System.Drawing.Size(447, 20);
            this.textBoxDeviceId.TabIndex = 4;
            this.textBoxDeviceId.Text = "<please enter the device id, if available>";
            // 
            // groupBoxTestSpecifc
            // 
            this.groupBoxTestSpecifc.Controls.Add(this.textBoxCompany);
            this.groupBoxTestSpecifc.Controls.Add(this.textBoxNameOfTester);
            this.groupBoxTestSpecifc.Controls.Add(this.dateTimePickerDateOfTest);
            this.groupBoxTestSpecifc.Controls.Add(this.labelDateOfTest);
            this.groupBoxTestSpecifc.Controls.Add(this.labelNameOfTester);
            this.groupBoxTestSpecifc.Controls.Add(this.labelCompany);
            this.groupBoxTestSpecifc.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTestSpecifc.Name = "groupBoxTestSpecifc";
            this.groupBoxTestSpecifc.Size = new System.Drawing.Size(547, 98);
            this.groupBoxTestSpecifc.TabIndex = 0;
            this.groupBoxTestSpecifc.TabStop = false;
            this.groupBoxTestSpecifc.Text = "Test specific";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Location = new System.Drawing.Point(94, 71);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(447, 20);
            this.textBoxCompany.TabIndex = 2;
            this.textBoxCompany.Text = "<please enter your company>";
            // 
            // textBoxNameOfTester
            // 
            this.textBoxNameOfTester.Location = new System.Drawing.Point(94, 45);
            this.textBoxNameOfTester.Name = "textBoxNameOfTester";
            this.textBoxNameOfTester.Size = new System.Drawing.Size(447, 20);
            this.textBoxNameOfTester.TabIndex = 1;
            this.textBoxNameOfTester.Text = "<please enter your name>";
            // 
            // dateTimePickerDateOfTest
            // 
            this.dateTimePickerDateOfTest.Location = new System.Drawing.Point(94, 19);
            this.dateTimePickerDateOfTest.Name = "dateTimePickerDateOfTest";
            this.dateTimePickerDateOfTest.Size = new System.Drawing.Size(185, 20);
            this.dateTimePickerDateOfTest.TabIndex = 0;
            // 
            // ControlTestInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTestSpecifc);
            this.Controls.Add(this.groupBoxDeviceSpecific);
            this.Name = "ControlTestInformation";
            this.Size = new System.Drawing.Size(553, 242);
            this.groupBoxDeviceSpecific.ResumeLayout(false);
            this.groupBoxDeviceSpecific.PerformLayout();
            this.groupBoxTestSpecifc.ResumeLayout(false);
            this.groupBoxTestSpecifc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNameOfTester;
        private System.Windows.Forms.Label labelDateOfTest;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelDeviceSerialNumber;
        private System.Windows.Forms.Label labelDeviceId;
        private System.Windows.Forms.GroupBox groupBoxDeviceSpecific;
        private System.Windows.Forms.TextBox textBoxDeviceSerialNumber;
        private System.Windows.Forms.TextBox textBoxDeviceId;
        private System.Windows.Forms.GroupBox groupBoxTestSpecifc;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.TextBox textBoxNameOfTester;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOfTest;
        private System.Windows.Forms.TextBox textBoxDeviceTypeName;
        private System.Windows.Forms.Label labelDeviceType;
    }
}
