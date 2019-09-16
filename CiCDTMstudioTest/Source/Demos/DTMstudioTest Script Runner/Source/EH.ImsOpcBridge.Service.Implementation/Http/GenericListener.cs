// ***********************************************************************
// <copyright file="GenericListener.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements a generic HTTP listener with some extra logic concerning restarting
// the listener or close it gracefully while it is listening.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Http
{
    using System;
    using System.Net;
    using System.Threading;

    using EH.ImsOpcBridge.Common.Queue;
    using EH.ImsOpcBridge.Service.Implementation.Diagnostics;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Implements a generic HTTP listener with some extra logic concerning restarting
    /// the listener or close it gracefully while it is listening.
    /// </summary>
    internal class GenericListener
    {
        #region Properties

        /// <summary>
        /// Gets or sets the listener.
        /// </summary>
        /// <value>The listener.</value>
        private HttpListener Listener { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [close requested].
        /// </summary>
        /// <value><c>true</c> if [close requested]; otherwise, <c>false</c>.</value>
        private bool CloseRequested { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        private RequestParameters Parameters { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the listener with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Start(RequestParameters parameters)
        {
            // Starts only if the new parameters are different.
            if (!this.Parameters.Equals(parameters))
            {
                this.Parameters = parameters;
                if (this.Listener == null)
                {
                    this.InternalStart();
                }
                else
                {
                    // Forces close to restart the mechanism again.
                    this.Listener.Close();
                }
            }
            else
            {
                Logger.Debug(this, "HTTP Listener no new start because same parameters requested.");
            }
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (this.Listener != null)
            {
                this.CloseRequested = true;
                this.Listener.Close();
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Checks the authentication.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if authentication not required or required and authentication parameters are correct, <c>false</c> otherwise.</returns>
        private static bool CheckAuthentication(RequestParameters parameters, HttpListenerContext context)
        {
            var result = true;

            if (parameters.AuthenticationRequired)
            {
                result = false;

                if (context.User != null)
                {
                    if (context.User.Identity.IsAuthenticated)
                    {
                        var identity = (HttpListenerBasicIdentity)context.User.Identity;

                        if (identity.Name.Equals(parameters.User) && identity.Password.Equals(parameters.Password))
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the URI.
        /// </summary>
        /// <param name="absolutePath">The URL absolute path.</param>
        /// <returns><c>true</c> if the HTTP request string is correct, <c>false</c> otherwise.</returns>
        private static bool CheckUri(string absolutePath)
        {
            var result = false;

            if (!string.IsNullOrEmpty(absolutePath))
            {
                absolutePath = absolutePath.ToUpper();
                result = absolutePath.Equals("/INDEX") || absolutePath.Equals("/INDEX.HTML");
            }

            return result;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="responseString">The response string.</param>
        /// <returns><c>true</c> if a valid response string has been received, <c>false</c> otherwise.</returns>
        private static bool GetResponse(out string responseString)
        {
            var resetEvent = new AutoResetEvent(false);
            var responseState = new ResponseState(resetEvent);

            // Sends the request to the task scheduler and wait for the response.
            var message = new Message(string.Empty, Guid.NewGuid(), MessageTypes.SceDataRequest, responseState);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);

            // Waits for the event to be set.
            resetEvent.WaitOne();

            responseString = responseState.ResponseString;
            return !string.IsNullOrEmpty(responseString);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Starts the thread that instantiates and starts the listener.
        /// </summary>
        private void InternalStart()
        {
            Logger.Debug(this, "HTTP Listener internally closed.");
            this.InternalClose();

            Logger.Debug(this, "HTTP Listener InternalStart called.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ThreadProc), this.Parameters);
        }

        /// <summary>
        /// Close the listener WITHOUT raising exceptions. This is needed to prevent that the listener does not start anymore after unexpected problems.
        /// </summary>
        private void InternalClose()
        {
            try
            {
                if (this.Listener != null)
                {
                    this.Listener.Close();
                    this.Listener = null;
                }
            }
            catch (Exception exception)
            {
                Logger.ErrorException(this, "Error while closing the listener internally, just before creating new.", exception);
            }
        }

        /// <summary>
        /// Creates the prefix.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The only valid prefix for the supported HTTP GET request.</returns>
        private string CreatePrefix(RequestParameters parameters)
        {
            return string.Format("http://*:{0}/", parameters.Port);
        }

        /// <summary>
        /// The thread that instantiates and starts the listener.
        /// </summary>
        /// <param name="stateInfo">The state information.</param>
        private void ThreadProc(object stateInfo)
        {
            Logger.Info(this, "HTTP Listener Threadproc starts.");
            try
            {
                // Parameters are saved locally to prevent changes while the threads are running.
                var parameters = (RequestParameters)stateInfo;

                try
                {
                    this.Listener = new HttpListener();
                    this.Listener.Prefixes.Add(this.CreatePrefix(parameters));

                    if (parameters.AuthenticationRequired)
                    {
                        this.Listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
                    }

                    this.Listener.Start();
                }
                catch (Exception exception)
                {
                    this.Listener = null;
                    Logger.ErrorException(this, "Error creating HTTP listener.", exception);
                    DiagnosticsCollection.Instance.AddMessage("Error creating HTTP listener.");
                    DiagnosticsCollection.Instance.AddMessage(exception);
                    return;
                }

                while (true)
                {
                    var result = this.Listener.BeginGetContext(new AsyncCallback(this.ListenerCallback), parameters);
                    Logger.Debug(this, "Waiting for request to be processed asyncronously.");
                    result.AsyncWaitHandle.WaitOne();
                    Logger.Debug(this, "Request processed asyncronously.");
                }
            }
            catch (Exception exception)
            {
                Logger.ErrorException(this, "Listener aborted.", exception);
            }

            Logger.Info(this, "HTTP Listener Threadproc stops.");
        }

        /// <summary>
        /// Callback for the listener asynchronous operations.
        /// </summary>
        /// <param name="result">The result.</param>
        private void ListenerCallback(IAsyncResult result)
        {
            try
            {
                Logger.Debug(this, "Callback called...");
                var parameters = (RequestParameters)result.AsyncState;

                // Call EndGetContext to complete the asynchronous operation.
                var context = this.Listener.EndGetContext(result);
                var request = context.Request;

                // Obtain a response object.
                var response = context.Response;
                response.ContentType = "text/xml";
                string responseString;

                // Check first the possible required authentication.
                if (!CheckAuthentication(parameters, context))
                {
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.StatusDescription = HttpStatusCode.Unauthorized.ToString();
                    responseString = string.Empty;
                }
                else if (!CheckUri(request.Url.AbsolutePath))
                {
                    // Then check the url.
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.StatusDescription = HttpStatusCode.NotFound.ToString();
                    responseString = string.Empty;
                }
                else
                {
                    // Send the request to the task scheduler.
                    if (!GetResponse(out responseString))
                    {
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.StatusDescription = HttpStatusCode.InternalServerError.ToString();
                        responseString = string.Empty;
                    }
                }

                // Get a response stream and write the response to it.
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;

                // The client might have closed the connection, therefore we have to deal with this special case here.
                // We cannot exit this method for this reason, otherwise the URL stay registered and we cannot create the listener anymore.
                // This happened and allowed us to find the issue.
                try
                {
                    output.Write(buffer, 0, buffer.Length);

                    // You must close the output stream.
                    output.Close();
                }
                catch (Exception exception)
                {
                    // Just log it.
                    Logger.ErrorException(this, "Error while writing the HTTP response to the client.", exception);
                }
            }
            catch (Exception exception)
            {
                Logger.ErrorException(this, "HTTP Listener aborted from callback.", exception);
                if (this.CloseRequested)
                {
                    Logger.ErrorException(this, "Close requested, the listener shall not start anymore.", exception);
                }
                else
                {
                    Logger.ErrorException(this, "Close NOT requested, the listener shall start again.", exception);
                    this.InternalStart();
                }
            }
        }

        #endregion
    }
}
