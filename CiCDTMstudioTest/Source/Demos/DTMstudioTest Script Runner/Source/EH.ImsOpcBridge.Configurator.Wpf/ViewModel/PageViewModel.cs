// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The page view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Class PageViewModel
    /// </summary>
    public class PageViewModel : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The title property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PageViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The window automation id property
        /// </summary>
        public static readonly DependencyProperty WindowAutomationIdProperty = DependencyProperty.Register("WindowAutomationId", typeof(string), typeof(PageViewModel), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModel"/> class.
        /// </summary>
        protected PageViewModel()
        {
            // ReSharper disable LocalizableElement
            this.Initialize(@"PageViewModel");

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModel"/> class.
        /// </summary>
        /// <param name="pageTitle">The page title.</param>
        /// <param name="automationId">The automation id.</param>
        protected PageViewModel(string pageTitle, [Localizable(false)] string automationId)
        {
            this.Title = pageTitle;
            this.Initialize(automationId);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return (string)this.GetValue(TitleProperty);
            }

            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the window automation id.
        /// </summary>
        /// <value>The window automation id.</value>
        public string WindowAutomationId
        {
            get
            {
                return (string)this.GetValue(WindowAutomationIdProperty);
            }

            set
            {
                this.SetValue(WindowAutomationIdProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified automation id.
        /// </summary>
        /// <param name="automationId">The automation id.</param>
        private void Initialize(string automationId)
        {
            this.WindowAutomationId = automationId;
        }

        #endregion
    }
}
