// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamTags.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ParamTags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    using System.Collections.Generic;

    /// <summary>
    /// The param tags.
    /// </summary>
    public class ParamTags
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamTags" /> class.
        /// </summary>
        public ParamTags()
        {
            this.Parameters = new List<ParamTag>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether tag found.
        /// </summary>
        public bool DocumentationTagFound { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public List<ParamTag> Parameters { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the specified parameter tag.
        /// </summary>
        /// <param name="paramTag">
        /// The parameter tag.
        /// </param>
        public void Add(ParamTag paramTag)
        {
            this.Parameters.Add(paramTag);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.Parameters.Clear();
        }

        /// <summary>
        /// The get description text.
        /// </summary>
        /// <returns>The <see cref="string" />.</returns>
        public string GetDescriptionText()
        {
            var result = string.Empty;

            foreach (var parameter in this.Parameters)
            {
                result += parameter.GetDescriptionText();
            }

            return result;
        }

        #endregion
    }
}