// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectableConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.MultipleData
{
    /// <summary>
    /// The selectable items.
    /// </summary>
    public class SelectableConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectableConfiguration"/> class.
        /// </summary>
        public SelectableConfiguration()
        {
            this.OperatingSystemItems = new ListOfCategoryAndItems();
            this.CommunicationItems = new ListOfCategoryAndItems();
            this.HostApplicationItems = new ListOfCategoryAndItems();
            this.DeviceFunctionsItems = new ListOfCategoryAndItems();
        }

        /// <summary>
        /// Gets or sets the operating system items.
        /// </summary>
        public ListOfCategoryAndItems OperatingSystemItems { get; set; }

        /// <summary>
        /// Gets or sets the communication items.
        /// </summary>
        public ListOfCategoryAndItems CommunicationItems { get; set; }

        /// <summary>
        /// Gets or sets the host application items.
        /// </summary>
        public ListOfCategoryAndItems HostApplicationItems { get; set; }

        /// <summary>
        /// Gets or sets the device functions items.
        /// </summary>
        public ListOfCategoryAndItems DeviceFunctionsItems { get; set; }
    }
}
