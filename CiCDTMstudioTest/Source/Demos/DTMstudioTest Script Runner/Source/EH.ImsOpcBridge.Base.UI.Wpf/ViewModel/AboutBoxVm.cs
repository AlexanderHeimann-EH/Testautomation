// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutBoxVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for about box
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.Collections.Generic;
    using System.Globalization;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    /// <summary>
    /// View model for about box
    /// </summary>
    public class AboutBoxVm
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBoxVm"/> class.
        /// </summary>
        /// <param name="loadedAssemblies">The loaded assemblies.</param>
        /// <param name="entryAssembly">The entry assembly.</param>
        public AboutBoxVm(IEnumerable<IAssemblyInformation> loadedAssemblies, IAssemblyInformation entryAssembly)
        {
            this.AssemblyInfoList = new AssemblyInfoListVm(loadedAssemblies);
            this.EntryAssembly = entryAssembly;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the link uri that is the navigation target of the link.
        /// </summary>
        public static string Link
        {
            get
            {
                return Resources.AboutBoxHttpWwwEndressCom;
            }
        }

        /// <summary>
        /// Gets the link text to display in the About dialog.
        /// </summary>
        public static string LinkText
        {
            get
            {
                return Resources.AboutBoxLinkText;
            }
        }

        /// <summary>
        /// Gets the assembly info list.
        /// </summary>
        public AssemblyInfoListVm AssemblyInfoList { get; private set; }

        /// <summary>
        /// Gets the product's company name.
        /// </summary>
        public string Company
        {
            get
            {
                return this.EntryAssembly != null ? this.EntryAssembly.Company : Resources.AboutBoxUnknownCompany;
            }
        }

        /// <summary>
        /// Gets the copyright information for the product.
        /// </summary>
        public string Copyright
        {
            get
            {
                return this.EntryAssembly != null ? this.EntryAssembly.Copyright : Resources.AboutBoxUnknownCopyright;
            }
        }

        /// <summary>
        /// Gets the description about the application.
        /// </summary>
        public string Description
        {
            get
            {
                return this.EntryAssembly != null ? this.EntryAssembly.Description : Resources.AboutBoxUnknownDescription;
            }
        }

        /// <summary>
        /// Gets the entry assembly.
        /// </summary>
        public IAssemblyInformation EntryAssembly { get; private set; }

        /// <summary>
        /// Gets the product's full name.
        /// </summary>
        public string Product
        {
            get
            {
                return this.EntryAssembly != null ? this.EntryAssembly.ProductName : Resources.AboutBoxUnknownProduct;
            }
        }

        /// <summary>
        /// Gets the title property, which is display in the About dialogs window title.
        /// </summary>
        public string ProductTitle
        {
            get
            {
                return this.EntryAssembly != null ? string.Format(CultureInfo.CurrentUICulture, Resources.AboutBoxAbout_Product, this.EntryAssembly.ProductName) : Resources.AboutBoxUnknownProductTitle;
            }
        }

        /// <summary>
        /// Gets the application's version information to show.
        /// </summary>
        public string Version
        {
            get
            {
                return this.EntryAssembly != null ? this.EntryAssembly.Version.ToString() : Resources.AboutBoxUnknownVersion;
            }
        }

        #endregion
    }
}
