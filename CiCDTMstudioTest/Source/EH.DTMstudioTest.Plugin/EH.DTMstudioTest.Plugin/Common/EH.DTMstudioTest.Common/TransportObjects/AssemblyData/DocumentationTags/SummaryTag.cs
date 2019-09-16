// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummaryTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SummaryTag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags 
{
    /// <summary>
    /// Class SummaryTag.
    /// </summary>
    public class SummaryTag : BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryTag"/> class.
        /// </summary>
        public SummaryTag()
        {
            this.SearchTag = "//summary";
            this.Caption = "Summary:";

            this.Description = "no description available!";
        }
    }
}
