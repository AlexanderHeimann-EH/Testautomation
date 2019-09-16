// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorTextBox.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The editor text box.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Security.Permissions;
    using System.Windows.Forms;

    /// <summary>
    /// The editor text box.
    /// </summary>
    public partial class EditorTextBox : RichTextBox
    {
        #region Fields

        /// <summary>
        /// The m_ filter mouse click messages.
        /// </summary>
        private bool m_FilterMouseClickMessages;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorTextBox"/> class.
        /// </summary>
        public EditorTextBox()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether filter mouse click messages.
        /// </summary>
        public bool FilterMouseClickMessages
        {
            get
            {
                return this.m_FilterMouseClickMessages;
            }

            set
            {
                this.m_FilterMouseClickMessages = value;
            }
        }

        #endregion

        // Override WndProc so that we can ignore the mouse clicks when macro recording
        #region Methods

        /// <summary>
        /// The wnd proc.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_LBUTTONDOWN:
                case NativeMethods.WM_RBUTTONDOWN:
                case NativeMethods.WM_MBUTTONDOWN:
                case NativeMethods.WM_LBUTTONDBLCLK:
                    if (this.m_FilterMouseClickMessages)
                    {
                        this.Focus();
                        return;
                    }

                    break;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// The set cursor.
        /// </summary>
        /// <param name="cursorNo">
        /// The cursor no.
        /// </param>
        private void SetCursor(bool cursorNo)
        {
            this.Cursor = cursorNo ? Cursors.No : Cursors.Default;
        }

        /// <summary>
        /// The rich text box ctrl_ mouse leave.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void richTextBoxCtrl_MouseLeave(object sender, EventArgs e)
        {
            if (this.m_FilterMouseClickMessages)
            {
                this.SetCursor(!this.m_FilterMouseClickMessages);
            }
        }

        /// <summary>
        /// The rich text box ctrl_ mouse recording.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void richTextBoxCtrl_MouseRecording(object sender, EventArgs e)
        {
            this.SetCursor(this.m_FilterMouseClickMessages);
        }

        #endregion
    }
}