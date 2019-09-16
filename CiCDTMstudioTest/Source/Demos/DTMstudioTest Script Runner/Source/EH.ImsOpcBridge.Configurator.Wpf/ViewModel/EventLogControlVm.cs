// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLogControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for a device type info DeviceTypeItemsDataGrid control
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class EventLogControlVm
    /// </summary>
    [CLSCompliant(false)]
    public class EventLogControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(EventLogControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The button control bitmap path property
        /// </summary>
        public static readonly DependencyProperty ButtonControlBitmapPathProperty = DependencyProperty.Register("ButtonControlBitmapPath", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button control label property
        /// </summary>
        public static readonly DependencyProperty ButtonControlLabelProperty = DependencyProperty.Register("ButtonControlLabel", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(EventLogControlVm), new FrameworkPropertyMetadata(1, OnCurrentPageChanged));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(EventLogControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The event logs property
        /// </summary>
        public static readonly DependencyProperty EventLogsProperty = DependencyProperty.Register("EventLogs", typeof(ObservableCollection<ImsOpcBridgeEventLog>), typeof(EventLogControlVm), new PropertyMetadata(default(ObservableCollection<ImsOpcBridgeEventLog>)));

        /// <summary>
        /// The filter expression property
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FilterExpressionProperty = DependencyProperty.Register("FilterExpression", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The has selection property
        /// </summary>
        public static readonly DependencyProperty HasSelectionProperty = DependencyProperty.Register("HasSelection", typeof(bool), typeof(EventLogControlVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(EventLogControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The number of items property
        /// </summary>
        public static readonly DependencyProperty NumberOfItemsProperty = DependencyProperty.Register("NumberOfItems", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The number of pages property
        /// </summary>
        public static readonly DependencyProperty NumberOfPagesProperty = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(EventLogControlVm), new FrameworkPropertyMetadata(1, OnNumberOfPagesChanged));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(EventLogControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The selected index property
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(EventLogControlVm), new FrameworkPropertyMetadata(-1, OnSelectedIndexChanged));

        /// <summary>
        /// The sort command property
        /// </summary>
        public static readonly DependencyProperty SortCommandProperty = DependencyProperty.Register("SortCommand", typeof(DelegateCommand), typeof(EventLogControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The sorted by property
        /// </summary>
        public static readonly DependencyProperty SortedByProperty = DependencyProperty.Register("SortedBy", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The device uid header property
        /// </summary>
        public static readonly DependencyProperty TimeHeaderProperty = DependencyProperty.Register("TimeHeader", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The device uid header property
        /// </summary>
        public static readonly DependencyProperty EventHeaderProperty = DependencyProperty.Register("EventHeader", typeof(string), typeof(EventLogControlVm), new PropertyMetadata(default(string)));
        
        #endregion

        #region Fields

        /// <summary>
        /// The delete event log command
        /// </summary>
        private readonly DelegateCommand deleteEventLogCommand;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public EventLogControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.MainWindowVm = mainWindowVm;

            this.SortCommand = new DelegateCommand(this.SortBy);

            this.deleteEventLogCommand = new DelegateCommand(this.DeleteEventLog);

            this.EventLogs = new ObservableCollection<ImsOpcBridgeEventLog>();

            // set default values
            this.FilterExpression = string.Empty;
            this.SortedBy = string.Empty;
            this.ButtonControlLabel = Resources.DeleteEventLog;
            this.TimeHeader = Resources.TimeHeader;
            this.EventHeader = Resources.EventHeader;

            this.ButtonControlBitmapPath = @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/DesignA2\Delete active.png";
            
            mainWindowVm.Host.UserInterface.ToggleMessageAgent += this.UserInterfaceToggleMessageAgent;

            this.UpdateNumberOfItems();
        }

        #endregion

        #region Public Properties

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
        /// Gets or sets the button control bitmap path.
        /// </summary>
        /// <value>The button control bitmap path.</value>
        public string ButtonControlBitmapPath
        {
            get
            {
                return (string)this.GetValue(ButtonControlBitmapPathProperty);
            }

            set
            {
                this.SetValue(ButtonControlBitmapPathProperty, value);
            }
        }
        
        /// <summary>
        /// Gets the time header.
        /// </summary>
        /// <value>The time header.</value>
        public string TimeHeader
        {
            get
            {
                return (string)this.GetValue(TimeHeaderProperty);
            }

            private set
            {
                this.SetValue(TimeHeaderProperty, value);
            }
        }
        
        /// <summary>
        /// Gets the event header.
        /// </summary>
        /// <value>The event header.</value>
        public string EventHeader
        {
            get
            {
                return (string)this.GetValue(EventHeaderProperty);
            }

            private set
            {
                this.SetValue(EventHeaderProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the button control label.
        /// </summary>
        /// <value>The button control label.</value>
        public string ButtonControlLabel
        {
            get
            {
                return (string)this.GetValue(ButtonControlLabelProperty);
            }

            set
            {
                this.SetValue(ButtonControlLabelProperty, value);
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
        /// Gets the delete event log command.
        /// </summary>
        /// <value>The delete event log command.</value>
        public ICommand DeleteEventLogCommand
        {
            get
            {
                return this.deleteEventLogCommand;
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
        /// Gets the event logs.
        /// </summary>
        /// <value>The event logs.</value>
        public ObservableCollection<ImsOpcBridgeEventLog> EventLogs
        {
            get
            {
                return (ObservableCollection<ImsOpcBridgeEventLog>)this.GetValue(EventLogsProperty);
            }

            private set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(EventLogsProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.EventLogs = value; });
                }
            }
        }

        /// <summary>
        /// Gets or sets the filter expression.
        /// </summary>
        /// <value>The filter expression.</value>
        public string FilterExpression
        {
            get
            {
                return (string)this.GetValue(FilterExpressionProperty);
            }

            set
            {
                this.SetValue(FilterExpressionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has selection.
        /// </summary>
        /// <value><c>true</c> if this instance has selection; otherwise, <c>false</c>.</value>
        public bool HasSelection
        {
            get
            {
                return (bool)this.GetValue(HasSelectionProperty);
            }

            set
            {
                this.SetValue(HasSelectionProperty, value);
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
        /// Gets or sets the number of items.
        /// </summary>
        /// <value>The number of items.</value>
        public string NumberOfItems
        {
            get
            {
                return (string)this.GetValue(NumberOfItemsProperty);
            }

            set
            {
                this.SetValue(NumberOfItemsProperty, value);
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
        /// Gets or sets the sort command.
        /// </summary>
        /// <value>The sort command.</value>
        public DelegateCommand SortCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(SortCommandProperty);
            }

            set
            {
                this.SetValue(SortCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the sorted by.
        /// </summary>
        /// <value>The sorted by.</value>
        public string SortedBy
        {
            get
            {
                return (string)this.GetValue(SortedByProperty);
            }

            set
            {
                this.SetValue(SortedByProperty, value);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the main window vm.
        /// </summary>
        /// <value>The main window vm.</value>
        protected MainWindowVm MainWindowVm { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Updates the number of items.
        /// </summary>
        public void UpdateNumberOfItems()
        {
            var currentPage = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.CurrentPage);
            var numberOfPages = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.NumberOfPages);
            this.NumberOfItems = Resources.Page + @" " + currentPage + @"/" + numberOfPages;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentPageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var eventLogControlVm = sender as EventLogControlVm;
            if (eventLogControlVm != null)
            {
                eventLogControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [number of pages changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnNumberOfPagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var eventLogControlVm = sender as EventLogControlVm;
            if (eventLogControlVm != null)
            {
                eventLogControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [selected index changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var deviceTypeInfoListVm = sender as EventLogControlVm;
            if (deviceTypeInfoListVm != null)
            {
                deviceTypeInfoListVm.HasSelection = deviceTypeInfoListVm.SelectedIndex != -1;
            }
        }

        /// <summary>
        /// Deletes the event log.
        /// </summary>
        private void DeleteEventLog()
        {
            var message = string.Format(CultureInfo.CurrentUICulture, Resources.DoYouWantToDeleteTheEventLog);

            if (this.MainWindowVm.Host.UserInterface.DisplayMessage(message, Resources.DeleteEventLog, MessageButton.ButtonsYesNo, MessageType.MessageQuestion, DefaultMessageButton.ButtonNo) == ResultMessage.ButtonYes)
            {
                this.EventLogs.Clear();
                this.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Sorts the by.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void SortBy(object parameter)
        {
            var param = parameter as string;

            if (parameter != null)
            {
                switch (param)
                {
                    case "version":
                        break;
                }
            }
        }
        
        /// <summary>
        /// Users the interface toggle message agent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageAgentEventArgs"/> instance containing the event data.</param>
        private void UserInterfaceToggleMessageAgent(object sender, MessageAgentEventArgs e)
        {
            var hoursMinutes = DateTime.Now;

            // ReSharper disable LocalizableElement
            var newEventlog = new ImsOpcBridgeEventLog(e.Message, Resources.EventLogStatusOK, hoursMinutes.ToString("g", CultureInfo.CurrentCulture));

            // ReSharper restore LocalizableElement
            this.EventLogs.Insert(0, newEventlog); // add as first item

            this.UpdateNumberOfItems();
        }

        #endregion
    }
}