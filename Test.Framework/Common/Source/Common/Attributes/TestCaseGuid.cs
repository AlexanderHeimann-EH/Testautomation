// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSuideGuids.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The test case guid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Attributes
{
    using System;

    using EH.PCPS.TestAutomation.Common.Annotations;

    /// <summary>
    /// The test case guid.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, Inherited = false)]
    public class TestSuideGuids : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuideGuids"/> class.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        public TestSuideGuids(string[] guid)
        {
            this.Guid = guid;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the guid.
        /// </summary>
        public string[] Guid { get; set; }

        #endregion
    }
}