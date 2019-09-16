// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ServerControlVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class ServerControlVm
    /// </summary>
    public class ServerControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(ServerControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The class id header property
        /// </summary>
        public static readonly DependencyProperty ClassIdHeaderProperty = DependencyProperty.Register("ClassIdHeader", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The current item property
        /// </summary>
        public static readonly DependencyProperty CurrentItemProperty = DependencyProperty.Register("CurrentItem", typeof(object), typeof(ServerControlVm), new FrameworkPropertyMetadata(null, OnCurrentItemChanged));

        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(ServerControlVm), new FrameworkPropertyMetadata(1, OnCurrentPageChanged));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(ServerControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The enter filter term property
        /// </summary>
        public static readonly DependencyProperty EnterFilterTermProperty = DependencyProperty.Register("EnterFilterTerm", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter active property
        /// </summary>
        public static readonly DependencyProperty FilterActiveProperty = DependencyProperty.Register("FilterActive", typeof(bool), typeof(ServerControlVm), new FrameworkPropertyMetadata(false, OnFilterExpanderChanged));

        /// <summary>
        /// The filter header property
        /// </summary>
        public static readonly DependencyProperty FilterHeaderProperty = DependencyProperty.Register("FilterHeader", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The name header property
        /// </summary>
        public static readonly DependencyProperty NameHeaderProperty = DependencyProperty.Register("NameHeader", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(ServerControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The number of pages property
        /// </summary>
        public static readonly DependencyProperty NumberOfPagesProperty = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(ServerControlVm), new FrameworkPropertyMetadata(1, OnNumberOfPagesChanged));

        /// <summary>
        /// The opc server items property
        /// </summary>
        public static readonly DependencyProperty OpcServerItemsProperty = DependencyProperty.Register("OpcServerItems", typeof(ObservableCollection<ServerData>), typeof(ServerControlVm), new PropertyMetadata(default(ObservableCollection<ServerData>)));

        /// <summary>
        /// The pages property
        /// </summary>
        public static readonly DependencyProperty PagesProperty = DependencyProperty.Register("Pages", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The active server property
        /// </summary>
        public static readonly DependencyProperty ActiveServerProperty = DependencyProperty.Register("ActiveServer", typeof(string), typeof(ServerControlVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(ServerControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The selected index property
        /// </summary>
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(object), typeof(ServerControlVm), new FrameworkPropertyMetadata(null, OnSelectedIndexChanged));

        /// <summary>
        /// The text filter property
        /// </summary>
        public static readonly DependencyProperty TextFilterProperty = DependencyProperty.Register("TextFilter", typeof(string), typeof(ServerControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The connect server command
        /// </summary>
        private readonly DelegateCommand connectServerCommand;

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public ServerControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.NameHeader = Resources.ServerNameHeader;
            this.ClassIdHeader = Resources.ClassIdHeader;
            this.FilterHeader = Resources.Filter;
            this.EnterFilterTerm = Resources.EnterFilterTerm;
            this.ActiveServer = Resources.NoServerForAddressSpaceBrowsingActivated;

            this.OpcServerItems = new ObservableCollection<ServerData>();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(this.OpcServerItems);
            view.Filter = this.UserFilter;

            this.connectServerCommand = new DelegateCommand(this.GoToConnectServer);
            this.SelectedServer = new OpcServerItem(true);

            this.mainWindowViewModel.ServiceDataReceiver.OpcServersResponse += this.HandleOpcServersResponse;
            this.mainWindowViewModel.ServiceDataReceiver.ReadOpcAddressSpaceResponse += this.HandleReadOpcAddressSpaceResponse;
            
            this.UpdateNumberOfItems();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the automation id.
        /// </summary>
        /// <value>The automation id.</value>
        public string AutomationId
        {
            get
            {
                return (string)this.GetValue(AutomationIdProperty);
            }

            private set
            {
                this.SetValue(AutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the begin page command.
        /// </summary>
        /// <value>The begin page command.</value>
        public DelegateCommand BeginPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(BeginPageCommandProperty);
            }

            set
            {
                this.SetValue(BeginPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets the class id header.
        /// </summary>
        /// <value>The class id header.</value>
        public string ClassIdHeader
        {
            get
            {
                return (string)this.GetValue(ClassIdHeaderProperty);
            }

            private set
            {
                this.SetValue(ClassIdHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the connect server command.
        /// </summary>
        /// <value>The connect server command.</value>
        public ICommand ConnectServerCommand
        {
            get
            {
                return this.connectServerCommand;
            }
        }

        /// <summary>
        /// Gets or sets the current item.
        /// </summary>
        /// <value>The current item.</value>
        public int CurrentItem
        {
            get
            {
                return (int)this.GetValue(CurrentItemProperty);
            }

            set
            {
                this.SetValue(CurrentItemProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage
        {
            get
            {
                return (int)this.GetValue(CurrentPageProperty);
            }

            set
            {
                this.SetValue(CurrentPageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the end page command.
        /// </summary>
        /// <value>The end page command.</value>
        public DelegateCommand EndPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(EndPageCommandProperty);
            }

            set
            {
                this.SetValue(EndPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets the enter filter term.
        /// </summary>
        /// <value>The enter filter term.</value>
        public string EnterFilterTerm
        {
            get
            {
                return (string)this.GetValue(EnterFilterTermProperty);
            }

            private set
            {
                this.SetValue(EnterFilterTermProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter active].
        /// </summary>
        /// <value><c>true</c> if [filter active]; otherwise, <c>false</c>.</value>
        public bool FilterActive
        {
            get
            {
                return (bool)this.GetValue(FilterActiveProperty);
            }

            set
            {
                this.SetValue(FilterActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets the filter header.
        /// </summary>
        /// <value>The filter header.</value>
        public string FilterHeader
        {
            get
            {
                return (string)this.GetValue(FilterHeaderProperty);
            }

            private set
            {
                this.SetValue(FilterHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the name header.
        /// </summary>
        /// <value>The name header.</value>
        public string NameHeader
        {
            get
            {
                return (string)this.GetValue(NameHeaderProperty);
            }

            private set
            {
                this.SetValue(NameHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the next page command.
        /// </summary>
        /// <value>The next page command.</value>
        public DelegateCommand NextPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(NextPageCommandProperty);
            }

            set
            {
                this.SetValue(NextPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        public int NumberOfPages
        {
            get
            {
                return (int)this.GetValue(NumberOfPagesProperty);
            }

            set
            {
                this.SetValue(NumberOfPagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the opc server items.
        /// </summary>
        /// <value>The opc server items.</value>
        public ObservableCollection<ServerData> OpcServerItems
        {
            get
            {
                return (ObservableCollection<ServerData>)this.GetValue(OpcServerItemsProperty);
            }

            set
            {
                this.SetValue(OpcServerItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>The pages.</value>
        public string Pages
        {
            get
            {
                return (string)this.GetValue(PagesProperty);
            }

            set
            {
                this.SetValue(PagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the active server.
        /// </summary>
        /// <value>The active server.</value>
        public string ActiveServer
        {
            get
            {
                return (string)this.GetValue(ActiveServerProperty);
            }

            set
            {
                this.SetValue(ActiveServerProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the previous page command.
        /// </summary>
        /// <value>The previous page command.</value>
        public DelegateCommand PreviousPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(PreviousPageCommandProperty);
            }

            set
            {
                this.SetValue(PreviousPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get
            {
                return (int)this.GetValue(SelectedIndexProperty);
            }

            set
            {
                this.SetValue(SelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected server.
        /// </summary>
        /// <value>The selected server.</value>
        public OpcServerItem SelectedServer { get; set; }

        /// <summary>
        /// Gets or sets the text filter.
        /// </summary>
        /// <value>The text filter.</value>
        public string TextFilter
        {
            get
            {
                return (string)this.GetValue(TextFilterProperty);
            }

            set
            {
                this.SetValue(TextFilterProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the opc server.
        /// </summary>
        public void GetOpcServer()
        {
            this.ActiveServer = Resources.NoServerForAddressSpaceBrowsingActivated;

            this.OpcServerItems.Clear();
            this.GetOpcServers();
        }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <returns>System Int32.</returns>
        public int GetSelection()
        {
            var selectedIndex = -1;

            if (this.OpcServerItems.Count > 0)
            {
                for (int i = 0; i < this.OpcServerItems.Count; i++)
                {
                    if ((this.OpcServerItems[i].Name == this.mainWindowViewModel.ConnectedServer.Name) && (this.OpcServerItems[i].ClassId == this.mainWindowViewModel.ConnectedServer.ClassId))
                    {
                        selectedIndex = i;
                    }
                }
            }

            return selectedIndex;
        }

        /// <summary>
        /// Handles the opc servers response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ServerDataEventArgs"/> instance containing the event data.</param>
        public void HandleOpcServersResponse(object sender, ServerDataEventArgs e)
        {
            if (e.OpcServerItems != null)
            {
                this.OpcServerItems.Clear();

                foreach (var opcServerItem in e.OpcServerItems)
                {
                    this.OpcServerItems.Add(new ServerData(opcServerItem));
                }

                this.SelectedIndex = this.GetSelection();

                if (this.SelectedIndex != -1)
                {
                    this.ActiveServer = Resources.ActiveServer + @" " + this.SelectedServer.Name;
                }
            }
        }

        /// <summary>
        /// Handles the read opc address space response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AddressSpaceDataEventArgs"/> instance containing the event data.</param>
        public void HandleReadOpcAddressSpaceResponse(object sender, AddressSpaceDataEventArgs e)
        {
            if (e.AddressSpace != null)
            {
                this.ActiveServer = Resources.ActiveServer + @" " + this.SelectedServer.Name;                
            }
        }
        
        /// <summary>
        /// Updates the number of items.
        /// </summary>
        public void UpdateNumberOfItems()
        {
            var currentPage = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.CurrentPage);
            var numberOfPages = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.NumberOfPages);
            this.Pages = Resources.Page + @" " + currentPage + @"/" + numberOfPages;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Goes to connect server.
        /// </summary>
        protected void GoToConnectServer()
        {
            this.mainWindowViewModel.ConnectedServer.Name = this.SelectedServer.Name;
            this.mainWindowViewModel.ConnectedServer.ClassId = this.SelectedServer.ClassId;
            this.mainWindowViewModel.ConnectedServer.IpAddress = this.SelectedServer.IpAddress;

            this.SelectedIndex = this.GetSelection();

            if (this.SelectedIndex != -1)
            {
                this.ReadOpcAddressSpace();
            }
            else
            {
                var message = Resources.PleaseSelectServer;
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);               
            }          
        }

        /// <summary>
        /// Called when [current item changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
                var serverData = e.NewValue as ServerData;

                if (serverData != null)
                {
                    serverControlVm.SelectedServer.Name = serverData.Name;
                    serverControlVm.SelectedServer.IpAddress = serverData.IpAddress;
                    serverControlVm.SelectedServer.ClassId = serverData.ClassId;
                }
                else
                {
                    serverControlVm.SelectedIndex = serverControlVm.GetSelection();
                }
            }
        }

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentPageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
                serverControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [filter expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
                if (!string.IsNullOrEmpty(serverControlVm.TextFilter))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    serverControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [number of pages changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnNumberOfPagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
                serverControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [selected index changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
            }
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var serverControlVm = sender as ServerControlVm;
            if (serverControlVm != null)
            {
                CollectionViewSource.GetDefaultView(serverControlVm.OpcServerItems).Refresh();

                var view = (CollectionView)CollectionViewSource.GetDefaultView(serverControlVm.OpcServerItems);
                view.Filter = serverControlVm.UserFilter;
            }
        }

        /// <summary>
        /// Gets the opc servers.
        /// </summary>
        private void GetOpcServers()
        {
            try
            {
                var client = new CommServerClient();
                client.ReadLocalOpcServersRequest(MainWindow.ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Reads the opc address space.
        /// </summary>
        private void ReadOpcAddressSpace()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.mainWindowViewModel.ConnectedServer.Name))
                {
                    this.mainWindowViewModel.ClearOpcItemMappingTreeOpcItems();

                    var client = new CommServerClient();
                    client.ReadOpcAddressSpaceRequest(MainWindow.ClientUri, Guid.NewGuid(), this.mainWindowViewModel.ConnectedServer.ClassId);
                    client.Close();
                }
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Users the filter.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(this.TextFilter))
            {
                return true;
            }
            else
            {
                var serverData = item as ServerData;
                var test = serverData != null && serverData.Name.IndexOf(this.TextFilter, StringComparison.OrdinalIgnoreCase) >= 0;
                return test;
            }
        }

        #endregion
    }
}