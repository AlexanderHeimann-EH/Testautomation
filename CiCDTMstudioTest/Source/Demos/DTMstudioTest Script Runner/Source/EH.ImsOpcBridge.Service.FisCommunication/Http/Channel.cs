// ***********************************************************************
// <copyright file="Channel.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements a communication channel for the FIS operations. An instance of this class is created once and kept for the entire life cycle.
// Each time a request has to be sent to FIS, HTTP related classes created new, used and then disposed. This also because the communication
// parameters might have changed.
// </summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.Service.FisCommunication.Http
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    using EH.ImsOpcBridge.Service.FisCommunication.Delegates;
    using EH.ImsOpcBridge.Service.FisCommunication.EventArguments;

    /// <summary>
    /// Implements a communication channel for the FIS operations. An instance of this class is created once and kept for the entire life cycle.
    /// Each time a request has to be sent to FIS, HTTP related classes created new, used and then disposed. This also because the communication
    /// parameters might have changed.
    /// </summary>
    public class Channel
    {
        #region Events

        /// <summary>
        /// Occurs when [HTTP response event].
        /// </summary>
        public event HttpResponseEventHandler HttpResponseEvent;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [first registration].
        /// </summary>
        /// <value><c>true</c> if [first registration]; otherwise, <c>false</c>.</value>
        public bool FirstRegistration { get; set; }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the FIS HTTP web request.
        /// </summary>
        /// <value>The FIS HTTP web request.</value>
        private HttpWebRequest FisHttpWebRequest { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        private object State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [synchronize state].
        /// </summary>
        /// <value><c>true</c> if [synchronize state]; otherwise, <c>false</c>.</value>
        private bool SyncState { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the HTTP web request. This method starts the whole story. The result shall be sent to the calling client by means of an event.
        /// </summary>
        /// <param name="parameters">The parameters for the HTTP request.</param>
        /// <param name="state">The state. This object is returned within the response. The calling client knows it.</param>
        public void SendRequest(RequestParameters parameters, object state)
        {
            // Check first whether a request is already running.
            if (this.SyncState)
            {
                this.OnHttpResponse(new HttpResponseEventArgs(false, HttpStatusCode.OK, string.Empty, null, new Exception("Registration request already running!"), state));
                return;
            }

            this.SyncState = true;
            this.State = state;
            Exception exception;

            // Create request.
            if (!this.CreateHttpWebRequest(parameters, out exception))
            {
                this.OnHttpResponse(new HttpResponseEventArgs(false, HttpStatusCode.OK, string.Empty, null, exception, state));
                return;
            }

            // Begin get response asynchronously.
            if (!this.BeginGetResponse(out exception))
            {
                this.OnHttpResponse(new HttpResponseEventArgs(false, HttpStatusCode.OK, string.Empty, null, exception, state));
            }

            // If we are here, the request-response succeeded, until now, and upon receiving the HTTP response this instance shall send the data
            // back to the calling client by means of a standard C# event.
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the <see cref="HttpResponse" /> event.
        /// </summary>
        /// <param name="e">The <see cref="HttpResponseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnHttpResponse(HttpResponseEventArgs e)
        {
            this.SyncState = false;
            var handler = this.HttpResponseEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the HTTP web request.
        /// </summary>
        /// <param name="parameters">The parameters for the HTTP request.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise. If the operation fails, there might be an exception, but not necessarily.</returns>
        private bool CreateHttpWebRequest(RequestParameters parameters, out Exception exception)
        {
            exception = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(parameters.BasicParameters.RequestUri);

                // Set some reasonable limits on resources used by this request.
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;

                // Set attributes from parameters.
                request.Timeout = parameters.WebTimeout * 1000;
                request.Method = parameters.Method;
                request.ContentType = parameters.ContentType;

                // Set credentials to use for this request.
                if (parameters.BasicParameters.AuthenticationRequired)
                {
                    request.PreAuthenticate = true;
                    var myCache = new CredentialCache
                                      {
                                          {
                                              new Uri(parameters.BasicParameters.RequestUri),
                                              "Basic",
                                              new NetworkCredential(parameters.BasicParameters.User, parameters.BasicParameters.Password)
                                          }
                                      };

                    // request.Credentials = CredentialCache.DefaultCredentials;
                    request.Credentials = myCache;
                }

                // Check for possible proxy.
                if (parameters.ProxyRequired)
                {
                    var proxy = new WebProxy(parameters.ProxyParameters.RequestUri);

                    // Set credentials to use for this request.
                    if (parameters.ProxyParameters.AuthenticationRequired)
                    {
                        var myCache = new CredentialCache
                                      {
                                          {
                                              new Uri(parameters.ProxyParameters.RequestUri),
                                              "Basic",
                                              new NetworkCredential(parameters.ProxyParameters.User, parameters.ProxyParameters.Password)
                                          }
                                      };

                        proxy.Credentials = myCache;
                    }

                    request.Proxy = proxy;
                }

                // Add the request data.
                if (parameters.Body != null)
                {
                    var requestBody = Encoding.UTF8.GetBytes(parameters.Body);
                    request.ContentLength = requestBody.Length;

                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestBody, 0, requestBody.Length);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }

                // Set field.
                this.FisHttpWebRequest = request;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;

                // Set field.
                this.FisHttpWebRequest = null;
                return false;
            }
        }

        /// <summary>
        /// Start the asynchronous request.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise. If the operation fails, there might be an exception, but not necessarily.</returns>
        private bool BeginGetResponse(out Exception exception)
        {
            exception = null;

            try
            {
                // Start the asynchronous request.
                var result = (IAsyncResult)this.FisHttpWebRequest.BeginGetResponse(new AsyncCallback(this.RespCallback), null);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        /// <summary>
        /// Asynchronous callback for the HTTP response.
        /// </summary>
        /// <param name="asynchronousResult">The asynchronous result.</param>
        private void RespCallback(IAsyncResult asynchronousResult)
        {
            HttpWebResponse response = null;
            StreamReader readStream = null;

            try
            {
                response = (HttpWebResponse)this.FisHttpWebRequest.EndGetResponse(asynchronousResult);

                // Read the response into a Stream object.
                var responseStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format.
                if (responseStream == null)
                {
                    throw new Exception("GetResponseStream returned a null response after HTTP Web Request.");
                }

                readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                // Notify the calling client.
                this.OnHttpResponse(
                    new HttpResponseEventArgs(
                        true, response.StatusCode, response.StatusDescription, responseString, null, this.State));
            }
            catch (Exception exception)
            {
                this.OnHttpResponse(
                    new HttpResponseEventArgs(false, HttpStatusCode.OK, string.Empty, null, exception, this.State));
            }
            finally
            {
                // Close under separate try-catch-block.
                try
                {
                    if (response != null)
                    {
                        response.Close();
                    }

                    if (readStream != null)
                    {
                        readStream.Close();
                    }
                }
                catch (Exception)
                {
                    // Nothing to do.
                }
            }
        }

        #endregion
    }
}
