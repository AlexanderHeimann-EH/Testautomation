using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReviewBoardVsx.UI
{
    public partial class FormProgress : Form
    {
        public object Result { get; protected set; }
        public Exception Error { get; protected set; }

        private readonly BackgroundWorker backgroundWorker;

        public FormProgress(string title, string label, BackgroundWorker backgroundWorker)
        {
            InitializeComponent();

            this.Text = title;
            labelProgress.Text = label;

            if (backgroundWorker != null)
            {
                backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            }
            this.backgroundWorker = backgroundWorker;
        }

        private void FormProgress_Resize(object sender, EventArgs e)
        {
            buttonCancel.Left = (this.ClientSize.Width - buttonCancel.Width) / 2;
        }

        private void FormSubmitProgress_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (backgroundWorker != null && !backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void FormSubmitProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
            {
                if (backgroundWorker != null)
                {
                    lock (backgroundWorker)
                    {
                        if (backgroundWorker.IsBusy)
                        {
                            Cancel();

                            // Cancel this close & let the background worker close the form later
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            buttonCancel.Enabled = false;
            DialogResult = DialogResult.Cancel;

            bool pending = false;
            if (backgroundWorker != null)
            {
                lock (backgroundWorker)
                {
                    if (backgroundWorker.WorkerSupportsCancellation && backgroundWorker.IsBusy)
                    {
                        labelProgress.Text = "Canceling...";
                        backgroundWorker.CancelAsync();
                        pending = true;
                    }
                }
            }

            if (!pending)
            {
                Close();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelProgress.Text = e.UserState as string;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lock (backgroundWorker)
            {
                //
                // Reference:
                //  http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker.runworkercompleted.aspx
                //
                //  "Your RunWorkerCompleted event handler should always check the 
                //  AsyncCompletedEventArgs.Error and AsyncCompletedEventArgs.Cancelled
                //  properties before accessing the RunWorkerCompletedEventArgs.Result property.
                //  If an exception was raised or if the operation was canceled, accessing the
                //  RunWorkerCompletedEventArgs.Result property raises an exception."
                //
                // See also:
                //  http://www.developerdotstar.com/community/node/671
                //

                DialogResult = DialogResult.Cancel;
                Error = null;
                Result = null;

                if (e.Error != null)
                {
                    Error = e.Error;
                }
                else
                {
                    if (!e.Cancelled)
                    {
                        Result = e.Result;
                        DialogResult = DialogResult.OK;
                    }
                }

                Close();
            }
        }
    }
}
