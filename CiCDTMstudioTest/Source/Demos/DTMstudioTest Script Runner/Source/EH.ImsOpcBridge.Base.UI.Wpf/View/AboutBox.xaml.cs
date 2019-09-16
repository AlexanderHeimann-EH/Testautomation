// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutBox.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for AboutBox.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Navigation;

    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    /// <summary>
    /// Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBox"/> class.
        /// Constructor that takes a parent for this AboutBox dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="loadedAssemblies">The loaded assemblies.</param>
        /// <param name="entryAssembly">The entry assembly.</param>
        public AboutBox(Window parent, IEnumerable<IAssemblyInformation> loadedAssemblies, IAssemblyInformation entryAssembly)
            : this(loadedAssemblies, entryAssembly)
        {
            this.Owner = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBox"/> class.
        /// Default constructor is protected so callers must use one with a parent.
        /// </summary>
        /// <param name="loadedAssemblies">The loaded assemblies.</param>
        /// <param name="entryAssembly">The entry assembly.</param>
        protected AboutBox(IEnumerable<IAssemblyInformation> loadedAssemblies, IAssemblyInformation entryAssembly)
        {
            this.InitializeComponent();

            this.DataContext = new AboutBoxVm(loadedAssemblies, entryAssembly);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles click navigation on the hyperlink in the About dialog.
        /// </summary>
        /// <param name="sender">Object the sent the event.</param>
        /// <param name="e">Navigation events arguments.</param>
        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (e.Uri != null && string.IsNullOrEmpty(e.Uri.OriginalString) == false)
            {
                var uri = e.Uri.AbsoluteUri;
                Process.Start(new ProcessStartInfo(uri));
                e.Handled = true;
            }
        }

        #endregion
    }
}
