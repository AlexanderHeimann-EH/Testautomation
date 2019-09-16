//------------------------------------------------------------------------------
// <copyright file="ConfigurationData.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Visual Studio
 * User: Effner, Christian
 * Date: 2014-04-28
 * Time: 13:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace Configurator.Data.SingleData
{
    public class ListOfFolderCategoryAndDll
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ListOfFolderCategoryAndDll()
        {
            Subcategories = new List<FolderCategoryAndDll>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="category">Category of application</param>
        /// <param name="subcategories">List of subcategories</param>
        public ListOfFolderCategoryAndDll(string category, List<FolderCategoryAndDll> subcategories)
        {
            Category = category;
            Subcategories = subcategories;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<FolderCategoryAndDll> Subcategories { get; set; }
        public string Category { get; set; }
    }
}
