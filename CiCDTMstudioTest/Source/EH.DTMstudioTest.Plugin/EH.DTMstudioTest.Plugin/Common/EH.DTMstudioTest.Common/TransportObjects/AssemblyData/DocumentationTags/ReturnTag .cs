// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReturnTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ReturnTag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    /// <summary>
    /// Class ReturnTag.
    /// </summary>
    public class ReturnTag : BaseTag
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnTag"/> class.
        /// </summary>
        public ReturnTag()
        {
            this.SearchTag = "//returns";
            this.Caption = "Returns:";
        }

        #endregion
    }
}