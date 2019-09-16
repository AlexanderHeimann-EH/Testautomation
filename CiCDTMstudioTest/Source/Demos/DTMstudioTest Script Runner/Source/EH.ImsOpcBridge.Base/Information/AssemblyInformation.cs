// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 04-16-2013
// ***********************************************************************
// <copyright file="AssemblyInformation.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.Information
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.ImsOpcBridge.Properties;

    /// <summary>
    /// The class for information about an assembly.
    /// </summary>
    public class AssemblyInformation : IAssemblyInformation
    {
        #region Fields

        /// <summary>
        /// The assembly
        /// </summary>
        private readonly Assembly assembly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyInformation" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AssemblyInformation(Assembly assembly)
        {
            this.assembly = assembly;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        public Assembly Assembly
        {
            get
            {
                return this.assembly;
            }
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>The company.</value>
        public string Company
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                var companyAttributes = this.assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                if (companyAttributes.Length > 0)
                {
                    return ((AssemblyCompanyAttribute)companyAttributes[0]).Company;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <value>The copyright.</value>
        public string Copyright
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                var companyAttributes = this.assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                if (companyAttributes.Length > 0)
                {
                    return ((AssemblyCopyrightAttribute)companyAttributes[0]).Copyright;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                var companyAttributes = this.assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                if (companyAttributes.Length > 0)
                {
                    return ((AssemblyDescriptionAttribute)companyAttributes[0]).Description;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                return Path.GetFileName(this.assembly.FullName);
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                try
                {
                    return Path.GetDirectoryName(this.assembly.Location);
                }
                catch (NotSupportedException)
                {
                    return Resources.AssemblyInformation_Location_NotSupported;
                }
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                return Path.GetFileName(this.assembly.GetName().Name);
            }
        }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                var companyAttributes = this.assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                if (companyAttributes.Length > 0)
                {
                    return ((AssemblyProductAttribute)companyAttributes[0]).Product;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the product title.
        /// </summary>
        /// <value>The product title.</value>
        public string ProductTitle
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                var companyAttributes = this.assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (companyAttributes.Length > 0)
                {
                    return ((AssemblyTitleAttribute)companyAttributes[0]).Title;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public Version Version
        {
            get
            {
                if (this.assembly == null)
                {
                    return null;
                }

                return this.assembly.GetName().Version;
            }
        }

        #endregion
    }
}
