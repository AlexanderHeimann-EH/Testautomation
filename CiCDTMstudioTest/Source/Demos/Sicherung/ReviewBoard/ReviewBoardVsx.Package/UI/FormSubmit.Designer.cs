namespace ReviewBoardVsx.UI
{
    partial class FormSubmit
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubmit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPaths = new ReviewBoardVsx.UI.SubmitListView();
            this.labelReviewId = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboReviewIds = new System.Windows.Forms.ComboBox();
            this.buttonClearReviewIds = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listPaths);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.MinimumSize = new System.Drawing.Size(255, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Changes made:";
            // 
            // listPaths
            // 
            this.listPaths.AllowColumnReorder = true;
            this.listPaths.CheckBoxes = true;
            this.listPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPaths.HideSelection = false;
            this.listPaths.Location = new System.Drawing.Point(3, 16);
            this.listPaths.MinimumSize = new System.Drawing.Size(245, 90);
            this.listPaths.Name = "listPaths";
            this.listPaths.ShowSelectAllCheckBox = true;
            this.listPaths.Size = new System.Drawing.Size(578, 200);
            this.listPaths.TabIndex = 0;
            this.listPaths.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listPaths_ItemChecked);
            // 
            // labelReviewId
            // 
            this.labelReviewId.AutoSize = true;
            this.labelReviewId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReviewId.Location = new System.Drawing.Point(3, 0);
            this.labelReviewId.Name = "labelReviewId";
            this.labelReviewId.Size = new System.Drawing.Size(56, 29);
            this.labelReviewId.TabIndex = 0;
            this.labelReviewId.Text = "Review #:";
            this.labelReviewId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelReviewId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboReviewIds, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClearReviewIds, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboReviewIds
            // 
            this.comboReviewIds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboReviewIds.Location = new System.Drawing.Point(65, 3);
            this.comboReviewIds.MaxLength = 128;
            this.comboReviewIds.Name = "comboReviewIds";
            this.comboReviewIds.Size = new System.Drawing.Size(435, 21);
            this.comboReviewIds.TabIndex = 1;
            this.comboReviewIds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboReviewIds_MouseClick);
            this.comboReviewIds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboReviewIds_KeyDown);
            this.comboReviewIds.TextUpdate += new System.EventHandler(this.comboReviewIds_TextUpdate);
            this.comboReviewIds.TextChanged += new System.EventHandler(this.comboReviewIds_TextChanged);
            // 
            // buttonClearReviewIds
            // 
            this.buttonClearReviewIds.Location = new System.Drawing.Point(506, 3);
            this.buttonClearReviewIds.Name = "buttonClearReviewIds";
            this.buttonClearReviewIds.Size = new System.Drawing.Size(75, 23);
            this.buttonClearReviewIds.TabIndex = 2;
            this.buttonClearReviewIds.Text = "Clear";
            this.buttonClearReviewIds.UseVisualStyleBackColor = true;
            this.buttonClearReviewIds.Click += new System.EventHandler(this.buttonClearReviewIds_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonOk, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 274);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 32);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(506, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOk.Location = new System.Drawing.Point(425, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 26);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelServer.Location = new System.Drawing.Point(3, 0);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(41, 26);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "Server:";
            this.labelServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxServer
            // 
            this.textBoxServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReviewBoardVsx.UI.Properties.Settings.Default, "rbServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxServer.Enabled = false;
            this.textBoxServer.Location = new System.Drawing.Point(50, 3);
            this.textBoxServer.MaxLength = 128;
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(193, 20);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.Text = global::ReviewBoardVsx.UI.Properties.Settings.Default.rbServer;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.textBoxServer, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelServer, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUsername, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxPassword, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelUsername, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelPassword, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 248);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(584, 26);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReviewBoardVsx.UI.Properties.Settings.Default, "rbUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxUsername.Location = new System.Drawing.Point(313, 3);
            this.textBoxUsername.MaxLength = 64;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 3;
            this.textBoxUsername.Text = global::ReviewBoardVsx.UI.Properties.Settings.Default.rbUsername;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.buttonOk_UpdateEnable);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReviewBoardVsx.UI.Properties.Settings.Default, "rbPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPassword.Location = new System.Drawing.Point(481, 3);
            this.textBoxPassword.MaxLength = 64;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.Text = global::ReviewBoardVsx.UI.Properties.Settings.Default.rbPassword;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.buttonOk_UpdateEnable);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Location = new System.Drawing.Point(249, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 26);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username:";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Location = new System.Drawing.Point(419, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 26);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSubmit
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "FormSubmit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReviewBoard";
            this.Load += new System.EventHandler(this.FormSubmit_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSubmit_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboReviewIds;
        private SubmitListView listPaths;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelReviewId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClearReviewIds;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label2;

    }
}