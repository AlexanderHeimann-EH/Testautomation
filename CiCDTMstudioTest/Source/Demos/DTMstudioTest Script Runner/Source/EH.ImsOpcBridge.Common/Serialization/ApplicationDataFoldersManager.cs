// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDataFoldersManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the application data folders manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Class ApplicationDataFoldersManager
    /// </summary>
    public class ApplicationDataFoldersManager
    {
        #region Public Methods and Operators

        /// <summary>
        /// Tries the create folders.
        /// </summary>
        /// <param name="folders">The folders.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool TryCreateFolders(out IList<string> folders, out Exception exception)
        {
            try
            {
                var assembly = Assembly.GetEntryAssembly();

                var company = this.GetCompany(assembly);
                var product = this.GetProduct(assembly);
                var version = this.GetFileVersion(assembly);
                version = this.ExtractMajorVersion(version);

                var rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company);
                rootFolder = Path.Combine(rootFolder, product);
                rootFolder = Path.Combine(rootFolder, version);

                var logsFolder = Path.Combine(rootFolder, Constants.LogsFolder);
                var configurationFolder = Path.Combine(rootFolder, Constants.ConfigurationFolder);

                // Creates the folders if they do not exist yet.
                Directory.CreateDirectory(logsFolder);
                Directory.CreateDirectory(configurationFolder);

                folders = new List<string> { logsFolder, configurationFolder };
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                folders = null;
                exception = ex;
                return false;
            }
        }
    
        #endregion

        #region Methods

        /// <summary>
        /// Extracts the major version.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>System String.</returns>
        /// <exception cref="System.Exception">File version missing or formatted ina wrong way.</exception>
        private string ExtractMajorVersion(string version)
        {
            var arr = version.Split('.');
            if (arr.Length > 1)
            {
                return arr[0] + '.' + arr[1];
            }

            throw new Exception("File version missing or formatted ina wrong way.");
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>System String.</returns>
        private string GetCompany(Assembly assembly)
        {
            try
            {
                var attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as AssemblyCompanyAttribute;
                    return attribute.Company;
                }
            }
            catch (Exception)
            {
            }

            return Constants.Unknown;
        }

        /// <summary>
        /// Gets the file version.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>System String.</returns>
        private string GetFileVersion(Assembly assembly)
        {
            try
            {
                var attributes = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as AssemblyFileVersionAttribute;
                    return attribute.Version;
                }
            }
            catch (Exception)
            {
            }

            return Constants.Unknown;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>System String.</returns>
        private string GetProduct(Assembly assembly)
        {
            try
            {
                var attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as AssemblyProductAttribute;
                    return attribute.Product;
                }
            }
            catch (Exception)
            {
            }

            return Constants.Unknown;
        }

        #endregion
    }
}