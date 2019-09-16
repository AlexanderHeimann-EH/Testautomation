// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlFileHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.BO
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The xml file handler.
    /// </summary>
    public static class XmlFileHandler
    {
        /// <summary>
        /// Read data from xml-file
        /// </summary>
        /// <param name="fileName">
        /// name of xml-file
        /// </param>
        /// <returns>
        /// Selected Items
        /// </returns>
        public static SelectedConfiguration ReadDataFromXml(string fileName)
        {
            try
            {
                var serializerObj = new XmlSerializer(typeof(SelectedConfiguration));
                if (File.Exists(fileName))
                {
                    var fileReader = new FileStream(fileName, FileMode.Open);
                    var selectedConfiguration = (SelectedConfiguration)serializerObj.Deserialize(fileReader);
                    fileReader.Close();
                    return selectedConfiguration;    
                }

                MessageBox.Show(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + " Error: file does not exist [" + fileName + "]");
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + " Error: file could not be read." + "\n" + fileName + "\n\n" + exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Write data into xml-file
        /// </summary>
        /// <param name="selectedConfiguration">source object</param>
        /// <param name="fileName">name of xml-file</param>
        public static void WriteDataToXml(SelectedConfiguration selectedConfiguration, string fileName)
        {
            var fileDirectory = Path.GetDirectoryName(fileName);
            if (fileDirectory != null && !Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            try
            {
                var serializerObj = new XmlSerializer(typeof(SelectedConfiguration));
                TextWriter writeFileStream = new StreamWriter(fileName);
                serializerObj.Serialize(writeFileStream, selectedConfiguration);
                writeFileStream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + " Error: file could not be written." + "\n" + fileName + "\n\n" + exception.Message);
                throw;
            }
        }

        /// <summary>
        /// Write an nearly empty xml-file
        /// </summary>
        /// <param name="pathToConfigurationXml">
        /// The path To Configuration Xml.
        /// </param>
        /// <param name="pathToAssemblies">
        /// The path To Assemblies.
        /// </param>
        public static void WriteEmptyXmlFile(string pathToConfigurationXml, string pathToAssemblies)
        {
            var selectedConfiguration = new SelectedConfiguration 
            {
                TestFramework = 
                {
                    PathToAssemblies = pathToAssemblies
                }
            };

            WriteDataToXml(selectedConfiguration, pathToConfigurationXml);
        }
    }
}
