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

namespace Configurator.Data.SingleData
{
    public class FolderCategoryAndDll
    {
        /// <summary>
        /// Constructor without parameters. Fields are initialized with empty strings.
        /// </summary>
        public FolderCategoryAndDll()
        {
            Folder = string.Empty;
            Category = string.Empty;
            Assembly = string.Empty;
        }

        /// <summary>
        /// Constructor with three parameters. Fields are initialized with specific values:
        /// </summary>
        /// <param name="folder">Folder</param>
        /// <param name="category">Category</param>
        /// <param name="assembly">Assembly</param>
        public FolderCategoryAndDll(string folder, string category, string assembly)
        {
            Folder = folder;
            Category = category;
            Assembly = assembly;
        }

        /// <summary>
        /// Folder
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Assembly
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// Assembly Namespace
        /// </summary>
        public string AssemblyNamespace
        {
            get
            {
                return Assembly.Replace(".", "._");
            }
        }
    }
}
