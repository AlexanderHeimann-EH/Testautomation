// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNameHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.TestScriptEngine.Reporting
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// The file name handler.
    /// </summary>
    public static class FileNameHandler
    {
        /// <summary>
        /// The relative path to test case.
        /// </summary>
        /// <param name="basePath">
        /// The base path.
        /// </param>
        /// <param name="fullPath">
        /// The full path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string RelativePathToTestCase(string basePath, string fullPath)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            string buffer = fullPath.Replace(basePath, string.Empty);
            return buffer.Remove(0, 1);
        }

        /// <summary>
        /// The get relative path to overview.
        /// </summary>
        /// <param name="baseFolder">
        /// The base folder.
        /// </param>
        /// <param name="currentFolder">
        /// The current folder.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetRelativePathToOverview(string baseFolder, string currentFolder)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            string buffer = currentFolder.Replace(baseFolder, string.Empty);
            string[] parts = buffer.Split(Convert.ToChar("\\"));
            buffer = string.Empty;
            foreach (var part in parts)
            {
                if (part != string.Empty)
                {
                    string value = part;
                    value = value.Replace(value, "\\..");
                    buffer = buffer + value;
                }
            }

            buffer = buffer.Remove(0, 1);
            return buffer;
        }

        /// <summary>
        /// The is path to long.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsPathToLong(string path)
        {
            if (path.Length > 255)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The trim path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="extension">
        /// The extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string TrimPath(string path, string extension)
        {
            int currentLength = path.Length;
            int overlength = currentLength - 256;

            char pathSeperator = '\\';
            string[] partsOfPath = path.Split(pathSeperator);

            string lastPathElement = partsOfPath[partsOfPath.Length - 1];
            lastPathElement = lastPathElement.Replace(extension, string.Empty);
            if (overlength > lastPathElement.Length)
            {
                Console.WriteLine("Filename of path [" + path + "] cannot be shortened to fit into 256 characters, without loosing folder(s) from the path.");
                return null;
            }

            int lastPartElementLength = lastPathElement.Length;
            lastPathElement = lastPathElement.Remove(lastPartElementLength - overlength, overlength);
            Console.WriteLine(lastPathElement);
            partsOfPath[partsOfPath.Length - 1] = lastPathElement + extension;
            return StringCombine.Combine(partsOfPath);
        }
    }
}
