// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The language control view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Information;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class LanguageControlVm
    /// </summary>
    public class LanguageControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// All languages property
        /// </summary>
        public static readonly DependencyProperty AllLanguagesProperty = DependencyProperty.Register("CurrentLanguages", typeof(ObservableCollection<LanguageControlItemVm>), typeof(LanguageControlVm), new PropertyMetadata(default(ObservableCollection<LanguageControlItemVm>)));

        /// <summary>
        /// The is next page command visible property
        /// </summary>
        public static readonly DependencyProperty IsNextPageCommandVisibleProperty = DependencyProperty.Register("IsNextPageCommandVisible", typeof(Visibility), typeof(LanguageControlVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is previous page command visible property
        /// </summary>
        public static readonly DependencyProperty IsPreviousPageCommandVisibleProperty = DependencyProperty.Register("IsPreviousPageCommandVisible", typeof(Visibility), typeof(LanguageControlVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The selected language property
        /// </summary>
        public static readonly DependencyProperty SelectedLanguageProperty = DependencyProperty.Register("SelectedLanguage", typeof(LanguageControlItemVm), typeof(LanguageControlVm), new PropertyMetadata(default(LanguageControlItemVm)));

        #endregion

        #region Fields

        /// <summary>
        /// The host
        /// </summary>
        private readonly IBaseHost host;

        /// <summary>
        /// The ims opc bridge settings
        /// </summary>
        private readonly ImsOpcBridgeSettings imsOpcBridgeSettings;

        /// <summary>
        /// The next page command
        /// </summary>
        private readonly DelegateCommand nextPageCommand;

        /// <summary>
        /// The previous page command
        /// </summary>
        private readonly DelegateCommand previousPageCommand;

        /// <summary>
        /// All languages
        /// </summary>
        private List<LanguageControlItemVm> allLanguages = new List<LanguageControlItemVm>();

        /// <summary>
        /// The current page
        /// </summary>
        private int currentPage;

        /// <summary>
        /// The number of items per page
        /// </summary>
        private int numberOfItemsPerPage;

        /// <summary>
        /// The number of pages
        /// </summary>
        private int numberOfPages;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageControlVm"/> class.
        /// </summary>
        public LanguageControlVm()
        {
            this.CurrentLanguages = new ObservableCollection<LanguageControlItemVm>();
            this.nextPageCommand = new DelegateCommand(this.GoToNextPage);
            this.previousPageCommand = new DelegateCommand(this.GoToPreviousPage);

            this.Title = Resources.SelectLanguage;
            this.FillAvailableLanguages();

            this.UpdatePage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageControlVm"/> class.
        /// </summary>
        /// <param name="imsOpcBridgeSettings">The ims opc bridge settings.</param>
        /// <param name="host">The host.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "mainWindowVm", Justification = @"Ok here.")]
        public LanguageControlVm(ImsOpcBridgeSettings imsOpcBridgeSettings, IBaseHost host)
        {
            this.host = host;
            this.CurrentLanguages = new ObservableCollection<LanguageControlItemVm>();
            this.nextPageCommand = new DelegateCommand(this.GoToNextPage);
            this.previousPageCommand = new DelegateCommand(this.GoToPreviousPage);

            this.Title = Resources.SelectLanguage;
            this.imsOpcBridgeSettings = imsOpcBridgeSettings;
            this.FillAvailableLanguages();

            this.UpdatePage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageControlVm"/> class.
        /// </summary>
        /// <param name="imsOpcBridgeSettings">The ims opc bridge settings.</param>
        public LanguageControlVm(ImsOpcBridgeSettings imsOpcBridgeSettings)
        {
            this.host = null;
            this.CurrentLanguages = new ObservableCollection<LanguageControlItemVm>();
            this.nextPageCommand = new DelegateCommand(this.GoToNextPage);
            this.previousPageCommand = new DelegateCommand(this.GoToPreviousPage);

            this.Title = Resources.SelectLanguage;
            this.imsOpcBridgeSettings = imsOpcBridgeSettings;
            this.FillAvailableLanguages();

            this.UpdatePage();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the current languages.
        /// </summary>
        /// <value>The current languages.</value>
        public ObservableCollection<LanguageControlItemVm> CurrentLanguages
        {
            get
            {
                return (ObservableCollection<LanguageControlItemVm>)this.GetValue(AllLanguagesProperty);
            }

            private set
            {
                this.SetValue(AllLanguagesProperty, value);
            }
        }

        /// <summary>
        /// Gets the ims opc bridge settings.
        /// </summary>
        /// <value>The ims opc bridge settings.</value>
        public ImsOpcBridgeSettings ImsOpcBridgeSettings
        {
            get
            {
                return this.imsOpcBridgeSettings;
            }
        }

        /// <summary>
        /// Gets or sets the is next page command visible.
        /// </summary>
        /// <value>The is next page command visible.</value>
        public Visibility IsNextPageCommandVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsNextPageCommandVisibleProperty);
            }

            set
            {
                this.SetValue(IsNextPageCommandVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is previous page command visible.
        /// </summary>
        /// <value>The is previous page command visible.</value>
        public Visibility IsPreviousPageCommandVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsPreviousPageCommandVisibleProperty);
            }

            set
            {
                this.SetValue(IsPreviousPageCommandVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets the next page command.
        /// </summary>
        /// <value>The next page command.</value>
        public ICommand NextPageCommand
        {
            get
            {
                return this.nextPageCommand;
            }
        }

        /// <summary>
        /// Gets the previous page command.
        /// </summary>
        /// <value>The previous page command.</value>
        public ICommand PreviousPageCommand
        {
            get
            {
                return this.previousPageCommand;
            }
        }

        /// <summary>
        /// Gets or sets the selected language.
        /// </summary>
        /// <value>The selected language.</value>
        public LanguageControlItemVm SelectedLanguage
        {
            get
            {
                return (LanguageControlItemVm)this.GetValue(SelectedLanguageProperty);
            }

            set
            {
                this.SetValue(SelectedLanguageProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Selects the language.
        /// </summary>
        /// <param name="languageControlItemVm">The language control item vm.</param>
        /// <exception cref="System.ArgumentNullException">@ languageControlItemVm</exception>
        public void SelectLanguage(LanguageControlItemVm languageControlItemVm)
        {
            if (languageControlItemVm == null)
            {
                throw new ArgumentNullException(@"languageControlItemVm");
            }

            if (this.ImsOpcBridgeSettings != null)
            {
                this.ImsOpcBridgeSettings.CultureName = languageControlItemVm.CultureInfo.Name;

                if (this.host != null)
                {
                    var baseCultureInfo = languageControlItemVm.CultureInfo;
                    while (!string.IsNullOrEmpty(baseCultureInfo.Parent.Name))
                    {
                        baseCultureInfo = baseCultureInfo.Parent;
                    }

                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.LanguageSetTo_PleaseRestartImsOpcBridgeToSwitchTo_, LanguageTranslation.GetLanguageDisplayName(baseCultureInfo));
                    this.host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
                else
                {
                    var baseCultureInfo = languageControlItemVm.CultureInfo;
                    while (!string.IsNullOrEmpty(baseCultureInfo.Parent.Name))
                    {
                        baseCultureInfo = baseCultureInfo.Parent;
                    }
                }
            }

            this.UpdatePage();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Goes to next page.
        /// </summary>
        protected void GoToNextPage()
        {
            this.currentPage++;
            this.UpdatePage();
        }

        /// <summary>
        /// Goes to previous page.
        /// </summary>
        protected void GoToPreviousPage()
        {
            this.currentPage--;
            this.UpdatePage();
        }

        /// <summary>
        /// Fills the available languages.
        /// </summary>
        private void FillAvailableLanguages()
        {
            // ReSharper disable LocalizableElement
            this.allLanguages = new List<LanguageControlItemVm>();

            this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("en-US"), this));
            this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("de-de"), this));

            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("fr-fr"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("it-it"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("es-es"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("ja-jp"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("ru-ru"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("zh-cn"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("cs-CZ"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("ar-DZ"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("id-ID"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("ko-KR"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("nl-NL"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("pl-PL"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("pt-PT"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("fi-FI"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("vi-VN"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("tr-TR"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("th-TH"), this));
            ////this.allLanguages.Add(new LanguageControlItemVm(new CultureInfo("sv-SE"), this));
            this.numberOfItemsPerPage = 14;
            this.numberOfPages = (int)Math.Ceiling(this.allLanguages.Count / (double)this.numberOfItemsPerPage);
            this.currentPage = 1;

            this.UpdatePage();

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Updates the page.
        /// </summary>
        private void UpdatePage()
        {
            this.CurrentLanguages.Clear();

            var position = (this.currentPage - 1) * this.numberOfItemsPerPage;
            var addedItems = 0;

            while ((addedItems < this.numberOfItemsPerPage) && (position < this.allLanguages.Count))
            {
                this.CurrentLanguages.Add(this.allLanguages[position]);
                position++;
                addedItems++;
            }

            if (this.numberOfPages > 1)
            {
                this.IsPreviousPageCommandVisible = this.currentPage > 1 ? Visibility.Visible : Visibility.Hidden;

                this.IsNextPageCommandVisible = this.currentPage < this.numberOfPages ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                this.IsNextPageCommandVisible = Visibility.Hidden;
                this.IsPreviousPageCommandVisible = Visibility.Hidden;
            }

            this.previousPageCommand.IsExecutable = this.currentPage > 1;
            this.nextPageCommand.IsExecutable = this.currentPage < this.numberOfPages;

            this.UpdateSelectedLanguage();
        }

        /// <summary>
        /// Updates the selected language.
        /// </summary>
        private void UpdateSelectedLanguage()
        {
            if (this.ImsOpcBridgeSettings != null)
            {
                foreach (var languageItem in this.CurrentLanguages)
                {
                    languageItem.IsSelected = languageItem.CultureInfo.Name == this.ImsOpcBridgeSettings.CultureName;
                }
            }
        }

        #endregion
    }
}