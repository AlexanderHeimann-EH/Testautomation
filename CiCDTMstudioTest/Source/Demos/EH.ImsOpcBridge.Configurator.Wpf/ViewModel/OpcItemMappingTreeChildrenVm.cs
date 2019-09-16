// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcItemMappingTreeChildrenVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The opc item mapping tree children vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class OpcItemMappingTreeChildrenVm
    /// </summary>
    public class OpcItemMappingTreeChildrenVm : TreeViewItemVm
    {
        #region Fields

        /// <summary>
        /// The opc item
        /// </summary>
        private readonly OpcItem opcItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcItemMappingTreeChildrenVm"/> class.
        /// </summary>
        /// <param name="opcItem">The opc item.</param>
        /// <param name="parentRegion">The parent region.</param>
        public OpcItemMappingTreeChildrenVm(OpcItem opcItem, OpcItemMappingTreeRootVm parentRegion)
            : base(parentRegion, true)
        {
            this.opcItem = opcItem;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcItemMappingTreeChildrenVm"/> class.
        /// </summary>
        /// <param name="opcItem">The opc item.</param>
        /// <param name="parentRegion">The parent region.</param>
        public OpcItemMappingTreeChildrenVm(OpcItem opcItem, OpcItemMappingTreeChildrenVm parentRegion)
            : base(parentRegion, true)
        {
            this.opcItem = opcItem;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the opc item id.
        /// </summary>
        /// <value>The opc item id.</value>
        public string OpcItemId
        {
            get
            {
                return this.opcItem.ItemId;
            }
        }

        /// <summary>
        /// Gets the name of the opc item.
        /// </summary>
        /// <value>The name of the opc item.</value>
        public string OpcItemName
        {
            get
            {
                return this.opcItem.Name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the opc item path.
        /// </summary>
        /// <returns>System String.</returns>
        public string GetOpcItemPath()
        {
            return this.GetOpcServerPath() + this.OpcItemId;
        }

        /// <summary>
        /// Gets the opc server path.
        /// </summary>
        /// <returns>System String.</returns>
        public string GetOpcServerPath()
        {
            var opcServerPath = string.Empty;

            var opcItemMappingTreeParent = this.Parent as OpcItemMappingTreeChildrenVm;

            // Gets the OpcItemPath
            if (opcItemMappingTreeParent != null)
            {
                opcServerPath = opcItemMappingTreeParent.GetOpcServerPath();
            }

            var opcItemMappingTreeRootParent = this.Parent as OpcItemMappingTreeRootVm;

            // Gets the leading Server string
            if (opcItemMappingTreeRootParent != null)
            {
                opcServerPath = opcItemMappingTreeRootParent.GetOpcServerPath();
            }

            return opcServerPath;
        }

        /// <summary>
        /// Determines whether [is null or white space] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is null or white space] [the specified value]; otherwise, <c>false</c>.</returns>
        public bool IsNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return string.IsNullOrEmpty(value.Trim());
        }

        /// <summary>
        /// Determines whether [is opc item drag able].
        /// </summary>
        /// <returns><c>true</c> if [is opc item drag able]; otherwise, <c>false</c>.</returns>
        public bool IsOpcItemDragAble()
        {
            return !this.IsNullOrWhiteSpace(this.OpcItemId);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the children.
        /// </summary>
        protected override void LoadChildren()
        {
            foreach (OpcItem opcItemChild in this.opcItem.Children)
            {
                this.Children.Add(new OpcItemMappingTreeChildrenVm(opcItemChild, this));
            }
        }

        #endregion
    }
}