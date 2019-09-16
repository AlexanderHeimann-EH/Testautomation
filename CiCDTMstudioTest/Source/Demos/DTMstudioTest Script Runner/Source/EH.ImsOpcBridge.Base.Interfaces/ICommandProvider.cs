// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandProvider.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of a component, which offers commands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;

    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of a component, which offers commands.
    /// </summary>
    public interface ICommandProvider : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Fired when a new command is added.
        /// </summary>
        event EventHandler<CommandEventArgs> CommandAdded;

        /// <summary>
        /// Fired when a new command has changed.
        /// </summary>
        event EventHandler<CommandEventArgs> CommandChanged;

        /// <summary>
        /// Fired when a new command is removed.
        /// </summary>
        event EventHandler<CommandEventArgs> CommandRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the commands.
        /// </summary>
        ReadOnlyCollection<ICommandItem> Commands { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="commandSortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="commandText">The commandText.</param>
        /// <param name="commandDescription">The commandDescription.</param>
        /// <param name="commandDoProc">The command procedure to be called to execute the command.</param>
        /// <param name="commandIcon">The icon of the command.</param>
        /// <returns>The new command item.</returns>
        ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc, Icon commandIcon);

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="commandSortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="commandText">The commandText.</param>
        /// <param name="commandDescription">The commandDescription.</param>
        /// <param name="commandDoProc">The command procedure to be called to execute the command.</param>
        /// <returns>The new command item.</returns>
        ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc);

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="commandItem">The command item.</param>
        /// <returns>The new command item.</returns>
        ICommandItem AddCommand(ICommandItem commandItem);

        /// <summary>
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The command with the specified id.</returns>
        ICommandItem FindCommand(string id);

        /// <summary>
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The list of commands with the specified id.</returns>
        ReadOnlyCollection<ICommandItem> FindCommands(string id);

        /// <summary>
        /// Removes the command item.
        /// </summary>
        /// <param name="commandItem">The command item to be removed.</param>
        void RemoveCommand(ICommandItem commandItem);

        #endregion
    }
}
