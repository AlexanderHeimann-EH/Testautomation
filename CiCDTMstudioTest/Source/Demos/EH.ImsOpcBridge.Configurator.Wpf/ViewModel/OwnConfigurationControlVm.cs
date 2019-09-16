// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnConfigurationControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The main window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.View;

    /// <summary>
    /// Class OwnConfigurationControlVm
    /// </summary>
    public class OwnConfigurationControlVm : DependencyObject, IDisposable
    {
        #region Static Fields

        /// <summary>
        /// The content control automation id property
        /// </summary>
        public static readonly DependencyProperty ContentControlAutomationIdProperty = DependencyProperty.Register("ContentControlAutomationId", typeof(string), typeof(OwnConfigurationControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The content property
        /// </summary>
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(UserControl), typeof(OwnConfigurationControlVm), new PropertyMetadata(default(UserControl)));

        /// <summary>
        /// The is own configuration control visible property
        /// </summary>
        public static readonly DependencyProperty IsOwnConfigurationControlVisibleProperty = DependencyProperty.Register("IsOwnConfigurationControlVisible", typeof(bool), typeof(OwnConfigurationControlVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The window automation id property
        /// </summary>
        public static readonly DependencyProperty WindowAutomationIdProperty = DependencyProperty.Register("WindowAutomationId", typeof(string), typeof(OwnConfigurationControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnConfigurationControlVm"/> class.
        /// </summary>
        public OwnConfigurationControlVm()
        {
            this.Initialize();
            this.IsOwnConfigurationControlVisible = false;

            var page = new OwnConfigurationInformationControl();
            var viewModel = new OwnConfigurationInformationControlVm();

            this.GoToPage(page, viewModel);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OwnConfigurationControlVm"/> class.
        /// </summary>
        ~OwnConfigurationControlVm()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public UserControl Content
        {
            get
            {
                return (UserControl)this.GetValue(ContentProperty);
            }

            set
            {
                this.SetValue(ContentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the content control automation id.
        /// </summary>
        /// <value>The content control automation id.</value>
        public string ContentControlAutomationId
        {
            get
            {
                return (string)this.GetValue(ContentControlAutomationIdProperty);
            }

            set
            {
                this.SetValue(ContentControlAutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is own configuration control visible.
        /// </summary>
        /// <value><c>true</c> if this instance is own configuration control visible; otherwise, <c>false</c>.</value>
        public bool IsOwnConfigurationControlVisible
        {
            get
            {
                return (bool)this.GetValue(IsOwnConfigurationControlVisibleProperty);
            }

            set
            {
                this.SetValue(IsOwnConfigurationControlVisibleProperty, value);
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

        #region Public Methods and Operators

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Goes to page.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="viewModel">The view model.</param>
        /// <exception cref="System.ArgumentNullException">@view xxx</exception>
        public void GoToPage(UserControl view, PageViewModel viewModel)
        {
            if (view == null)
            {
                throw new ArgumentNullException(@"view");
            }

            if (viewModel != null)
            {
                view.DataContext = viewModel;
            }

            this.Content = view;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            // ReSharper disable LocalizableElement
            this.WindowAutomationId = @"OwnConfigurationControl";
            this.ContentControlAutomationId = @"Content";

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
