// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The task event argument class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// The task event argument class.
    /// </summary>
    public class TaskEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public TaskEventArgs(ITaskItem item)
        {
            this.Item = item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the task item, which has changed.
        /// </summary>
        /// <value>The task item</value>
        public ITaskItem Item { get; private set; }

        #endregion
    }
}
