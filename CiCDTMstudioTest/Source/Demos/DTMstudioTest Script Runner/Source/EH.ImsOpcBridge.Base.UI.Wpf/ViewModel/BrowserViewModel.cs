// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The browser view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf.Model;
    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// The browser view model.
    /// </summary>
    public class BrowserViewModel : INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The get desktop.
        /// </summary>
        private readonly DelegateCommand navigateToDesktop;

        /// <summary>
        /// The navigate to dtm folder.
        /// </summary>
        private readonly DelegateCommand navigateToDtmFolder;

        /// <summary>
        /// The go entered location.
        /// </summary>
        private readonly DelegateCommand navigateToEnteredLocation;

        /// <summary>
        /// The navigate to my documents.
        /// </summary>
        private readonly DelegateCommand navigateToMyDocuments;

        /// <summary>
        /// The selected fc dtm item.
        /// </summary>
        private FcDtmFile selectedFcDtmItem;

        /// <summary>
        /// The selected file path.
        /// </summary>
        private string selectedFilePath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserViewModel"/> class.
        /// </summary>
        public BrowserViewModel()
        {
            this.FcDtmFiles = new ObservableCollection<FcDtmFile>();
            this.Folders = new ObservableCollection<FolderViewModel>();

            this.navigateToDesktop = new DelegateCommand(this.GoToDesktop);
            this.navigateToMyDocuments = new DelegateCommand(this.GoToMyDocuments);
            this.navigateToDtmFolder = new DelegateCommand(this.GoToDtmFolder);
            this.navigateToEnteredLocation = new DelegateCommand(this.GoToEnteredLocation);
            this.PrepareLogicalDrives();
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
        /// Gets or sets the name of the device type.
        /// </summary>
        /// <value>The name of the device type.</value>
        public string DeviceTypeName { get; set; }

        /// <summary>
        /// Gets or sets DtmFolderPath.
        /// </summary>
        /// <value>The DTM folder path.</value>
        public string DtmFolderPath { get; set; }

        /// <summary>
        /// Gets FcDtmFiles.
        /// </summary>
        /// <value>The fc DTM files.</value>
        public ObservableCollection<FcDtmFile> FcDtmFiles { get; private set; }

        /// <summary>
        /// Gets Folders.
        /// </summary>
        /// <value>The folders.</value>
        public ObservableCollection<FolderViewModel> Folders { get; private set; }

        /// <summary>
        /// Gets navigateToDesktop.
        /// </summary>
        public ICommand NavigateToDesktop
        {
            get
            {
                return this.navigateToDesktop;
            }
        }

        /// <summary>
        /// Gets NavigateToDtmFolder.
        /// </summary>
        public ICommand NavigateToDtmFolder
        {
            get
            {
                return this.navigateToDtmFolder;
            }
        }

        /// <summary>
        /// Gets navigateToEnteredLocation.
        /// </summary>
        public ICommand NavigateToEnteredLocation
        {
            get
            {
                return this.navigateToEnteredLocation;
            }
        }

        /// <summary>
        /// Gets NavigateToMyDocuments.
        /// </summary>
        public ICommand NavigateToMyDocuments
        {
            get
            {
                return this.navigateToMyDocuments;
            }
        }

        /// <summary>
        /// Gets or sets the name of the protocol.
        /// </summary>
        /// <value>The name of the protocol.</value>
        public string ProtocolName { get; set; }

        /// <summary>
        /// Gets or sets SelectedFilePath.
        /// </summary>
        /// <value>The selected fc DTM item.</value>
        public FcDtmFile SelectedFcDtmItem
        {
            get
            {
                return this.selectedFcDtmItem;
            }

            set
            {
                if (null != value)
                {
                    this.selectedFcDtmItem = value;
                    this.OnPropertyChanged("SelectedFcDtmItem");

                    if (File.Exists(this.SelectedFilePath))
                    {
                        var test = Path.GetDirectoryName(this.SelectedFilePath);

                        // ReSharper disable LocalizableElement
                        this.SelectedFilePath = test + @"\" + value.Name;
                    }
                    else
                    {
                        this.SelectedFilePath += @"\" + value.Name;

                        // ReSharper restore LocalizableElement
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets SelectedFilePath.
        /// </summary>
        /// <value>The selected file path.</value>
        public string SelectedFilePath
        {
            get
            {
                return this.selectedFilePath;
            }

            set
            {
                if (value != this.selectedFilePath)
                {
                    this.selectedFilePath = value;
                    this.OnPropertyChanged("SelectedFilePath");

                    if (!File.Exists(value))
                    {
                        this.CreateFcDtmFileList();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>The name of the vendor.</value>
        public string VendorName { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The filter fc dtm files.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void FilterFcDtmFiles(string filePath)
        {
           //// if (this.fileCompareService.FileMatchesDtm(Path.Combine(this.SelectedFilePath + @"\", filePath)))
           //// {
                this.FcDtmFiles.Add(new FcDtmFile(filePath));
           //// }
        }

        /// <summary>
        /// The go my documents.
        /// </summary>
        public void GoMyDocuments()
        {
            this.SelectedFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.GoToEnteredLocation();
        }

        /// <summary>
        /// The go program files.
        /// </summary>
        public void GoProgramFiles()
        {
            this.SelectedFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            this.GoToEnteredLocation();
        }

        /// <summary>
        /// Goes to path.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path.
        /// </param>
        public void GoToPath(string destinationPath)
        {
            this.SelectedFilePath = destinationPath;
            this.GoToEnteredLocation();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        [Localizable(false)]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The find folder.
        /// </summary>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <param name="folderVm">
        /// The folder vm.
        /// </param>
        /// <returns>
        /// true, if folder was found.
        /// </returns>
        /// <remarks>
        /// The next folders to be expanded
        /// </remarks>
        private static ObservableCollection<FolderViewModel> ExpandFolder(string folderName, IEnumerable<FolderViewModel> folderVm)
        {
            foreach (var model in folderVm)
            {
                if (string.Equals(model.FolderName.ToUpper(CultureInfo.InvariantCulture), folderName.ToUpper(CultureInfo.InvariantCulture)))
                {
                    // model.IsSelected = true;
                    model.IsExpanded = true;
                    return model.Folders;
                }
            }

            return null;
        }

        /// <summary>
        /// The create fc dtm file list.
        /// </summary>
        private void CreateFcDtmFileList()
        {
            try
            {
                this.FcDtmFiles.Clear();

                var selectedDirectory = new DirectoryInfo(this.SelectedFilePath + @"\");

                // allFiles = selectedDirectory.GetFiles("*.fcdtm", SearchOption.TopDirectoryOnly).ToList();
                selectedDirectory.GetFiles("*.xml", SearchOption.TopDirectoryOnly).ToList().ForEach(it => this.FilterFcDtmFiles(it.ToString()));
                selectedDirectory.GetFiles("*.xml", SearchOption.TopDirectoryOnly).ToList().ForEach(it => this.FilterFcDtmFiles(it.ToString()));
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

        /// <summary>
        /// The my method.
        /// </summary>
        private void GoToDesktop()
        {
            this.SelectedFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.GoToEnteredLocation();
        }

        /// <summary>
        /// The go to dtm folder.
        /// </summary>
        private void GoToDtmFolder()
        {
            this.SelectedFilePath = this.DtmFolderPath;
            this.GoToEnteredLocation();
        }

        // TODO (IF): this fuction needs refactoring. It works, but it is too complicated.

        /// <summary>
        /// The go to entered location.
        /// </summary>
        private void GoToEnteredLocation()
        {
            var filePath = string.Empty;

            try
            {
                this.Folders.Clear();
                this.PrepareLogicalDrives();

                if (null == this.SelectedFilePath)
                {
                    return;
                }

                var splitFilePath = this.SelectedFilePath;

                if (File.Exists(this.SelectedFilePath))
                {
                    filePath = this.SelectedFilePath;
                    splitFilePath = Path.GetDirectoryName(filePath);
                }

                if (splitFilePath != null)
                {
                    var folderNames = splitFilePath.Split('\\').ToList();
                    var nextFolders = this.Folders;
                    var foundFolderName = string.Empty;
                    var foundFolder = new ObservableCollection<FolderViewModel>();

                    // expand all folders in the path
                    foreach (var folderName in folderNames)
                    {
                        foundFolder = nextFolders;

                        nextFolders = ExpandFolder(folderName, nextFolders);

                        if ((null == nextFolders) || (nextFolders.Count == 0) || (folderName == folderNames.Last()))
                        {
                            foundFolderName = folderName;
                            break;
                        }
                    }

                    // select the last found folder
                    if (foundFolder != null)
                    {
                        foreach (var folder in
                            foundFolder.Where(folder => string.Equals(folder.FolderName.ToUpper(CultureInfo.InvariantCulture), foundFolderName.ToUpper(CultureInfo.InvariantCulture))))
                        {
                            folder.IsSelected = true;
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                this.SelectedFilePath = filePath;

                                foreach (var dtmFile in this.FcDtmFiles.Where(dtmFile => string.Equals(Path.GetFileName(filePath), dtmFile.Name)))
                                {
                                    this.SelectedFcDtmItem = dtmFile;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(Resources.NavigationToEnteredFolderFailed, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// The go to my documents.
        /// </summary>
        private void GoToMyDocuments()
        {
            this.SelectedFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.GoToEnteredLocation();
        }

        /// <summary>
        /// The prepare logical drives.
        /// </summary>
        private void PrepareLogicalDrives()
        {
            // ReSharper disable LocalizableElement
            Environment.GetLogicalDrives().ToList().ForEach(it => this.Folders.Add(new FolderViewModel { Root = this, FolderPath = it.TrimEnd('\\'), FolderName = it.TrimEnd('\\'), FolderIcon = "..\\Resources\\HardDisk.ico" }));

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
