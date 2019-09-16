// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CodeTag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags  
{
    /// <summary>
    /// Class CodeTag.
    /// </summary>
    public class CodeTag : BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeTag"/> class.
        /// </summary>
        public CodeTag()
        {
            this.SearchTag = "//code";
            this.Caption = "Code:";
        }
    }
}
