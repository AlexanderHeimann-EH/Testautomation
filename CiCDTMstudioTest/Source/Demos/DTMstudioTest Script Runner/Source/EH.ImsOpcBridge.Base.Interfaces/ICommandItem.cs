// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface for command item hierarchy
    /// </summary>
    public interface ICommandItem : ICommandProvider, ICommandItemBase
    {
        #region Public Properties

        /// <summary>
        /// Gets the child commands.
        /// </summary>
        /// <value>The child commands.</value>
        ReadOnlyCollection<ICommandItem> ChildCommands { get; }

        /// <summary>
        /// Gets or sets the parent command.
        /// </summary>
        /// <value>The parent command.</value>
        ICommandItem ParentCommand { get; set; }

        /// <summary>
        /// Gets or sets the sort index of the command item.
        /// </summary>
        /// <value>The sort index of the command item.</value>
        int SortIndex { get; set; }

        #endregion
    }
}
