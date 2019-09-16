using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Project;

namespace EndressHauser.DTMstudioTest
{
    class TestSuiteNode : ReferenceContainerNode
    {
        private string _title;

        public TestSuiteNode(ProjectNode root, string title) : base(root)
        {
            _title = title;
        }

        public override string Caption
        {
            get
            {
                string caption = _title;
                return caption;
            }
        }
    }
}
