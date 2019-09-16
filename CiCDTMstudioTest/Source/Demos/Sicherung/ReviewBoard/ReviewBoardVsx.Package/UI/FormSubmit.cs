using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using ReviewBoardVsx.Package;
using ReviewBoardVsx.Package.Tracker;

namespace ReviewBoardVsx.UI
{
    /// <summary>
    /// TODO:(pv) Handle ability to refresh solution changes if item(s) are edited outside of VS
    /// </summary>
    public partial class FormSubmit : Form
    {
        public PostReview.ReviewInfo Review { get; protected set; }

        private MySolutionTracker.SubmitItemMap.ValueCollection solutionChanges;

        public FormSubmit(MySolutionTracker.SubmitItemMap.ValueCollection solutionChanges)
        {
            InitializeComponent();

            if (solutionChanges == null)
            {
                throw new ArgumentNullException("solutionChanges");
            }

            this.solutionChanges = solutionChanges;
        }

        class ListViewItemComparer : IComparer
        {
            private int column;
            private SortOrder order;

            public ListViewItemComparer(int column)
                : this(column, SortOrder.Ascending)
            {
            }

            public ListViewItemComparer(int column, SortOrder order)
            {
                this.column = column;
                this.order = order;
            }

            public int Compare(object a, object b) 
            {
                int returnVal= -1;

                string textA = ((ListViewItem)a).SubItems[column].Text;
                string textB = ((ListViewItem)b).SubItems[column].Text;

                switch (column)
                {
                    case 0: // Path
                        returnVal = String.Compare(textA, textB);
                        break;
                    case 1: // Project
                        // TODO:(pv) Sort by Solution, then Solution Items, then Project(s)...
                        returnVal = String.Compare(textA, textB);
                        break;
                    case 2: // Change
                        PostReview.ChangeType changeA = (PostReview.ChangeType)Enum.Parse(typeof(PostReview.ChangeType), textA);
                        PostReview.ChangeType changeB = (PostReview.ChangeType)Enum.Parse(typeof(PostReview.ChangeType), textB);
                        returnVal = changeA.CompareTo(changeB);
                        break;
                    case 3: // Full Path
                        returnVal = String.Compare(textA, textB);
                        break;
                }

                // Determine whether the sort order is descending.
                if (order == SortOrder.Descending)
                {
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
                }

                return returnVal;
            }
        }

        private void FormSubmit_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Point location = Properties.Settings.Default.Location;
            Size size = Properties.Settings.Default.Size;
            if (!location.IsEmpty && !size.IsEmpty)
            {
                Rectangle rect = new Rectangle(location, size);
                if (MyUtils.IsOnScreen(rect))
                    DesktopBounds = rect;
            }

            // Enabled by listPaths_ItemChecked validation
            buttonOk.Enabled = false;

            /*
            listPaths.Groups.Clear();
            foreach (string changeType in Enum.GetNames(typeof(PostReview.ChangeType)))
            {
                listPaths.Groups.Add(new ListViewGroup(changeType, changeType));
            }
            listPaths.ListViewItemSorter = new ListViewItemComparer(listPaths.Columns["Change"].Index);
            */

            InitializeReviewIds(false);

            InitializeSolutionChanges();
        }

        private void FormSubmit_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the post-review was successful, save the review info to the list for next time.
            if (DialogResult == DialogResult.OK)
            {
                PostReview.ReviewInfo reviewInfo = Review;
                if (reviewInfo != null)
                {
                    // Always insert new items just below the "<New>" entry
                    if (!comboReviewIds.Items.Contains(reviewInfo))
                    {
                        comboReviewIds.Items.Insert(1, Review);
                        Properties.Settings.Default.reviewIdHistory = new ArrayList(comboReviewIds.Items);
                    }
                }
            }
            else
            {
                Review = null;
            }

            Properties.Settings.Default.Location = this.DesktopBounds.Location;
            Properties.Settings.Default.Size = this.DesktopBounds.Size;
            Properties.Settings.Default.Save();
        }

        private void buttonClearReviewIds_Click(object sender, EventArgs e)
        {
            InitializeReviewIds(true);
        }

        private void listPaths_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            buttonOk_UpdateEnable(sender, e);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // DoPostReview will call FormSubmit_FormClosing after PostReview has finished
            DoPostReview(this);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOk_UpdateEnable(object sender, EventArgs e)
        {
            buttonOk.Enabled = listPaths.CheckedItems.Count > 0;
            buttonOk.Enabled &= !String.IsNullOrEmpty(textBoxUsername.Text);
            buttonOk.Enabled &= !String.IsNullOrEmpty(textBoxPassword.Text);
        }

        /// <summary>
        /// The 0th item is special; it is a hard coded string, NOT a ReviewInfo type.
        /// All the other items should be a ReviewInfo type.
        /// </summary>
        /// <param name="clear"></param>
        private void InitializeReviewIds(bool clear)
        {
            ArrayList values = Properties.Settings.Default.reviewIdHistory;
            if (values == null)
            {
                values = new ArrayList();
            }

            if (values.Count == 0 || clear)
            {
                values.Clear();
                values.Add(Resources.ReviewIdNew);
                Properties.Settings.Default.reviewIdHistory = new ArrayList(values);
            }

            object[] items = values.ToArray();

            comboReviewIds.BeginUpdate();
            comboReviewIds.Items.Clear();
            comboReviewIds.Items.AddRange(items);
            // TODO:(pv) Remember last selected review id/index?
            if (comboReviewIds.Items.Count > 0)
                comboReviewIds.SelectedIndex = 0;
            comboReviewIds.EndUpdate();
        }

        private void InitializeSolutionChanges()
        {
            string commonRoot = MyUtils.GetCommonRoot(new List<string>(solutionChanges.Select(p => p.FullPath))) + '\\';
            commonRoot = Regex.Escape(commonRoot);

            string pathFull;
            string pathShort;
            string changeType;
            ListViewItem item;
            ListViewItem.ListViewSubItem subitem;

            IComparer sorter = listPaths.ListViewItemSorter;
            listPaths.ListViewItemSorter = null;

            listPaths.BeginUpdate();

            listPaths.Items.Clear();
            foreach (PostReview.SubmitItem solutionChange in solutionChanges)
            {
                pathFull = solutionChange.FullPath;
                pathShort = Regex.Replace(pathFull, commonRoot, "", RegexOptions.IgnoreCase);
                changeType = solutionChange.ChangeType.ToString();

                item = listPaths.Items.Add(pathShort);

                // TODO:(pv) Pull ReviewableAttribute from each changeType value and sort reviewable above non-reviewable
                //item.Group = listPaths.Groups[changeType];

                subitem = item.SubItems.Add(solutionChange.Project);
                subitem.Name = "Project";

                subitem = item.SubItems.Add(changeType);
                subitem.Name = "Change";

                subitem = item.SubItems.Add(pathFull);
                subitem.Name = "FullPath";
            }

            ColumnHeaderAutoResizeStyle resizeStyle = (solutionChanges.Count == 0) ? ColumnHeaderAutoResizeStyle.HeaderSize : ColumnHeaderAutoResizeStyle.ColumnContent;
            foreach (ColumnHeader columnHeader in listPaths.Columns)
            {
                columnHeader.AutoResize(resizeStyle);
            }

            listPaths.ListViewItemSorter = sorter;
            listPaths.Sort();

            listPaths.EndUpdate();
        }

        #region private property getters

        private int GetSelectedReviewId()
        {
            int reviewId;
            switch (comboReviewIds.SelectedIndex)
            {
                case -1:
                    // Pre-validated comboReviewIds_KeyDown in and comboReviewIds_TextUpdate
                    // Should never throw an exception
                    reviewId = int.Parse(comboReviewIds.Text);
                    break;
                case 0:
                    reviewId = 0;
                    break;
                default:
                    // Should never throw InvalidCastException
                    PostReview.ReviewInfo reviewInfo = (PostReview.ReviewInfo)comboReviewIds.SelectedItem;
                    reviewId = reviewInfo.Id;
                    break;
            }
            return reviewId;
        }

        private List<string> GetCheckedFullPaths()
        {
            ListView.CheckedListViewItemCollection checkedItems = listPaths.CheckedItems;
            List<string> checkedFullPaths = new List<string>(checkedItems.Count);
            foreach (ListViewItem item in checkedItems)
            {
                checkedFullPaths.Add(item.SubItems["FullPath"].Text);
            }
            return checkedFullPaths;
        }

        #endregion private property getters

        #region comboReviewIds keyboard/mouse input handlers

        private void comboReviewIds_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboReviewIds.SelectedIndex == 0)
            {
                comboReviewIds.SelectAll();
            }
        }

        /// <summary>
        /// Very ugly nazi function that has the audacity to try to control the keys that are allowed to be pressed.
        /// I don't like doing this, but I couldn't find any better way to prevent users from entering invalid data.
        /// The road to hell is paved with good intentions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboReviewIds_KeyDown(object sender, KeyEventArgs e)
        {
            bool allow = true;

            // The spirit of this method is to have comboReviewIds accept only keys '0'-'9'.
            // In reality this is too strict; we allow cut/copy/paste [and perhaps a few others if needed].

            if (comboReviewIds.SelectedIndex == -1 || comboReviewIds.SelectedIndex == 0)
            {
                // Both free-hand-edit-mode and hard-coded "<New>" allow 0-9 or cut/copy/paste
                allow = (MyUtils.IsDigit((Char)e.KeyValue)) || MyUtils.IsCutCopyPaste(e.KeyValue, e.Modifiers);

                switch ((Keys)e.KeyValue)
                {
                    case Keys.NumLock:
                        //case Keys.Up:
                        //case Keys.Down:
                        //case Keys.PageUp:
                        //case Keys.PageDown:
                        // TODO:(pv) Allow up/down/pgup/pgdn to pull up dropdown and navigate items...
                        allow = true;
                        break;
                }

                if (comboReviewIds.SelectedIndex == -1)
                {
                    // free-hand-edit-mode adds allowing horizontal cursor movement keys
                    switch ((Keys)e.KeyValue)
                    {
                        case Keys.Back:
                        case Keys.Insert:
                        case Keys.Home:
                        case Keys.Delete:
                        case Keys.End:
                        case Keys.Left:
                        case Keys.Right:
                            allow = true;
                            break;
                    }
                }

                e.SuppressKeyPress = !allow;
            }

            if (!allow)
            {
                // Play a rejection sound if they pressed a printable character without pressing CTRL
                if (comboReviewIds.SelectedIndex == 0 || !Char.IsControl((Char)e.KeyValue) && !e.Control)
                {
                    string path = MyUtils.PathCombine(Environment.SystemDirectory, "..", "Media", "Windows Ding.wav");
                    if (File.Exists(path))
                    {
                        // TODO:(pv) Uh, why can I not hear this play?
                        new SoundPlayer(path).Play();
                    }
                }
            }
        }

        private void comboReviewIds_TextUpdate(object sender, EventArgs e)
        {
            if (comboReviewIds.SelectedIndex == -1)
            {
                string text = comboReviewIds.Text;
                if (!String.IsNullOrEmpty(text))
                {
                    try
                    {
                        // Validate free-hand-edit-mode entered review # as integer
                        int.Parse(text);
                    }
                    catch
                    {
                        MessageBox.Show(this, "Invalid number entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboReviewIds.Text = text.Substring(0, text.Length - 1);
                        comboReviewIds.SelectAll();
                    }
                }
            }
        }

        private void comboReviewIds_TextChanged(object sender, EventArgs e)
        {
            if (comboReviewIds.SelectedIndex == -1)
            {
                if (String.IsNullOrEmpty(comboReviewIds.Text))
                {
                    // Empty string; go back to selecting "<New>" item (always index == 0)

                    // BUGBUG:(pv) Toggling DroppedDown is the only way I can get the SelectedIndex to stick...
                    comboReviewIds.DroppedDown = true;
                    comboReviewIds.SelectedIndex = 0;
                    comboReviewIds.DroppedDown = false;
                }
            }
        }

        #endregion comboReviewIds keyboard/mouse input handlers

        #region DoPostReview

        protected static void DoPostReview(FormSubmit form)
        {
            int reviewId = form.GetSelectedReviewId();
            List<string> changes = form.GetCheckedFullPaths();

            BackgroundWorker backgroundPostReview = new BackgroundWorker();
            backgroundPostReview.WorkerReportsProgress = true;
            backgroundPostReview.WorkerSupportsCancellation = true;
            backgroundPostReview.DoWork += (s, e) =>
            {
                string server = form.textBoxServer.Text;
                string username = form.textBoxUsername.Text;
                string password = form.textBoxPassword.Text;

                string submitAs = null;
                bool publish = false;
                PostReview.PostReviewOpen open = PostReview.PostReviewOpen.Internal;
                bool debug = false;

                e.Result = PostReview.Submit(backgroundPostReview, server, username, password, submitAs, reviewId, changes, publish, open, debug);

                if (backgroundPostReview.CancellationPending)
                {
                    e.Cancel = true;
                }
            };

            string label = String.Format("Uploading Code Review #{0} ({1} files)...", reviewId, changes.Count);

            FormProgress progress = new FormProgress("Uploading...", label, backgroundPostReview);

            progress.FormClosed += (s, e) =>
            {
                bool close = true;

                PostReview.PostReviewException pre = (PostReview.PostReviewException)progress.Error;
                if (pre != null)
                {
                    StringBuilder message = new StringBuilder();
                    message.AppendLine(pre.ToString());
                    message.AppendLine();
                    message.AppendLine("Click \"Retry\" to return to dialog, or \"Cancel\" to return to Visual Studio.");

                    if (MessageBox.Show(form, message.ToString(), "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        close = false;
                    }
                }

                if (close)
                {
                    form.Review = progress.Result as PostReview.ReviewInfo;
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                }
            };

            progress.ShowDialog(form);
        }

        #endregion DoPostReview
    }
}
