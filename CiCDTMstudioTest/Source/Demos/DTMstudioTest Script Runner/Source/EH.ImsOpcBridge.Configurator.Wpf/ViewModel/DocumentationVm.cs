// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// The documentation vm.
    /// </summary>
    public class DocumentationVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The documentation items property.
        /// </summary>
        public static readonly DependencyProperty DocumentationItemsProperty = DependencyProperty.Register("DocumentationItems", typeof(ObservableCollection<DocumentationItemVm>), typeof(DocumentationVm), new PropertyMetadata(default(ObservableCollection<DocumentationItemVm>)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationVm" /> class.
        /// </summary>
        public DocumentationVm()
        {
            this.DocumentationItems = new ObservableCollection<DocumentationItemVm>();

            // ReSharper disable LocalizableElement
            this.DocumentationItems.Add(new DocumentationItemVm(this, @"HART", @"FXA195", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/TestPic.jpg", 618, false, @"HART"));

            var item = new DocumentationItemVm(this, @"PROFIBUS", @"USB or PCMCIA", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/TestPic.jpg", 618, true, @"PROFIBUS");
            item.IsExpanded = true;

            this.DocumentationItems.Add(item);
            this.DocumentationItems.Add(new DocumentationItemVm(this, null, @"Your Benefits", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, null, 0, true, @"Your Benefits"));
            this.DocumentationItems.Add(new DocumentationItemVm(this, @"Foundation Fieldbus", @"USB or PCMCIA", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/TestPic.jpg", 618, true, @"Foundation Fieldbus"));
            this.DocumentationItems.Add(new DocumentationItemVm(this, @"CDI", @"FXA291, Ethernet, USB", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/TestPic.jpg", 618, true, @"CDI"));
            this.DocumentationItems.Add(new DocumentationItemVm(this, @"Service Interfaces", @"IPC, ISS, PCP", @"EH.ImsOpcBridge.Configurator.Resources.Documents.TestDocument.xaml", 200, @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/TestPic.jpg", 618, true, @"Service Interfaces"));

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationVm" /> class.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "id", Justification = @"OK here.")]
        public DocumentationVm(int id)
        {
            this.DocumentationItems = new ObservableCollection<DocumentationItemVm>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the documentation items.
        /// </summary>
        /// <value>The documentation items.</value>
        public ObservableCollection<DocumentationItemVm> DocumentationItems
        {
            get
            {
                return (ObservableCollection<DocumentationItemVm>)this.GetValue(DocumentationItemsProperty);
            }

            set
            {
                this.SetValue(DocumentationItemsProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Selects the documentation item.
        /// </summary>
        /// <param name="itemToSelect">The item automatic select.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "OK here.")]
        public void SelectDocumentationItem(DocumentationItemVm itemToSelect)
        {
            foreach (var item in this.DocumentationItems)
            {
                if (item.ExpandButtonVisibility == Visibility.Visible)
                {
                    item.IsExpanded = false;
                }
            }
            
            foreach (var item in this.DocumentationItems)
            {
                if (Equals(item, itemToSelect))
                {
                    item.IsExpanded = true;
                    return;
                }
            }
        }

        #endregion
    }
}
