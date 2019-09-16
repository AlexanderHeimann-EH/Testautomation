// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressItemEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Selection change event argument for a base selector view model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.EventArguments
{
    using System;

    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    /// <summary>
    /// Progress item completed
    /// </summary>
    public class ProgressItemEventArgs : EventArgs
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets completed item.
        /// </summary>
        /// <value>The completed item.</value>
        public ProgressItemVm CompletedItem { get; set; }

        #endregion
    }
}
