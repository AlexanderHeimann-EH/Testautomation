// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptInformation.cs" company="Endress+Hauser Process Solutions AG">
//   sfasdfasdfasdf
// </copyright>
// <summary>
//   The test script information attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestLibraryCommon
{
    using System;

    /// <summary>
    /// The test script information attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class TestScriptInformation : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestScriptInformation"/> class.
        /// </summary>
        /// <param name="testScript">
        /// The test script.
        /// </param>
        /// <param name="testCategory">
        /// The test category.
        /// </param>
        /// <param name="testFocus">
        /// The test focus.
        /// </param>
        public TestScriptInformation(Enumerations.TestScript testScript, string testCategory, string testFocus)
        {
            this.TestScript = testScript;
            this.TestCategory = testCategory;
            this.TestFocus = testFocus;
        }

        /// <summary>
        /// Gets or sets the test script.
        /// </summary>
        public Enumerations.TestScript TestScript { get; set; }

        /// <summary>
        /// Gets or sets the test category.
        /// </summary>
        public string TestCategory { get; set; }

        /// <summary>
        /// Gets or sets the test focus.
        /// </summary>
        public string TestFocus { get; set; }
    }
}
