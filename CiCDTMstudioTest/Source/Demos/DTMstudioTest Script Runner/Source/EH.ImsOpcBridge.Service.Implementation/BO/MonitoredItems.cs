// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitoredItems.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the monitored items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using EH.ImsOpcBridge.Service.Implementation.Data;

    using OpcLabs.EasyOpc;
    using OpcLabs.EasyOpc.DataAccess;

    using Descriptor = System.Tuple<string, string>;
    using References = System.Collections.Generic.List<Data.MonitoredItemReference>;

    /// <summary>
    /// Implements the monitored items.
    /// </summary>
    internal class MonitoredItems
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitoredItems"/> class.
        /// </summary>
        /// <param name="opcRefreshRate">The OPC refresh rate in milliseconds.</param>
        public MonitoredItems(int opcRefreshRate)
        {
            this.ItemGroupArgumentList = new List<DAItemGroupArguments>();
            this.ItemDescriptors = new Dictionary<Descriptor, References>();
            this.OpcRefreshRate = opcRefreshRate;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the item group arguments converted to array for the OpcLabs drivers..
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public DAItemGroupArguments[] ItemGroupArguments
        {
            get
            {
                return this.ItemGroupArgumentList.ToArray();
            }
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the item group arguments.
        /// </summary>
        private List<DAItemGroupArguments> ItemGroupArgumentList { get; set; }

        /// <summary>
        /// Gets or sets the item descriptors.
        /// </summary>
        private Dictionary<Descriptor, References> ItemDescriptors { get; set; }

        /// <summary>
        /// Gets or sets the OPC refresh rate for the subscription.
        /// </summary>
        private int OpcRefreshRate { get; set; }

        #endregion

        #region PublicMethods

        /// <summary>
        /// Adds a new item to the collection.
        /// </summary>
        /// <param name="reference">The reference to the corresponding monitored item from the calling client.</param>
        /// <param name="serverClass">The server class.</param>
        /// <param name="itemId">The OPC item id.</param>
        /// <remarks>
        /// This method adds a new item or only the reference when the item exists already.
        /// </remarks>
        public void Add(MonitoredItemReference reference, string serverClass, string itemId)
        {
            var descriptor = new Descriptor(serverClass, itemId);
            References references;

            if (!this.ItemDescriptors.TryGetValue(descriptor, out references))
            {
                references = new References() { reference };
                this.ItemDescriptors.Add(descriptor, references);
                this.ItemGroupArgumentList.Add(
                    new DAItemGroupArguments(
                        new ServerDescriptor(serverClass),
                        new DAItemDescriptor(itemId),
                        new DAGroupParameters(this.OpcRefreshRate),
                        references));
            }
            else
            {
                references.Add(reference);
            }
        }

        #endregion
    }
}
