// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfiguratorDialog.Designer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The configurator dialog.
// </summary> 
// -------------------------------------------------------------------------------------------------------------------- 

namespace EH.PCPS.TestAutomation.Common.Configurator.GUI 
{
    /// <summary>
    /// The configurator dialog.
    /// </summary>
    public partial class ConfiguratorDialog 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The tab control configuration dialog.
        /// </summary>
        private System.Windows.Forms.TabControl tabControlConfigurationDialog;

        /// <summary>
        /// The tab page test environment.
        /// </summary>
        private System.Windows.Forms.TabPage tabPageTestEnvironment;

        /// <summary>
        /// The tab page test framework.
        /// </summary>
        private System.Windows.Forms.TabPage tabPageTestFramework;

        /// <summary>
        /// The tab page additional information.
        /// </summary>
        private System.Windows.Forms.TabPage tabPageAdditionalInformation;

        /// <summary>
        /// The button start.
        /// </summary>
        private System.Windows.Forms.Button buttonStart;

        /// <summary>
        /// The button apply.
        /// </summary>
        private System.Windows.Forms.Button buttonApply;

        /// <summary>
        /// The button cancel.
        /// </summary>
        private System.Windows.Forms.Button buttonCancel;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlConfigurationDialog = new System.Windows.Forms.TabControl();
            this.tabPageAdditionalInformation = new System.Windows.Forms.TabPage();
            this.tabPageTestEnvironment = new System.Windows.Forms.TabPage();
            this.tabPageTestFramework = new System.Windows.Forms.TabPage();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlConfigurationDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlConfigurationDialog
            // 
            this.tabControlConfigurationDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlConfigurationDialog.Controls.Add(this.tabPageAdditionalInformation);
            this.tabControlConfigurationDialog.Controls.Add(this.tabPageTestEnvironment);
            this.tabControlConfigurationDialog.Controls.Add(this.tabPageTestFramework);
            this.tabControlConfigurationDialog.Location = new System.Drawing.Point(12, 12);
            this.tabControlConfigurationDialog.Name = "tabControlConfigurationDialog";
            this.tabControlConfigurationDialog.SelectedIndex = 0;
            this.tabControlConfigurationDialog.Size = new System.Drawing.Size(561, 350);
            this.tabControlConfigurationDialog.TabIndex = 0;
            // 
            // tabPageAdditionalInformation
            // 
            this.tabPageAdditionalInformation.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAdditionalInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdditionalInformation.Name = "tabPageAdditionalInformation";
            this.tabPageAdditionalInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdditionalInformation.Size = new System.Drawing.Size(553, 324);
            this.tabPageAdditionalInformation.TabIndex = 2;
            this.tabPageAdditionalInformation.Text = "Additional Information";
            // 
            // tabPageTestEnvironment
            // 
            this.tabPageTestEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabPageTestEnvironment.Name = "tabPageTestEnvironment";
            this.tabPageTestEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTestEnvironment.Size = new System.Drawing.Size(553, 242);
            this.tabPageTestEnvironment.TabIndex = 0;
            this.tabPageTestEnvironment.Text = "TestEnvironment";
            this.tabPageTestEnvironment.UseVisualStyleBackColor = true;
            // 
            // tabPageTestFramework
            // 
            this.tabPageTestFramework.Location = new System.Drawing.Point(4, 22);
            this.tabPageTestFramework.Name = "tabPageTestFramework";
            this.tabPageTestFramework.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTestFramework.Size = new System.Drawing.Size(553, 242);
            this.tabPageTestFramework.TabIndex = 1;
            this.tabPageTestFramework.Text = "TestFramework";
            this.tabPageTestFramework.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonStart.Location = new System.Drawing.Point(332, 368);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(413, 368);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(494, 368);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // ConfiguratorDialog
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 399);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tabControlConfigurationDialog);
            this.Name = "ConfiguratorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfiguratorDialog";
            this.tabControlConfigurationDialog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}