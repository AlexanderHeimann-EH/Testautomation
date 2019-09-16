// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandItemBase.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Drawing;

    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of a command.
    /// </summary>
    public interface ICommandItemBase
    {
        #region Public Events

        /// <summary>
        /// Fired when a new command has changed.
        /// </summary>
        event EventHandler<CommandEventArgs> CommandItemChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the command supports undo.
        /// </summary>
        /// <value>Value indicating whether the command supports undo.</value>
        bool CanUndo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICommandItemBase" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        bool Checked { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets the command procedure to be called to execute the command.
        /// </summary>
        /// <value>The do proc.</value>
        CommandProc DoProc { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICommandItemBase" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICommandItemBase" /> is hidden.
        /// </summary>
        /// <value><c>true</c> if hidden otherwise, <c>false</c>.</value>
        bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the icon of the command.
        /// </summary>
        /// <value>The icon of the command.</value>
        Icon Icon { get; set; }

        /// <summary>
        /// Gets the unique command id.
        /// </summary>
        /// <value>The id.</value>
        string Id { get; }

        /// <summary>
        /// Gets or sets the state object of the command.
        /// </summary>
        /// <value>The state object of the command.</value>
        object State { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the command procedure to be called to undo the command.
        /// </summary>
        /// <value>The command procedure to be called to undo the command.</value>
        CommandProc UndoProc { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>The result of the command.</returns>
        ICommandResult DoIt();

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <param name="newDescription">The description to set.</param>
        void SetDescription(ITranslatableString newDescription);

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="newText">The text to set.</param>
        void SetText(ITranslatableString newText);

        /// <summary>
        /// Undoes the command.
        /// </summary>
        void UndoIt();

        #endregion
    }
}
