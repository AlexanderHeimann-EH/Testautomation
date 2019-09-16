// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.BO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData;
    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The configuration.
    /// </summary>
    public static class Configuration
    {
        #region Fields

        /// <summary>
        /// The path to configuration xml.
        /// </summary>
        private static string pathToConfigurationXml;

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        public static SelectedConfiguration SelectedConfiguration { get; set; }

        /// <summary>
        /// Gets the selectable items.
        /// </summary>
        public static SelectableConfiguration SelectableConfiguration { get; private set; }

        /// <summary>
        /// Gets path to frame specific code
        /// </summary>
        public static string HostApplication
        {
            get
            {
                return StringCombine.Combine(new[] 
                {
                    SelectedConfiguration.TestFramework.PathToAssemblies, 
                    SelectedConfiguration.TestEnvironment.HostApplication.Folder, 
                    SelectedConfiguration.TestEnvironment.HostApplication.Category, 
                    SelectedConfiguration.TestEnvironment.HostApplication.Assembly
                });
            }
        }

        /// <summary>
        /// Gets path to Host Application Namespace
        /// </summary>
        public static string HostApplicationNamespace
        {
            get
            {
                return SelectedConfiguration.TestEnvironment.HostApplication.AssemblyNamespace;
            }
        }

        /// <summary>
        /// Gets path to frame specific code
        /// </summary>
        public static string Communication
        {
            get
            {
                return StringCombine.Combine(new[] 
                {
                    SelectedConfiguration.TestFramework.PathToAssemblies, 
                    SelectedConfiguration.TestEnvironment.Communication.Folder, 
                    SelectedConfiguration.TestEnvironment.Communication.Category, 
                    SelectedConfiguration.TestEnvironment.Communication.Assembly
                });
            }
        }

        /// <summary>
        /// Gets path to Communication Namespace
        /// </summary>
        public static string CommunicationNamespace
        {
            get
            {
                return SelectedConfiguration.TestEnvironment.Communication.AssemblyNamespace;
            }
        }

        /// <summary>
        /// Gets path to operating system specific code
        /// </summary>
        public static string OperatingSystem
        {
            get
            {
                return StringCombine.Combine(new[] 
                {
                    SelectedConfiguration.TestFramework.PathToAssemblies, 
                    SelectedConfiguration.TestEnvironment.OperatingSystem.Folder, 
                    SelectedConfiguration.TestEnvironment.OperatingSystem.Category, 
                    SelectedConfiguration.TestEnvironment.OperatingSystem.Assembly
                });
            }
        }

        /// <summary>
        /// Gets path to Operating SystemNamespace
        /// </summary>
        public static string OperatingSystemNamespace
        {
            get
            {
                return SelectedConfiguration.TestEnvironment.OperatingSystem.AssemblyNamespace;
            }
        }

        /// <summary>
        /// Gets path to DeviceFunction specific code
        /// </summary>
        public static string DeviceFunction
        {
            get
            {
                return StringCombine.Combine(new[] 
                {
                    SelectedConfiguration.TestFramework.PathToAssemblies, 
                    SelectedConfiguration.TestEnvironment.DeviceFunction.Folder, 
                    SelectedConfiguration.TestEnvironment.DeviceFunction.Category, 
                    SelectedConfiguration.TestEnvironment.DeviceFunction.Assembly
                });
            }
        }

        /// <summary>
        /// Gets path to DeviceFunctionNamespace
        /// </summary>
        public static string DeviceFunctionNamespace
        {
            get
            {
                return SelectedConfiguration.TestEnvironment.DeviceFunction.AssemblyNamespace;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="pathToXmlFile">
        /// The xml file.
        /// </param>
        public static void Initialize(string pathToXmlFile)
        {
            if (pathToXmlFile == string.Empty)
            {
                pathToXmlFile = GetXmlSourcePath();
            }

            if (pathToXmlFile != string.Empty)
            {
                pathToConfigurationXml = pathToXmlFile;

                var fileInfoToXmlFile = new FileInfo(pathToXmlFile);
                if (!fileInfoToXmlFile.Exists)
                {
                    XmlFileHandler.WriteEmptyXmlFile(pathToXmlFile, RegistryHandler.GetPathFromRegistry());
                }

                SelectedConfiguration = XmlFileHandler.ReadDataFromXml(pathToConfigurationXml);
                ValidateTestFrameworkPaths();
                GetDataFromHardDisk();
            }
            else
            {
                var exception = new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ": No valid path is available during initialization.");
                throw exception;
            }
        }

        #endregion 

        #region private methods

        /// <summary>
        /// Starts recursive call to get folders and functions for configuration dialog
        /// </summary>
        private static void GetDataFromHardDisk()
        {
            var foldersAndFiles = new List<string>();
            foldersAndFiles = GetDataFromDirectory(SelectedConfiguration.TestFramework.PathToAssemblies, foldersAndFiles);
            foldersAndFiles = CleanListOfFoldersAndFiles(SelectedConfiguration.TestFramework.PathToAssemblies, foldersAndFiles);
            SelectableConfiguration = ListToObjectConverter.ConvertFromListToConfigurationItems(foldersAndFiles, SelectedConfiguration);
        }

        /// <summary>
        /// The get data from directory.
        /// </summary>
        /// <param name="currentDirectory">
        /// The current directory.
        /// </param>
        /// <param name="listOfStrings">
        /// The list of strings.
        /// </param>
        /// <returns>
        /// The List of strings
        /// </returns>
        private static List<string> GetDataFromDirectory(string currentDirectory, List<string> listOfStrings)
        {
            string[] files = Directory.GetFiles(currentDirectory);
            string[] directories = Directory.GetDirectories(currentDirectory);

            if (files.Length > 0)
            {
                if (!(files.Length > 0 && directories.Length > 0))
                {
                    foreach (var file in files)
                    {
                        listOfStrings.Add(file);
                    }
                }
            }

            if (directories.Length <= 0)
            {
                return listOfStrings;
            }

            foreach (var directory in directories)
            {
                listOfStrings.Add(directory);
                GetDataFromDirectory(directory, listOfStrings);
            }

            return listOfStrings;
        }

        /// <summary>
        /// The clean list of folders and files.
        /// </summary>
        /// <param name="partOfPathToDelete">
        /// The part of path to delete.
        /// </param>
        /// <param name="foldersAndFiles">
        /// The folders and files.
        /// </param>
        /// <returns>
        /// The List of strings
        /// </returns>
        private static List<string> CleanListOfFoldersAndFiles(string partOfPathToDelete, IEnumerable<string> foldersAndFiles)
        {
            var modidfiedList = new List<string>();

            foreach (var stringInList in foldersAndFiles)
            {
                if (stringInList.Contains(".dll"))
                {
                    var toModify = stringInList;
                    toModify = toModify.Replace(".dll", string.Empty);

                    toModify = partOfPathToDelete[partOfPathToDelete.Length - 1] != '\\' ? toModify.Replace(partOfPathToDelete + "\\", string.Empty) : toModify.Replace(partOfPathToDelete, string.Empty);

                    modidfiedList.Add(toModify);
                }
            }

            return modidfiedList;
        }

        /// <summary>
        /// The get xml source path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetXmlSourcePath()
        {
            // Bin Verzeichnis, Unterordener ConfigData
            string configFile = Directory.GetCurrentDirectory() + @"\ConfigData\Configuration.xml";
            FileInfo fileInfoConfig = new FileInfo(configFile);

            if (fileInfoConfig.Exists)
            {
                System.Diagnostics.Debug.Print(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ": Bin-Folder-path is used [" + fileInfoConfig.FullName + "].");
                return fileInfoConfig.FullName;
            }

            System.Diagnostics.Debug.Print(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ": Path is invalid.");
            return string.Empty;
        }

        /// <summary>
        /// The validate test framework paths.
        /// </summary>
        private static void ValidateTestFrameworkPaths()
        {
            string pathToAssemblies = SelectedConfiguration.TestFramework.PathToAssemblies;

            if (pathToConfigurationXml != string.Empty)
            {
                var fileInfoConfiguration = new FileInfo(pathToConfigurationXml);
                if (!fileInfoConfiguration.Exists)
                {
                    GetPathToConfigurationXml();
                }
            }
            else
            {
                GetPathToConfigurationXml();
            }

            if (pathToAssemblies != string.Empty)
            {
                var directoryInfoAssembly = new DirectoryInfo(pathToAssemblies);
                if (!directoryInfoAssembly.Exists)
                {
                    GetPathToAssemblies();
                }
            }
            else
            {
                GetPathToAssemblies();
            }
        }

        /// <summary>
        /// The get path to configuration xml.
        /// </summary>
        private static void GetPathToConfigurationXml()
        {
            var folderBrowser = new FolderBrowserDialog
                                    {
                                        Description = "Select Path to Configuration.xml",
                                        SelectedPath = @"C:\"
                                    };

            var objResult = folderBrowser.ShowDialog();
            if (objResult == DialogResult.OK)
            {
                pathToConfigurationXml = folderBrowser.SelectedPath + @"\Configuration.xml";
            }
            else
            {
                MessageBox.Show("Please select a valid path to Configuration.xml");
            }
        }

        /// <summary>
        /// The get path to assemblies.
        /// </summary>
        private static void GetPathToAssemblies()
        {
            var folderBrowser = new FolderBrowserDialog
                                    {
                                        Description = "Select Path to Assemblies",
                                        SelectedPath = RegistryHandler.GetPathFromRegistry()
                                    };

            if (folderBrowser.SelectedPath == string.Empty)
            {
                folderBrowser.SelectedPath = @"C:\";
            }

            DialogResult objResult = folderBrowser.ShowDialog();
            if (objResult == DialogResult.OK)
            {
                SelectedConfiguration.TestFramework.PathToAssemblies = folderBrowser.SelectedPath;
            }
            else
            {
                MessageBox.Show("Please select a valid path to TestFramework-Assemblies.");
            }
        }

        #endregion
    }
}
