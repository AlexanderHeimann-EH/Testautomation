// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Event arguments for a log entry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;
    using System.Text;

    /// <summary>
    /// Event arguments for a log entry.
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public LogEventArgs(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="exception">The exception.</param>
        public LogEventArgs(string text, Exception exception)
        {
            this.Text = text;
            this.Exception = exception;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets the long text of the logging message.
        /// </summary>
        /// <returns>The long text of the logging message.</returns>
        public string LongText
        {
            get
            {
                var messageBuilder = new StringBuilder();

                messageBuilder.Append(this.Text);
                this.AppendExceptionHierarchy(messageBuilder);

                return messageBuilder.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the text of the log entry.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Appends the exception hierarchy to the string builder.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        private void AppendExceptionHierarchy(StringBuilder stringBuilder)
        {
            var exception = this.Exception;

            while (exception != null)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(exception.GetType().Name);
                stringBuilder.Append("\n");
                stringBuilder.Append(exception.Message);

                exception = exception.InnerException;
            }
        }

        #endregion
    }
}
