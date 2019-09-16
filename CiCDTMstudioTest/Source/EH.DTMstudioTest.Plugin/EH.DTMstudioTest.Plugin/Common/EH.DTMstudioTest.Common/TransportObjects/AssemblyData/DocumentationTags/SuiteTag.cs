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
    /// <summary>
    /// The suite tag.
    /// </summary>
    public class SuiteTag : BaseTag
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuiteTag"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="guid">
        /// The guid.
        /// </param>
        public SuiteTag(string name, string[] guid)
            : base()
        {
            this.Name = name;
            this.Guid = guid;
            this.SearchTag = "//suite[starts-with(@name, '" + name + "')]";
            this.Caption = "Suite:";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the giud.
        /// </summary>
        public string[] Guid { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}