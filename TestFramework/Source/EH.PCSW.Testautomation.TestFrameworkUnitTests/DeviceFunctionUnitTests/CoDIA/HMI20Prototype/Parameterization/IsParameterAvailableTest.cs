namespace EH.PCPS.Testautomation.TestFrameworkUnitTests.DeviceFunctionUnitTests.CoDIA.HMI20Prototype.Parameterization
{
    using System.IO;
    using System.Text;

    using EH.PCPS.TestAutomation.PrototypeHMI20;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Summary description for IsParameterAvailableTest
    /// </summary>
    [TestClass]
    public class IsParameterAvailableTest
    {
        public IsParameterAvailableTest()
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
                return this.testContextInstance;
            }
            set
            {
                this.testContextInstance = value;
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
        public void RunIsParameterAvailableTest()
        {
            string fullLocation = @"P:\EH.PCSW.Testautomation.TestFramework\Source\EH.PCSW.Testautomation.TestFrameworkUnitTests\DeviceFunctionUnitTests\CoDIA\HMI20Prototype\Parameterization\Data\DisplayContent1.xml";

            string[] allLines = File.ReadAllLines(fullLocation);
            StringBuilder text = new StringBuilder();

            foreach (string line in allLines)
            {
                text.Append(line);
            }

            var test = new IsParameterAvailable();
            bool result = test.Run(@"Parameters.PRES_CorrectedPressure_1");
            result = test.Run(@"Parameters.PRES_SensorTemperature_2");
            result = test.Run(@"Parameters.PRES_Habib_1");
            Assert.AreEqual(result, false);
        }
    }
}
