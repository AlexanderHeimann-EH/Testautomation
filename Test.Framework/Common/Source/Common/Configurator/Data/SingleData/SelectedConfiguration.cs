// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectedConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData
{
    /// <summary>
    /// Class SelectedConfiguration.
    /// </summary>
    public class SelectedConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedConfiguration"/> class.
        /// </summary>
        public SelectedConfiguration()
        {
            this.TestEnvironment = new TestEnvironment();
            this.TestFramework = new TestFramework();
            this.TestInformation = new TestInformation();
        }

        /// <summary>
        /// Gets or sets the test environment.
        /// </summary>
        /// <value>The test environment.</value>
        public TestEnvironment TestEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the test framework.
        /// </summary>
        /// <value>The test framework.</value>
        public TestFramework TestFramework { get; set; }

        /// <summary>
        /// Gets or sets the test information.
        /// </summary>
        /// <value>The test information.</value>
        public TestInformation TestInformation { get; set; }
    }
}
