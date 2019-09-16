// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZipHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template
{
    using System;
    using System.IO;
    using Ionic.Zip;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// The zip handler.
    /// </summary>
    public static class ZipHandler
    {
        /// <summary>
        /// The unzip.
        /// </summary>
        /// <param name="pathAndNameOfZipFile">
        /// The zip file.
        /// </param>
        /// <param name="folderToExtract">
        /// The folder to extract.
        /// </param>
        /// <exception cref="FileNotFoundException">File Not Found Exception
        /// </exception>
        public static void Unzip(string pathAndNameOfZipFile, string folderToExtract)
        {
            if (!File.Exists(pathAndNameOfZipFile))
            {
                throw new FileNotFoundException();
            }

            if (!Directory.Exists(folderToExtract))
            {
                Directory.CreateDirectory(folderToExtract);
            }

            try
            {
                ZipFile zipFile = new ZipFile(pathAndNameOfZipFile);
                zipFile.ExtractAll(folderToExtract);
            }
            catch (Exception exception)
            {
                Log.ErrorEx(string.Empty, exception, exception.Message);
                throw;
            }
        }
    }
}
