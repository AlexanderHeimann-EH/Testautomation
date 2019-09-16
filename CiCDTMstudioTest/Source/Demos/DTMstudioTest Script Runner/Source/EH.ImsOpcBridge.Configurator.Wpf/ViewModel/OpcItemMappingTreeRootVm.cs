// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcItemMappingTreeRootVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The opc item mapping tree root vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class OpcItemMappingTreeRootVm
    /// </summary>
    public class OpcItemMappingTreeRootVm : TreeViewItemVm
    {
        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The opc item
        /// </summary>
        private readonly OpcItem opcItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcItemMappingTreeRootVm"/> class.
        /// </summary>
        /// <param name="opcItem">
        /// The opc item.
        /// </param>
        /// <param name="mainWindowVm">
        /// The main window vm.
        /// </param>
        public OpcItemMappingTreeRootVm(OpcItem opcItem, MainWindowVm mainWindowVm)
            : base(null, true)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.opcItem = opcItem;

            this.IsExpanded = true;

            this.RootOpcItemName = this.mainWindowViewModel.ConnectedServer.Name;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the root opc item.
        /// </summary>
        /// <value>The name of the root opc item.</value>
        public string RootOpcItemName
        {
            get
            {
                return this.opcItem.Name;
            }

            set
            {
                this.opcItem.Name = value;
            }
        }

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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the opc server path.
        /// </summary>
        /// <returns>Returns System String.</returns>
        public string GetOpcServerPath()
        {
            return this.mainWindowViewModel.ConnectedServer.ClassId + ",";
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