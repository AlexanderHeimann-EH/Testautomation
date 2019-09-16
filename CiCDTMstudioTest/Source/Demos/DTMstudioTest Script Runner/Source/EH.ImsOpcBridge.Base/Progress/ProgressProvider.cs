// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressProvider.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Progress
{
    using EH.ImsOpcBridge.Helpers;

    /// <summary>
    /// A progress provider.
    /// </summary>
    public class ProgressProvider : IProgressProvider
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressProvider" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="context">The context.</param>
        public ProgressProvider(TranslatableString title, object context)
        {
            this.ProgressTitle = title;
            this.ProgressContext = context;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public object ProgressContext { get; set; }

        /// <summary>
        /// Gets or sets the title of the progress to be displayed.
        /// </summary>
        /// <value>The title.</value>
        public ITranslatableString ProgressTitle { get; set; }

        #endregion
    }
}
