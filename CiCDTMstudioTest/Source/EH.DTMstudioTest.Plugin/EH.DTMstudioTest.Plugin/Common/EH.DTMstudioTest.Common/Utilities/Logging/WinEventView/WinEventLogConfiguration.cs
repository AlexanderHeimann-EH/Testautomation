// -----------------------------------------------------------------------
// <copyright file="WinEventLogConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// -----------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Logging.WinEventView
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The eh event log entry type.
    /// </summary>
    [Flags]
    public enum EHEventLogEntryType
    {
        /// <summary>
        /// The error.
        /// </summary>
        Error = 1,

        /// <summary>
        /// The warning.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// The information.
        /// </summary>
        Information = 4,

        /// <summary>
        /// The debug.
        /// </summary>
        Debug = 8,

        /// <summary>
        /// The success audit.
        /// </summary>
        SuccessAudit = 16,

        /// <summary>
        /// The failure audit.
        /// </summary>
        FailureAudit = 32,
    }

    /// <summary>
    /// The win event log configuration.
    /// </summary>
    [Serializable]
    public class WinEventLogConfiguration
    {
        #region Fields

        /// <summary>
        /// Gets or sets the eh event log entry type.
        /// </summary>
        [XmlIgnore]
        public EHEventLogEntryType EHEventLogEntryType { get; set; }

        /// <summary>
        /// Gets or sets the eh event log entry type xml.
        /// </summary>
        [XmlElement]
        public int EHEventLogEntryTypeXml
        {
            get
            {
                return (int)this.EHEventLogEntryType;
            }

            set
            {
                this.EHEventLogEntryType = (EHEventLogEntryType)value;
            }
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Windows Event logging is active.
        /// </summary>
        public bool IsWinEventLoggingActive { get; set; }

        #endregion

        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <param name="loggerConfigurationPath">
        /// The logger configuration path.
        /// </param>
        public void GetConfiguration(string loggerConfigurationPath)
        {
            if (System.IO.File.Exists(loggerConfigurationPath))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(WinEventLogConfiguration));
                    System.IO.TextReader tr = new System.IO.StreamReader(loggerConfigurationPath);
                    var winEventLogConfiguration = (WinEventLogConfiguration)serializer.Deserialize(tr);

                    tr.Close();

                    this.EHEventLogEntryType = winEventLogConfiguration.EHEventLogEntryType;
                    this.Source = winEventLogConfiguration.Source;
                }
                catch (Exception ex)
                {
                    this.IsWinEventLoggingActive = false;
                    Log.ErrorEx(this, ex, ex.Message);
                }

                this.IsWinEventLoggingActive = true;
            }
            else
            {
                this.IsWinEventLoggingActive = false;
            }
        }
    }
}
