// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHExportManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh export manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Manager  
{
    using System;
    using System.Globalization;
    using System.IO;

    using Ionic.Zip;

    /// <summary>
    /// The eh export manager.
    /// </summary>
    public class EhExportManager : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EhExportManager"/> class.
        /// </summary>
        public EhExportManager()
        {
            this.disposed = false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The export.
        /// </summary>
        /// <param name="sourceDirectory">
        /// The source Directory.
        /// </param>
        /// <param name="zipFileDirectory">
        /// The zip File Directory.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Export(string sourceDirectory, string zipFileDirectory)
        {
            try
            {
                // Get temp file name
                var tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName());

                if (tempFileName == null)
                {
                    return false;
                }

                // Get temp directory
                var targetPath = Path.Combine(Path.GetTempPath(), tempFileName);

                if (Directory.Exists(targetPath))
                {
                    Directory.Delete(targetPath, true);
                }

                // copy solutioin to the temp directory
                RecursivelyCopyDirectory(sourceDirectory, targetPath);

                // Create and save the zip file 
                using (var zipfile = new ZipFile())
                {
                    zipfile.AddDirectory(targetPath);
                    zipfile.Save(zipFileDirectory);
                }

                // Delete the temporary zip file
                Directory.Delete(targetPath, true);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region protected Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.disposed = true;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copy a directory recursively to the specified non-existing directory
        /// </summary>
        /// <param name="source">Directory to copy from</param>
        /// <param name="target">Directory to copy to</param>
        private static void RecursivelyCopyDirectory(string source, string target)
        {
            // Make sure it doesn't already exist
            if (Directory.Exists(target))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "FileOrFolderAlreadyExists"));
            }

            Directory.CreateDirectory(target);
            var directory = new DirectoryInfo(source);

            // Copy files
            foreach (var file in directory.GetFiles())
            {
                if (!IsFileExcluded(file.Name))
                {
                    file.CopyTo(Path.Combine(target, file.Name));
                }
            }

            // Now recurse to child directories
            foreach (var child in directory.GetDirectories())
            {
                if (!IsFolderExcluded(child.Name))
                {
                    RecursivelyCopyDirectory(child.FullName, Path.Combine(target, child.Name));
                }
            }
        }

        /// <summary>
        /// Is the file excluded
        /// </summary>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsFolderExcluded(string folder)
        {
            switch (folder)
            {
                //case "bin":
                case "obj":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// The is exclude file.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsFileExcluded(string name)
        {
            var extension = Path.GetExtension(name);

            switch (extension)
            {
                case ".suo":
                case ".user":
                case ".Cache":
                case ".pdb":
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}