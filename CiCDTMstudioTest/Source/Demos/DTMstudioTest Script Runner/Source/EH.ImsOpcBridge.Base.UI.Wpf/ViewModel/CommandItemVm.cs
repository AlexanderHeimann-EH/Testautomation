// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   model for command like "Add DTM" and "Remove DTM"
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Windows;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// model for command like "Add DTM" and "Remove DTM"
    /// </summary>
    public class CommandItemVm : DependencyObject, IDisposable
    {
        // <summary>
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(CommandItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The command ctrl view model property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty CommandCtrlViewModelProperty = DependencyProperty.Register("CommandCtrlViewModel", typeof(CommandCtrlVm), typeof(CommandItemVm), new PropertyMetadata(default(CommandCtrlVm)));

        /// <summary>
        /// The command icon property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty CommandIconProperty = DependencyProperty.Register("CommandIcon", typeof(Icon), typeof(CommandItemVm), new PropertyMetadata(default(Icon)));

        /// <summary>
        /// The execute command property.
        /// </summary>
        public static readonly DependencyProperty ExecuteCommandProperty = DependencyProperty.Register("ExecuteCommand", typeof(DelegateCommand), typeof(CommandItemVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The has child items property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty HasChildItemsProperty = DependencyProperty.Register("HasChildItems", typeof(bool), typeof(CommandItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The has command property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty HasCommandProperty = DependencyProperty.Register("HasButton", typeof(bool), typeof(CommandItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The image source property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(CommandItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is checked property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(CommandItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is enabled property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsExpandableProperty = DependencyProperty.Register("IsExpandable", typeof(bool), typeof(CommandItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is visible property.
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register("IsVisible", typeof(bool), typeof(CommandItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The sort index property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SortIndexProperty = DependencyProperty.Register("SortIndex", typeof(int), typeof(CommandItemVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CommandItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItemVm" /> class.
        /// </summary>
        /// <param name="cmdItem">The CMD item.</param>
        public CommandItemVm(ICommandItem cmdItem)
        {
            try
            {
                this.ExecuteCommand = new DelegateCommand(this.ExeCmd);

                this.CommandItem = cmdItem;
                this.CommandItem.CommandChanged += this.OnCommandChanged;
                this.CommandItem.CommandAdded += this.OnCommandAdded;
                this.CommandItem.CommandRemoved += this.OnCommandRemoved;

                this.UpdateProperties();
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(Resources.InstantiationOfCommandItemFailed, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CommandItemVm" /> class.
        /// Finalizes an instance of the <see cref="CommandItem" /> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="CommandItem" /> is reclaimed by garbage collection.
        /// </summary>
        ~CommandItemVm()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets AutomationId.
        /// </summary>
        /// <value>The automation id.</value>
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
        /// Gets or sets CommandCtrlViewModel.
        /// </summary>
        /// <value>The command CTRL view model.</value>
        public CommandCtrlVm CommandCtrlViewModel
        {
            get
            {
                return (CommandCtrlVm)this.GetValue(CommandCtrlViewModelProperty);
            }

            set
            {
                this.SetValue(CommandCtrlViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets CommandIcon.
        /// </summary>
        /// <value>The command icon.</value>
        public Icon CommandIcon
        {
            get
            {
                return (Icon)this.GetValue(CommandIconProperty);
            }

            set
            {
                this.SetValue(CommandIconProperty, value);
            }
        }

        /// <summary>
        /// Gets CommandItem.
        /// </summary>
        /// <value>The command item.</value>
        public ICommandItem CommandItem { get; private set; }

        /// <summary>
        /// Gets ExecuteCommand.
        /// </summary>
        /// <value>The execute command.</value>
        public DelegateCommand ExecuteCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ExecuteCommandProperty);
            }

            private set
            {
                this.SetValue(ExecuteCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether HasButton.
        /// </summary>
        /// <value><c>true</c> if this instance has button; otherwise, <c>false</c>.</value>
        public bool HasButton
        {
            get
            {
                return (bool)this.GetValue(HasCommandProperty);
            }

            set
            {
                this.SetValue(HasCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are child items.
        /// </summary>
        /// <value><c>true</c> if this instance has child items; otherwise, <c>false</c>.</value>
        public bool HasChildItems
        {
            get
            {
                return (bool)this.GetValue(HasChildItemsProperty);
            }

            set
            {
                this.SetValue(HasChildItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets ImageSource.
        /// </summary>
        /// <value>The image source.</value>
        public string ImageSource
        {
            get
            {
                return (string)this.GetValue(ImageSourceProperty);
            }

            set
            {
                this.SetValue(ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsChecked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        public bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(IsCheckedProperty);
            }

            set
            {
                this.SetValue(IsCheckedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsExpandable.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsExpandable
        {
            get
            {
                return (bool)this.GetValue(IsExpandableProperty);
            }

            set
            {
                this.SetValue(IsExpandableProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        public bool IsVisible
        {
            get
            {
                return (bool)this.GetValue(IsVisibleProperty);
            }

            set
            {
                this.SetValue(IsVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets SortIndex.
        /// </summary>
        /// <value>The index of the sort.</value>
        public int SortIndex
        {
            get
            {
                return (int)this.GetValue(SortIndexProperty);
            }

            set
            {
                this.SetValue(SortIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Implements IDisposable
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

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    if (this.CommandItem != null)
                    {
                        this.CommandItem.CommandAdded -= this.OnCommandAdded;
                        this.CommandItem.CommandChanged -= this.OnCommandChanged;
                        this.CommandItem.CommandRemoved -= this.OnCommandRemoved;
                    }

                    var commandProvider = this.CommandItem as ICommandProvider;
                    if (commandProvider != null)
                    {
                        ////commandProvider.CommandAdded -= this.OnCommandAdded;
                        ////commandProvider.CommandChanged -= this.OnCommandChanged;
                        ////commandProvider.CommandRemoved -= this.OnCommandRemoved;

                        ////if (commandProvider.Commands.Count > 0)
                        ////{
                        ////    lock (commandProvider.Commands)
                        ////    {
                        ////        foreach (var command in commandProvider.Commands)
                        ////        {
                        ////            commandProvider.RemoveCommand(command);
                        ////        }
                        ////    }
                        ////}
                    }

                    ////if (this.CommandItem != null)
                    ////{
                    ////    this.CommandItem.Dispose();
                    ////}
                    if (this.CommandCtrlViewModel != null)
                    {
                        this.CommandCtrlViewModel.Dispose();
                    }

                    this.ExecuteCommand = null;
                }
            }

            this.disposed = true;
        }

        /// <summary>
        /// executes the command
        /// </summary>
        private void ExeCmd()
        {
            this.CommandItem.DoIt();
        }

        /// <summary>
        /// The get icon for button.
        /// </summary>
        /// <returns>Icon. Depends on command id and status ( checked, disabled )</returns>
        private Icon GetCommandIcon()
        {
            // build the icon name            
            // ReSharper disable LocalizableElement
            var iconKey = new StringBuilder("Icon_"); // start with "Icon_"
            iconKey.Append(this.CommandItem.Id); // continue with the command id
            iconKey.Replace("-", "_"); // replace all "-" with "_"

            if (this.CommandItem.Checked)
            {
                iconKey.Append("_checked"); // if button is checked, add "_checked" and use that item
            }

            // ReSharper restore LocalizableElement
            return Resources.ResourceManager.GetObject(iconKey.ToString()) as Icon;
        }

        /// <summary>
        /// The on command added.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnCommandAdded(object sender, CommandEventArgs e)
        {
            if (e.Command.ParentCommand == this.CommandItem)
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.UpdateProperties();
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)(() => this.OnCommandAdded(sender, e)));
                }
            }
        }

        /// <summary>
        /// The command item_ command changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        private void OnCommandChanged(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.Command == this.CommandItem)
                {
                    if (this.Dispatcher.CheckAccess())
                    {
                        this.UpdateProperties();
                    }
                    else
                    {
                        this.Dispatcher.BeginInvoke((Action)(() => this.OnCommandChanged(sender, e)));
                    }
                }
            }
            catch (Exception ex)
            {
                var message = Resources.HandlingOfCommandChangedEventFailed;

                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(message, ex);
                }

                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(@"Handling of OnCommandChanged has failed.", ex);
                }
            }
        }

        /// <summary>
        /// The on command removed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnCommandRemoved(object sender, CommandEventArgs e)
        {
            if (e.Command.ParentCommand == this.CommandItem)
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.UpdateProperties();
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)(() => this.OnCommandRemoved(sender, e)));
                }
            }
        }

        /// <summary>
        /// Updates the properties used for displaying the item.
        /// </summary>
        private void UpdateProperties()
        {
            if (this.CommandItem != null)
            {
                this.Text = this.CommandItem.Text;
                this.ExecuteCommand.IsExecutable = this.CommandItem.Enabled;
                this.IsExpandable = this.CommandItem.Enabled;
                this.IsVisible = !this.CommandItem.Hidden;
                this.IsChecked = this.CommandItem.Checked;
                this.CommandIcon = this.GetCommandIcon();
                if (this.CommandItem.Id == CommandIdLexicon.AddNodeCommandId)
                {
                    // ReSharper disable LocalizableElement
                    this.ImageSource = @"/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/AddNode.ico";

                    // ReSharper restore LocalizableElement
                }

                this.AutomationId = string.Format(CultureInfo.InvariantCulture, "automId_{0}", this.CommandItem.Id);
                this.SortIndex = this.CommandItem.SortIndex;
                this.HasChildItems = this.CommandItem.ChildCommands.Count > 0;

                // If the command item has child items, this button item represents an according group of buttons
                // but has no function of a button anymore.
                // If it has no command or text (separator), than we hide the button as well.
                this.HasButton = !this.HasChildItems && this.CommandItem.DoProc != null && !string.IsNullOrEmpty(this.CommandItem.Text);

                if (this.HasChildItems)
                {
                    if (this.CommandCtrlViewModel == null)
                    {
                        this.CommandCtrlViewModel = new CommandCtrlVm();
                    }

                    // As command provider might have changed, update it in view model for child items.
                    this.CommandCtrlViewModel.SetCommandProvider(this.CommandItem);
                }
                else
                {
                    this.CommandCtrlViewModel = null;
                }
            }
        }

        #endregion
    }
}
