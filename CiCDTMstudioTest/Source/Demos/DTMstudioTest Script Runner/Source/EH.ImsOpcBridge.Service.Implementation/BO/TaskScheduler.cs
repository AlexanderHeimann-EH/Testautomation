// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskScheduler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the main task scheduler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using System;
    using System.Net;
    using System.Threading;

    using EH.ImsOpcBridge.Common.Data;
    using EH.ImsOpcBridge.Common.Queue;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.FisCommunication.EventArguments;
    using EH.ImsOpcBridge.Service.FisCommunication.Http;
    using EH.ImsOpcBridge.Service.Implementation.BO.MonitorSchedulers;
    using EH.ImsOpcBridge.Service.Implementation.Clients;
    using EH.ImsOpcBridge.Service.Implementation.Data;
    using EH.ImsOpcBridge.Service.Implementation.Diagnostics;
    using EH.ImsOpcBridge.Service.Implementation.Documents;
    using EH.ImsOpcBridge.Service.Implementation.Fis;
    using EH.ImsOpcBridge.Service.Implementation.Http;
    using EH.ImsOpcBridge.Service.Implementation.Logging;
    using EH.ImsOpcBridge.Service.Implementation.Wcf;

    using OpcLabs.EasyOpc.DataAccess;

    using RequestParameters = EH.ImsOpcBridge.Service.Implementation.Http.RequestParameters;

    /// <summary>
    /// Class TaskScheduler
    /// </summary>
    internal class TaskScheduler
    {
        #region Constants

        /// <summary>
        /// The client end point name
        /// </summary>
        private const string ClientEndPointName = "EhImsOpcBridgeBinding_ICommServerCallback";

        /// <summary>
        /// The monitor refresh rate for the runtime view, in milliseconds.
        /// </summary>
        private const int ViewMonitorRefreshRate = 1000;

        /// <summary>
        /// Multiplication factor minutes to milliseconds.
        /// </summary>
        private const int MinutesToMilliseconds = 60000;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskScheduler"/> class.
        /// </summary>
        public TaskScheduler()
        {
            // Creates instances.
            this.DataManager = new DataManager();
            this.OpcManager = new OpcManager();
            this.FisRegistrationChannel = new Channel();
            this.FisRegistrationChannel.HttpResponseEvent += this.HttpRegistrationResponseEvent;
            this.FisDataChannel = new Channel();
            this.FisDataChannel.HttpResponseEvent += this.HttpDataResponseEvent;
            this.ViewMonitorTimeoutHandler = new TimeoutHandler(ViewMonitorRefreshRate);
            this.ViewMonitorScheduler = new ViewMonitorScheduler();
            this.SceMonitorScheduler = new SceMonitorScheduler();
            this.SceListener = new GenericListener();
            this.FisScheduler = new FisScheduler();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
        private DataManager DataManager { get; set; }

        /// <summary>
        /// Gets or sets the monitor callback address.
        /// </summary>
        /// <value>The monitor callback address.</value>
        private string MonitorCallbackAddress { get; set; }

        /// <summary>
        /// Gets or sets the opc manager.
        /// </summary>
        /// <value>The opc manager.</value>
        private OpcManager OpcManager { get; set; }

        /// <summary>
        /// Gets or sets the view monitor scheduler.
        /// </summary>
        /// <value>The view monitor scheduler.</value>
        private MonitorScheduler ViewMonitorScheduler { get; set; }

        /// <summary>
        /// Gets or sets the SupplyCare Enterprise monitor scheduler.
        /// </summary>
        /// <value>The SupplyCare Enterprise monitor scheduler.</value>
        private MonitorScheduler SceMonitorScheduler { get; set; }

        /// <summary>
        /// Gets or sets the view monitor timeout handler.
        /// </summary>
        /// <value>The view monitor timeout handler.</value>
        private TimeoutHandler ViewMonitorTimeoutHandler { get; set; }

        /// <summary>
        /// Gets or sets the HTTP listener for SupplyCare Enterprise.
        /// </summary>
        /// <value>The HTTP listener for SupplyCare Enterprise.</value>
        private GenericListener SceListener { get; set; }

        /// <summary>
        /// Gets or sets the communication channel for the FIS registration.
        /// </summary>
        /// <value>The communication channel for the FIS registration.</value>
        private Channel FisRegistrationChannel { get; set; }

        /// <summary>
        /// Gets or sets the communication channel for the FIS data.
        /// </summary>
        /// <value>The communication channel for the FIS data.</value>
        private Channel FisDataChannel { get; set; }

        /// <summary>
        /// Gets or sets the FIS scheduler.
        /// </summary>
        /// <value>The FIS scheduler.</value>
        private FisScheduler FisScheduler { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Runs the specified thread context.
        /// </summary>
        /// <param name="threadContext">The thread context.</param>
        public void Run(ThreadContext threadContext)
        {
            Logger.Info(this, "The task scheduler has started.");

            try
            {
                // Start SupplyCare Enterprise monitor.
                this.SceMonitorScheduler.Start(
                    this.DataManager.Configuration,
                    this.DataManager.Configuration.ConfiguredMeasurements,
                    this.RecalculateSamplingRate());

                // Subscribes configuration changes.
                this.DataManager.ConfigurationChanged += this.ConfigurationChanged;

                // Creates the request parameters and starts the HTTP listener.
                var parameters = this.CreateRequestParameters();
                this.SceListener.Start(parameters);

                while (true)
                {
                    // Release the CPU. We do not need to be faster at this point, because at each cycle the scheduler
                    // deques all messages that are in the message queue, therefore we do not lose any message.
                    Thread.Sleep(15);

                    // Checks whether the thread must terminate.
                    if (threadContext.ThreadTerminationRequestEvent.WaitOne(0))
                    {
                        break;
                    }

                    // Executes the various tasks.
                    this.TaskMessageQueue();
                    this.TaskViewMonitor();

                    // emilio temp
                    // This method is the only point where FIS can be disabled in the code. It will be disabled for the first release,
                    // where only SCE is active.
                    // this.TaskFisScheduler();
                }

                // Close the HTTP listener.
                this.SceListener.Close();

                // Unsubscribes configuration changes.
                this.DataManager.ConfigurationChanged -= this.ConfigurationChanged;

                // Clean resources and/or stops possible running tasks.
                this.ViewMonitorScheduler.Stop();
                this.SceMonitorScheduler.Stop();

                // Set termination response event.
                threadContext.ThreadTerminationResponseEvent.Set();
            }
            catch (Exception exception)
            {
                Logger.FatalException(this, "Fatal exception during task scheduler execution!", exception);
                throw;
            }

            Logger.Info(this, "The task scheduler has stopped.");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Task that handles the message queue.
        /// </summary>
        private void TaskMessageQueue()
        {
            Message[] messages;
            if (MessageQueue.Instance.TryDequeueAll(out messages))
            {
                foreach (var message in messages)
                {
                    uint error;
                    Exception exception;
                    switch (message.MessageType)
                    {
                        case MessageTypes.LoadConfigurationRequest:
                            {
                                // The service has always a valid configuration.
                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnLoadConfigurationResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId,
                                            this.DataManager.Configuration, ResultCodes.Success, null
                                        });
                            }

                            break;

                        case MessageTypes.SaveConfigurationRequest:
                            {
                                var x = message.ReadParameter(ParameterTypes.Configuration);
                                var configuration = x as Configuration;
                                this.DataManager.TrySaveConfiguration(configuration, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnSaveConfigurationResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, error,
                                            exception
                                        });
                            }

                            break;

                        case MessageTypes.ImportConfigurationRequest:
                            {
                                var x = message.ReadParameter(ParameterTypes.FileName);
                                var fileName = x as string;
                                Configuration configuration;
                                this.DataManager.TryImportConfiguration(
                                    fileName, out configuration, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnImportConfigurationResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId,
                                            configuration, error, exception
                                        });
                            }

                            break;

                        case MessageTypes.ExportConfigurationRequest:
                            {
                                var x = message.ReadParameter(ParameterTypes.Configuration);
                                var configuration = x as Configuration;
                                x = message.ReadParameter(ParameterTypes.FileName);
                                var fileName = x as string;
                                this.DataManager.TryExportConfiguration(
                                    fileName, configuration, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnExportConfigurationResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, error,
                                            exception
                                        });
                            }

                            break;

                        case MessageTypes.ReadLocalOpcServersRequest:
                            {
                                OpcServerItems servers;
                                this.OpcManager.ReadLocalOpcServers(out servers, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnReadLocalOpcServersResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, servers
                                            , error, exception
                                        });
                            }

                            break;

                        case MessageTypes.ReadOpcAddressSpaceRequest:
                            {
                                var x = message.ReadParameter(ParameterTypes.ServerName);
                                var serverName = x as string;
                                OpcItem opcItem;
                                this.OpcManager.ReadOpcAddressSpace(serverName, out opcItem, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnReadOpcAddressSpaceResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, opcItem
                                            , error, exception
                                        });
                            }

                            break;

                        case MessageTypes.StartMonitorRequest:
                            {
                                var x = message.ReadParameter(ParameterTypes.ConfiguredMeasurements);
                                var measurements = x as ConfiguredMeasurements;
                                this.StartViewMonitor(
                                    message.CallbackEndpointAddress, measurements, out error, out exception);

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnStartMonitorResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, error,
                                            exception
                                        });
                            }

                            break;

                        case MessageTypes.StopMonitorRequest:
                            {
                                this.StopViewMonitor(out error, out exception);

                                // Internally we have error handling, but the GUI should never see an error at this point.
                                error = ResultCodes.Success;
                                exception = null;
                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnStopMonitorResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId, error,
                                            exception
                                        });
                            }

                            break;

                        case MessageTypes.SceDataRequest:
                            {
                                var state = message.State as ResponseState;
                                if (state != null)
                                {
                                    string responseString;
                                    this.CreateDocument(out responseString);
                                    state.SetResponse(responseString);
                                }
                            }

                            break;

                        case MessageTypes.DiagnosticsRequest:
                            {
                                var diagnosticsMessages = DiagnosticsCollection.Instance.ReadMessages();

                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnDiagnosticsResponse,
                                    new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId,
                                            diagnosticsMessages, ResultCodes.Success, null
                                        });
                            }

                            break;

                        case MessageTypes.FisRegistrationRequest:
                            {
                                // The FIS registration request can be sent if there is a valid gateway model and serial number.
                                // If not, then an immediate error response is given back here.
                                FisCommunication.Http.RequestParameters parameters;
                                bool firstRegistration;
                                string body;

                                if (!this.CreateBodyForFisRegistration(out body, out exception) || !this.CreateFisRequestParameters(out parameters, CommonFormat.FisRegistrationUri, body, out firstRegistration, out exception))
                                {
                                    ThreadPool.QueueUserWorkItem(
                                        Callbacks.OnFisRegistrationResponse,
                                        new object[]
                                        {
                                            ClientEndPointName, message.CallbackEndpointAddress, message.InvokeId,
                                            ResultCodes.CannotRegisterFis, exception
                                        });
                                }
                                else
                                {
                                    // The registration can be sent to the FIS Server.
                                    this.FisRegistrationChannel.FirstRegistration = firstRegistration;
                                    this.FisRegistrationChannel.SendRequest(parameters, new Tuple<string, Guid>(message.CallbackEndpointAddress, message.InvokeId));
                                }
                            }

                            break;

                        case MessageTypes.FisRegistrationResponse:
                            {
                                var x = message.ReadParameter(ParameterTypes.FisHttpResponse);
                                var args = x as HttpResponseEventArgs;

                                this.ProcessFisRegistrationResponse(message.CallbackEndpointAddress, message.InvokeId, args);
                            }

                            break;

                        case MessageTypes.ClientStartIndication:
                            {
                                ClientCollection.Instance.AddClientUri(message.CallbackEndpointAddress);
                            }

                            break;

                        case MessageTypes.ClientStopIndication:
                            {
                                ClientCollection.Instance.RemoveClientUri(message.CallbackEndpointAddress);
                            }

                            break;

                        case MessageTypes.DiagnosticsIndication:
                            {
                                var x = message.ReadParameter(ParameterTypes.Diagnostics);
                                var diagnosticsMessages = x as DiagnosticsMessages;
                                ThreadPool.QueueUserWorkItem(
                                    Callbacks.OnDiagnosticsIndication,
                                    new object[]
                                        { ClientEndPointName, message.CallbackEndpointAddress, diagnosticsMessages });
                            }

                            break;

                        case MessageTypes.OnMonitoredItemChangedIndication:
                            {
                                var opcMonitor = message.State as OpcMonitor;
                                var x = message.ReadParameter(ParameterTypes.OpcDaItemChangedEventArgs);
                                var args = x as EasyDAItemChangedEventArgs;
                                if (opcMonitor != null && args != null)
                                {
                                    opcMonitor.OnMonitoredItemChanged(args);
                                }
                            }

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handle the FIS scheduler.
        /// </summary>
        private void TaskFisScheduler()
        {
            var result = this.FisScheduler.TimeToSendData(this.DataManager.Configuration.FisSettings.TimeSchedule);
            if (result)
            {
                // We must always check for the time to keep the time mechanism ongoing.
                // Additionally we check also whether FIS is active or not, before sending data.
                // The time checking is independent and it should run constantly.
                if (this.IsFisCommunicationRequired())
                {
                    // Data must be prepared and sent here because at this time everything is consistent.
                    // We don't know what it shall be later if th request is enqueued.
                    FisCommunication.Http.RequestParameters parameters;
                    Exception exception;
                    bool firstRegistration;
                    string body;

                    if (!this.CreateBodyForFisDataSend(out body, out exception) || !this.CreateFisRequestParameters(out parameters, CommonFormat.FisDataSendUri, body, out firstRegistration, out exception))
                    {
                        // There is nothing to do but logging.
                        Logger.ErrorException(this, "Create Fis Data Send Parameters: error creating parameters.", exception);
                        DiagnosticsCollection.Instance.AddMessage("Create Fis Data Send Parameters: error creating parameters.");
                        DiagnosticsCollection.Instance.AddMessage(exception);
                    }
                    else
                    {
                        // The data can be sent to the FIS Server.
                        this.FisDataChannel.FirstRegistration = firstRegistration;
                        this.FisDataChannel.SendRequest(parameters, null);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the body for the FIS registration.
        /// </summary>
        /// <param name="body">The body of the HTTP request.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the body string could be created, <c>false</c> otherwise.</returns>
        private bool CreateBodyForFisRegistration(out string body, out Exception exception)
        {
            var result = true;
            body = null;
            exception = null;

            var model = this.DataManager.Configuration.Gateway.Model;
            var serialNumber = this.DataManager.Configuration.Gateway.SerialNumber;

            if (string.IsNullOrEmpty(model) || string.IsNullOrEmpty(serialNumber))
            {
                exception = new Exception("Cannot register Gateway to FIS. Missing Model or SerialNumber");

                Logger.ErrorException(this, "Error during Gateway registration to FIS.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error during Gateway registration to FIS.");
                DiagnosticsCollection.Instance.AddMessage(exception);

                result = false;
            }
            else
            {
                body = string.Format(CommonFormat.FisRegistrationBody, model, serialNumber);
            }

            return result;
        }

        /// <summary>
        /// Creates the body for the FIS data send.
        /// </summary>
        /// <param name="body">The body of the HTTP request.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the body string could be created, <c>false</c> otherwise.</returns>
        private bool CreateBodyForFisDataSend(out string body, out Exception exception)
        {
            // todo.
            var result = true;
            body = null;
            exception = null;
            return result;
        }

        /// <summary>
        /// Creates the parameters for the FIS request.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="uriSpecific">The URI specific part, registration or data send.</param>
        /// <param name="body">The body of the HTTP request.</param>
        /// <param name="firstRegistration">if set to <c>true</c> [first registration].</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the parameters could be created, <c>false</c> otherwise. In case of false an additional exception is returned.</returns>
        private bool CreateFisRequestParameters(out FisCommunication.Http.RequestParameters parameters, string uriSpecific, string body, out bool firstRegistration, out Exception exception)
        {
            bool result;

            parameters = default(FisCommunication.Http.RequestParameters);
            var uri = this.DataManager.Configuration.FisSettings.InternetAddress.Url;
            var user = this.DataManager.Configuration.FisSettings.Authentication.User;
            var password = this.DataManager.Configuration.FisSettings.Authentication.Password;

            // It must be checked here whether we are requesting a first registration or not.
            firstRegistration = this.FisFirstRegistrationRequired(ref user, ref password);

            if (string.IsNullOrEmpty(uri) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                exception =
                    new Exception(
                        "Cannot register Gateway to FIS. Missing FIS internet address, User or Password.");
                parameters = default(FisCommunication.Http.RequestParameters);

                Logger.ErrorException(this, "Error during Gateway registration to FIS.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error during Gateway registration to FIS.");
                DiagnosticsCollection.Instance.AddMessage(exception);

                result = false;
            }
            else
            {
                exception = null;
                var completeUri = uri + uriSpecific;

                var basicParameters = new BasicParameters(completeUri, true, user, password);
                var proxyParameters = default(BasicParameters);

                if (this.DataManager.Configuration.ProxySettings.Enabled)
                {
                    try
                    {
                        proxyParameters = this.CreateProxyParameters();
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        Logger.ErrorException(this, "CreateFisRegistrationParameters: error creating proxy parameters.", exception);
                        DiagnosticsCollection.Instance.AddMessage("CreateFisRegistrationParameters: error creating proxy parameters.");
                        DiagnosticsCollection.Instance.AddMessage(exception);
                        return false;
                    }
                }

                parameters =
                    new FisCommunication.Http.RequestParameters(
                        basicParameters,
                        this.DataManager.Configuration.ProxySettings.Enabled,
                        proxyParameters,
                        CommonFormat.FisRegistrationMethod,
                        CommonFormat.FisRegistrationContentType,
                        CommonFormat.FisRegistrationWebTimeout,
                        body);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creates the proxy parameters. This struct is created only if the proxy is required.
        /// </summary>
        /// <returns>The struct containing the proxy parameters.</returns>
        private BasicParameters CreateProxyParameters()
        {
            try
            {
                var ub = new UriBuilder(this.DataManager.Configuration.ProxySettings.InternetAddress.Url)
                             {
                                 Port =
                                     (int)
                                     this
                                         .DataManager
                                         .Configuration
                                         .ProxySettings
                                         .InternetAddress
                                         .Port
                             };

                var proxyParameters = new BasicParameters(
                    ub.Uri.ToString(),
                    this.DataManager.Configuration.ProxySettings.Authentication.Active,
                    this.DataManager.Configuration.ProxySettings.Authentication.User,
                    this.DataManager.Configuration.ProxySettings.Authentication.Password);

                return proxyParameters;
            }
            catch (Exception exception)
            {
                Logger.ErrorException(this, "CreateProxyParameters: error creating proxy parameters.", exception);
                DiagnosticsCollection.Instance.AddMessage("CreateProxyParameters: error creating proxy parameters.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                throw;
            }
        }

        /// <summary>
        /// Creates the document to send to SupplyCare Enterprise.
        /// </summary>
        /// <param name="responseString">The response string.</param>
        private void CreateDocument(out string responseString)
        {
            try
            {
                RuntimeMeasurements measurements;
                if (!this.SceMonitorScheduler.DataToSend(out measurements))
                {
                    // Empty document is valid, only the header shall be sent.
                    // The empty collection must be created here because the out variable can be unpredictable at this point.
                    measurements = new RuntimeMeasurements();
                }

                var document = new SceDocument(this.DataManager.Configuration, measurements);
                document.Create();

                responseString = document.ToString();
            }
            catch (Exception exception)
            {
                Logger.FatalException(this, "Error creating SupplyCare Enterprise document.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error creating SupplyCare Enterprise document.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                
                // Sets the local variables to prevent somehow unexpected values.
                responseString = string.Empty;
            }
        }

        /// <summary>
        /// Create the request parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="Http.RequestParameters"/>.
        /// </returns>
        private RequestParameters CreateRequestParameters()
        {
            var port = (int)this.DataManager.Configuration.SupplyCareSettings.Port;
            var authenticationRequired = this.DataManager.Configuration.SupplyCareSettings.Authentication.Active;
            var user = this.DataManager.Configuration.SupplyCareSettings.Authentication.User;
            var password = this.DataManager.Configuration.SupplyCareSettings.Authentication.Password;

            return new RequestParameters(port, authenticationRequired, user, password);
        }

        /// <summary>
        /// Called when the configurations has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ConfigurationChanged(object sender, EventArgs e)
        {
            Logger.Info(this, "The configuration has changed. The OPC Monitor shall restart.");

            // The SupplyCare Enterprise monitor must be stopped and started again,
            // because the underlying configured measurements might have changed.
            // A new instance is started before stopping the current one otherwise
            // we have side effects when the OPC server stops and starts immediately.
            // Some OPC server restarts too slow and we miss data for SCE.
            var scheduler = new SceMonitorScheduler();
            scheduler.Start(
                this.DataManager.Configuration,
                this.DataManager.Configuration.ConfiguredMeasurements,
                this.RecalculateSamplingRate());

            this.SceMonitorScheduler.Stop();
            this.SceMonitorScheduler = scheduler;

            // Creates the request parameters and starts the HTTP listener.
            var parameters = this.CreateRequestParameters();
            this.SceListener.Start(parameters);
        }

        /// <summary>
        /// Task that handles the view monitor.
        /// </summary>
        private void TaskViewMonitor()
        {
            if (this.ViewMonitorTimeoutHandler.IsExpired())
            {
                // Checks whether there is data to send.
                RuntimeMeasurements runtimeMeasurements;
                if (this.ViewMonitorScheduler.DataToSend(out runtimeMeasurements))
                {
                    // Send the data.
                    ThreadPool.QueueUserWorkItem(
                        Callbacks.OnRuntimeMeasurementsIndication,
                        new object[] { ClientEndPointName, this.MonitorCallbackAddress, runtimeMeasurements });
                }

                // Sets the current time.
                this.ViewMonitorTimeoutHandler.SetCurrentTime();
            }
        }

        /// <summary>
        /// Starts the view monitor.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="measurements">The measurements.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise</returns>
        private bool StartViewMonitor(string callbackEndpointAddress, ConfiguredMeasurements measurements, out uint error, out Exception exception)
        {
            if (this.ViewMonitorScheduler.IsRunning)
            {
                error = ResultCodes.MonitorAlreadyRunning;
                exception = null;
                return false;
            }

            if (measurements == null)
            {
                error = ResultCodes.MissingArgument;
                exception = null;
                return false;
            }

            // Checks gateway validity.
            if (!OpcMonitor.IsGatewayValid(this.DataManager.Configuration.Gateway))
            {
                error = ResultCodes.InvalidGateway;
                exception = null;
                return false;
            }

            // Start monitor.
            this.ViewMonitorScheduler.Start(this.DataManager.Configuration, measurements, ViewMonitorRefreshRate);
            this.ViewMonitorTimeoutHandler.SetCurrentTime();
            this.MonitorCallbackAddress = callbackEndpointAddress;
            error = ResultCodes.Success;
            exception = null;
            return true;
        }

        /// <summary>
        /// Stops the view monitor.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise</returns>
        private bool StopViewMonitor(out uint error, out Exception exception)
        {
            if (!this.ViewMonitorScheduler.IsRunning)
            {
                error = ResultCodes.MonitorNotRunning;
                exception = null;
                return false;
            }

            // Stop monitor.
            this.ViewMonitorScheduler.Stop();
            error = ResultCodes.Success;
            exception = null;
            return true;
        }

        /// <summary>
        /// Processes the HttpResponseEvent event of the channel control. This event brings the response after FIS registration.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke identifier.</param>
        /// <param name="e">The <see cref="HttpResponseEventArgs" /> instance containing the event data.</param>
        private void ProcessFisRegistrationResponse(string callbackEndpointAddress, Guid invokeId, HttpResponseEventArgs e)
        {
            if (e != null)
            {
                var user = string.Empty;
                var pw = string.Empty;
                var good = false;

                // Check whether the response is good.
                if (e.ResultCode)
                {
                    // In some case the HttpStatusCode is wrapped into an Exception, in some case not. Check it before continuing.
                    if (e.StatusCode == HttpStatusCode.OK || e.StatusCode == HttpStatusCode.Created)
                    {
                        // Body is included only for first registrations.
                        if (this.FisRegistrationChannel.FirstRegistration)
                        {
                            // Parse the body for the received data.
                            var model = this.DataManager.Configuration.Gateway.Model;
                            var serialNumber = this.DataManager.Configuration.Gateway.SerialNumber;

                            var parser = new RegistrationParser(e.ResponseString, model, serialNumber);
                            if (parser.ExtractUserPassword(out user, out pw))
                            {
                                good = true;
                            }
                        }
                        else
                        {
                            // It is enough to check here the HttpStatusCode.
                            good = true;
                        }
                    }
                }

                if (good)
                {
                    // Change the FIS authentication for future data send to FIS server.
                    if (this.FisRegistrationChannel.FirstRegistration)
                    {
                        this.ChangeFisAuthentication(user, pw);
                    }

                    Logger.Info(this, "Gateway registered to FIS successfully.");

                    ThreadPool.QueueUserWorkItem(
                        Callbacks.OnFisRegistrationResponse,
                        new object[] { ClientEndPointName, callbackEndpointAddress, invokeId, ResultCodes.Success, null });
                }
                else
                {
                    Logger.ErrorException(this, "Error received Gateway registration response.", e.Exception);
                    DiagnosticsCollection.Instance.AddMessage("Error received Gateway registration response.");
                    DiagnosticsCollection.Instance.AddMessage(e.Exception);

                    ThreadPool.QueueUserWorkItem(
                        Callbacks.OnFisRegistrationResponse,
                        new object[]
                            {
                                ClientEndPointName, callbackEndpointAddress, invokeId, ResultCodes.CannotRegisterFis,
                                e.Exception
                            });
                }
            }
        }

        /// <summary>
        /// Changes the FIS authentication.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        private void ChangeFisAuthentication(string user, string password)
        {
            this.DataManager.Configuration.FisSettings.Authentication.User = user;
            this.DataManager.Configuration.FisSettings.Authentication.Password = password;
        }

        /// <summary>
        /// Handles the HttpResponseEvent event of the channel control. This event brings the response after FIS registration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="HttpResponseEventArgs"/> instance containing the event data.</param>
        private void HttpRegistrationResponseEvent(object sender, HttpResponseEventArgs e)
        {
            if (e != null)
            {
                var state = e.State as Tuple<string, Guid>;
                if (state != null)
                {
                    var callbackEndpointAddress = state.Item1;
                    var invokeId = state.Item2;

                    // Create message.
                    var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.FisRegistrationResponse);
                    message.AddParameter(ParameterTypes.FisHttpResponse, e);

                    // Enqueue message.
                    MessageQueue.Instance.Enqueue(message);
                }
            }
        }

        /// <summary>
        /// Handles the HttpResponseEvent event of the channel control. This event brings the response after FIS data send.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="HttpResponseEventArgs"/> instance containing the event data.</param>
        private void HttpDataResponseEvent(object sender, HttpResponseEventArgs e)
        {
            // This event is used only to log possible errors.
            if (e != null)
            {
                if (e.ResultCode)
                {
                    if (e.StatusCode == HttpStatusCode.OK || e.StatusCode == HttpStatusCode.Created)
                    {
                        Logger.InfoFormat(this, "Data sent to FIS success! HttpStatusDescription: {0}", e.StatusDescription);
                    }
                    else
                    {
                        var t = "Data sent to FIS error. " + e.StatusDescription;
                        Logger.Error(this, t);
                        DiagnosticsCollection.Instance.AddMessage(t);
                    }
                }
                else
                {
                    if (e.Exception != null)
                    {
                        const string T = "Data sent to FIS exception.";
                        Logger.ErrorException(this, T, e.Exception);
                        DiagnosticsCollection.Instance.AddMessage(T);
                        DiagnosticsCollection.Instance.AddMessage(e.Exception);
                    }
                    else
                    {
                        const string T = "Data sent to FIS error.";
                        Logger.Error(this, T);
                        DiagnosticsCollection.Instance.AddMessage(T);
                    }
                }
            }
        }

        /// <summary>
        /// Recalculates the sampling rate for the OPC scheduling. This method checks whether FIS monitoring is also requested or not and
        /// recalculate the optimal OPC sampling rate accordingly.
        /// </summary>
        /// <returns>The sampling rate in milliseconds.</returns>
        private int RecalculateSamplingRate()
        {
            var samplingRate = (int)this.DataManager.Configuration.SupplyCareSettings.SamplingRate * MinutesToMilliseconds;
            if (this.IsFisCommunicationRequired())
            {
                samplingRate = Math.Min(samplingRate, this.CalculateFisSamplingRate());
            }

            return samplingRate;
        }

        /// <summary>
        /// Calculates the FIS sampling rate. This method calculates the FIS OPC sampling rate according to the configured data.
        /// </summary>
        /// <returns>The OPC sampling rate in milliseconds.</returns>
        /// <remarks>
        /// SupplyCare is always requesting data, with a maximum interval of 10 minutes.
        /// Data should be sent to the FIS server exactly at a given time, for example at 12:00:00 or 12:05:00, depending on the settings.
        /// For this reason we set always one minute if FIS communication is enabled, to be sure that the data sent are relatively fresh.
        /// We leave this method here for possible future modifications.
        /// </remarks>
        private int CalculateFisSamplingRate()
        {
            return MinutesToMilliseconds;
        }

        /// <summary>
        /// Determines whether the FIS communication is required.
        /// </summary>
        /// <returns><c>true</c> if the FIS communication is required; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method checks all the conditions for which the FIS communication is required or not.
        /// </remarks>
        private bool IsFisCommunicationRequired()
        {
            // The communication with the FIS server is required if some conditions meet.
            // All the conditions are checked here in cascade.

            // Check FIS activation flag.
            if (!this.DataManager.Configuration.FisSettings.Enabled)
            {
                return false;
            }

            // Check the gateway validity.
            if (!OpcMonitor.IsGatewayValid(this.DataManager.Configuration.Gateway))
            {
                return false;
            }

            // Check whether a first registration has already been done.
            string user = null;
            string password = null;
            if (this.FisFirstRegistrationRequired(ref user, ref password))
            {
                return false;
            }

            // The communication with the FIS Server is active!
            return true;
        }

        /// <summary>
        /// Checks whether a first registration to the FIS server is required.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if a first registration to the FIS server is required, <c>false</c> otherwise.</returns>
        private bool FisFirstRegistrationRequired(ref string user, ref string password)
        {
            // It must be checked here whether we are requesting a first registration or not.
            var firstRegistration = false;

            // If some of these parameters is empty then we treat it as first registration.
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                firstRegistration = true;
                user = CommonFormat.FisFirstRegistrationUser;
                password = CommonFormat.FisFirstRegistrationPassword;
            }

            // It can be that both parameters were non empty and already set as first registration, it must also be checked here.
            if (user.Equals(CommonFormat.FisFirstRegistrationUser) && password.Equals(CommonFormat.FisFirstRegistrationPassword))
            {
                firstRegistration = true;
            }

            return firstRegistration;
        }

        #endregion
    }
}