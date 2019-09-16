// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandResult.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The interface to a result of a command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    /// <summary>
    /// The interface to a result of a command.
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// Gets a value indicating whether the command <see cref="ICommandResult"/> is succeeded.
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Gets the result of the command.
        /// </summary>
        object Result { get; }

        /// <summary>
        /// Gets the exception, which occurred during execution.
        /// </summary>
        Exception Exception { get; }
    }
}
