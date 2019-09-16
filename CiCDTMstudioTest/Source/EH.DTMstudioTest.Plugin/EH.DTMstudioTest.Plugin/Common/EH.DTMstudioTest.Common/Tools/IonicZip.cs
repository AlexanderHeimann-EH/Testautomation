// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IonicZip.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Tools
{
    using System.Linq;

    using Ionic.Zip;

    /// <summary>
    /// The ionic zip.
    /// </summary>
    public class IonicZip
    {
        #region Public Methods and Operators

        /// <summary>
        /// The extract file from archive.
        /// </summary>
        /// <param name="zipFile">
        /// The zip file.
        /// </param>
        /// <param name="extractFile">
        /// The extract file.
        /// </param>
        /// <param name="extractPath">
        /// The extract path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ExtractFileFromArchive(string zipFile, string extractFile, string extractPath)
        {
            var result = false;

            using (var zip = ZipFile.Read(zipFile))
            {
                foreach (var e in zip.Where(x => x.FileName == extractFile))
                {
                    e.Extract(extractPath);
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}