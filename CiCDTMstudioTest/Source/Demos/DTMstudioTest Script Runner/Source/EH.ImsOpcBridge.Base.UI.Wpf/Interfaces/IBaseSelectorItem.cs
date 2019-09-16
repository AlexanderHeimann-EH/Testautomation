// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseSelectorItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface for item displayed by the base selector control
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Interfaces
{
    /// <summary>
    /// Interface for item displayed by the base selector control
    /// </summary>
    public interface IBaseSelectorItem
    {
        #region Public Properties

        /// <summary>
        /// Gets AutomationId.
        /// </summary>
        string AutomationId { get; }

        /// <summary>
        /// Gets the execute command.
        /// </summary>
        DelegateCommand ExecuteCommand { get; }

        /// <summary>
        /// Gets the general ImageSource.
        /// </summary>
        string ImageSource { get; }

        /// <summary>
        /// Gets Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets ImageSource for selected item.
        /// </summary>
        string SelectedImageSource { get; }

        /// <summary>
        /// Gets SortOrder.
        /// </summary>
        int SortOrder { get; }

        /// <summary>
        /// Gets Text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets the items value.
        /// </summary>
        object Value { get; }

        #endregion
    }
}
