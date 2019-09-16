// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// The documentation item vm.
    /// </summary>
    public class DocumentationItemVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(DocumentationItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The document height property.
        /// </summary>
        public static readonly DependencyProperty DocumentHeightProperty = DependencyProperty.Register("DocumentHeight", typeof(int), typeof(DocumentationItemVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The document property.
        /// </summary>
        public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(FlowDocument), typeof(DocumentationItemVm), new PropertyMetadata(default(FlowDocument)));

        /// <summary>
        /// The expand button image path property.
        /// </summary>
        public static readonly DependencyProperty ExpandButtonImagePathProperty = DependencyProperty.Register("ExpandButtonImagePath", typeof(string), typeof(DocumentationItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The expand button visibility property.
        /// </summary>
        public static readonly DependencyProperty ExpandButtonVisibilityProperty = DependencyProperty.Register("ExpandButtonVisibility", typeof(Visibility), typeof(DocumentationItemVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The height property.
        /// </summary>
        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(int), typeof(DocumentationItemVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The image path property
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(DocumentationItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The image width property.
        /// </summary>
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(int), typeof(DocumentationItemVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The is expanded property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DocumentationItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The sub title property.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "SubTitle", Justification = @"OK here.")]
        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(string), typeof(DocumentationItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The title property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DocumentationItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The visibility property.
        /// </summary>
        public static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility", typeof(Visibility), typeof(DocumentationItemVm), new PropertyMetadata(default(Visibility)));

        #endregion

        #region Fields

        /// <summary>
        /// The documentation view model
        /// </summary>
        private readonly DocumentationVm documentationViewModel;

        /// <summary>
        /// The expand command.
        /// </summary>
        private readonly DelegateCommand expandCommand;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationItemVm" /> class.
        /// </summary>
        /// <param name="documentationViewModel">The documentation view model.</param>
        /// <param name="title">The title.</param>
        /// <param name="subTitle">The sub title.</param>
        /// <param name="document">The flow document.</param>
        /// <param name="documentHeight">Height of the document.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageWidth">Width of the image.</param>
        /// <param name="isExpandable">if set to <c>true</c> the item is expandable.</param>
        /// <param name="automationId">The automation unique identifier.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "subTitle", Justification = @"OK here.")]
        public DocumentationItemVm(DocumentationVm documentationViewModel, string title, string subTitle, FlowDocument document, int documentHeight, string imagePath, int imageWidth, bool isExpandable, [Localizable(false)] string automationId)
        {
            this.documentationViewModel = documentationViewModel;
            this.Title = title;
            this.SubTitle = subTitle;
            this.ImagePath = imagePath;
            this.ImageWidth = imageWidth;
            this.AutomationId = automationId;
            this.Document = document;
            this.expandCommand = new DelegateCommand(this.Expand);
            this.DocumentHeight = documentHeight;

            if (isExpandable)
            {
                this.IsExpanded = false;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Visible;
            }
            else
            {
                this.IsExpanded = true;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationItemVm" /> class.
        /// </summary>
        /// <param name="documentationViewModel">The documentation view model.</param>
        /// <param name="title">The title.</param>
        /// <param name="subTitle">The sub title.</param>
        /// <param name="documentResource">The document resource.</param>
        /// <param name="documentHeight">Height of the document.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageWidth">Width of the image.</param>
        /// <param name="isExpandable">if set to <c>true</c> the item is expandable.</param>
        /// <param name="automationId">The automation unique identifier.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "subTitle", Justification = @"OK here.")]
        public DocumentationItemVm(DocumentationVm documentationViewModel, string title, string subTitle, [Localizable(false)] string documentResource, int documentHeight, [Localizable(false)] string imagePath, int imageWidth, bool isExpandable, [Localizable(false)] string automationId)
        {
            this.documentationViewModel = documentationViewModel;
            this.Title = title;
            this.SubTitle = subTitle;
            this.ImagePath = imagePath;
            this.ImageWidth = imageWidth;
            this.AutomationId = automationId;

            this.expandCommand = new DelegateCommand(this.Expand);

            // ReSharper disable LocalizableElement
            var languageName = Thread.CurrentThread.CurrentUICulture;
            var languageDocumentResource = Path.GetFileNameWithoutExtension(documentResource) + @"_" + languageName + Path.GetExtension(documentResource);

            // ReSharper restore LocalizableElement
            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(languageDocumentResource))
            {
                if (resourceStream != null)
                {
                    this.Document = XamlReader.Load(resourceStream) as FlowDocument;
                }
                else
                {
                    using (var resourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(documentResource))
                    {
                        if (resourceStream2 != null)
                        {
                            this.Document = XamlReader.Load(resourceStream2) as FlowDocument;
                        }
                    }
                }
            }

            this.DocumentHeight = documentHeight;

            if (isExpandable)
            {
                this.IsExpanded = false;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Visible;
            }
            else
            {
                this.IsExpanded = true;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the automation id.
        /// </summary>
        /// <value>The automation unique identifier.</value>
        public string AutomationId
        {
            get
            {
                return (string)this.GetValue(AutomationIdProperty);
            }

            set
            {
                this.SetValue(AutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public FlowDocument Document
        {
            get
            {
                return (FlowDocument)this.GetValue(DocumentProperty);
            }

            set
            {
                this.SetValue(DocumentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the document height.
        /// </summary>
        /// <value>The height of the document.</value>
        public int DocumentHeight
        {
            get
            {
                return (int)this.GetValue(DocumentHeightProperty);
            }

            set
            {
                this.SetValue(DocumentHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets the documentation view model.
        /// </summary>
        /// <value>The documentation view model.</value>
        public DocumentationVm DocumentationViewModel
        {
            get
            {
                return this.documentationViewModel;
            }
        }

        /// <summary>
        /// Gets or sets the expand button image path.
        /// </summary>
        /// <value>The expand button image path.</value>
        public string ExpandButtonImagePath
        {
            get
            {
                return (string)this.GetValue(ExpandButtonImagePathProperty);
            }

            set
            {
                this.SetValue(ExpandButtonImagePathProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the expand button visibility.
        /// </summary>
        /// <value>The expand button visibility.</value>
        public Visibility ExpandButtonVisibility
        {
            get
            {
                return (Visibility)this.GetValue(ExpandButtonVisibilityProperty);
            }

            set
            {
                this.SetValue(ExpandButtonVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets the expand command.
        /// </summary>
        /// <value>The expand command.</value>
        public ICommand ExpandCommand
        {
            get
            {
                return this.expandCommand;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return (int)this.GetValue(HeightProperty);
            }

            set
            {
                this.SetValue(HeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public string ImagePath
        {
            get
            {
                return (string)this.GetValue(ImagePathProperty);
            }

            set
            {
                this.SetValue(ImagePathProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the image width.
        /// </summary>
        /// <value>The width of the image.</value>
        public int ImageWidth
        {
            get
            {
                return (int)this.GetValue(ImageWidthProperty);
            }

            set
            {
                this.SetValue(ImageWidthProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded
        {
            get
            {
                return (bool)this.GetValue(IsExpandedProperty);
            }

            set
            {
                if (value)
                {
                    // ReSharper disable LocalizableElement
                    this.ExpandButtonImagePath = @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/DesignA2/Arrow down.png";

                    // ReSharper restore LocalizableElement
                }
                else
                {
                    // ReSharper disable LocalizableElement
                    this.ExpandButtonImagePath = @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/DesignA2/Arrow Right.png";

                    // ReSharper restore LocalizableElement
                }

                this.SetValue(IsExpandedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the sub title.
        /// </summary>
        /// <value>The sub title.</value>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "SubTitle", Justification = @"OK here.")]
        public string SubTitle
        {
            get
            {
                return (string)this.GetValue(SubTitleProperty);
            }

            set
            {
                this.SetValue(SubTitleProperty, value);
            }
        }

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
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>The visibility.</value>
        public Visibility Visibility
        {
            get
            {
                return (Visibility)this.GetValue(VisibilityProperty);
            }

            set
            {
                this.SetValue(VisibilityProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The expand.
        /// </summary>
        protected void Expand()
        {
            if (!this.IsExpanded)
            {
                this.DocumentationViewModel.SelectDocumentationItem(this);
            }
            else
            {
                this.IsExpanded = false;
            }
        }

        #endregion
    }
}
