// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TestConfiguration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// Class TestConfiguration.
    /// </summary>
    [Serializable]
    [XmlRoot("TestConfiguration")]
    [XmlInclude(typeof(TestMethod))]
    [XmlInclude(typeof(TestFolder))]
    [XmlInclude(typeof(TestModule))]
    [XmlInclude(typeof(TestSuite))]
    [XmlInclude(typeof(TestCase))]
    [XmlInclude(typeof(TestObject))]
    public class TestConfiguration : INotifyPropertyChanged
    {
        #region Constants

        /// <summary>
        /// The root folder name.
        /// </summary>
        private const string RootFolderName = "TestFolder";

        #endregion

        #region Fields

        /// <summary>
        /// All available test objects
        /// </summary>
        private TestObjectCollection availableTestObjects;

        /// <summary>
        /// The configuration file.
        /// </summary>
        private string configurationFile;

        /// <summary>
        /// The description.
        /// </summary>
        private string description;

        /// <summary>
        /// The dtm studio codia version.
        /// </summary>
        private string dtMstudioCoDiaVersion;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The test framework version.
        /// </summary>
        private string testFrameworkVersion;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestConfiguration"/> class.
        /// </summary>
        public TestConfiguration()
        {
            Log.Enter(this, "TestConfiguration()");

            this.AvailableTestObjects = new TestObjectCollection();
            this.AvailableTestObjects.CollectionChanged += this.OnAvailableTestObjectsCollectionChanged;

            this.ConfigurationFile = string.Empty;
            this.DTMstudioCoDIAVersion = string.Empty;
            this.TestFrameworkVersion = string.Empty;
            this.Description = string.Empty;
            this.Name = string.Empty;
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
        /// Gets or sets the predefined test suites.
        /// </summary>
        public TestObjectCollection AvailableTestObjects
        {
            get
            {
                return this.availableTestObjects;
            }

            set
            {
                this.availableTestObjects = value;
                this.RaisePropertyChanged("AllAvailableTestObjects");
            }
        }

        /// <summary>
        /// Gets or sets the test configuration file.
        /// </summary>
        public string ConfigurationFile
        {
            get
            {
                return this.configurationFile;
            }

            set
            {
                this.configurationFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the dt mstudio co dia version.
        /// </summary>
        /// <value>The dt mstudio co dia version.</value>
        public string DTMstudioCoDIAVersion
        {
            get
            {
                return this.dtMstudioCoDiaVersion;
            }

            set
            {
                if (value == this.dtMstudioCoDiaVersion)
                {
                    return;
                }

                this.dtMstudioCoDiaVersion = value;
                this.RaisePropertyChanged("DTMstudioCoDIAVersion");
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (value == this.description)
                {
                    return;
                }

                this.description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == this.name)
                {
                    return;
                }

                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the test framework version.
        /// </summary>
        /// <value>The test framework version.</value>
        public string TestFrameworkVersion
        {
            get
            {
                return this.testFrameworkVersion;
            }

            set
            {
                if (value == this.testFrameworkVersion)
                {
                    return;
                }

                this.testFrameworkVersion = value;
                this.RaisePropertyChanged("TestFrameworkVersion");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load control document.
        /// </summary>
        /// <param name="defaultRootObject">
        /// The default root object.
        /// </param>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        /// <returns>
        /// The <see cref="TestConfiguration"/>.
        /// </returns>
        public TestConfiguration LoadControlDocument(string defaultRootObject, string configFile)
        {
            Log.Enter(this, "LoadControlDocument(string defaultRootObject, string configFile)");
            return this.LoadControlDocument(new TestFolder() { Name = defaultRootObject }, configFile);
        }


        /// <summary>
        /// The get test configuration.
        /// </summary>
        /// <param name="defaultRootObject">
        /// The root folder.
        /// </param>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        /// <returns>
        /// The <see cref="TestConfiguration"/>.
        /// </returns>
        public TestConfiguration LoadControlDocument(TestObject defaultRootObject, string configFile)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var configExtension = Path.GetExtension(configFile);
            TestConfiguration testConfig = null;

            if (configExtension == ".xml")
            {
                // wenn kein noch keine Konfiguration vorhanden ist 
                if (!File.Exists(configFile))
                {
                    Log.Info(this, string.Format("TestConfiguration File {0} not exist.", configFile));

                    // neue Konfiguration hinzufügen 
                    this.CreateEmptyTestConfiguration(defaultRootObject, configFile);
                }

                // Steuerdokument vorhanden -> Deserializieren 
                testConfig = DeserializeTestConfiguration(configFile);

                // Kein Konfiguration im Steuerdokument vorhanden 
                if (testConfig == null || testConfig.availableTestObjects.Count <= 0)
                {
                    Log.Info(this, string.Format("No TestConfiguration found.  File: {0}", configFile));

                    this.CreateEmptyTestConfiguration(defaultRootObject, configFile);

                    // neue Konfiguration hinzufügen 
                    testConfig = DeserializeTestConfiguration(configFile);
                }

                testConfig.PropertyChanged += this.OnPropertyChanged;
            }
            else
            {
                Log.Error(this, string.Format("The {0} file is not a valid configuration file.", configFile));
            }

            return testConfig;
        }

        /// <summary>
        /// The get test configuration.
        /// </summary>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        /// <returns>
        /// The <see cref="TestConfiguration"/>.
        /// </returns>
        public TestConfiguration GetTestConfiguration(string configFile)
        {
            Log.Enter(this, "GetTestConfiguration(string configFile)");

            var configExtension = Path.GetExtension(configFile);
            TestConfiguration testConfig;

            if (configExtension == ".xml")
            {
                // wenn eine Konfiguration vorhanden ist 
                if (File.Exists(configFile))
                {
                    // Steuerdokument vorhanden -> Deserializieren 
                    testConfig = DeserializeTestConfiguration(configFile);

                    testConfig.PropertyChanged += this.OnPropertyChanged;
                    return testConfig;
                }

                Log.Error(this, string.Format("Configuration file: {0} is not available.", configFile));
                return null;
            }

            Log.Error(this, string.Format("The {0} file is not a valid configuration file.", configFile));
            return null;
        }

        /// <summary>
        /// The get test object.
        /// </summary>
        /// <param name="testObjects">
        /// The test objects.
        /// </param>
        /// <param name="searchGuid">
        /// The search guid.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public TestObject GetTestObject(ObservableCollection<TestObject> testObjects, string searchGuid)
        {
            Log.Enter(this, "GetTestObject(ObservableCollection<TestObject> testObjects, string searchGuid)");

            foreach (TestObject testObject in testObjects)
            {
                if (testObject is TestCollection)
                {
                    var result = this.GetTestObject(((TestCollection)testObject).TestObjects, searchGuid);
                    if (result != null)
                    {
                        return result;
                    }
                }

                if (testObject.Guid == searchGuid)
                {
                    return testObject;
                }
            }

            return null;
        }

        /// <summary>
        /// The get test object parameters.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="TestParameter"/>.
        /// </returns>
        public IList<TestParameter> GetTestObjectParameters(TestObject testObject)
        {
            Log.Enter(this, "GetTestObjectParameters(TestObject testObject)");

            if (((TestMethod)testObject).Parameters.Count > 0)
            {
                IList<TestParameter> parameterList = new List<TestParameter>();
                TestParameterCollection parameters = ((TestMethod)testObject).Parameters;
                foreach (var item in parameters)
                {
                    parameterList.Add(item);
                }

                return parameterList;
            }

            return null;
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Initalize()
        {
        }

        /// <summary>
        /// Called when [serialization].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public void OnSerialization(object sender)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// The save test configuration.
        /// </summary>
        public void SaveTestConfiguration()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            FileStream f = null;

            if (this.ConfigurationFile != string.Empty)
            {
                try
                {
                    if (File.Exists(this.ConfigurationFile))
                    {
                        File.Delete(this.ConfigurationFile);
                    }

                    var s = new XmlSerializer(typeof(TestConfiguration));
                    f = new FileStream(this.ConfigurationFile, FileMode.OpenOrCreate);
                    var n = new XmlSerializerNamespaces();
                    n.Add(string.Empty, string.Empty);
                    this.OnSerialization(n);
                    s.Serialize(f, this, n);
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, string.Format("ConfigFile: {0} - {1}", this.ConfigurationFile, ex.Message));
                }
                finally
                {
                    if (f != null)
                    {
                        f.Close();
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            Log.Enter(this, string.Format("RaisePropertyChanged: {0}", propertyName));

            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The create empty test configuration.
        /// </summary>
        /// <param name="rootObject">
        /// The root object.
        /// </param>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        private void CreateEmptyTestConfiguration(TestObject rootObject, string configFile)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.ConfigurationFile = configFile;
            this.TestFrameworkVersion = string.Empty;
            this.AvailableTestObjects.Clear();
            this.DTMstudioCoDIAVersion = string.Empty;
            this.Description = string.Empty;
            this.Name = string.Empty;

            this.AvailableTestObjects.Add(rootObject);
            
            this.SaveTestConfiguration();
        }

        /// <summary>
        /// The deserialize test configuration.
        /// </summary>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        /// <returns>
        /// The <see cref="TestConfiguration"/>.
        /// </returns>
        public static TestConfiguration DeserializeTestConfiguration(string configFile)
        {
            Log.Enter(MethodBase.GetCurrentMethod().Name);
            
            TestConfiguration testConfig = new TestConfiguration();
            Stream fs = new FileStream(configFile, FileMode.Open);
            try
            {
                Type objectType = typeof(TestConfiguration);
                XmlReader reader = new XmlTextReader(fs);
                XmlSerializer serializer = new XmlSerializer(objectType);
                if (serializer.CanDeserialize(reader))
                {
                    testConfig = (TestConfiguration)serializer.Deserialize(reader);
                }
                else
                {
                    string errorMessage = "File could not be deserialized";
                    Log.Error(null, string.Format("ConfigFile: {0} - {1}", configFile, errorMessage));
                }

                fs.Close();
            }
            catch (Exception ex)
            {
                Log.ErrorEx(null, ex, string.Format("ConfigFile: {0} - {1}", configFile, ex.Message));
            }
            finally
            {
                fs.Close();
            }

            return testConfig;
        }

        /// <summary>
        /// The on all available test objects collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnAvailableTestObjectsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newTestObject = e.NewItems;

                        foreach (TestObject testObject in newTestObject)
                        {
                            if (!testObject.HasPropertyChanged())
                            {
                                testObject.PropertyChanged += this.OnPropertyChanged;
                            }
                        }

                        break;
                    }
            }

            this.RaisePropertyChanged("OnAvailableTestObjectsCollectionChanged");
        }

        /// <summary>
        /// The on predefined test suites collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnPredefinedTestSuitesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newTestObject = e.NewItems;

                        foreach (TestObject testObject in newTestObject)
                        {
                            if (!testObject.HasPropertyChanged())
                            {
                                testObject.PropertyChanged += this.OnPropertyChanged;
                            }
                        }

                        break;
                    }
            }

            this.RaisePropertyChanged("OnPredefinedTestSuitesCollectionChanged");
        }

        /// <summary>
        /// The test sequence of test objects_ property changed.
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

            this.RaisePropertyChanged(e.PropertyName);
        }

        #endregion
    }
}