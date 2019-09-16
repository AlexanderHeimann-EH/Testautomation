// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData
{
    /// <summary>
    /// The element.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class. 
        /// Constructor without parameters. Fields are initialized with empty strings.
        /// </summary>
        public Element()
        {
            this.Folder = string.Empty;
            this.Category = string.Empty;
            this.Assembly = string.Empty;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class. 
        /// Constructor with three parameters. Fields are initialized with specific values:
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        public Element(string folder, string category, string assembly)
        {
            this.Folder = folder;
            this.Category = category;
            this.Assembly = assembly;
        }

        /// <summary>
        /// Gets or sets Folder
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Assembly
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// Gets Assembly Namespace
        /// </summary>
        public string AssemblyNamespace
        {
            get
            {
                // return this.Assembly.Replace(".", "._");
                return this.Assembly;
            }
        }
    }
}
