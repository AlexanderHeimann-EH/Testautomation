using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Shell.Interop;

namespace EndressHauser.DTMstudioTest
{
    class TestCaseNode : ReferenceContainerNode
    {
        private string _title;
        private bool _enabled;
        
        public TestCaseNode(ProjectNode root, string title) : base(root)
        {
            _title = title;
            _enabled = false;
        }

        public override string Caption
        {
            get
            {
                string caption = _title;
                if (Enabled)
                {
                    caption += " (Enabled)";
                }
                else
                {
                    caption += " (Disabled)";
                }
                return caption;
            }
        }

        /// <summary>
        /// Returns command Id for context menu
        /// </summary>
        public override int MenuCommandId
        {
            get
            {
                return PkgCmdIDList.TestCaseContextMenu;
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_Caption, 0);
            }
        }
    }
}
