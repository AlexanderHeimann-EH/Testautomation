// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The folder view model.
    /// </summary>
    public class FolderViewModel : INotifyPropertyChanged
    {
        #region Constants and Fields

        /// <summary>
        /// The is expanded.
        /// </summary>
        private bool isExpanded;

        /// <summary>
        /// The is selected.
        /// </summary>
        private bool isSelected;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderViewModel"/> class.
        /// </summary>
        public FolderViewModel()
        {
            this.Folders = new ObservableCollection<FolderViewModel>();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets FolderIcon.
        /// </summary>
        /// <value>The folder icon.</value>
        public string FolderIcon { get; set; }

        /// <summary>
        /// Gets or sets FolderName.
        /// </summary>
        /// <value>The name of the folder.</value>
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets FolderPath.
        /// </summary>
        /// <value>The folder path.</value>
        public string FolderPath { get; set; }

        /// <summary>
        /// Gets Folders.
        /// </summary>
        /// <value>The folders.</value>
        public ObservableCollection<FolderViewModel> Folders { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsExpanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }

            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;

                    this.OnPropertyChanged("IsExpanded");

                    if (!this.FolderName.Contains(':'))
                    {
                        // Folder icon change not applicable for drive(s)
                        // ReSharper disable LocalizableElement
                        this.FolderIcon = value ? "..\\Resources\\FolderOpen.png" : "..\\Resources\\FolderClosed.png";

                        // ReSharper restore LocalizableElement
                    }

                    this.LoadFolders();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");

                    this.IsExpanded = true; // Default windows behaviour of expanding the selected folder                
                    this.Root.SelectedFilePath = this.FolderPath;
                }
            }
        }

        /// <summary>
        /// Gets or sets Root.
        /// </summary>
        /// <value>The root.</value>
        public BrowserViewModel Root { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        [Localizable(false)]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The load folders.
        /// </summary>
        private void LoadFolders()
        {
            try
            {
                if (this.Folders.Count > 0)
                {
                    return;
                }

                // ReSharper disable LocalizableElement
                var fullPath = this.FolderName.Contains(':') ? string.Concat(this.FolderName, "\\") : this.FolderPath;

                // ReSharper restore LocalizableElement
                var dirs = Directory.GetDirectories(fullPath);

                this.Folders.Clear();

                foreach (var dir in dirs)
                {
                    // ReSharper disable LocalizableElement
                    this.Folders.Add(new FolderViewModel { Root = this.Root, FolderName = Path.GetFileName(dir), FolderPath = Path.GetFullPath(dir), FolderIcon = "..\\Resources\\FolderClosed.png" });

                    // ReSharper restore LocalizableElement
                }

                // ReSharper disable LocalizableElement
                if (this.FolderName.Contains(":"))
                {
                    this.FolderIcon = "..\\Resources\\HardDisk.ico";

                    // ReSharper restore LocalizableElement
                }
            }
            catch (UnauthorizedAccessException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (IOException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        #endregion
    }
}
