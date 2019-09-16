// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProgressProvider.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge
{
    /// <summary>
    /// The interface of a progress provider.
    /// </summary>
    public interface IProgressProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        object ProgressContext { get; }

        /// <summary>
        /// Gets the title of the progress to be displayed.
        /// </summary>
        ITranslatableString ProgressTitle { get; }

        #endregion
    }
}
