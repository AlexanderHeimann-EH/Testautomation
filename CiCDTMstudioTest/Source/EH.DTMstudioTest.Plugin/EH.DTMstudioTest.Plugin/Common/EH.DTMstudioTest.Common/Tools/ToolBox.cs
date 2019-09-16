// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Toolbox.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The infrastructure.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    using Microsoft.Build.Evaluation;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;

    /// <summary>
    /// The infrastructure.
    /// </summary>
    public class ToolBox
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get assembly directory.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }

        /// <summary>
        /// The get file stream.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFileStream(string filename)
        {
            var result = string.Empty;

            try
            {
                using (var sr = new StreamReader(filename))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return result;
        }

        /// <summary>
        /// The get project directory by extension.
        /// </summary>
        /// <param name="loadedProjects">
        /// The loaded projects.
        /// </param>
        /// <param name="projectExtension">
        /// The project extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetProjProjectDirectoryByExtension(ICollection<Project> loadedProjects, string projectExtension)
        {
            var directoryPath = string.Empty;

            foreach (var project in loadedProjects)
            {
                var extension = Path.GetExtension(project.FullPath);
                if (extension == null || extension.ToUpper() != projectExtension.ToUpper())
                {
                    continue;
                }

                Debug.Assert(directoryPath == string.Empty, "Multiple DeviceTypeProjecte available!");

                directoryPath = project.DirectoryPath;
                break;
            }

            return directoryPath;
        }

        /// <summary>
        /// The get Project name.
        /// </summary>
        /// <param name="loadedProjects">
        /// The loaded projects.
        /// </param>
        /// <param name="projectExtension">
        /// The project Extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetProjProjectNameByExtension(ICollection<Project> loadedProjects, string projectExtension)
        {
            var projProjectName = string.Empty;

            foreach (var project in loadedProjects)
            {
                var extension = Path.GetExtension(project.FullPath);
                if (extension == null || extension.ToUpper() != projectExtension.ToUpper())
                {
                    continue;
                }

                Debug.Assert(projProjectName == string.Empty, "Multiple DeviceTypeProjecte available!");

                projProjectName = project.GetPropertyValue("ProjectName");
                break;
            }

            return projProjectName;
        }

        /// <summary>
        /// The get project path.
        /// </summary>
        /// <param name="projectNames">
        /// The project Names.
        /// </param>
        /// <param name="projectExtension">
        /// The project Extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetProjectOutputDirByExtension(ICollection<Project> projectNames, string projectExtension)
        {
            var projectOutputPath = string.Empty;

            foreach (var projectName in projectNames)
            {
                var extension = Path.GetExtension(projectName.FullPath);
                if (extension == null || extension.ToUpper() != projectExtension.ToUpper())
                {
                    continue;
                }

                Debug.Assert(projectOutputPath == string.Empty, "Multiple DeviceTypeProjecte available!");

                projectOutputPath = projectName.GetPropertyValue("OutDir");

                break;
            }

            return projectOutputPath;
        }

        /// <summary>
        /// The project path.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetProjectPath(IVsSolution solution)
        {
            uint projectCount;

            var hr = solution.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, 0, null, out projectCount);

            Debug.Assert(hr == VSConstants.S_OK, "GetProjectFilesInSolution failed.");

            var projectNames = new string[projectCount];
            var projProjectPath = string.Empty;

            hr = solution.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, projectCount, projectNames, out projectCount);

            Debug.Assert(hr == VSConstants.S_OK, "GetProjectFilesInSolution failed.");

            foreach (var projectName in projectNames)
            {
                var extension = Path.GetExtension(projectName);
                if (extension == null || extension.ToUpper() != ConstStrings.DeviceTypeProjectExtension.ToUpper())
                {
                    continue;
                }

                projProjectPath = projProjectPath == string.Empty ? projectName : string.Empty;

                Debug.Assert(projProjectPath != string.Empty, "Multiple DeviceTypeProjecte available!");
            }

            return projProjectPath;
        }

        /// <summary>
        /// The get project path by extension.
        /// </summary>
        /// <param name="projectNames">
        /// The project names.
        /// </param>
        /// <param name="projectExtension">
        /// The project extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetProjectPathByExtension(ICollection<Project> projectNames, string projectExtension)
        {
            var projectPath = string.Empty;

            foreach (var projectName in projectNames)
            {
                var extension = Path.GetExtension(projectName.FullPath);
                if (extension == null || extension.ToUpper() != projectExtension.ToUpper())
                {
                    continue;
                }

                Debug.Assert(projectPath == string.Empty, "Multiple DeviceTypeProjecte available!");

                projectPath = projectName.FullPath;

                break;
            }

            return projectPath;
        }

        /// <summary>
        /// The get template version by extension.
        /// </summary>
        /// <param name="loadedProjects">
        /// The loaded projects.
        /// </param>
        /// <param name="projectExtension">
        /// The project extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetTemplateVersionByExtension(ICollection<Project> loadedProjects, string projectExtension)
        {
            var templateVersion = string.Empty;

            foreach (var project in loadedProjects)
            {
                var extension = Path.GetExtension(project.FullPath);
                if (extension == null || extension.ToUpper() != projectExtension.ToUpper())
                {
                    continue;
                }

                Debug.Assert(templateVersion == string.Empty, "Multiple DeviceTypeProjecte available!");

                templateVersion = project.GetPropertyValue("TemplateVersion");
                break;
            }

            return templateVersion;
        }

        /// <summary>
        /// The get test framework install path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetTestFrameworkInstallPath()
        {
            return (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);
        }

        /// <summary>
        /// The set setup delivery test.
        /// </summary>
        /// <param name="filename">
        /// The setup delivery file.
        /// </param>
        /// <param name="fileStream">
        /// The content.
        /// </param>
        public static void SetFileStream(string filename, string fileStream)
        {
            try
            {
                // Pass the filepath and filename to the StreamWriter Constructor
                var sw = new StreamWriter(filename);

                // Write a line of text
                sw.WriteLine(fileStream);

                // Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        #endregion
    }
}