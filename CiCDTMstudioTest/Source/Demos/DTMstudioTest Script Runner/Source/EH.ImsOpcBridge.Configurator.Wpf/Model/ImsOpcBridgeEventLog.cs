// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImsOpcBridgeEventLog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Windows;

    /// <summary>
    /// The event log.
    /// </summary>
    public class ImsOpcBridgeEventLog : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The event log property.
        /// </summary>
        public static readonly DependencyProperty EventLogProperty = DependencyProperty.Register("EventLog", typeof(string), typeof(ImsOpcBridgeEventLog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The full event log property.
        /// </summary>
        public static readonly DependencyProperty EventLogFullProperty = DependencyProperty.Register("EventLogFull", typeof(string), typeof(ImsOpcBridgeEventLog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The status property.
        /// </summary>
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(ImsOpcBridgeEventLog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The time property.
        /// </summary>
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(ImsOpcBridgeEventLog), new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImsOpcBridgeEventLog" /> class.
        /// </summary>
        /// <param name="eventLog">The event log.</param>
        /// <param name="status">The status.</param>
        /// <param name="time">The time.</param>
        public ImsOpcBridgeEventLog(string eventLog, string status, string time)
        {
            if (eventLog == null)
            {
                throw new ArgumentNullException(@"eventLog");
            }

            // ReSharper disable LocalizableElement
            var eventLogLines = eventLog.Split(new string[] { Environment.NewLine, @"\n" }, 0);

            if (eventLogLines.Length > 1)
            {
                this.EventLog = eventLogLines[0] + @" ...";
            }
            else
            {
                this.EventLog = eventLog;
            }

            // ReSharper restore LocalizableElement
            this.EventLogFull = eventLog;
            this.Status = status;
            this.Time = time;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the event log.
        /// </summary>
        /// <value>The event log.</value>
        public string EventLog
        {
            get
            {
                return (string)this.GetValue(EventLogProperty);
            }

            set
            {
                this.SetValue(EventLogProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the full event log.
        /// </summary>
        /// <value>The full event log.</value>
        public string EventLogFull
        {
            get
            {
                return (string)this.GetValue(EventLogFullProperty);
            }

            set
            {
                this.SetValue(EventLogFullProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status
        {
            get
            {
                return (string)this.GetValue(StatusProperty);
            }

            set
            {
                this.SetValue(StatusProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public string Time
        {
            get
            {
                return (string)this.GetValue(TimeProperty);
            }

            set
            {
                this.SetValue(TimeProperty, value);
            }
        }

        #endregion
    }
}
