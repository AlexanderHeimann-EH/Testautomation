// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HowToUseVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Available pages in the how to use control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Navigation;

    using EH.ImsOpcBridge.Common.Serialization;
    using EH.ImsOpcBridge.Configuration;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Information;
    using EH.ImsOpcBridge.Support;
    using EH.ImsOpcBridge.UI.Wpf;
    using EH.ImsOpcBridge.UI.Wpf.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    using log4net;

    /// <summary>
    /// Enum HowToUsePage
    /// </summary>
    public enum HowToUsePage
    {
        /// <summary>
        /// The about
        /// </summary>
        About,

        /// <summary>
        /// The manual
        /// </summary>
        Manual
    }

    /// <summary>
    /// Class HowToUseVm
    /// </summary>
    public class HowToUseVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The about documentation view model property
        /// </summary>
        public static readonly DependencyProperty AboutDocumentationViewModelProperty = DependencyProperty.Register("AboutDocumentationViewModel", typeof(DocumentationVm), typeof(HowToUseVm), new PropertyMetadata(default(DocumentationVm)));

        /// <summary>
        /// The actual page property
        /// </summary>
        public static readonly DependencyProperty ActualPageProperty = DependencyProperty.Register("ActualPage", typeof(HowToUsePage), typeof(HowToUseVm), new PropertyMetadata(default(HowToUsePage)));

        /// <summary>
        /// The choice property
        /// </summary>
        public static readonly DependencyProperty ChoiceProperty = DependencyProperty.Register("Choice", typeof(BaseSelectorControlViewModel), typeof(HowToUseVm), new PropertyMetadata(default(BaseSelectorControlViewModel)));

        /// <summary>
        /// The manual documentation view model property
        /// </summary>
        public static readonly DependencyProperty ManualDocumentationViewModelProperty = DependencyProperty.Register("ManualDocumentationViewModel", typeof(DocumentationVm), typeof(HowToUseVm), new PropertyMetadata(default(DocumentationVm)));

        /// <summary>
        /// The settings view model property
        /// </summary>
        public static readonly DependencyProperty SettingsViewModelProperty = DependencyProperty.Register("SettingsViewModel", typeof(SettingsVm), typeof(HowToUseVm), new PropertyMetadata(default(SettingsVm)));

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The contact support command
        /// </summary>
        private readonly ICommand contactSupportCommand;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HowToUseVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public HowToUseVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.Choice = new BaseSelectorControlViewModel();
            this.Choice.SelectedItemChanged += this.ChoiceSelectedItemChangedHandler;

            this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.HowToUseCommandManual, string.Empty, string.Empty, "automId_Manual", HowToUsePage.Manual, 1));
            this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.HowToUseCommandAbout, string.Empty, string.Empty, "automId_About", HowToUsePage.About, 2));

            // About documentation view model
            this.AboutDocumentationViewModel = new DocumentationVm(0);

            var documentationItem = new DocumentationItemVm(this.AboutDocumentationViewModel, Resources.Imprint, Resources.EndressHauser, @"EH.ImsOpcBridge.Configurator.Resources.Documents.HowToUseAboutImprintDocument.xaml", 230, null, 0, true, @"Imprint");
            documentationItem.IsExpanded = false;
            this.AboutDocumentationViewModel.DocumentationItems.Add(documentationItem);

            documentationItem = new DocumentationItemVm(this.AboutDocumentationViewModel, Resources.OpenSource, Resources.OpenSourceSoftware, @"EH.ImsOpcBridge.Configurator.Resources.Documents.HowToUseAboutOpenSourceDocument.xaml", 100, null, 0, true, @"OpenSource");
            documentationItem.IsExpanded = false;

            var link = documentationItem.Document.FindName(@"LoggingServices") as Hyperlink;

            if (link != null)
            {
                link.RequestNavigate += this.HyperlinkRequestNavigate;
            }

            link = documentationItem.Document.FindName(@"ZIPComponent") as Hyperlink;

            if (link != null)
            {
                link.RequestNavigate += this.HyperlinkRequestNavigate;
            }

            this.AboutDocumentationViewModel.DocumentationItems.Add(documentationItem);

            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"EH.ImsOpcBridge.Configurator.Resources.Documents.HowToUseAboutVersionDocument.xaml"))
            {
                if (resourceStream != null)
                {
                    var flowDocument = XamlReader.Load(resourceStream) as FlowDocument;

                    if (flowDocument != null)
                    {
                        var stringBuiler = new StringBuilder();
                        var firstItem = true;

                        // ReSharper disable LocalizableElement
                        var sortedQuery = from item in AssemblyManagement.LoadedAssemblies orderby item.Name select item;
                        foreach (var assemblyInformation in sortedQuery.ToArray())
                        {
                            if (!firstItem)
                            {
                                stringBuiler.Append(@", ");
                            }

                            stringBuiler.Append(assemblyInformation.Name);
                            stringBuiler.Append(@"[");
                            stringBuiler.Append(assemblyInformation.Version);
                            stringBuiler.Append(@"]");
                            firstItem = false;
                        }

                        // ReSharper restore LocalizableElement
                        var paragraph = new Paragraph(new Run(stringBuiler.ToString()));
                        paragraph.TextAlignment = TextAlignment.Left;
                        flowDocument.Blocks.Add(paragraph);

                        documentationItem = new DocumentationItemVm(this.AboutDocumentationViewModel, Resources.Version, Assembly.GetEntryAssembly().GetName().Version.ToString(), flowDocument, 200, null, 0, true, @"Version");
                        documentationItem.IsExpanded = false;
                        this.AboutDocumentationViewModel.DocumentationItems.Add(documentationItem);
                    }
                }
            }

            // Manual documentation view model
            this.ManualDocumentationViewModel = new DocumentationVm(0);

            documentationItem = new DocumentationItemVm(this.ManualDocumentationViewModel, Resources.HowToUseCommandManual, Resources.ViewManual, @"EH.ImsOpcBridge.Configurator.Resources.Documents.HowToUseAboutManualDocument.xaml", 100, null, 0, true, @"OpenSource");
            documentationItem.IsExpanded = true;

            var helpFolder = Path.Combine(this.AssemblyDirectory, Constants.HelpFolder);
            var languageName = Thread.CurrentThread.CurrentUICulture;
            helpFolder = Path.Combine(helpFolder, languageName.ToString());
            var manualPath = string.Empty;

            if (Directory.Exists(helpFolder))
            {
                var files = Directory.GetFiles(helpFolder, Constants.ManualFileNameExtension);
                if (files.Length > 0)
                {
                    manualPath = files[0];
                }
            }
           
            link = documentationItem.Document.FindName(@"Manual") as Hyperlink;

            if (link != null)
            {
                if (File.Exists(manualPath))
                {
                    var uri = new Uri(manualPath);
                    link.NavigateUri = uri;
                    link.IsEnabled = true;
                    link.RequestNavigate += this.HyperlinkRequestNavigateManual;
                }
                else
                {
                    link.IsEnabled = false;
                }
            }

            this.ManualDocumentationViewModel.DocumentationItems.Add(documentationItem);

            this.Choice.SelectItem(HowToUsePage.Manual);
            this.SettingsViewModel = mainWindowVm.SettingsViewModel;

            this.contactSupportCommand = new DelegateCommand(this.ContactSupportPressed);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the about documentation view model.
        /// </summary>
        /// <value>The about documentation view model.</value>
        public DocumentationVm AboutDocumentationViewModel
        {
            get
            {
                return (DocumentationVm)this.GetValue(AboutDocumentationViewModelProperty);
            }

            set
            {
                this.SetValue(AboutDocumentationViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the actual page.
        /// </summary>
        /// <value>The actual page.</value>
        public HowToUsePage ActualPage
        {
            get
            {
                return (HowToUsePage)this.GetValue(ActualPageProperty);
            }

            set
            {
                if (this.ActualPage != value)
                {
                    this.SetValue(ActualPageProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets the assembly directory.
        /// </summary>
        /// <value>The assembly directory.</value>
        public string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Gets the choice.
        /// </summary>
        /// <value>The choice.</value>
        public BaseSelectorControlViewModel Choice
        {
            get
            {
                return (BaseSelectorControlViewModel)this.GetValue(ChoiceProperty);
            }

            private set
            {
                this.SetValue(ChoiceProperty, value);
            }
        }

        /// <summary>
        /// Gets the contact support command.
        /// </summary>
        /// <value>The contact support command.</value>
        public ICommand ContactSupportCommand
        {
            get
            {
                return this.contactSupportCommand;
            }
        }

        /// <summary>
        /// Gets or sets the manual documentation view model.
        /// </summary>
        /// <value>The manual documentation view model.</value>
        public DocumentationVm ManualDocumentationViewModel
        {
            get
            {
                return (DocumentationVm)this.GetValue(ManualDocumentationViewModelProperty);
            }

            set
            {
                this.SetValue(ManualDocumentationViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets the settings view model.
        /// </summary>
        /// <value>The settings view model.</value>
        public SettingsVm SettingsViewModel
        {
            get
            {
                return (SettingsVm)this.GetValue(SettingsViewModelProperty);
            }

            private set
            {
                this.SetValue(SettingsViewModelProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Hyperlinks the request navigate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RequestNavigateEventArgs"/> instance containing the event data.</param>
        public void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// Hyperlinks the request navigate manual.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RequestNavigateEventArgs"/> instance containing the event data.</param>
        public void HyperlinkRequestNavigateManual(object sender, RequestNavigateEventArgs e)
        {
            if (File.Exists(e.Uri.AbsolutePath))
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            }

            e.Handled = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Choices the selected item changed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="BaseSelectorSelectionChangedEventArgs"/> instance containing the event data.</param>
        [Localizable(false)]
        private void ChoiceSelectedItemChangedHandler(object sender, BaseSelectorSelectionChangedEventArgs e)
        {
            if (e != null)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, "Executing: {0}", e.SelectedItem.Text);
                Logger.Info(message);
                if (e.SelectedItem == null)
                {
                    this.ActualPage = HowToUsePage.About;
                }
                else
                {
                    HowToUsePage selPage;

                    if (Enum.TryParse(e.SelectedItem.Value.ToString(), out selPage))
                    {
                        this.ActualPage = selPage;
                    }
                }
            }
        }

        /// <summary>
        /// Contacts the support pressed.
        /// </summary>
        private void ContactSupportPressed()
        {
            // ReSharper disable LocalizableElement
            var relativePathItems = new[] { @"SupportFiles" };
            var supportFiles = ConfigurationFileSupport.GetConfigurationPath(@"Endress+Hauser", @"DeviceCare", null, false, true, relativePathItems, true);
            var systemInfo = new SystemInfo(supportFiles);
            systemInfo.WriteInTextFiles();

            //// // ReSharper restore LocalizableElement
            ////using (var zipFile = new ZipFile())
            ////{
            ////    zipFile.AddDirectory(supportFiles.FullName);

            ////    // ReSharper disable LocalizableElement
            ////    zipFile.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DC_SupportFiles.zip");

            ////    // ReSharper restore LocalizableElement
            ////}
        }

        #endregion
    }
}