// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLogHotkeyControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for EventLogHotkeyControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class EventLogHotkeyControl
    /// </summary>
    public partial class EventLogHotkeyControl
    {
        #region Static Fields

        /// <summary>
        /// The delete log command property
        /// </summary>
        public static readonly DependencyProperty DeleteLogCommandProperty = DependencyProperty.Register("DeleteLogCommand", typeof(DelegateCommand), typeof(EventLogHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The tool tip delete event log property
        /// </summary>
        public static readonly DependencyProperty ToolTipDeleteEventLogProperty = DependencyProperty.Register("ToolTipDeleteEventLog", typeof(string), typeof(EventLogHotkeyControl), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogHotkeyControl"/> class.
        /// </summary>
        public EventLogHotkeyControl()
        {
            this.ToolTipDeleteEventLog = Properties.Resources.DeleteEventLog;
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the delete log command.
        /// </summary>
        /// <value>The delete log command.</value>
        public DelegateCommand DeleteLogCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(DeleteLogCommandProperty);
            }

            set
            {
                this.SetValue(DeleteLogCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip delete event log.
        /// </summary>
        /// <value>The tool tip delete event log.</value>
        public string ToolTipDeleteEventLog
        {
            get
            {
                return (string)this.GetValue(ToolTipDeleteEventLogProperty);
            }

            set
            {
                this.SetValue(ToolTipDeleteEventLogProperty, value);
            }
        }

        #endregion
    }
}