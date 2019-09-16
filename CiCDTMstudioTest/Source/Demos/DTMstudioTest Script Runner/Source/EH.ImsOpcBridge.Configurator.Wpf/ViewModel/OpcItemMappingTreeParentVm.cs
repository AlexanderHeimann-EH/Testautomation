// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcItemMappingTreeParentVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The opc item mapping tree parent vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class OpcItemMappingTreeParentVm
    /// </summary>
    public class OpcItemMappingTreeParentVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The opc items property
        /// </summary>
        public static readonly DependencyProperty OpcItemsProperty = DependencyProperty.Register("OpcItems", typeof(ObservableCollection<OpcItemMappingTreeRootVm>), typeof(OpcItemMappingTreeParentVm), new PropertyMetadata(default(ObservableCollection<OpcItemMappingTreeRootVm>)));

        /// <summary>
        /// The allow drag property
        /// </summary>
        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(OpcItemMappingTreeParentVm), new PropertyMetadata(true));
  
        #endregion
        
        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcItemMappingTreeParentVm"/> class.
        /// </summary>
        /// <param name="opcItems">The opc items.</param>
        /// <param name="mainWindowVm">The main window vm.</param>
        public OpcItemMappingTreeParentVm(IEnumerable<OpcItem> opcItems, MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;
            this.AllowDrag = true;

            this.OpcItems = new ObservableCollection<OpcItemMappingTreeRootVm>((from opcItem in opcItems select new OpcItemMappingTreeRootVm(opcItem, this.mainWindowViewModel)).ToList());
        }

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Gets or sets the opc items.
        /// </summary>
        /// <value>The opc items.</value>
        public ObservableCollection<OpcItemMappingTreeRootVm> OpcItems
        {
            get
            {
                return (ObservableCollection<OpcItemMappingTreeRootVm>)this.GetValue(OpcItemsProperty);
            }

            set
            {
                this.SetValue(OpcItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether allow drag.
        /// </summary>
        public bool AllowDrag
        {
            get
            {
                return (bool)this.GetValue(AllowDragProperty);
            }

            set
            {
                this.SetValue(AllowDragProperty, value);
            }
        }

        #endregion
    }
}