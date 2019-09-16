// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusyIndicator.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of a busy indicator, which can be used to show, that the application is busy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI
{
    using System;

    /// <summary>
    /// Interface of a busy indicator, which can be used to show, that the application is busy.
    /// </summary>
    public interface IBusyIndicator : IDisposable
    {
        /// <summary>
        /// Gets or sets the progress item.
        /// </summary>
        /// <value>The progress item.</value>
        IProgressItem ProgressItem { get; set; }
    }
}
