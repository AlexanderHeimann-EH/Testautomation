// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuiteTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The suite tag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    using System.Collections.Generic;

    /// <summary>
    /// The suite tag.
    /// </summary>
    public class SuiteTags
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuiteTags"/> class.
        /// </summary>
        public SuiteTags()
        {
            this.Suites = new List<SuiteTag>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether tag found.
        /// </summary>
        public bool DocumentationTagFound { get; set; }

        /// <summary>
        /// Gets or sets the suites.
        /// </summary>
        public List<SuiteTag> Suites { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="suiteTag">
        /// The suite tag.
        /// </param>
        public void Add(SuiteTag suiteTag)
        {
            this.Suites.Add(suiteTag);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.Suites.Clear();
        }

        /// <summary>
        /// The get description text.
        /// </summary>
        /// <returns>The <see cref="string" />.</returns>
        public string GetDescriptionText()
        {
            var result = string.Empty;

            foreach (var suite in this.Suites)
            {
                result += suite.GetDescriptionText();
            }

            return result;
        }

        #endregion
    }
}