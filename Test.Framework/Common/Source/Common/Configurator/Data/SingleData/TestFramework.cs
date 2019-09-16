// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestFramework.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData
{
    /// <summary>
    /// The test framework.
    /// </summary>
    public class TestFramework
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFramework"/> class.
        /// </summary>
        public TestFramework()
        {
           this.PathToAssemblies = string.Empty;
        }

        /// <summary>
        /// Gets or sets the path to assemblies.
        /// </summary>
        public string PathToAssemblies { get; set; }
    }
}
