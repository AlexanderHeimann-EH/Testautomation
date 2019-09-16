// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_TESTAREA.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of TC_TESTAREA.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare
{
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// Description of TC_TESTAREA.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_TESTAREA
    {
        // ReSharper restore InconsistentNaming
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="testArray">
        /// The test array.
        /// </param>
        /// <returns>
        /// The string.
        /// </returns>
        [TestScriptInformation("01A8A9A7-2568-419E-B380-B251A5431B50", TestDefinition.Predefined, TestScript.TestCase)]
        public static string Run(string[] testArray)
        {
            MessageBox.Show("string[] testArray", "TestMessageBox");
            return "Dies ist ein Test";
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="testString">
        /// The test string.
        /// </param>
        /// <param name="testInteger">
        /// The test integer.
        /// </param>
        /// <param name="testFloat">
        /// The test float.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [TestScriptInformation("9FE556D9-F720-468E-A440-4733B3B821BD", TestDefinition.Predefined, TestScript.TestCase)]
        public static string Run(string testString, int testInteger, float testFloat)
        {
            MessageBox.Show("string testString, int testInteger, float testFloat", "TestMessageBox");
            return "Dies ist ein Test";
        }

        /// <summary>
        /// Run test case
        /// </summary>
        [TestScriptInformation("AC5EFE61-CBC3-4C5B-BE0A-97EE50F99889", TestDefinition.Predefined, TestScript.TestCase)]
        public static void Run()
        {
            MessageBox.Show("no parameter", "TestMessageBox");
        }

        #endregion

        // [TestScriptInformation("49850901-6118-4ED9-BE47-5F162DA9910C", TestDefinition.Predefined, TestScript.TestScript)]
        // [TestSuideGuids(new[] { 
        // "0F83B0D3-5670-4CF0-A6C2-D57CC37CD55B", 
        // "9C7D4859-9AD5-4CC8-80BB-34E415D85227", 
        // "A496E5EF-E11E-400E-87E5-76BD1EC646DE",
        // "4A35B995-AA3E-4FC7-B964-0CA2CDEFF024",
        // "50AD0C1A-0821-4E14-AC44-E81891CB0CA1" })]
        // public static void TestSuiteRun()
        // {
        // }
    }
}