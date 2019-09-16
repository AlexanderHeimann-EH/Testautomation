// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.UI.Wpf
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 05-02-2013
// ***********************************************************************
// <copyright file="IBaseCommandItem.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.UI.Wpf.Interfaces
{
    using System.Windows.Input;

    /// <summary>
    /// Interface for command item
    /// </summary>
    public interface IBaseCommandItem
    {
        #region Public Properties

        /// <summary>
        /// Gets AutomationId.
        /// </summary>
        /// <value>The automation id.</value>
        string AutomationId { get; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        ICommand Command { get; }

        /// <summary>
        /// Gets the general ImageSource.
        /// </summary>
        /// <value>The image source.</value>
        string ImageSource { get; }

        /// <summary>
        /// Gets the index of the sort.
        /// </summary>
        /// <value>The index of the sort.</value>
        int SortIndex { get; }

        /// <summary>
        /// Gets Text.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; }

        #endregion
    }
}
