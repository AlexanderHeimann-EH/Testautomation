// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListToObjectConverter.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData;
    using EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The list to object converter.
    /// </summary>
    public static class ListToObjectConverter
    {
        /// <summary>
        /// Converts one dimensional list to ConfigurationItems
        /// </summary>
        /// <param name="foldersAndFiles">List of found folders and items</param>
        /// <param name="selectedConfiguration">Available information from configuration file</param>
        /// <returns>Selectable Items</returns>
        public static SelectableConfiguration ConvertFromListToConfigurationItems(List<string> foldersAndFiles, SelectedConfiguration selectedConfiguration)
        {
            var selectableConfiguration = new SelectableConfiguration();
            var folder = string.Empty;
            CategoryAndItems categoryAndItemsCase3 = null;

            foreach (var item in foldersAndFiles)
            {
                string[] innerStringParts = item.Split(new[] { @"\" }, StringSplitOptions.None);

                switch (innerStringParts.Length)
                {
                    case 3:
                        {
                            // Wenn der Container leer ist
                            if (categoryAndItemsCase3 == null)
                            {
                                categoryAndItemsCase3 = new CategoryAndItems
                                                            {
                                                                Category = innerStringParts[1]
                                                            };
                                categoryAndItemsCase3.Items.Add(innerStringParts[2]);    // Hinzufügen des ersten Listenelements

                                folder = innerStringParts[0];
                            }
                            else
                            {
                                // Wenn es die aktuelle Kategorie bereits gibt
                                if (categoryAndItemsCase3.Category.Equals(innerStringParts[1]))
                                {
                                    categoryAndItemsCase3.Items.Add(innerStringParts[2]);    // Hinzufügen eines weiteren Listenelements
                                }
                                else
                                {
                                    // Wenn es die aktuelle Kategorie noch nicht gibt
                                    AddListToConfigurationItems(selectedConfiguration, selectableConfiguration, categoryAndItemsCase3, folder);  // Einfügen zu den ConfigurationItems
                                    categoryAndItemsCase3 = new CategoryAndItems { Category = innerStringParts[1] };
                                    categoryAndItemsCase3.Items.Add(innerStringParts[2]);

                                    folder = innerStringParts[0];
                                }
                            }

                            break;
                        }

                    default:
                        {
                            var exception = new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ": Unexpected number of elements.");
                            throw exception;
                        }
                }
            }

            AddListToConfigurationItems(selectedConfiguration, selectableConfiguration, categoryAndItemsCase3, folder);
            return selectableConfiguration;
        }

        /// <summary>
        /// Add List To Configuration Items
        /// </summary>
        /// <param name="selectedConfiguration">Available information from configuration file</param>
        /// <param name="selectableConfiguration">Container to store available information from hard disk into</param>
        /// <param name="categoryAndItems">Found category and items to put into "selectableItems"</param>
        /// <param name="folder">Found folder to put into "selectableItems"</param>
        private static void AddListToConfigurationItems(SelectedConfiguration selectedConfiguration, SelectableConfiguration selectableConfiguration, CategoryAndItems categoryAndItems, string folder)
        {
            if (selectedConfiguration.TestEnvironment.Communication.Folder.Equals(folder))
            {
                selectableConfiguration.CommunicationItems.Items.Add(categoryAndItems);
            }

            if (selectedConfiguration.TestEnvironment.HostApplication.Folder.Equals(folder))
            {
                selectableConfiguration.HostApplicationItems.Items.Add(categoryAndItems);
            }

            if (selectedConfiguration.TestEnvironment.OperatingSystem.Folder.Equals(folder))
            {
                selectableConfiguration.OperatingSystemItems.Items.Add(categoryAndItems);
            }

            if (selectedConfiguration.TestEnvironment.DeviceFunction.Folder.Equals(folder))
            {
                selectableConfiguration.DeviceFunctionsItems.Items.Add(categoryAndItems);
            }
        }
    }
}
