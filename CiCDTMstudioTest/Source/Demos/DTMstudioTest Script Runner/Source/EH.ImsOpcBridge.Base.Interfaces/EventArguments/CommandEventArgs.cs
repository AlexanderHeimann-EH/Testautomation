// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Event arguments for events around commands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// Event arguments for events around commands.
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// The command.
        /// </summary>
        private readonly ICommandItem command;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public CommandEventArgs(ICommandItem command)
        {
            this.command = command;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        public ICommandItem Command
        {
            get
            {
                return this.command;
            }
        }

        #endregion
    }
}
