namespace EH.PCPS.TestAutomation.Common.Configurator.GUI
{
    partial class ControlTestFramework
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
            this.textBoxPathToConfiguration = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogConfiguration = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFolderBrowserConfiguration = new System.Windows.Forms.Button();
            this.labelPathToConfiguration = new System.Windows.Forms.Label();
            this.labelPathToAssemblies = new System.Windows.Forms.Label();
            this.textBoxPathToAssemblies = new System.Windows.Forms.TextBox();
            this.buttonFolderBrowserAssemblies = new System.Windows.Forms.Button();
            this.groupBoxPathSelection = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialogAssemblies = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxPathSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPathToConfiguration
            // 
            this.textBoxPathToConfiguration.AccessibleName = "textBoxPathToConfiguration";
            this.textBoxPathToConfiguration.Location = new System.Drawing.Point(136, 21);
            this.textBoxPathToConfiguration.Name = "textBoxPathToConfiguration";
            this.textBoxPathToConfiguration.ReadOnly = true;
            this.textBoxPathToConfiguration.Size = new System.Drawing.Size(370, 20);
            this.textBoxPathToConfiguration.TabIndex = 0;
            this.textBoxPathToConfiguration.Text = "c:\\";
            // 
            // buttonFolderBrowserConfiguration
            // 
            this.buttonFolderBrowserConfiguration.AccessibleName = "buttonFolderBrowserConfiguration";
            this.buttonFolderBrowserConfiguration.Location = new System.Drawing.Point(512, 19);
            this.buttonFolderBrowserConfiguration.Name = "buttonFolderBrowserConfiguration";
            this.buttonFolderBrowserConfiguration.Size = new System.Drawing.Size(26, 23);
            this.buttonFolderBrowserConfiguration.TabIndex = 1;
            this.buttonFolderBrowserConfiguration.Text = "...";
            this.buttonFolderBrowserConfiguration.UseVisualStyleBackColor = true;
            this.buttonFolderBrowserConfiguration.Click += new System.EventHandler(this.buttonFolderBrowserConfiguration_Click);
            // 
            // labelPathToConfiguration
            // 
            this.labelPathToConfiguration.AccessibleName = "labelPathToConfiguration";
            this.labelPathToConfiguration.AutoSize = true;
            this.labelPathToConfiguration.Location = new System.Drawing.Point(6, 24);
            this.labelPathToConfiguration.Name = "labelPathToConfiguration";
            this.labelPathToConfiguration.Size = new System.Drawing.Size(124, 13);
            this.labelPathToConfiguration.TabIndex = 2;
            this.labelPathToConfiguration.Text = "Path to Configuration.xml";
            // 
            // labelPathToAssemblies
            // 
            this.labelPathToAssemblies.AccessibleName = "labelPathToAssemblies";
            this.labelPathToAssemblies.AutoSize = true;
            this.labelPathToAssemblies.Location = new System.Drawing.Point(6, 53);
            this.labelPathToAssemblies.Name = "labelPathToAssemblies";
            this.labelPathToAssemblies.Size = new System.Drawing.Size(96, 13);
            this.labelPathToAssemblies.TabIndex = 3;
            this.labelPathToAssemblies.Text = "Path to Assemblies";
            // 
            // textBoxPathToAssemblies
            // 
            this.textBoxPathToAssemblies.AccessibleName = "textBoxPathToAssemblies";
            this.textBoxPathToAssemblies.Location = new System.Drawing.Point(136, 50);
            this.textBoxPathToAssemblies.Name = "textBoxPathToAssemblies";
            this.textBoxPathToAssemblies.ReadOnly = true;
            this.textBoxPathToAssemblies.Size = new System.Drawing.Size(370, 20);
            this.textBoxPathToAssemblies.TabIndex = 2;
            // 
            // buttonFolderBrowserAssemblies
            // 
            this.buttonFolderBrowserAssemblies.AccessibleName = "buttonFolderBrowserAssemblies";
            this.buttonFolderBrowserAssemblies.Location = new System.Drawing.Point(512, 48);
            this.buttonFolderBrowserAssemblies.Name = "buttonFolderBrowserAssemblies";
            this.buttonFolderBrowserAssemblies.Size = new System.Drawing.Size(26, 23);
            this.buttonFolderBrowserAssemblies.TabIndex = 3;
            this.buttonFolderBrowserAssemblies.Text = "...";
            this.buttonFolderBrowserAssemblies.UseVisualStyleBackColor = true;
            this.buttonFolderBrowserAssemblies.Click += new System.EventHandler(this.buttonFolderBrowserAssemblies_Click);
            // 
            // groupBoxPathSelection
            // 
            this.groupBoxPathSelection.AccessibleName = "groupBoxPathSelection";
            this.groupBoxPathSelection.Controls.Add(this.labelPathToConfiguration);
            this.groupBoxPathSelection.Controls.Add(this.buttonFolderBrowserAssemblies);
            this.groupBoxPathSelection.Controls.Add(this.textBoxPathToConfiguration);
            this.groupBoxPathSelection.Controls.Add(this.textBoxPathToAssemblies);
            this.groupBoxPathSelection.Controls.Add(this.buttonFolderBrowserConfiguration);
            this.groupBoxPathSelection.Controls.Add(this.labelPathToAssemblies);
            this.groupBoxPathSelection.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPathSelection.Name = "groupBoxPathSelection";
            this.groupBoxPathSelection.Size = new System.Drawing.Size(547, 81);
            this.groupBoxPathSelection.TabIndex = 6;
            this.groupBoxPathSelection.TabStop = false;
            this.groupBoxPathSelection.Text = "Path Selection";
            // 
            // ControlTestFramework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBoxPathSelection);
            this.Name = "ControlTestFramework";
            this.Size = new System.Drawing.Size(553, 242);
            this.groupBoxPathSelection.ResumeLayout(false);
            this.groupBoxPathSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPathToConfiguration;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogConfiguration;
        private System.Windows.Forms.Button buttonFolderBrowserConfiguration;
        private System.Windows.Forms.Label labelPathToConfiguration;
        private System.Windows.Forms.Label labelPathToAssemblies;
        private System.Windows.Forms.TextBox textBoxPathToAssemblies;
        private System.Windows.Forms.Button buttonFolderBrowserAssemblies;
        private System.Windows.Forms.GroupBox groupBoxPathSelection;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogAssemblies;
    }
}
