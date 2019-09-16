// ***********************************************************************
// <copyright file="HttpResponseEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements the event arguments for an HTTP response.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.FisCommunication.EventArguments
{
    using System;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Implements the event arguments for an HTTP response.
    /// </summary>
    public class HttpResponseEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// The result code
        /// </summary>
        private readonly bool resultCode;

        /// <summary>
        /// The HTTP status code
        /// </summary>
        private readonly HttpStatusCode statusCode;

        /// <summary>
        /// The status description
        /// </summary>
        private readonly string statusDescription;

        /// <summary>
        /// The response string
        /// </summary>
        private readonly string responseString;

        /// <summary>
        /// The exception
        /// </summary>
        private readonly Exception exception;

        /// <summary>
        /// The state.
        /// </summary>
        private readonly object state;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseEventArgs" /> class.
        /// </summary>
        /// <param name="resultCode">if set to <c>true</c> there is a valid HTTP response. Otherwise there is no response and optionally there might be an exception.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="statusDescription">The status description.</param>
        /// <param name="responseString">The response string.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="state">The state.</param>
        public HttpResponseEventArgs(bool resultCode, HttpStatusCode statusCode, string statusDescription,  string responseString, Exception exception, object state)
        {
            this.resultCode = resultCode;
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
            this.responseString = responseString;
            this.exception = exception;
            this.state = state;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether there is a valid HTTP response.
        /// </summary>
        /// <value><c>true</c> if there is a valid HTTP response. Otherwise there is no response and optionally there might be an exception.</value>
        public bool ResultCode
        {
            get
            {
                return this.resultCode;
            }
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <value>The HTTP status code.</value>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this.statusCode;
            }
        }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>The status description.</value>
        public string StatusDescription
        {
            get
            {
                return this.statusDescription;
            }
        }

        /// <summary>
        /// Gets the response string.
        /// </summary>
        /// <value>The response string.</value>
        public string ResponseString
        {
            get
            {
                return this.responseString;
            }
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception
        {
            get
            {
                return this.exception;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public object State
        {
            get
            {
                return this.state;
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[HttpResponseEventArgs: ResultCode {0}", this.ResultCode);
            sb.AppendFormat(", StatusCode {0}", this.StatusCode);
            sb.AppendFormat(", StatusDescription {0}", this.StatusDescription ?? "(null)");
            sb.AppendFormat(", Exception {0}", this.Exception == null ? "(null)" : this.Exception.Message);

            if (this.ResponseString == null)
            {
                sb.Append(", ResponseString (null)]");
            }
            else
            {
                sb.AppendFormat("]{0}{1}", Environment.NewLine, this.ResponseString);
            }

            return sb.ToString();
        }

        #endregion
    }
}
