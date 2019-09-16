// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.Interfaces
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 05-07-2013
// ***********************************************************************
// <copyright file="IProgressItem.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge
{
    using System;

    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of the progress item, which is used to report a progress.
    /// </summary>
    public interface IProgressItem : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Fired when a progress item has been canceled
        /// </summary>
        event EventHandler<ProgressEventArgs> Canceled;

        /// <summary>
        /// Fired when a progress item changes
        /// </summary>
        event EventHandler<ProgressEventArgs> Changed;

        /// <summary>
        /// Fired when a progress item has been completed
        /// </summary>
        event EventHandler<ProgressEventArgs> Completed;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this item can be canceled.
        /// </summary>
        /// <value><c>true</c> if this progress item can be canceled; otherwise, <c>false</c>.</value>
        bool CancelEnabled { get; set; }

        /// <summary>
        /// Gets or sets the current count of the progress.
        /// </summary>
        /// <value>The current count of the progress.</value>
        int CountCurrent { get; set; }

        /// <summary>
        /// Gets the total count of the progress.
        /// </summary>
        /// <value>The total count of the progress.</value>
        int CountTotal { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this item is be canceled
        /// </summary>
        /// <value><c>true</c> if canceled; otherwise, <c>false</c>.</value>
        bool IsCanceled { get; set; }

        /// <summary>
        /// Gets a value indicating whether this item is Complete
        /// </summary>
        /// <value><c>true</c> if this instance is complete; otherwise, <c>false</c>.</value>
        bool IsComplete { get; }

        /// <summary>
        /// Gets a value indicating whether this progress item is active.
        /// </summary>
        /// <value><c>true</c> if this instance is progress active; otherwise, <c>false</c>.</value>
        bool IsProgressActive { get; }

        /// <summary>
        /// Gets or sets the percentage value between 0 and 100 indicating progress.
        /// </summary>
        /// <value>The percentage.</value>
        int Percentage { get; set; }

        /// <summary>
        /// Gets the progress handler.
        /// </summary>
        /// <value>The progress handler.</value>
        IProgressHandler ProgressHandler { get; }

        /// <summary>
        /// Gets the provider of the progress.
        /// </summary>
        /// <value>The progress provider.</value>
        IProgressProvider ProgressProvider { get; }

        /// <summary>
        /// Gets or sets the text describing this item.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; set; }

        /// <summary>
        /// Gets the title of the progress.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; }

        /// <summary>
        /// Gets the translatable text.
        /// </summary>
        /// <value>The translatable text.</value>
        ITranslatableString TranslatableText { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Cancels the progress item by initiating a call to the specified cancel delegate.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Sets the cancel delegate.
        /// </summary>
        /// <param name="cancelDelegateToSet">The cancel delegate to be called to cancel the progress.</param>
        void SetCancelDelegate(CancelProc cancelDelegateToSet);

        /// <summary>
        /// Indicates that this progress item is canceled.
        /// </summary>
        void SetCanceled();

        /// <summary>
        /// Indicates that this progress item is complete.
        /// </summary>
        void SetComplete();

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        void SetText(ITranslatableString text);

        /// <summary>
        /// Moves the progress bar another step and updates the current text
        /// </summary>
        /// <param name="textUpdate">Text to be displayed.</param>
        void StepUpdate(ITranslatableString textUpdate);

        /// <summary>
        /// Moves the progress bar another step
        /// </summary>
        void StepUpdate();

        #endregion
    }
}
