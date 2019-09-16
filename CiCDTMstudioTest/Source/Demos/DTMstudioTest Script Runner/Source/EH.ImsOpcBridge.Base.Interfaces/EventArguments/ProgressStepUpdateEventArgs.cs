// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressStepUpdateEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Argument class for ProgressStepUpdate event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// Argument class for ProgressStepUpdate event.
    /// </summary>
    public class ProgressStepUpdateEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Text describing the progress.
        /// </summary>
        private readonly string message;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressStepUpdateEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ProgressStepUpdateEventArgs(string message)
        {
            this.message = message;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text describing the progress.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        #endregion
    }
}
