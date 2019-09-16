// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Static methods for file handling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.FileHandling
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security;

    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// Static methods for file handling.
    /// </summary>
    public static class FileHandler
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clears the directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool ClearDirectory(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            return ClearDirectory(directoryInfo);
        }

        /// <summary>
        /// Clears the directory.
        /// </summary>
        /// <param name="directoryInfo">The directory info.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool ClearDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException(@"directoryInfo");
            }

            directoryInfo.Refresh();
            if (directoryInfo.Exists)
            {
                foreach (var subdirectoryInfo in directoryInfo.GetDirectories())
                {
                    if (ClearDirectory(subdirectoryInfo))
                    {
                        subdirectoryInfo.Delete();
                    }
                    else
                    {
                        return false;
                    }
                }

                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    fileInfo.Delete();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the filename to a valid file name.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        /// <returns>The valid filename</returns>
        public static string ConvertToValidFileName(string fileName)
        {
            foreach (var invalidChar in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidChar, '_');
            }

            return fileName;
        }

        /// <summary>
        /// Copies the directory.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool CopyDirectory(string sourcePath, string destinationPath)
        {
            var sourceDirectoryInfo = new DirectoryInfo(sourcePath);
            var destinationDirectoryInfo = new DirectoryInfo(destinationPath);
            return CopyDirectory(sourceDirectoryInfo, destinationDirectoryInfo);
        }

        /// <summary>
        /// Copies the directory.
        /// </summary>
        /// <param name="sourceDirectoryInfo">The source directory info.</param>
        /// <param name="destinationDirectoryInfo">The destination directory info.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool CopyDirectory(DirectoryInfo sourceDirectoryInfo, DirectoryInfo destinationDirectoryInfo)
        {
            if (sourceDirectoryInfo == null)
            {
                throw new ArgumentNullException(@"sourceDirectoryInfo");
            }

            if (destinationDirectoryInfo == null)
            {
                throw new ArgumentNullException(@"destinationDirectoryInfo");
            }

            try
            {
                sourceDirectoryInfo.Refresh();
                destinationDirectoryInfo.Refresh();
                if (sourceDirectoryInfo.Exists)
                {
                    if (destinationDirectoryInfo.Exists)
                    {
                        if (!ClearDirectory(destinationDirectoryInfo))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        destinationDirectoryInfo.Create();
                    }

                    foreach (var subdirectoryInfo in sourceDirectoryInfo.GetDirectories())
                    {
                        var destinationSubDirectoryInfo = new DirectoryInfo(Path.Combine(destinationDirectoryInfo.FullName, subdirectoryInfo.Name));
                        if (!CopyDirectory(subdirectoryInfo, destinationSubDirectoryInfo))
                        {
                            return false;
                        }
                    }

                    foreach (var fileInfo in sourceDirectoryInfo.GetFiles())
                    {
                        var destinationFile = Path.Combine(destinationDirectoryInfo.FullName, fileInfo.Name);
                        File.Copy(fileInfo.FullName, destinationFile, true);
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CopyDirectoryFailedSource_Destination_, sourceDirectoryInfo.FullName, destinationDirectoryInfo.FullName);

                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(message, ex);
                }

                throw new BaseException(message, ex);
            }
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileMode">The file mode.</param>
        /// <param name="fileAccess">The file access.</param>
        /// <returns>The File Stream.</returns>
        public static FileStream OpenFile(string path, FileMode fileMode, FileAccess fileAccess)
        {
            if ((fileAccess == FileAccess.ReadWrite) || (fileAccess == FileAccess.Write))
            {
                var fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                {
                    if ((fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.ReadOnly;
                    }
                }
            }

            string errorMessage;
            Exception errorException;

            try
            {
                return new FileStream(path, fileMode, fileAccess);
            }
            catch (PathTooLongException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedPath_IsTooLong, path);
            }
            catch (FileNotFoundException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedFile_NotFound, path);
            }
            catch (DirectoryNotFoundException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedDirectory_NotFound, path);
            }
            catch (IOException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedIoErrorAccessing_, path);
            }
            catch (SecurityException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedMissingPermissionsToAccess_, path);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedWrongArgumentsAccessing_, path);
            }
            catch (ArgumentNullException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedInvalidPath_, path);
            }
            catch (ArgumentException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedInvalidPath_, path);
            }
            catch (NotSupportedException ex)
            {
                errorException = ex;
                errorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingFileFailedInvalidPath_, path);
            }

            if (Logger.IsErrorEnabled)
            {
                Logger.Error(errorMessage);
            }

            throw new FileException(errorMessage, errorException);
        }

        #endregion
    }
}
