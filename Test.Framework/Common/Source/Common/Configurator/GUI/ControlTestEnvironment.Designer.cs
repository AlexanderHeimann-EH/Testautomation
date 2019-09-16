namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    using System.Windows.Forms;

    partial class ControlTestEnvironment
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
            this.groupBoxOperatingSystem = new System.Windows.Forms.GroupBox();
            this.comboBoxOperatingSystemName = new System.Windows.Forms.ComboBox();
            this.comboBoxOperatingSystemBitVersion = new System.Windows.Forms.ComboBox();
            this.labelOperatingSystemName = new System.Windows.Forms.Label();
            this.labelOperatingSystemBitVersion = new System.Windows.Forms.Label();
            this.groupBoxHostApplication = new System.Windows.Forms.GroupBox();
            this.comboBoxHostApplicationNameVersion = new System.Windows.Forms.ComboBox();
            this.labelHostApplicationType = new System.Windows.Forms.Label();
            this.comboBoxHostApplicationType = new System.Windows.Forms.ComboBox();
            this.labelHostApplicationNameVersion = new System.Windows.Forms.Label();
            this.groupBoxCommunication = new System.Windows.Forms.GroupBox();
            this.comboBoxCommunicationDeviceType = new System.Windows.Forms.ComboBox();
            this.comboBoxCommunicationProtocol = new System.Windows.Forms.ComboBox();
            this.labelCommunicationDeviceType = new System.Windows.Forms.Label();
            this.labelCommunicationProtocol = new System.Windows.Forms.Label();
            this.groupBoxDeviceFunction = new System.Windows.Forms.GroupBox();
            this.comboBoxDeviceFunctionPackage = new System.Windows.Forms.ComboBox();
            this.labelDeviceFunctionPackage = new System.Windows.Forms.Label();
            this.comboBoxDeviceFunctionPlatform = new System.Windows.Forms.ComboBox();
            this.labelDeviceFunctionPlatform = new System.Windows.Forms.Label();
            this.groupBoxOperatingSystem.SuspendLayout();
            this.groupBoxHostApplication.SuspendLayout();
            this.groupBoxCommunication.SuspendLayout();
            this.groupBoxDeviceFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOperatingSystem
            // 
            this.groupBoxOperatingSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOperatingSystem.Controls.Add(this.comboBoxOperatingSystemName);
            this.groupBoxOperatingSystem.Controls.Add(this.comboBoxOperatingSystemBitVersion);
            this.groupBoxOperatingSystem.Controls.Add(this.labelOperatingSystemName);
            this.groupBoxOperatingSystem.Controls.Add(this.labelOperatingSystemBitVersion);
            this.groupBoxOperatingSystem.Location = new System.Drawing.Point(3, 3);
            this.groupBoxOperatingSystem.Name = "groupBoxOperatingSystem";
            this.groupBoxOperatingSystem.Size = new System.Drawing.Size(545, 75);
            this.groupBoxOperatingSystem.TabIndex = 0;
            this.groupBoxOperatingSystem.TabStop = false;
            this.groupBoxOperatingSystem.Text = "OperatingSystem";
            // 
            // comboBoxOperatingSystemName
            // 
            this.comboBoxOperatingSystemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOperatingSystemName.FormattingEnabled = true;
            this.comboBoxOperatingSystemName.Location = new System.Drawing.Point(99, 46);
            this.comboBoxOperatingSystemName.Name = "comboBoxOperatingSystemName";
            this.comboBoxOperatingSystemName.Size = new System.Drawing.Size(440, 21);
            this.comboBoxOperatingSystemName.TabIndex = 1;
            // 
            // comboBoxOperatingSystemBitVersion
            // 
            this.comboBoxOperatingSystemBitVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOperatingSystemBitVersion.FormattingEnabled = true;
            this.comboBoxOperatingSystemBitVersion.Location = new System.Drawing.Point(99, 19);
            this.comboBoxOperatingSystemBitVersion.Name = "comboBoxOperatingSystemBitVersion";
            this.comboBoxOperatingSystemBitVersion.Size = new System.Drawing.Size(440, 21);
            this.comboBoxOperatingSystemBitVersion.TabIndex = 0;
            this.comboBoxOperatingSystemBitVersion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperatingSystemBitVersionSelectedIndexChanged);
            // 
            // labelOperatingSystemName
            // 
            this.labelOperatingSystemName.AutoSize = true;
            this.labelOperatingSystemName.Location = new System.Drawing.Point(6, 49);
            this.labelOperatingSystemName.Name = "labelOperatingSystemName";
            this.labelOperatingSystemName.Size = new System.Drawing.Size(35, 13);
            this.labelOperatingSystemName.TabIndex = 1;
            this.labelOperatingSystemName.Text = "Name";
            // 
            // labelOperatingSystemBitVersion
            // 
            this.labelOperatingSystemBitVersion.AutoSize = true;
            this.labelOperatingSystemBitVersion.Location = new System.Drawing.Point(6, 22);
            this.labelOperatingSystemBitVersion.Name = "labelOperatingSystemBitVersion";
            this.labelOperatingSystemBitVersion.Size = new System.Drawing.Size(57, 13);
            this.labelOperatingSystemBitVersion.TabIndex = 0;
            this.labelOperatingSystemBitVersion.Text = "Bit Version";
            // 
            // groupBoxHostApplication
            // 
            this.groupBoxHostApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHostApplication.Controls.Add(this.comboBoxHostApplicationNameVersion);
            this.groupBoxHostApplication.Controls.Add(this.labelHostApplicationType);
            this.groupBoxHostApplication.Controls.Add(this.comboBoxHostApplicationType);
            this.groupBoxHostApplication.Controls.Add(this.labelHostApplicationNameVersion);
            this.groupBoxHostApplication.Location = new System.Drawing.Point(3, 84);
            this.groupBoxHostApplication.Name = "groupBoxHostApplication";
            this.groupBoxHostApplication.Size = new System.Drawing.Size(545, 75);
            this.groupBoxHostApplication.TabIndex = 1;
            this.groupBoxHostApplication.TabStop = false;
            this.groupBoxHostApplication.Text = "HostApplication";
            // 
            // comboBoxHostApplicationNameVersion
            // 
            this.comboBoxHostApplicationNameVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHostApplicationNameVersion.FormattingEnabled = true;
            this.comboBoxHostApplicationNameVersion.Location = new System.Drawing.Point(98, 46);
            this.comboBoxHostApplicationNameVersion.Name = "comboBoxHostApplicationNameVersion";
            this.comboBoxHostApplicationNameVersion.Size = new System.Drawing.Size(441, 21);
            this.comboBoxHostApplicationNameVersion.TabIndex = 1;
            // 
            // labelHostApplicationType
            // 
            this.labelHostApplicationType.AutoSize = true;
            this.labelHostApplicationType.Location = new System.Drawing.Point(6, 22);
            this.labelHostApplicationType.Name = "labelHostApplicationType";
            this.labelHostApplicationType.Size = new System.Drawing.Size(31, 13);
            this.labelHostApplicationType.TabIndex = 4;
            this.labelHostApplicationType.Text = "Type";
            // 
            // comboBoxHostApplicationType
            // 
            this.comboBoxHostApplicationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHostApplicationType.FormattingEnabled = true;
            this.comboBoxHostApplicationType.Location = new System.Drawing.Point(98, 19);
            this.comboBoxHostApplicationType.Name = "comboBoxHostApplicationType";
            this.comboBoxHostApplicationType.Size = new System.Drawing.Size(441, 21);
            this.comboBoxHostApplicationType.TabIndex = 0;
            this.comboBoxHostApplicationType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHostApplicationTypeSelectedIndexChanged);
            // 
            // labelHostApplicationNameVersion
            // 
            this.labelHostApplicationNameVersion.AutoSize = true;
            this.labelHostApplicationNameVersion.Location = new System.Drawing.Point(6, 49);
            this.labelHostApplicationNameVersion.Name = "labelHostApplicationNameVersion";
            this.labelHostApplicationNameVersion.Size = new System.Drawing.Size(82, 13);
            this.labelHostApplicationNameVersion.TabIndex = 5;
            this.labelHostApplicationNameVersion.Text = "Name + Version";
            // 
            // groupBoxCommunication
            // 
            this.groupBoxCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommunication.Controls.Add(this.comboBoxCommunicationDeviceType);
            this.groupBoxCommunication.Controls.Add(this.comboBoxCommunicationProtocol);
            this.groupBoxCommunication.Controls.Add(this.labelCommunicationDeviceType);
            this.groupBoxCommunication.Controls.Add(this.labelCommunicationProtocol);
            this.groupBoxCommunication.Location = new System.Drawing.Point(3, 165);
            this.groupBoxCommunication.Name = "groupBoxCommunication";
            this.groupBoxCommunication.Size = new System.Drawing.Size(545, 75);
            this.groupBoxCommunication.TabIndex = 2;
            this.groupBoxCommunication.TabStop = false;
            this.groupBoxCommunication.Text = "Communication";
            // 
            // comboBoxCommunicationDeviceType
            // 
            this.comboBoxCommunicationDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCommunicationDeviceType.FormattingEnabled = true;
            this.comboBoxCommunicationDeviceType.Location = new System.Drawing.Point(98, 46);
            this.comboBoxCommunicationDeviceType.Name = "comboBoxCommunicationDeviceType";
            this.comboBoxCommunicationDeviceType.Size = new System.Drawing.Size(441, 21);
            this.comboBoxCommunicationDeviceType.TabIndex = 1;
            // 
            // comboBoxCommunicationProtocol
            // 
            this.comboBoxCommunicationProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCommunicationProtocol.FormattingEnabled = true;
            this.comboBoxCommunicationProtocol.Location = new System.Drawing.Point(98, 19);
            this.comboBoxCommunicationProtocol.Name = "comboBoxCommunicationProtocol";
            this.comboBoxCommunicationProtocol.Size = new System.Drawing.Size(441, 21);
            this.comboBoxCommunicationProtocol.TabIndex = 0;
            this.comboBoxCommunicationProtocol.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCommunicationProtocolSelectedIndexChanged);
            // 
            // labelCommunicationDeviceType
            // 
            this.labelCommunicationDeviceType.AutoSize = true;
            this.labelCommunicationDeviceType.Location = new System.Drawing.Point(6, 49);
            this.labelCommunicationDeviceType.Name = "labelCommunicationDeviceType";
            this.labelCommunicationDeviceType.Size = new System.Drawing.Size(68, 13);
            this.labelCommunicationDeviceType.TabIndex = 5;
            this.labelCommunicationDeviceType.Text = "Device Type";
            // 
            // labelCommunicationProtocol
            // 
            this.labelCommunicationProtocol.AutoSize = true;
            this.labelCommunicationProtocol.Location = new System.Drawing.Point(6, 22);
            this.labelCommunicationProtocol.Name = "labelCommunicationProtocol";
            this.labelCommunicationProtocol.Size = new System.Drawing.Size(46, 13);
            this.labelCommunicationProtocol.TabIndex = 4;
            this.labelCommunicationProtocol.Text = "Protocol";
            // 
            // groupBoxDeviceFunction
            // 
            this.groupBoxDeviceFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDeviceFunction.Controls.Add(this.comboBoxDeviceFunctionPackage);
            this.groupBoxDeviceFunction.Controls.Add(this.labelDeviceFunctionPackage);
            this.groupBoxDeviceFunction.Controls.Add(this.comboBoxDeviceFunctionPlatform);
            this.groupBoxDeviceFunction.Controls.Add(this.labelDeviceFunctionPlatform);
            this.groupBoxDeviceFunction.Location = new System.Drawing.Point(3, 246);
            this.groupBoxDeviceFunction.Name = "groupBoxDeviceFunction";
            this.groupBoxDeviceFunction.Size = new System.Drawing.Size(545, 75);
            this.groupBoxDeviceFunction.TabIndex = 3;
            this.groupBoxDeviceFunction.TabStop = false;
            this.groupBoxDeviceFunction.Text = "DeviceFunction";
            // 
            // comboBoxDeviceFunctionPackage
            // 
            this.comboBoxDeviceFunctionPackage.AccessibleName = "";
            this.comboBoxDeviceFunctionPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDeviceFunctionPackage.FormattingEnabled = true;
            this.comboBoxDeviceFunctionPackage.Location = new System.Drawing.Point(98, 47);
            this.comboBoxDeviceFunctionPackage.Name = "comboBoxDeviceFunctionPackage";
            this.comboBoxDeviceFunctionPackage.Size = new System.Drawing.Size(441, 21);
            this.comboBoxDeviceFunctionPackage.TabIndex = 1;
            // 
            // labelDeviceFunctionPackage
            // 
            this.labelDeviceFunctionPackage.AutoSize = true;
            this.labelDeviceFunctionPackage.Location = new System.Drawing.Point(6, 50);
            this.labelDeviceFunctionPackage.Name = "labelDeviceFunctionPackage";
            this.labelDeviceFunctionPackage.Size = new System.Drawing.Size(50, 13);
            this.labelDeviceFunctionPackage.TabIndex = 5;
            this.labelDeviceFunctionPackage.Text = "Package";
            // 
            // comboBoxDeviceFunctionPlatform
            // 
            this.comboBoxDeviceFunctionPlatform.AccessibleName = "";
            this.comboBoxDeviceFunctionPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDeviceFunctionPlatform.FormattingEnabled = true;
            this.comboBoxDeviceFunctionPlatform.Location = new System.Drawing.Point(98, 20);
            this.comboBoxDeviceFunctionPlatform.Name = "comboBoxDeviceFunctionPlatform";
            this.comboBoxDeviceFunctionPlatform.Size = new System.Drawing.Size(441, 21);
            this.comboBoxDeviceFunctionPlatform.TabIndex = 0;
            this.comboBoxDeviceFunctionPlatform.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDeviceFunctionPlatformSelectedIndexChanged);
            // 
            // labelDeviceFunctionPlatform
            // 
            this.labelDeviceFunctionPlatform.AutoSize = true;
            this.labelDeviceFunctionPlatform.Location = new System.Drawing.Point(6, 22);
            this.labelDeviceFunctionPlatform.Name = "labelDeviceFunctionPlatform";
            this.labelDeviceFunctionPlatform.Size = new System.Drawing.Size(45, 13);
            this.labelDeviceFunctionPlatform.TabIndex = 3;
            this.labelDeviceFunctionPlatform.Text = "Platform";
            // 
            // ControlTestEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBoxDeviceFunction);
            this.Controls.Add(this.groupBoxCommunication);
            this.Controls.Add(this.groupBoxOperatingSystem);
            this.Controls.Add(this.groupBoxHostApplication);
            this.Name = "ControlTestEnvironment";
            this.Size = new System.Drawing.Size(553, 324);
            this.groupBoxOperatingSystem.ResumeLayout(false);
            this.groupBoxOperatingSystem.PerformLayout();
            this.groupBoxHostApplication.ResumeLayout(false);
            this.groupBoxHostApplication.PerformLayout();
            this.groupBoxCommunication.ResumeLayout(false);
            this.groupBoxCommunication.PerformLayout();
            this.groupBoxDeviceFunction.ResumeLayout(false);
            this.groupBoxDeviceFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxOperatingSystem;
        private ComboBox comboBoxOperatingSystemName;
        private ComboBox comboBoxOperatingSystemBitVersion;
        private Label labelOperatingSystemName;
        private Label labelOperatingSystemBitVersion;
        private GroupBox groupBoxHostApplication;
        private ComboBox comboBoxHostApplicationNameVersion;
        private Label labelHostApplicationType;
        private ComboBox comboBoxHostApplicationType;
        private Label labelHostApplicationNameVersion;
        private GroupBox groupBoxCommunication;
        private ComboBox comboBoxCommunicationDeviceType;
        private ComboBox comboBoxCommunicationProtocol;
        private Label labelCommunicationDeviceType;
        private Label labelCommunicationProtocol;
        private GroupBox groupBoxDeviceFunction;
        private ComboBox comboBoxDeviceFunctionPlatform;
        private Label labelDeviceFunctionPlatform;
        private ComboBox comboBoxDeviceFunctionPackage;
        private Label labelDeviceFunctionPackage;

    }
}
