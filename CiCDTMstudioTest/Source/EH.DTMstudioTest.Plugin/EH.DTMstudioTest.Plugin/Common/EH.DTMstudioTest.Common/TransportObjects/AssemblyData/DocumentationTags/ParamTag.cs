// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class Param.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    using System;

    /// <summary>
    /// Class ParamTag.
    /// </summary>
    public class ParamTag : BaseTag
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamTag"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public ParamTag(string name)
            : base()
        {
            this.Name = name;
            this.SearchTag = "//param[starts-with(@name, '" + name + "')]";
            this.Caption = "Param:";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamTag"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="paramType">
        /// The method type.
        /// </param>
        public ParamTag(string name, string paramType)
            : base()
        {
            this.Name = name;
            this.SearchTag = "//param[starts-with(@name, '" + name + "')]";
            this.Caption = "Param:";
            this.ParamType = paramType;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the param type.
        /// </summary>
        public string ParamType { get; set; }

        #endregion
    }
}