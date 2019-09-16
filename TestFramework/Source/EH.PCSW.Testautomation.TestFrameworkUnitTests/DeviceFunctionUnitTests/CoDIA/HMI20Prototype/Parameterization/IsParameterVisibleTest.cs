using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EH.PCPS.Testautomation.TestFrameworkUnitTests.DeviceFunctionUnitTests.CoDIA.HMI20Prototype.Parameterization
{
    using System.IO;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Summary description for IsParameterVisibleTest
    /// </summary>
    [TestClass]
    public class IsParameterVisibleTest
    {
        public IsParameterVisibleTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void RunIsParameterVisibleTest()
        {
            string fullLocation = @"P:\EH.PCSW.Testautomation.TestFramework\Source\EH.PCSW.Testautomation.TestFrameworkUnitTests\DeviceFunctionUnitTests\CoDIA\HMI20Prototype\Parameterization\Data\DisplayContent1.xml";

            string[] allLines = File.ReadAllLines(fullLocation);
            StringBuilder text = new StringBuilder();

            foreach (string line in allLines)
            {
                text.Append(line);
            }

            var test = new IsParameterVisible();
            bool result = test.Run(@"Parameters.PRES_SensorTemperature_1");            
            Assert.AreEqual(result, true);
            result = test.Run(@"Parameters.PRES_SensorTemperature_2");            
            Assert.AreEqual(result, false);
        }
    }
}
