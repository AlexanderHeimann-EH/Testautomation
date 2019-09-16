﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System.Collections.ObjectModel;
using System.Windows.Automation;
using EnvDTE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUtilities;
using TestUtilities.Python;
using TestUtilities.UI;

namespace PythonToolsUITests {
    [TestClass]
    public class ObjectBrowserTest {

        private class NodeInfo {
            public NodeInfo(string name, string description, string[] members = null) {
                Name = name;
                Description = description;
                Members = (members != null) ? new Collection<string>(members) : new Collection<string>();
            }

            public string Name { get; private set; }

            public string Description { get; private set; }

            public Collection<string> Members { get; private set; }
        }

        private static void AssertNodes(ObjectBrowser objectBrowser, params NodeInfo[] expectedNodes) {
            int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
            Assert.AreEqual(expectedNodes.Length, nodeCount, "Node count: " + nodeCount.ToString());

            for (int i = 0; i < expectedNodes.Length; ++i) {
                // Check node name
                string str = objectBrowser.TypeBrowserPane.Nodes[i].Value.Trim();
                Assert.AreEqual(expectedNodes[i].Name, str, "");

                objectBrowser.TypeBrowserPane.Nodes[i].Select();
                System.Threading.Thread.Sleep(1000);

                // Check detailed node description.
                str = objectBrowser.DetailPane.Value.Trim();
                Assert.AreEqual(expectedNodes[i].Description, str, "");

                // Check dependent nodes in member pane
                nodeCount = objectBrowser.TypeNavigatorPane.Nodes.Count;
                var expectedMembers = expectedNodes[i].Members;
                if (expectedMembers == null) {
                    Assert.AreEqual(0, nodeCount, "Node Count: " + nodeCount.ToString());
                } else {
                    Assert.AreEqual(expectedMembers.Count, nodeCount, "Node Count: " + nodeCount.ToString());
                    for (int j = 0; j < expectedMembers.Count; ++j) {
                        str = objectBrowser.TypeNavigatorPane.Nodes[j].Value.Trim();
                        Assert.AreEqual(expectedMembers[j], str, "");
                    }
                }
            }
        }

        [ClassInitialize]
        public static void DoDeployment(TestContext context) {
            AssertListener.Initialize();
            PythonTestData.Deploy();
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserBasicTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\Outlining.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(4, nodeCount, "Node count: " + nodeCount.ToString());

                AssertNodes(objectBrowser,
                    new NodeInfo("Outlining", "Outlining"),
                    new NodeInfo("BadForStatement.py", "BadForStatement.py"),
                    new NodeInfo("NestedFuncDef.py", "NestedFuncDef.py", new[] { "f()" }),
                    new NodeInfo("Program.py", "Program.py", new[] { "f()" }));

                app.Dte.Solution.Close(false);

                System.Threading.Thread.Sleep(1000);
                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserSearchTextTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\ObjectBrowser.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                objectBrowser.EnsureLoaded();

                // Initially, we should have only the top-level collapsed node for the project

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                // Now that it is expanded, we should also get a node for Program.py

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                // Sanity-check the starting view with all nodes expanded.

                var expectedNodesBeforeSearch = new[] {
                new NodeInfo("ObjectBrowser", "ObjectBrowser"),
                new NodeInfo("Program.py", "Program.py", new[] { "frob()" }),
                new NodeInfo("Oar", "class Oar", new[] { "oar(self)" }),
                new NodeInfo("Fob", "class Fob"),
                new NodeInfo("FobOarBaz", "class FobOarBaz", new[] { "frob(self)" }),
            };
                AssertNodes(objectBrowser, expectedNodesBeforeSearch);

                // Do the search and check results

                objectBrowser.SearchText.SetValue("oar");
                System.Threading.Thread.Sleep(1000);

                objectBrowser.SearchButton.Click();
                System.Threading.Thread.Sleep(1000);

                var expectedNodesAfterSearch = new[] {
                new NodeInfo("oar", "def oar(self)"),
                new NodeInfo("Oar", "class Oar", new[] { "oar(self)" }),
                new NodeInfo("FobOarBaz", "class FobOarBaz", new[] { "frob(self)" }),
            };
                AssertNodes(objectBrowser, expectedNodesAfterSearch);

                // Clear the search and check that we get back to the starting view.

                objectBrowser.ClearSearchButton.Click();
                System.Threading.Thread.Sleep(1000);

                AssertNodes(objectBrowser, expectedNodesBeforeSearch);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserExpandTypeBrowserTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\Inheritance.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                objectBrowser.EnsureLoaded();

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[0].Value;
                Assert.AreEqual("Inheritance", str, "");
                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node count: " + nodeCount.ToString());

                str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(5, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserCommentsTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\Inheritance.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("Program.py", str, "");
                objectBrowser.TypeBrowserPane.Nodes[1].Select();
                nodeCount = objectBrowser.TypeNavigatorPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node Count: " + nodeCount.ToString());
                str = objectBrowser.TypeNavigatorPane.Nodes[0].Value;
                Assert.AreEqual("members", str.Trim(), "");
                str = objectBrowser.TypeNavigatorPane.Nodes[1].Value;
                Assert.AreEqual("s", str.Trim(), "");
                str = objectBrowser.TypeNavigatorPane.Nodes[2].Value;
                Assert.AreEqual("t", str.Trim(), "");

                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(5, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[2].Select();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeNavigatorPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node Count: " + nodeCount.ToString());
                str = objectBrowser.TypeNavigatorPane.Nodes[0].Value;
                Assert.IsTrue(str.Trim().StartsWith("__init__(self"), str);
                str = objectBrowser.TypeNavigatorPane.Nodes[1].Value;
                Assert.AreEqual("tell(self)", str.Trim(), "");

                str = objectBrowser.DetailPane.Value;
                Assert.IsTrue(str.Trim().Contains("SchoolMember"), str);
                Assert.IsTrue(str.Trim().Contains("Represents any school member."), str);

                objectBrowser.TypeNavigatorPane.Nodes[1].Select();
                System.Threading.Thread.Sleep(1000);

                str = objectBrowser.DetailPane.Value;
                Assert.IsTrue(str.Trim().Contains("def tell(self)"), str);
                Assert.IsTrue(str.Trim().Contains("Tell my detail."), str);

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserInheritanceRelationshipTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\Inheritance.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(5, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[3].Select();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeNavigatorPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node Count: " + nodeCount.ToString());
                str = objectBrowser.TypeNavigatorPane.Nodes[0].Value;
                Assert.IsTrue(str.Trim().StartsWith("__init__(self"), str);
                str = objectBrowser.TypeNavigatorPane.Nodes[1].Value;
                Assert.AreEqual("tell(self)", str.Trim(), "");

                str = objectBrowser.DetailPane.Value;
                Assert.IsTrue(str.Trim().Contains("Student(SchoolMember)"), str);
                Assert.IsTrue(str.Trim().Contains("Represents a student."), str);

                objectBrowser.TypeNavigatorPane.Nodes[1].Select();
                System.Threading.Thread.Sleep(1000);

                str = objectBrowser.DetailPane.Value;
                Assert.IsTrue(str.Trim().Contains("def tell(self)"), str);

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserNavigationTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                objectBrowser.EnsureLoaded();

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[2].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[4].Select();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[4].DoubleClick();
                System.Threading.Thread.Sleep(1000);

                str = app.Dte.ActiveDocument.Name;
                Assert.AreEqual("Program.py", str, "");

                int lineNo = ((TextSelection)app.Dte.ActiveDocument.Selection).ActivePoint.Line;
                Assert.AreEqual(14, lineNo, "Line number: " + lineNo.ToString());

                app.OpenObjectBrowser();
                objectBrowser.TypeBrowserPane.Nodes[2].Select();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[2].DoubleClick();
                System.Threading.Thread.Sleep(1000);

                str = app.Dte.ActiveDocument.Name;
                Assert.AreEqual("MyModule.py", str, "");

                lineNo = ((TextSelection)app.Dte.ActiveDocument.Selection).ActivePoint.Line;
                Assert.AreEqual(1, lineNo, "Line number: " + lineNo.ToString());

                objectBrowser.TypeBrowserPane.Nodes[3].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserContextMenuBasicTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[2].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[1].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                Condition con = new PropertyCondition(
                                        AutomationElement.ClassNameProperty,
                                        "ContextMenu"
                                    );
                AutomationElement el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                Menu menu = new Menu(el);
                int itemCount = menu.Items.Count;
                Assert.AreEqual(7, itemCount, "Item count: " + itemCount.ToString());
                Assert.AreEqual("Copy", menu.Items[0].Value.Trim(), "");
                Assert.AreEqual("View Namespaces", menu.Items[1].Value.Trim(), "");
                Assert.AreEqual("View Containers", menu.Items[2].Value.Trim(), "");
                Assert.AreEqual("Sort Alphabetically", menu.Items[3].Value.Trim(), "");
                Assert.AreEqual("Sort By Object Type", menu.Items[4].Value.Trim(), "");
                Assert.AreEqual("Sort By Object Access", menu.Items[5].Value.Trim(), "");
                Assert.AreEqual("Group By Object Type", menu.Items[6].Value.Trim(), "");
                Keyboard.PressAndRelease(System.Windows.Input.Key.Escape);

                objectBrowser.TypeBrowserPane.Nodes[2].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                menu = new Menu(el);
                itemCount = menu.Items.Count;
                Assert.AreEqual(13, itemCount, "Item count: " + itemCount.ToString());
                Assert.AreEqual("Go To Definition", menu.Items[0].Value.Trim(), "");
                Assert.AreEqual("Go To Declaration", menu.Items[1].Value.Trim(), "");
                Assert.AreEqual("Go To Reference", menu.Items[2].Value.Trim(), "");
                Assert.AreEqual("Browse Definition", menu.Items[3].Value.Trim(), "");
                Assert.AreEqual("Find All References", menu.Items[4].Value.Trim(), "");
                Assert.AreEqual("Filter To Type", menu.Items[5].Value.Trim(), "");
                Assert.AreEqual("Copy", menu.Items[6].Value.Trim(), "");
                Assert.AreEqual("View Namespaces", menu.Items[7].Value.Trim(), "");
                Assert.AreEqual("View Containers", menu.Items[8].Value.Trim(), "");
                Assert.AreEqual("Sort Alphabetically", menu.Items[9].Value.Trim(), "");
                Assert.AreEqual("Sort By Object Type", menu.Items[10].Value.Trim(), "");
                Assert.AreEqual("Sort By Object Access", menu.Items[11].Value.Trim(), "");
                Assert.AreEqual("Group By Object Type", menu.Items[12].Value.Trim(), "");
                Keyboard.PressAndRelease(System.Windows.Input.Key.Escape);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserTypeBrowserViewTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[1].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                Condition con = new PropertyCondition(
                                        AutomationElement.ClassNameProperty,
                                        "ContextMenu"
                                    );
                AutomationElement el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                Menu menu = new Menu(el);
                int itemCount = menu.Items.Count;
                Assert.AreEqual(7, itemCount, "Item count: " + itemCount.ToString());
                menu.Items[1].Check();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(2, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                menu = new Menu(el);
                itemCount = menu.Items.Count;
                Assert.AreEqual(7, itemCount, "Item count: " + itemCount.ToString());
                Assert.IsTrue(menu.Items[1].ToggleStatus);
                menu.Items[2].Check();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserTypeBrowserSortTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[1].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                Condition con = new PropertyCondition(
                                        AutomationElement.ClassNameProperty,
                                        "ContextMenu"
                                    );
                AutomationElement el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                Menu menu = new Menu(el);
                int itemCount = menu.Items.Count;
                Assert.AreEqual(7, itemCount, "Item count: " + itemCount.ToString());
                menu.Items[6].Check();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(4, nodeCount, "Node count: " + nodeCount.ToString());
                objectBrowser.TypeBrowserPane.Nodes[2].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(5, nodeCount, "Node count: " + nodeCount.ToString());
                Assert.AreEqual("Namespaces", objectBrowser.TypeBrowserPane.Nodes[3].Value, "");
                Assert.AreEqual("Namespaces", objectBrowser.TypeBrowserPane.Nodes[1].Value, "");
                objectBrowser.TypeBrowserPane.Nodes[3].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[3].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                objectBrowser.TypeBrowserPane.Nodes[0].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                menu = new Menu(el);
                itemCount = menu.Items.Count;
                Assert.AreEqual(7, itemCount, "Item count: " + itemCount.ToString());
                Assert.IsTrue(menu.Items[6].ToggleStatus);
                menu.Items[3].Check();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(4, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[3].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("SchoolMember", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[3].Value;
                Assert.AreEqual("Program.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[4].Value;
                Assert.AreEqual("Student", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[5].Value;
                Assert.AreEqual("Teacher", str, "");
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserNavigateVarContextMenuTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                objectBrowser.EnsureLoaded();

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[2].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[4].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                Condition con = new PropertyCondition(
                                        AutomationElement.ClassNameProperty,
                                        "ContextMenu"
                                    );
                AutomationElement el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                Menu menu = new Menu(el);
                int itemCount = menu.Items.Count;
                Assert.AreEqual(13, itemCount, "Item count: " + itemCount.ToString());
                menu.Items[0].Check();
                System.Threading.Thread.Sleep(1000);

                str = app.Dte.ActiveDocument.Name;
                Assert.AreEqual("Program.py", str, "");

                int lineNo = ((TextSelection)app.Dte.ActiveDocument.Selection).ActivePoint.Line;
                Assert.AreEqual(14, lineNo, "Line number: " + lineNo.ToString());

                app.OpenObjectBrowser();
                objectBrowser.TypeBrowserPane.Nodes[5].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                menu = new Menu(el);
                menu.Items[0].Check();
                System.Threading.Thread.Sleep(1000);

                lineNo = ((TextSelection)app.Dte.ActiveDocument.Selection).ActivePoint.Line;
                Assert.AreEqual(3, lineNo, "Line number: " + lineNo.ToString());
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ObjectBrowserFindAllReferencesTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\MultiModule.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenObjectBrowser();
                var objectBrowser = app.ObjectBrowser;
                System.Threading.Thread.Sleep(1000);

                int nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(1, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[0].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(3, nodeCount, "Node count: " + nodeCount.ToString());

                string str = objectBrowser.TypeBrowserPane.Nodes[1].Value;
                Assert.AreEqual("MyModule.py", str, "");
                str = objectBrowser.TypeBrowserPane.Nodes[2].Value;
                Assert.AreEqual("Program.py", str, "");

                objectBrowser.TypeBrowserPane.Nodes[2].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);
                objectBrowser.TypeBrowserPane.Nodes[1].ExpandCollapse();
                System.Threading.Thread.Sleep(1000);

                nodeCount = objectBrowser.TypeBrowserPane.Nodes.Count;
                Assert.AreEqual(6, nodeCount, "Node count: " + nodeCount.ToString());

                objectBrowser.TypeBrowserPane.Nodes[4].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                Condition con = new PropertyCondition(
                                        AutomationElement.ClassNameProperty,
                                        "ContextMenu"
                                    );
                AutomationElement el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                Menu menu = new Menu(el);
                int itemCount = menu.Items.Count;
                Assert.AreEqual(13, itemCount, "Item count: " + itemCount.ToString());
                menu.Items[4].Check();
                System.Threading.Thread.Sleep(1000);

                //this needs to be updated for bug #4840
                str = app.Dte.ActiveWindow.Caption;
                Assert.IsTrue(str.Contains("2 matches found"), str);

                objectBrowser.TypeBrowserPane.Nodes[2].ShowContextMenu();
                System.Threading.Thread.Sleep(1000);
                el = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, con);
                Assert.IsNotNull(el);
                menu = new Menu(el);
                menu.Items[4].Check();
                System.Threading.Thread.Sleep(1000);

                str = app.Dte.ActiveWindow.Caption;
                Assert.IsTrue(str.Contains("2 matches found"), str);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void NavigateTo() {
            using (var app = new VisualStudioApp()) {
                app.OpenProject(@"TestData\Navigation.sln");
                
                using (var dialog = app.OpenNavigateTo()) {
                    dialog.SearchTerm = "Class";
                    Assert.AreEqual(4, dialog.WaitForNumberOfResults(4));
                }

                using (var dialog = app.OpenNavigateTo()) {
                    dialog.SearchTerm = "cls";
                    Assert.AreEqual(4, dialog.WaitForNumberOfResults(4));
                }

                using (var dialog = app.OpenNavigateTo()) {
                    dialog.SearchTerm = "func";
                    Assert.AreEqual(8, dialog.WaitForNumberOfResults(8));
                }

                using (var dialog = app.OpenNavigateTo()) {
                    dialog.SearchTerm = "fn";
                    Assert.AreEqual(8, dialog.WaitForNumberOfResults(8));
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ResourceViewIsDisabledTest() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\Outlining.sln");
                System.Threading.Thread.Sleep(1000);

                app.OpenResourceView();
                var resourceView = app.ResourceView;
                Assert.IsNotNull(resourceView);
                System.Threading.Thread.Sleep(1000);

                Assert.IsNull(resourceView.TypeBrowserPane);
            }
        }
    }
}
