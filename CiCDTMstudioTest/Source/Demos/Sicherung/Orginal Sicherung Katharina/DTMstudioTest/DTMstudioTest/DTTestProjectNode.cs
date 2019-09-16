using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Build.Evaluation;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Shell.Interop;

namespace EndressHauser.DTMstudioTest
{
    class DTTestProjectNode : ProjectNode
    {private DTMstudioTestPackage package;

    public DTTestProjectNode(DTMstudioTestPackage package)
        {
            this.package = package;
        }
        public override Guid ProjectGuid
        {
            get { return GuidList.guidDTTestProjectFactory; }
        }
        public override string ProjectType
        {
            get { return "DTTestProjectType"; }
        }

        public override void AddFileFromTemplate(
            string source, string target)
        {
            this.FileTemplateProcessor.UntokenFile(source, target);
            this.FileTemplateProcessor.Reset();
        }


        /// <summary>
        /// Loads reference items from the project file into the hierarchy.
        /// </summary>
        protected internal override void ProcessReferences()
        {
            base.ProcessReferences();
            IEnumerable<ProjectItem> references = ProjectMgr.BuildProject.GetItems("TestSuite");

            foreach (ProjectItem item in references)
            {
                var element = new ProjectElement(ProjectMgr, item, false);

                string title = element.GetMetadata("Title");
                TestSuiteNode testSuiteNode = new TestSuiteNode(this, title);
                AddChild(testSuiteNode);

                IEnumerable<ProjectItem> testcases = ProjectMgr.BuildProject.GetItems("TestCase");

                foreach (ProjectItem testcase in testcases)
                {
                    var testcaseElement = new ProjectElement(ProjectMgr, testcase, false);

                    string testsuite = testcaseElement.GetMetadata("TestSuite");
                    if (testsuite == element.Item.EvaluatedInclude)
                    {
                        string TestCaseNodetitle = testcaseElement.GetMetadata("Title");
                        TestCaseNode testCaseNode = new TestCaseNode(this, TestCaseNodetitle);
                        testSuiteNode.AddChild(testCaseNode);
                    }
                }
            }
        }

        /// <summary>
        /// Displays the context menu. Redirects the call of a reference container node context menu.
        /// </summary>
        /// <param name="selectedNodes">list of selected nodes.</param>
        /// <param name="pointerToVariant">contains the location (x,y) at which to show the menu.</param>
        protected override int DisplayContextMenu(IList<HierarchyNode> selectedNodes, IntPtr pointerToVariant)
        {
            int retValue; // return value

            int idmxStoredMenu = 0;
            var menuGuid = VsMenus.guidSHLMainMenu;

            if (selectedNodes == null || selectedNodes.Count == 0 || pointerToVariant == IntPtr.Zero)
            {
                retValue = 0;
            }
            else
            {
                foreach (HierarchyNode node in selectedNodes)
                {
                    // We check here whether we have a multiple selection of
                    // nodes of differing type.
                    if (idmxStoredMenu == 0)
                    {
                        // First time through or single node case
                        idmxStoredMenu = node.MenuCommandId;
                    }
                    else if (idmxStoredMenu != node.MenuCommandId)
                    {
                        idmxStoredMenu = VsMenus.IDM_VS_CTXT_NOCOMMANDS;
                    }
                }

                if (idmxStoredMenu == PkgCmdIDList.TestCaseContextMenu)
                {
                    if (selectedNodes.Count > 1)
                    {
                        // special context menus do not make sense if multiple nodes are selected
                        idmxStoredMenu = VsMenus.IDM_VS_CTXT_XPROJ_MULTIITEM;
                    }
                    else // one single test case node is selected
                    {
                        // CoDIA Studio specific context menus need a special GUID
                        menuGuid = GuidList.guidDTMstudioTestCmdSet;

                        // store selected nod in the package
                        package.SelectedNode = selectedNodes[0];
                    }
                }

                object variant = Marshal.GetObjectForNativeVariant(pointerToVariant);
                var pointsAsUint = (UInt32)variant;
                var x = (short)(pointsAsUint & 0x0000ffff);
                var y = (short)((pointsAsUint & 0xffff0000) / 0x10000);


                var points = new POINTS { x = x, y = y };

                retValue = ShowContextMenu(idmxStoredMenu, menuGuid, points);
            }

            return retValue;
        }
    }
}
