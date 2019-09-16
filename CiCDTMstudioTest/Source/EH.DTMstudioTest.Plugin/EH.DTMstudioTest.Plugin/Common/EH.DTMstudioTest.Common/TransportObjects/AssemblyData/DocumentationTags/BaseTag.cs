// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class BaseTag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    using System;

    /// <summary>
    /// Class BaseTag.
    /// </summary>
    public class BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTag"/> class.
        /// </summary>
        public BaseTag()
        {
            this.DocumentationTagFound = false;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the search tag.
        /// </summary>
        /// <value>The search tag.</value>
        public string SearchTag { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether tag found.
        /// </summary>
        public bool DocumentationTagFound { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get description text.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDescriptionText()  
        {
            if (this.DocumentationTagFound)
            {
                var result = this.Caption + Environment.NewLine;
                result += this.Description + Environment.NewLine;
                result += Environment.NewLine;

                return result;
            }

            return string.Empty;
        }

        #endregion
    }
}