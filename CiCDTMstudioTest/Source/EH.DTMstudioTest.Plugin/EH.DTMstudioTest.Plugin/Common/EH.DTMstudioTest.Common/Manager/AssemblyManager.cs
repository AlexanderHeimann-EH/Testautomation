// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class AssemblyManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Manager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;

    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// Class AssemblyManager.
    /// </summary>
    public class AssemblyManager : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The loaded assembly list.
        /// </summary>
        private readonly LoadedAssemblyCollection loadedAssembliesCollection;

        /// <summary>
        /// The test configuration
        /// </summary>
        private TestConfiguration testConfiguration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyManager"/> class.
        /// </summary>
        public AssemblyManager()
        {
            Log.Enter(this, "AssemblyManager");

            this.InitializeTestConfiguration();

            this.loadedAssembliesCollection = new LoadedAssemblyCollection();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the test configuration.
        /// </summary>
        /// <value>The test configuration.</value>
        public TestConfiguration TestConfiguration
        {
            get
            {
                return this.testConfiguration;
            }

            set
            {
                this.RaisePropertyChanged("TestConfiguration");
                this.testConfiguration = value;
            }
        }

        /// <summary>
        /// Gets or sets the test configuration file.
        /// </summary>
        public string TestConfigurationFile { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get assembly temp file.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="documentName">
        /// The document name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetAssemblyTempFile(string assemblyName, string documentName)
        {
            // Temporären Dateierweiterung
            var tempFileName = Path.ChangeExtension(Path.GetFileName(Path.GetTempFileName()), Path.GetExtension(assemblyName));

            // Temporären Dateiername
            var tempAssemblyName = assemblyName + "_" + documentName + "_" + tempFileName;

            return tempAssemblyName;
        }

        /// <summary>
        /// The add assemblies.
        /// </summary>
        /// <param name="assemblyFullPath">
        /// The assembly full path.
        /// </param>
        public void AddAssemblies(string assemblyFullPath)
        {
            this.TestConfiguration.PropertyChanged -= this.OnPropertyChanged;

            this.AddToLoadedAssembliesCollection(assemblyFullPath);

            this.InitializeTestConfiguration();

            this.ReloadAssemblies();

            this.TestConfiguration.PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        /// The add assembly.
        /// </summary>
        /// <param name="assemblyFullPath">
        /// The assembly full path.
        /// </param>
        public void AddAssembly(string assemblyFullPath)
        {
            Log.Enter(this, string.Format("LoadAssembly: {0}", assemblyFullPath));

            try
            {
                this.AddToLoadedAssembliesCollection(assemblyFullPath);

                this.AddMethodInfoFromAssembly(assemblyFullPath);
                this.AddTestSuitesFromAssembly(assemblyFullPath);
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, string.Format("AssemblyFullPath: {0} - {1}.", assemblyFullPath, ex.Message));
            }
        }

        /// <summary>
        /// The load assembly documentation xml.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="XmlDocument"/>.
        /// </returns>
        public XmlDocument AddAssemblyDocumentation(string assemblyName)
        {
            Log.Enter(this, "LoadAssemblyDocumentation: " + assemblyName);

            if (!string.IsNullOrEmpty(assemblyName))
            {
                var docuPath = assemblyName.Substring(0, assemblyName.LastIndexOf(".", StringComparison.Ordinal)) + ".XML";

                var docuDoc = new XmlDocument();

                if (File.Exists(docuPath))
                {
                    docuDoc = new XmlDocument();
                    docuDoc.Load(docuPath);
                }
                else
                {
                    Log.Info(this, string.Format("Xml documentation does not exist. There is no method description for {0}", assemblyName));
                }

                return docuDoc;
            }

            return null;
        }

        /// <summary>
        /// The add predefined test suites from assembly.
        /// </summary>
        /// <param name="rootObject">
        /// The root object.
        /// </param>
        /// <param name="loadingAssemblyName">
        /// The loading assembly name.
        /// </param>
        /// <param name="deviceFunctions">
        /// </param>
        public void AddPredefinedTestSuitesFromAssembly(TestCollection rootObject, string loadingAssemblyName, List<DeviceFunction> deviceFunctions)
        {
            if (deviceFunctions != null)
            {
                var suitesFiles = AssemblyProxy.GetTestSuitesFileFromAssembly(loadingAssemblyName);

                foreach (var suitesFile in suitesFiles)
                {
                    try
                    {
                        var testConfig = new TestConfiguration();
                        testConfig = testConfig.GetTestConfiguration(suitesFile.ResourceNameFullPath);

                        foreach (var availableTestObject in testConfig.AvailableTestObjects)
                        {
                            if (availableTestObject is TestSuite)
                            {
                                var testSuite = availableTestObject as TestSuite;
                                if (testSuite.TestCategory == TestCategory.DeviceTypeAcceptance)
                                {
                                    testConfig.AvailableTestObjects = FilderTestConfig(deviceFunctions, testSuite.TestObjects);

                                    // var testObjects = this.AddNamespaceToTestObjectCollection(rootObject, string.Format("{0}.{1}.{2}", testSuite.TestDefinition, testSuite.TestCategory, testSuite.TestFocus), testConfig.AvailableTestObjects);
                                    var testObjects = this.AddNamespaceToTestObjectCollection(rootObject, string.Format("{0}", testSuite.TestDefinition), testConfig.AvailableTestObjects);

                                    foreach (var testObject in testObjects)
                                    {
                                        MergeTestObjectCollection(this.TestConfiguration.AvailableTestObjects, testObject as TestCollection);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorEx(this, ex, string.Format("AddPredefinedTestSuitesFromAssembly: {0} - {1}", suitesFile.ResourceNameFullPath, ex.Message));
                    }
                    finally
                    {
                        File.Delete(suitesFile.ResourceNameFullPath);
                    }
                }
            }
        }

        /// <summary>
        /// The get method info from assembly.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="EhMethodInfo"/>.
        /// </returns>
        public EhMethodInfoCollection GetMethodInfoFromAssembly(string assemblyName)
        {
            Log.Enter(this, string.Format("GetTestScriptMethodsFromAssembly: {0}", assemblyName));

            try
            {
                if (File.Exists(assemblyName))
                {
                    return AssemblyProxy.GetTestScriptMethodsFromAssembly(assemblyName);
                }

                Log.Error(this, string.Format("The {0} file does not exist", assemblyName));
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, string.Format("GetTestScriptMethodsFromAssembly: {0}", ex.Message));
            }

            return null;
        }

        /// <summary>
        /// The load test configuration.
        /// </summary>
        /// <param name="rootTestObject">
        /// The root folder.
        /// </param>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        public void LoadControlDocument(TestObject rootTestObject, string configFile)
        {
            Log.Enter(this, "LoadTestConfiguration: " + configFile);

            this.TestConfiguration = this.TestConfiguration.LoadControlDocument(rootTestObject, configFile);

            this.RaisePropertyChanged("TestConfiguration");
        }

        /// <summary>
        /// The reload assemblies.
        /// </summary>
        public void ReloadAssemblies()
        {
            var tempLoadedAssembliesList = this.loadedAssembliesCollection.Copy();

            foreach (var loadedAssembly in tempLoadedAssembliesList)
            {
                this.AddAssembly(loadedAssembly.FullPath);
            }
        }

        /// <summary>
        /// The unload.
        /// </summary>
        public void Unload()
        {
            this.TestConfiguration.PropertyChanged -= this.OnPropertyChanged;

            this.InitializeTestConfiguration();
            this.loadedAssembliesCollection.Clear();

            this.TestConfiguration.PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        /// The unload assembly.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        public void UnloadAssembly(string assemblyName)
        {
            this.TestConfiguration.PropertyChanged -= this.OnPropertyChanged;

            // Lösche alle Termporären Versionen und sich selbst aus der Assembly List
            for (var i = 0; i < this.loadedAssembliesCollection.Count; i++)
            {
                if (this.loadedAssembliesCollection[i].FullPath.StartsWith(assemblyName) || this.loadedAssembliesCollection[i].FullPath == assemblyName)
                {
                    this.loadedAssembliesCollection.Remove(this.loadedAssembliesCollection[i]);
                    i--;
                }
            }

            this.InitializeTestConfiguration();

            this.ReloadAssemblies();

            this.TestConfiguration.PropertyChanged += this.OnPropertyChanged;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The filder test config.
        /// </summary>
        /// <param name="deviceFunctions">
        /// The device functions.
        /// </param>
        /// <param name="availableTestObjects">
        /// The available test objects.
        /// </param>
        /// <returns>
        /// The <see cref="TestObjectCollection"/>.
        /// </returns>
        private static TestObjectCollection FilderTestConfig(List<DeviceFunction> deviceFunctions, TestObjectCollection availableTestObjects)
        {
            for (var i = 0; i < availableTestObjects.Count; i++)
            {
                var testObject = availableTestObjects[i];

                if (testObject is TestSuite)
                {
                    var testSuite = testObject as TestSuite;

                    if (!IsDeviceFunctionActive(deviceFunctions, testSuite))
                    {
                        availableTestObjects.Remove(testSuite);
                        i--;
                    }
                    else
                    {
                        testSuite.TestObjects = FilderTestConfig(deviceFunctions, testSuite.TestObjects);
                    }
                }
                else if (testObject is TestFolder)
                {
                    var testFolder = testObject as TestFolder;
                    testFolder.TestObjects = FilderTestConfig(deviceFunctions, testFolder.TestObjects);
                    if (testFolder.TestObjects.Count == 0)
                    {
                        availableTestObjects.Remove(testFolder);
                        i--;
                    }
                }
            }

            return availableTestObjects;
        }

        /// <summary>
        /// The get class namespace.
        /// </summary>
        /// <param name="classNamespace">
        /// The class namespace.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetLastNamespaceSegment(string classNamespace)
        {
            var lastNamespace = classNamespace.Split('.');
            return lastNamespace[lastNamespace.Length - 1];
        }

        /// <summary>
        /// The is test focus.
        /// </summary>
        /// <param name="deviceFunctions">
        /// The device functions.
        /// </param>
        /// <param name="testSuite">
        /// The test suite.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsDeviceFunctionActive(IEnumerable<DeviceFunction> deviceFunctions, TestSuite testSuite)
        {
            foreach (var deviceFunction in deviceFunctions)
            {
                if (deviceFunction.FrameworkMappingName == testSuite.TestFocus.ToString() && deviceFunction.Active)
                {
                    return true;
                }

                if (deviceFunction.FrameworkMappingName == testSuite.TestFocus.ToString() && deviceFunction.Active == false)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Merges the test case collection.
        /// </summary>
        /// <param name="tree">
        /// The tree.
        /// </param>
        /// <param name="assemblyObject">
        /// The assembly object.
        /// </param>
        private static void MergeTestCaseCollection(TestObjectCollection tree, TestCase assemblyObject)
        {
            var vorhanden = false;

            foreach (var name in tree)
            {
                if (name.Name == assemblyObject.Name)
                {
                    vorhanden = true;
                    break;
                }
            }

            if (!vorhanden)
            {
                tree.Add(assemblyObject);
            }
        }

        /// <summary>
        /// The merge test object collection.
        /// </summary>
        /// <param name="tree">
        /// The tree.
        /// </param>
        /// <param name="assemblyObject">
        /// The assembly object.
        /// </param>
        private static void MergeTestFolderCollection(TestObjectCollection tree, TestFolder assemblyObject)
        {
            var vorhanden = false;

            foreach (var name in tree)
            {
                if (name.Name == assemblyObject.Name)
                {
                    foreach (var ob in assemblyObject.TestObjects)
                    {
                        if (name is TestCollection)
                        {
                            MergeTestObjectCollection((name as TestCollection).TestObjects, ob);
                        }
                    }

                    vorhanden = true;
                }
            }

            if (!vorhanden)
            {
                tree.Add(assemblyObject);
            }
        }

        /// <summary>
        /// Merges the test object collection.
        /// </summary>
        /// <param name="tree">
        /// The tree.
        /// </param>
        /// <param name="assemblyObject">
        /// The assembly object.
        /// </param>
        private static void MergeTestObjectCollection(TestObjectCollection tree, TestObject assemblyObject)
        {
            if (assemblyObject is TestFolder)
            {
                MergeTestFolderCollection(tree, assemblyObject as TestFolder);
            }

            if (assemblyObject is TestSuite)
            {
                MergeTestSuiteCollection(tree, assemblyObject as TestSuite);
            }

            if (assemblyObject is TestCase)
            {
                MergeTestCaseCollection(tree, assemblyObject as TestCase);
            }
        }

        /// <summary>
        /// Merges the test suite collection.
        /// </summary>
        /// <param name="tree">
        /// The tree.
        /// </param>
        /// <param name="assemblyObject">
        /// The assembly object.
        /// </param>
        private static void MergeTestSuiteCollection(TestObjectCollection tree, TestSuite assemblyObject)
        {
            var vorhanden = false;

            foreach (var name in tree)
            {
                if (name.Name == assemblyObject.Name)
                {
                    foreach (var ob in assemblyObject.TestObjects)
                    {
                        if (name is TestCollection)
                        {
                            MergeTestObjectCollection((name as TestCollection).TestObjects, ob);
                        }
                    }

                    vorhanden = true;
                }
            }

            if (!vorhanden)
            {
                tree.Add(assemblyObject);
            }
        }

        /// <summary>
        /// The add folder element.
        /// </summary>
        /// <param name="testObjectCollection">
        /// The assembly object list.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="TestFolder"/>.
        /// </returns>
        private TestFolder AddFolderElement(TestObjectCollection testObjectCollection, string name)
        {
            Log.Enter(this, string.Format("AddFolderElement: {0}", name));

            var parent = testObjectCollection.FirstOrDefault(n => n.Name == name);

            if (parent == null)
            {
                var testFolder = new TestFolder { Name = name };

                testObjectCollection.Add(testFolder);
                return testFolder;
            }

            return parent as TestFolder;
        }

        /// <summary>
        /// The add method documentation.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <param name="xmlDocument">
        /// The xml document.
        /// </param>
        /// <param name="methodTags">
        /// The method tags.
        /// </param>
        /// <returns>
        /// The <see cref="MethodTags"/>.
        /// </returns>
        private MethodTags AddMethodDocumentation(EhMethodInfo methodInfo, XmlNode xmlDocument, MethodTags methodTags)
        {
            // nach Methoden in docuDoc suchen
            if (methodInfo != null)
            {
                var path = "M:" + methodInfo.MethodFullName + "." + methodInfo.MethodName;
                var xmlDocuOfMethods = xmlDocument.SelectNodes("//member[starts-with(@name, '" + path + "')]");

                if (xmlDocuOfMethods != null)
                {
                    foreach (var xmlDocuOfMethod in xmlDocuOfMethods)
                    {
                        var methoddocu = new XmlDocument();
                        methoddocu.LoadXml("<root>" + ((XmlElement)xmlDocuOfMethod).InnerXml + "</root>");

                        // Summary hinzufügen 
                        methodTags.Summary = this.GetDocumentationTag(methoddocu, methodTags.Summary) as SummaryTag;

                        // Return hinzufügen 
                        methodTags.Return = this.GetDocumentationTag(methoddocu, methodTags.Return) as ReturnTag;

                        // Parameter hinzufügen 
                        var xmlNodeList = methoddocu.SelectNodes("//param[starts-with(@name, '')]");
                        if (xmlNodeList != null)
                        {
                            var dokuParamsCount = xmlNodeList.Count;

                            // Anzahl der Parameter vergleichen
                            if (methodTags.Parameter.Parameters.Count() <= 0 || methodTags.Parameter.Parameters.Count() != dokuParamsCount)
                            {
                                continue;
                            }

                            for (var i = 0; i <= methodTags.Parameter.Parameters.Count() - 1; i++)
                            {
                                var dokuParams = methoddocu.SelectNodes(methodTags.Parameter.Parameters[i].SearchTag);

                                if (dokuParams != null)
                                {
                                    if (dokuParams.Count > 1)
                                    {
                                        Log.Error(this, string.Format("Parameter '{0}' mehrfach in Methode '{1}' vorhanden ", methodTags.Parameter.Parameters[i].Name, methodInfo.MethodName));
                                    }
                                    else if (dokuParams.Count < 1)
                                    {
                                        Log.Error(this, string.Format("Parameter '{0}' nicht in Methode '{1}' vorhanden ", methodTags.Parameter.Parameters[i].Name, methodInfo.MethodName));
                                    }
                                    else if (dokuParams.Count == 1)
                                    {
                                        methodTags.Parameter.Parameters[i].DocumentationTagFound = true;
                                        methodTags.Parameter.Parameters[i] = this.GetDocumentationParameterTag(dokuParams[0], methodTags.Parameter.Parameters[i]);
                                    }
                                }
                                else
                                {
                                    Log.Error(this, string.Format("Parameter '{0}' nicht in Methode '{1}' vorhanden ", methodTags.Parameter.Parameters[i].Name, methodInfo.MethodName));
                                }
                            }

                            methodTags.Parameter.DocumentationTagFound = true;
                        }

                        return methodTags;
                    }
                }
            }

            return methodTags;
        }

        /// <summary>
        /// The add method info from assembly.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        private void AddMethodInfoFromAssembly(string assemblyName)
        {
            EhMethodInfoCollection methodInfoList = this.GetMethodInfoFromAssembly(assemblyName);
            var docuDoc = this.AddAssemblyDocumentation(assemblyName);

            if (methodInfoList != null)
            {
                Log.Info(this, string.Format("{0} Run Methods in Assembly {1}", methodInfoList.Count(), assemblyName));

                IEnumerable<TestObject> testObjects = this.GetTestObjectCollection(methodInfoList, docuDoc);

                foreach (var testObject in testObjects)
                {
                    MergeTestObjectCollection(this.TestConfiguration.AvailableTestObjects, testObject as TestCollection);
                }
            }
        }

        /// <summary>
        /// The get test object collection.
        /// </summary>
        /// <param name="rootTestObject">
        /// The root Test Object.
        /// </param>
        /// <param name="subNamespace">
        /// The root folder.
        /// </param>
        /// <param name="testObjects">
        /// The test objects.
        /// </param>
        /// <returns>
        /// The <see cref="TestObjectCollection"/>.
        /// </returns>
        private IEnumerable<TestObject> AddNamespaceToTestObjectCollection(TestCollection rootTestObject, string subNamespace, IEnumerable<TestObject> testObjects)
        {
            Log.Enter(this, "GetTestObjectCollection");
            var ns = new TestObjectCollection();

            ns.Add(rootTestObject);

            var rootFolder = subNamespace.Split('.');

            foreach (var testObject in testObjects)
            {
                var tempFolder = this.AddFolderElement(rootTestObject.TestObjects, rootFolder[0]);

                for (var i = 1; i < rootFolder.Count(); i++)
                {
                    tempFolder = this.AddFolderElement(tempFolder.TestObjects, rootFolder[i]);
                }

                testObject.Parent = tempFolder;
                tempFolder.TestObjects.Add(testObject);
            }

            return ns;
        }

        /// <summary>
        /// The get test object collection.
        /// </summary>
        /// <param name="subNamespace">
        /// The root folder.
        /// </param>
        /// <param name="testObjects">
        /// The test objects.
        /// </param>
        /// <returns>
        /// The <see cref="TestObjectCollection"/>.
        /// </returns>
        private IEnumerable<TestObject> AddNamespaceToTestObjectCollection(string subNamespace, IEnumerable<TestObject> testObjects)
        {
            Log.Enter(this, "GetTestObjectCollection");
            var ns = new TestObjectCollection();

            var rootFolder = subNamespace.Split('.');

            foreach (var testObject in testObjects)
            {
                var tempFolder = this.AddFolderElement(ns, testObject.TestDefinition.ToString());

                for (var i = 0; i < rootFolder.Count(); i++)
                {
                    tempFolder = this.AddFolderElement(tempFolder.TestObjects, rootFolder[i]);
                }

                testObject.Parent = tempFolder;
                tempFolder.TestObjects.Add(testObject);
            }

            return ns;
        }

        /// <summary>
        /// The add test case element.
        /// </summary>
        /// <param name="assemblyObjectList">
        /// The assembly object list.
        /// </param>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <param name="methodDocumentation">
        /// The method documentation.
        /// </param>
        private void AddTestCaseElement(TestObjectCollection assemblyObjectList, EhMethodInfo methodInfo, MethodTags methodDocumentation)
        {
            Log.Enter(this, string.Format("AddTestCaseElement: {0}", methodInfo.MethodName));

            var parent = assemblyObjectList.FirstOrDefault(n => n.Name == methodInfo.MethodName);

            if (parent == null)
            {
                var testCase = new TestCase();

                testCase.Name = methodInfo.MethodDisplayName;

                var lastNamespaceSegment = GetLastNamespaceSegment(methodInfo.Namespace);
                testCase.DisplayName = string.Format("{0}.{1}.{2}", lastNamespaceSegment, methodInfo.ClassName, methodInfo.MethodName);

                testCase.Description = methodDocumentation.GetDocumentationText();

                testCase.AssemblyMethodRefId = methodInfo.CustomAttributGuid;

                testCase.AssemblyName = Path.GetFileName(methodInfo.AssemblyFullPath);
                testCase.Parameters = this.GetTestParameterCollection(methodDocumentation);

                assemblyObjectList.Add(testCase);
            }
        }

        /// <summary>
        /// The add test suites from assembly.
        /// </summary>
        /// <param name="loadingAssemblyName">
        /// The loading assembly name.
        /// </param>
        private void AddTestSuitesFromAssembly(string loadingAssemblyName)
        {
            var suitesFiles = AssemblyProxy.GetTestSuitesFileFromAssembly(loadingAssemblyName);

            foreach (var suitesFile in suitesFiles)
            {
                var testConfig = new TestConfiguration();

                var allAvailableTestObjects = testConfig.GetTestConfiguration(suitesFile.ResourceNameFullPath).AvailableTestObjects;

                var testObjectNamespace = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(suitesFile.ResourceName));

                var testObjects = this.AddNamespaceToTestObjectCollection(testObjectNamespace, allAvailableTestObjects);

                foreach (var testObject in testObjects)
                {
                    MergeTestObjectCollection(this.TestConfiguration.AvailableTestObjects, testObject as TestCollection);
                }

                File.Delete(suitesFile.ResourceNameFullPath);
            }
        }

        /// <summary>
        /// The add to loaded assemblies collection.
        /// </summary>
        /// <param name="assemblyFullPath">
        /// The assembly full path.
        /// </param>
        private void AddToLoadedAssembliesCollection(string assemblyFullPath)
        {
            var loadedAssembly = new LoadedAssembly { FullPath = assemblyFullPath };

            if (!this.loadedAssembliesCollection.Contains(loadedAssembly))
            {
                this.loadedAssembliesCollection.Add(loadedAssembly);
            }
        }

        /// <summary>
        /// The get documentation parameter tag.
        /// </summary>
        /// <param name="doc">
        /// The doc.
        /// </param>
        /// <param name="parameterTag">
        /// The parameter tag.
        /// </param>
        /// <returns>
        /// The <see cref="ParamTag"/>.
        /// </returns>
        private ParamTag GetDocumentationParameterTag(XmlNode doc, ParamTag parameterTag)
        {
            parameterTag.DocumentationTagFound = true;

            parameterTag.Description = doc.InnerText.Trim('\r').Trim('\n').Trim();
            return parameterTag;
        }

        /// <summary>
        /// The get documentation tag.
        /// </summary>
        /// <param name="doc">
        /// The doc.
        /// </param>
        /// <param name="baseTag">
        /// The base Tag.
        /// </param>
        /// <returns>
        /// The <see cref="BaseTag"/>.
        /// </returns>
        private BaseTag GetDocumentationTag(XmlNode doc, BaseTag baseTag)
        {
            XmlNode xmlDocuOfsummary = doc.SelectSingleNode(baseTag.SearchTag);

            if (xmlDocuOfsummary != null)
            {
                baseTag.DocumentationTagFound = true;
                baseTag.Description = xmlDocuOfsummary.InnerText.Trim('\r').Trim('\n').Trim();
            }

            return baseTag;
        }

        /// <summary>
        /// The get method documentation.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <param name="methodDocumentation">
        /// The xml document.
        /// </param>
        /// <returns>
        /// The <see cref="MethodTags"/>.
        /// </returns>
        private MethodTags GetMethodTags(EhMethodInfo methodInfo, XmlNode methodDocumentation)
        {
            if (methodInfo != null)
            {
                var methodTags = new MethodTags(methodInfo.MethodName);

                // Nach Prameter suchen
                var methodParams = methodInfo.ParameterInfo;

                foreach (var paramTag in methodParams.Select(methodParam => new ParamTag(methodParam.Name, methodParam.ParameterType)))
                {
                    methodTags.Parameter.Add(paramTag);
                }

                return this.AddMethodDocumentation(methodInfo, methodDocumentation, methodTags);
            }

            return new MethodTags(string.Empty);
        }

        /// <summary>
        /// The get test object collection.
        /// </summary>
        /// <param name="methodsInfo">
        /// The methods info.
        /// </param>
        /// <param name="xmlDocument">
        /// The xml document.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        private IEnumerable<TestObject> GetTestObjectCollection(IEnumerable<EhMethodInfo> methodsInfo, XmlDocument xmlDocument)
        {
            Log.Enter(this, "GetTestObjectCollection");
            var ns = new TestObjectCollection();

            foreach (EhMethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo != null)
                {
                    var methodNamespace = methodInfo.Namespace;
                    if (methodNamespace == null)
                    {
                        continue;
                    }

                    var rootElement = this.AddFolderElement(ns, methodInfo.CustomAttributTestDefinition).TestObjects;

                    var spaces = methodNamespace.Split('.');
                    var parent = rootElement;

                    for (var i = 0; i < spaces.Count(); i++)
                    {
                        // Folder hinzufügen
                        var folderName = spaces[i];
                        parent = this.AddFolderElement(parent, folderName).TestObjects;
                    }

                    // Folder hinzufügen 
                    parent = this.AddFolderElement(parent, methodInfo.ClassName).TestObjects;

                    // TestCase hinzufügen 
                    var methodDocumentation = this.GetMethodTags(methodInfo, xmlDocument);
                    this.AddTestCaseElement(parent, methodInfo, methodDocumentation);
                }
            }

            return ns;
        }

        /// <summary>
        /// The get test parameter collection.
        /// </summary>
        /// <param name="methodTag">
        /// The method tag.
        /// </param>
        /// <returns>
        /// The <see cref="TestParameterCollection"/>.
        /// </returns>
        private TestParameterCollection GetTestParameterCollection(MethodTags methodTag)
        {
            var testParameterCollection = new TestParameterCollection();

            foreach (var parameterTag in methodTag.Parameter.Parameters)
            {
                var testParameter = new TestParameter();

                testParameter.Name = parameterTag.Name;
                testParameter.Description = parameterTag.Description;
                testParameter.ParameterType = parameterTag.ParamType;

                testParameterCollection.Add(testParameter);
            }

            return testParameterCollection;
        }

        /// <summary>
        /// The initialize test configuration.
        /// </summary>
        private void InitializeTestConfiguration()
        {
            if (this.TestConfiguration != null)
            {
                this.TestConfiguration.PropertyChanged -= this.OnPropertyChanged;

                this.TestConfiguration.AvailableTestObjects.Clear();

                this.TestConfiguration = null;
            }

            this.TestConfiguration = new TestConfiguration();

            this.TestConfiguration.PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        /// The test configuration_ property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.SaveTestConfiguration();
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The save test configuration.
        /// </summary>
        private void SaveTestConfiguration()
        {
            this.TestConfiguration.SaveTestConfiguration();
        }

        #endregion
    }
}