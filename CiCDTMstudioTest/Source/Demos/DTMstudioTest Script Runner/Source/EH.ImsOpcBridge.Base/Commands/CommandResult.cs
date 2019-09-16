// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandResult.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The result of a command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Commands
{
    using System;

    /// <summary>
    /// The result of a command.
    /// </summary>
    public class CommandResult : ICommandResult
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public CommandResult(object result)
        {
            this.Success = true;
            this.Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> the command succeeded.</param>
        /// <param name="result">The result.</param>
        public CommandResult(bool success, object result)
        {
            this.Success = success;
            this.Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="exception">The exception.</param>
        public CommandResult(object result, Exception exception)
        {
            this.Success = false;
            this.Exception = exception;
            this.Result = result;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the exception, which occurred during execution.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the result of the command.
        /// </summary>
        public object Result { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the command succeeded.
        /// </summary>
        public bool Success { get; private set; }

        #endregion
    }
}
