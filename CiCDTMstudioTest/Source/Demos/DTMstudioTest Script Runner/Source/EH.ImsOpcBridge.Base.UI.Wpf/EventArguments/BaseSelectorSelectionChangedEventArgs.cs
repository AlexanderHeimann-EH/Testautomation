// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSelectorSelectionChangedEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Selection change event argument for a base selector view model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.EventArguments
{
    using System;

    using EH.ImsOpcBridge.UI.Wpf.Interfaces;

    /// <summary>
    /// Selection change event argument for a base selector view model
    /// </summary>
    public class BaseSelectorSelectionChangedEventArgs : EventArgs
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets SelectedItem.
        /// </summary>
        /// <value>The selected item.</value>
        public IBaseSelectorItem SelectedItem { get; set; }

        #endregion
    }
}
