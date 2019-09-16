// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListOfCategoryAndItems.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData
{
    using System.Collections.Generic;

    /// <summary>
    /// The list of category and items.
    /// </summary>
    public class ListOfCategoryAndItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfCategoryAndItems"/> class.
        /// </summary>
        public ListOfCategoryAndItems()
        {
            this.Items = new List<CategoryAndItems>();
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<CategoryAndItems> Items { get; set; }
    }
}
