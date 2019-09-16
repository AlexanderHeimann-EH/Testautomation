// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryAndItems.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The category and items.
    /// </summary>
    public class CategoryAndItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAndItems"/> class.
        /// </summary>
        public CategoryAndItems()
        {
            this.Category = string.Empty;
            this.Items = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAndItems"/> class.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="items">
        /// The items.
        /// </param>
        public CategoryAndItems(string category, List<string> items)
        {
            this.Category = category;
            this.Items = items;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<string> Items { get; set; }
    }
}
