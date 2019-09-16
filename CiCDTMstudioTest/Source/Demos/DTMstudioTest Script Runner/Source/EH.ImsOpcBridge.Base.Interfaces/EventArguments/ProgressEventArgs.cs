// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The progress event argument class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// The progress event argument class.
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ProgressEventArgs(IProgressItem item)
        {
            this.Item = item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the progress item, which has changed.
        /// </summary>
        /// <value>The progress item</value>
        public IProgressItem Item { get; private set; }

        #endregion
    }
}
