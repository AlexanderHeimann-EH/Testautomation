// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TddAppComController.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    using DisplayContentLib;

    using ProtocolStack.AppComProtocolLayer;
    using ProtocolStack.AppComProtocolLayer.Requests;
    using ProtocolStack.AppComProtocolLayer.SynchronousResponses;
    using ProtocolStack.LowLevelLayer;

    using TDD_APPCOM.MessageProcessing;
    using TDD_APPCOM.Uri;

    using TDD_Common.Constants;
    using TDD_Common.Interfaces;
    using TDD_Common.Types;

    /// <summary>
    /// Controller class for TDD_APPCOM. This is the main entry point for commands.
    /// </summary>
    public class TddAppComController : IInvokableTddControlInstance
    {
        #region constants

        /// <summary>
        /// The device id.
        /// </summary>
        public const int DefaultDeviceNumber = 1;

        /// <summary>
        /// No error string.
        /// </summary>
        public const string NoErrorString = "No error";

        /// <summary>
        /// Polling interval for polling responses received via terminal.
        /// </summary>
        private const int WaitForTerminalResponsePeriodMs = 100;

        /// <summary>
        /// Polling interval for polling echo responses received.
        /// </summary>
        private const int WaitForEchoResponsePeriodMs = 10;

        /// <summary>
        /// The data format strings.
        /// </summary>
        private static readonly string[] DateFormats = { "yyyy-MM-dd", "dd.MM.yyyy", "MM/dd/yyyy" };

        /// <summary>
        /// The time format strings.
        /// </summary>
        private static readonly string[] TimeFormats = { "HH:mm:ss" };

        #endregion

        #region member variables

        /// <summary>
        /// The APPCOM HTTP client.
        /// </summary>
        private readonly AppComHttpClient httpClient;

        /// <summary>
        /// The APPCOM HTTP server (used for reception of push messages).
        /// </summary>
        public readonly AppComHttpServer pushMessageServer;

        /// <summary>
        /// The push message processor.
        /// </summary>
        private readonly PushMessageProcessor pushMessageProcessor;

        /// <summary>
        /// The APPCOM protocol layer.
        /// </summary>
        private readonly AppComProtocolLayer appComProtocolLayer;

        /// <summary>
        /// The URI creator. This instance is used for creation of URIs.
        /// </summary>
        private readonly UriCreator uriCreator;
        
        /// <summary>
        /// The logger object. This reference is used to write log entries.
        /// </summary>
        //private Logger log;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TddAppComController"/> class.
        /// </summary>
        /// <param name="remoteHost">The host name of APP interface.</param>
        /// <param name="remotePort">The port of APP interface.</param>
        /// <param name="pushMessageServerHost">The host name of the push message server.</param>
        /// <param name="pushMessageServerPort">The port of the push message server.</param>
        public TddAppComController(string remoteHost, ushort remotePort, string pushMessageServerHost, ushort pushMessageServerPort)
        {
            // get logger reference
            // this.log = LogCreator.GetInstance();

            // method entry log message
            // this.log.Trace("TddAppComController(...) - running...");

            // set parameter inherited parameter values
            this.LastError = new KeyValuePair<int, string>(0, NoErrorString);
            this.DeviceNumber = DefaultDeviceNumber;
            this.ChannelNumber = TddConstants.NoChannelNumber;

            // create URI creator
            this.uriCreator = new UriCreator(remoteHost, remotePort);

            // create HTTP client
            this.httpClient = new AppComHttpClient();
            // this.log.Info("TddAppComController(...) - HTTP client started.");

            // create HTTP server
            this.pushMessageServer = new AppComHttpServer(pushMessageServerHost, pushMessageServerPort);            
            // this.log.Info("TddAppComController(...) - Push message server is started. Listening on '{0}':{1}", pushMessageServerHost, pushMessageServerPort);

            // create APPCOM protocol layer.
            this.appComProtocolLayer = new AppComProtocolLayer(this.httpClient, this.pushMessageServer);
            // this.log.Info("TddAppComController(...) - APPCOM protocol layer started.");

            // create processors for asynchronous messages
            this.pushMessageProcessor = new PushMessageProcessor(this.appComProtocolLayer);
            // this.log.Info("TddAppComController(...) - Push message processor started.");

            // register push message server
            try
            {
                this.RegisterPushMessageServer();
                // this.log.Info("TddAppComController(...) - Push message server registered.");
            }
            catch (Exception exception)
            {
                // this.log.Warn("TddAppComController(...) - Cannot register push message server. Error: {0}", exception.Message);
            }

            // method exit log message
            // this.log.Trace("TddAppComController(...) - done");
        }

        #endregion

        #region properties (inherited from IInvokableTddControlInstance)

        /// <summary>
        /// Gets the device number.
        /// </summary>
        public int DeviceNumber { get; private set; }

        /// <summary>
        /// Gets the channel number.
        /// </summary>
        public int ChannelNumber { get; private set; }

        /// <summary>
        /// Gets or sets the thread queue id.
        /// </summary>
        public int ThreadQueueId { get; set; }

        /// <summary>
        /// Gets the last error.
        /// </summary>
        public KeyValuePair<int, string> LastError { get; private set; }

        #endregion

        #region public methods (interface to JSON interface)

        /// <summary>
        /// This method registers the push message server to test automation server in app.
        /// </summary>
        public void RegisterPushMessageServer()
        {
            // method entry log message
            // this.log.Trace("RegisterPushMessageServer(...) - running...");

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var pushMessageServerUri = UriCreator.BuildUri(this.pushMessageServer.Host, this.pushMessageServer.Port);
            var appComMessage =
                RequestCreator.CreateRegisterResponseServerRequest(
                    pushMessageServerUri.ToString(),
                    this.pushMessageProcessor.Token);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);
            // this.log.Debug("RegisterPushMessageServer(...) - Push message server '{0}' registered", pushMessageServerUri);

            // enable all notifications
            this.EnableTerminalNotifications();
            // this.log.Info("RegisterPushMessageServer(...) - terminal notifications enabled.");

            // method exit log message
            // this.log.Trace("RegisterPushMessageServer(...) - done");
        }

        /// <summary>
        /// This method unregisters a push message server.
        /// </summary>
        public void UnregisterPushMessageServer()
        {
            // method entry log message
            // this.log.Trace("UnregisterPushMessageServer(...) - running...");

            // disable all notifications
            this.DisableTerminalNotifications();
            // this.log.Info("UnregisterPushMessageServer(...) - Terminal notifications disabled.");

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateUnregisterResponseServerRequest();

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Trace("UnregisterPushMessageServer(...) - done");
        }

        /// <summary>
        /// This method sends a echo message and waits for a response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="timeoutMilliseconds">The timeout in milliseconds.</param>
        /// <returns>The echo.</returns>
        public string CallEcho(string message, uint timeoutMilliseconds)
        {
            // method entry log message
            // this.log.Trace("CallEcho(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create string for response
            var response = new StringBuilder();

            // clear list of echo messages
            this.pushMessageProcessor.GetEchoMessages();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateCallEchoRequest(message);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // wait for answer
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var succeed = false;
            var done = false;

            while (!done)
            {
                if (stopWatch.ElapsedMilliseconds > timeoutMilliseconds)
                {
                    done = true;
                }
                else
                {
                    Thread.Sleep(WaitForEchoResponsePeriodMs);
                    var newMessages = this.pushMessageProcessor.GetEchoMessages();

                    foreach (var newMessage in newMessages)
                    {
                        response.Append(newMessage);
                    }

                    if (newMessages.Length > 0)
                    {
                        done = true;
                        succeed = true;
                    }
                }
            }

            if (!succeed)
            {
                // this.log.Info("Timeout");
                throw new TDDException("Timeout");
            }

            // method exit log message
            // this.log.Debug("CallEcho(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("CallEcho(...) - done");

            return response.ToString();
        }

        /// <summary>
        /// This method queries the device list from app.
        /// </summary>
        /// <returns>The device list.</returns>
        public DeviceDataSet[] GetDeviceList()
        {
            // method entry log message
            // this.log.Trace("GetDeviceList(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetDeviceListUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());
            var responseString = Encoding.UTF8.GetString(resonse);

            // analyze response
            var devices = GetDeviceListResponseAnalyzer.Analyze(responseString);
            // this.log.Info("GetDeviceList(...) - {0} devices found.", devices.Length);

            // method exit log message
            // this.log.Debug("GetDeviceList(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("GetDeviceList(...) - done");

            return devices;
        }

        /// <summary>
        /// This method establishes a connection to device by wireless name.
        /// </summary>
        /// <param name="name">The wireless name of the device.</param>
        /// <param name="username">The user name for log-in to field device.</param>
        /// <param name="password">The password for log-in to field device.</param>
        public void ConnectToDeviceByName(string name, string username, string password)
        {
            // method entry log message
            // this.log.Trace("ConnectToDeviceByName(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateConnectToDeviceByNameRequest(name, username, password);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("ConnectToDeviceByName(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("ConnectToDeviceByName(...) - done");
        }

        /// <summary>
        /// This method establishes a connection to device by UUID.
        /// </summary>
        /// <param name="uuid">The UUID of the device.</param>
        /// <param name="username">The user name for log-in to field device.</param>
        /// <param name="password">The password for log-in to field device.</param>
        public void ConnectToDeviceByUuid(string uuid, string username, string password)
        {
            // method entry log message
            // this.log.Trace("ConnectToDeviceByUuid(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateConnectToDeviceByUuidRequest(uuid, username, password);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("ConnectToDeviceByUuid(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("ConnectToDeviceByUuid(...) - done");
        }

        /// <summary>
        /// This method disconnects from device.
        /// </summary>
        public void DisconnectFromDevice()
        {
            // method entry log message
            // this.log.Trace("DisconnectFromDevice(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateDisconnectFromDeviceRequest();

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("DisconnectFromDevice(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("DisconnectFromDevice(...) - done");
        }

        /// <summary>
        /// This method returns current connection data.
        /// </summary>
        /// <returns>The data of connected device.</returns>
        public DeviceIdentifier IdentifyCurrentDeviceConnection()
        {
            // method entry log message
            // this.log.Trace("IdentifyCurrentDeviceConnection(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetIdentifyCurrentDeviceConnectionUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());
            var responseString = Encoding.UTF8.GetString(resonse);

            // analyze response
            var deviceIdentifier = IdentifyCurrentDeviceConnectionAnalyzer.Analyze(responseString);
            // this.log.Info("IdentifyCurrentDeviceConnection(...) - Version = {0}; Name = '{1}'; UUID = '{2}'", deviceIdentifier.Version, deviceIdentifier.Name, deviceIdentifier.Uuid);

            // method exit log message
            // this.log.Debug("IdentifyCurrentDeviceConnection(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("IdentifyCurrentDeviceConnection(...) - done");

            return deviceIdentifier;
        }

        /// <summary>
        /// This method creates a screenshot of complete screen and stores it in a file.
        /// </summary>
        /// <param name="filename">The screenshot file name.</param>
        public void SaveScreenScreenshot(string filename)
        {
            // method entry log message
            // this.log.Trace("SaveScreenScreenshot(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetScreenScreenshotUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());

            // store screenshot to file
            using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(resonse, 0, resonse.Length);
            }

            // method exit log message
            // this.log.Debug("SaveScreenScreenshot(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SaveScreenScreenshot(...) - done");
        }

        /// <summary>
        /// This method creates a screenshot of complete screen and returns its content as base64 string.
        /// </summary>
        /// <returns>The base64 encoded screenshot.</returns>
        public string GetScreenScreenshot()
        {
            // method entry log message
            // this.log.Trace("GetScreenScreenshot(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetScreenScreenshotUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());

            // encode screenshot bytes to base64
            var base64EncodedScreenshot = System.Convert.ToBase64String(resonse);

            // method exit log message
            // this.log.Debug("GetScreenScreenshot(...) - size = {0} Byte (base64 size = {1})", resonse.Length, base64EncodedScreenshot.Length);
            // this.log.Debug("GetScreenScreenshot(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("GetScreenScreenshot(...) - done");

            return base64EncodedScreenshot;
        }

        /// <summary>
        /// This method creates a screenshot of app content and stores it in a file.
        /// </summary>
        /// <param name="filename">The screenshot file name.</param>
        public void SaveAppContentScreenshot(string filename)
        {
            // method entry log message
            // this.log.Trace("SaveAppContentScreenshot(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetAppContentScreenshotUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());

            // store screenshot to file
            using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(resonse, 0, resonse.Length);
            }

            // method exit log message
            // this.log.Debug("SaveAppContentScreenshot(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SaveAppContentScreenshot(...) - done");
        }

        /// <summary>
        /// This method creates a screenshot of app content and returns its content as base64 string.
        /// </summary>
        /// <returns>The base64 encoded screenshot.</returns>
        public string GetAppContentScreenshot()
        {
            // method entry log message
            // this.log.Trace("GetAppContentScreenshot(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetAppContentScreenshotUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());

            // encode screenshot bytes to base64
            var base64EncodedScreenshot = System.Convert.ToBase64String(resonse);

            // method exit log message
            // this.log.Debug("GetAppContentScreenshot(...) - size = {0} Byte (base64 size = {1})", resonse.Length, base64EncodedScreenshot.Length);
            // this.log.Debug("GetAppContentScreenshot(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("GetAppContentScreenshot(...) - done");

            return base64EncodedScreenshot;
        }

        /// <summary>
        /// This method queries the display content of field device.
        /// </summary>
        /// <returns>The display content.</returns>
        public string GetDisplayContent()
        {
            // method entry log message
            // this.log.Trace("GetDisplayContent(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetDisplayContentUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());
            var responseString = Encoding.UTF8.GetString(resonse);

            // method exit log message
            // this.log.Debug("GetDisplayContent(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("GetDisplayContent(...) - done");

            return responseString;
        }

        /// <summary>
        /// This method queries display content and converts it to a JSON string.
        /// </summary>
        /// <returns>The display content as JSON string.</returns>
        public string GetDisplayContentAsJson()
        {
            // method entry log message
            // this.log.Trace("GetDisplayContentAsJson(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create URI
            var uri = this.uriCreator.GetDisplayContentUri();

            // send get request
            var resonse = this.httpClient.Get(uri.ToString());
            var responseString = Encoding.UTF8.GetString(resonse);

            // convert response string to JSON string
            var jsonDisplayContentString = DisplayContentSupport.ConvertXmlToJson(responseString);

            // method exit log message
            // this.log.Debug("GetDisplayContentAsJson(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("GetDisplayContentAsJson(...) - done");

            return jsonDisplayContentString;
        }

        /// <summary>
        /// This method sends an ASCII command and collects the response/s. The commands are sent via terminal tunnel.
        /// </summary>
        /// <param name="message">The message that shall be sent.</param>
        /// <param name="answerCollectPeriodMilliseconds">The time duration in milliseconds in which the responses are collected.</param>
        /// <param name="endTag">
        /// The answer is complete, if end tag is found. If end tag is null or empty, the end tag will not be searched.
        /// </param>
        /// <returns>The response to the command.</returns>
        public string CallAsciiCommand(string message, uint answerCollectPeriodMilliseconds, string endTag)
        {
            // method entry log message
            // this.log.Trace("CallAsciiCommand(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();            
            
            // clear list of terminal output messages
            this.pushMessageProcessor.GetTerminalOutputMessage();

            // send ASCII command
            this.SendAsciiCommand(message);

            // wait for answer
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var succeed = true;
            var done = false;
            StringBuilder response = new StringBuilder();

            while (!done)
            {
                if (stopWatch.ElapsedMilliseconds > answerCollectPeriodMilliseconds)
                {
                    done = true;

                    if (!string.IsNullOrEmpty(endTag))
                    {
                        succeed = false;
                    }
                }
                else
                {
                    Thread.Sleep(WaitForTerminalResponsePeriodMs);
                    var newMessage = this.pushMessageProcessor.GetTerminalOutputMessage();
                    response.Append(newMessage);

                    if (!string.IsNullOrEmpty(endTag) && response.ToString().Contains(endTag))
                    {
                        done = true;
                    }
                }
            }

            if (!succeed)
            {
                // this.log.Info("Timeout");
                throw new TDDException("Timeout");
            }

            // method exit log message
            // this.log.Debug("CallAsciiCommand(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("CallAsciiCommand(...) - done");

            return response.ToString();
        }

        /// <summary>
        /// This method sends a ASCII command. The commands are sent via terminal tunnel.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void SendAsciiCommand(string message)
        {
            // method entry log message
            // this.log.Trace("SendAsciiCommand(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSendAsciiCommandRequest(message);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SendAsciiCommand(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SendAsciiCommand(...) - done");
        }

        /// <summary>
        /// This method is used to command the SmartBlue application to select a selectable item. 
        /// </summary>
        /// <param name="id">
        /// ID of item that shall be selected.
        /// </param>
        public void SelectItem(string id)
        {
            // method entry log message
            // this.log.Trace("SelectItem(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSelectItemRequest(id);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SelectItem(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SelectItem(...) - done");
        }

        /// <summary>
        /// This method is used to command the SmartBlue application to scroll a list.
        /// </summary>
        /// <param name="id">
        /// After scrolling, the item referenced by this ID should be the first visible item in the list. 
        /// </param>
        public void ScrollToItem(string id)
        {
            // method entry log message
            // this.log.Trace("ScrollToItem(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateScrollToItemRequest(id);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("ScrollToItem(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("ScrollToItem(...) - done");
        }

        /// <summary>
        /// This command is used to command the SmartBlue application to set the text value of a text box to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="value">New value</param>
        public void SetStringValue(string id, string value)
        {
            // method entry log message
            // this.log.Trace("SetStringValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSetStringValueRequest(id, value);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SetStringValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetStringValue(...) - done");
        }

        /// <summary>
        /// This method is used to command the SmartBlue application to set the text value of a text box to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="value">New value</param>
        public void SetNumericValue(string id, double value)
        {
            // method entry log message
            // this.log.Trace("SetNumericValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSetNumericValueRequest(id, value);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SetNumericValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetNumericValue(...) - done");
        }

        /// <summary>
        /// This method is used to command the SmartBlue application to set the date of an editable control to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="value">New value</param>
        public void SetDateValue(string id, string value)
        {
            // method entry log message
            // this.log.Trace("SetDateValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            DateTime dateTimeValue;
            var isSucceed = DateTime.TryParseExact(value, DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeValue);

            if (isSucceed)
            {
                var appComMessage = RequestCreator.CreateSetDateValueRequest(id, dateTimeValue);

                // send message
                this.appComProtocolLayer.Post(uri.ToString(), appComMessage);
            }
            else
            {
                var errorMessage = string.Format("Cannot parse date string '{0}'. Check format.", value);
                // this.log.Error("SetDateValue(...) - {0}", errorMessage);
                throw new TDDException(errorMessage);
            }

            // method exit log message
            // this.log.Debug("SetDateValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetDateValue(...) - done");
        }

        /// <summary>
        /// This command is used to command the SmartBlue application to set the time of an editable control to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="value">New value</param>
        public void SetTimeValue(string id, string value)
        {
            // method entry log message
            // this.log.Trace("SetTimeValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            DateTime dateTimeValue;
            var isSucceed = DateTime.TryParseExact(value, TimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeValue);

            if (isSucceed)
            {
                var appComMessage = RequestCreator.CreateSetTimeValueRequest(id, dateTimeValue);

                // send message
                this.appComProtocolLayer.Post(uri.ToString(), appComMessage);
            }
            else
            {
                var errorMessage = string.Format("Cannot parse time string '{0}'. Check format.", value);
                // this.log.Error("SetTimeValue(...) - {0}", errorMessage);
                throw new TDDException(errorMessage);
            }

            // method exit log message
            // this.log.Debug("SetTimeValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetTimeValue(...) - done");
        }

        /// <summary>
        /// This command is used to command the SmartBlue application to set the Boolean value of an editable control to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="value">New value</param>
        public void SetBooleanValue(string id, bool value)
        {
            // method entry log message
            // this.log.Trace("SetBooleanValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSetBooleanValueRequest(id, value);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SetBooleanValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetBooleanValue(...) - done");
        }

        /// <summary>
        /// This command is used to command the SmartBlue application to set the selection of a selection control to the specified value.
        /// </summary>
        /// <param name="id">
        /// The ID of the item, whose value shall be set.
        /// </param>
        /// <param name="values">A list of values that shall be selected.</param>
        public void SetSelectionValue(string id, int[] values)
        {
            // method entry log message
            // this.log.Trace("SetSelectionValue(...) - running...");

            // start stop watch for execution time measurement
            var executionTimeStopWatch = new Stopwatch();
            executionTimeStopWatch.Start();

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateSetSelectionValueRequest(id, values);

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Debug("SetSelectionValue(...) - duration = {0} ms", executionTimeStopWatch.ElapsedMilliseconds);
            // this.log.Trace("SetSelectionValue(...) - done");
        }

        /// <summary>
        /// This method returns all terminal output messages.
        /// </summary>
        /// <returns>A list of output messages.</returns>
        public string GetTerminalOutputMessage()
        {
            // method entry log message
            // this.log.Trace("GetTerminalOutputMessage(...) - running...");

            var outputMessages = this.pushMessageProcessor.GetTerminalOutputMessage();

            // method exit log message
            // this.log.Trace("GetTerminalOutputMessage(...) - done");

            return outputMessages;
        }

        /// <summary>
        /// This method returns a list of toast data sets and clears the list.
        /// </summary>
        /// <returns>The toast data sets.</returns>
        public ProtocolStack.AppComProtocolLayer.Notifications.ToastDataSet[] GetToastDataSets()
        {
            // method entry log message
            // this.log.Trace("GetToastDataSets(...) - running...");

            var toastDataSets = this.pushMessageProcessor.GetToastDataSets();

            // method exit log message
            // this.log.Trace("GetToastDataSets(...) - done");

            return toastDataSets;
        }

        /// <summary>
        /// This method returns a list of asynchronous errors.
        /// </summary>
        /// <returns>A list of error messages.</returns>
        public string[] GetExceptions()
        {
            // method entry log message
            // this.log.Trace("GetExceptions(...) - running...");

            var errorMessages = this.pushMessageProcessor.GetAsyncErrorMessages();

            // method entry log message
            // this.log.Trace("GetExceptions(...) - done");

            return errorMessages;
        }

        /// <summary>
        /// A notification listener can log in to notification service using this method.
        /// </summary>
        /// <param name="listenerName">The name of the notification listener.</param>
        /// <param name="listenerAddress">The address of the notification listener. Messages are sent to this address.</param>
        /// <param name="listenerPort">The port of the notification listener. Messages are sent to this port.</param>
        public void LoginNotificationListener(
            string listenerName, string listenerAddress, ushort listenerPort)
        {
            // method entry log message
            // this.log.Trace("LoginNotificationListener(...) - running...");

            this.pushMessageProcessor.LoginNotificationListener(listenerName, listenerAddress, listenerPort);

            // method exit log message
            // this.log.Trace("LoginNotificationListener(...) - done");
        }

        /// <summary>
        /// A notification listener can log out from notification service using this method.
        /// </summary>
        /// <param name="listenerName">The name of the notification listener.</param>
        public void LogoutNotificationListener(string listenerName)
        {
            // method entry log message
            // this.log.Trace("LogoutNotificationListener(...) - running...");

            this.pushMessageProcessor.LogoutNotificationListener(listenerName);

            // method exit log message
            // this.log.Trace("LogoutNotificationListener(...) - done");
        }

        /// <summary>
        /// This method returns a list of notification listener names.
        /// </summary>
        /// <returns>
        /// An array of notification listener names.
        /// </returns>
        public string[] GetNotificationListenerNames()
        {
            // method entry log message
            // this.log.Trace("GetNotificationListenerNames(...) - running...");

            var notificationListenerNames = this.pushMessageProcessor.GetNotificationListenerNames();

            // method exit log message
            // this.log.Trace("GetNotificationListenerNames(...) - done");
            return notificationListenerNames;
        }

        #endregion

        #region overridden methods (inherited from IInvokableTddControlInstance)

        /// <summary>
        /// The dynamic method invoker.
        /// </summary>
        /// <param name="methodName">
        /// The method name.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="T"> the return value of the invoked method
        /// </typeparam>
        /// <returns>
        /// The result of the invoked method.
        /// </returns>
        public T DynamicMethodInvoker<T>(string methodName, object[] parameters)
        {
            T retVal = default(T);
            int parameterCount = parameters.Length;

            Type moduleType = this.GetType();

            try
            {
                MethodInfo method = moduleType.GetMethod(methodName);

                if (null != method)
                {
                    // get parameters
                    ParameterInfo[] parameterInfos = method.GetParameters();

                    // check if given params are equal to expected params
                    if (parameterInfos.Length.Equals(parameterCount))
                    {
                        int index = 0;
                        foreach (var parameterInfo in parameterInfos)
                        {
                            if (parameters.Length > index)
                            {
                                // check parameter type
                                if (!(parameterInfo.ParameterType == parameters[index].GetType()))
                                {
                                    throw new TDDException("Unexpected parameter type");
                                }
                            }

                            index++;
                        }

                        // invoke method of specific channel
                        object obj = method.Invoke(this, parameters);
                        retVal = obj is T ? (T)obj : default(T);
                    }
                    else
                    {
                        throw new TDDException(string.Format("Invalid parameter count for method: {0}", methodName));
                    }
                }
                else
                {
                    throw new TDDException(
                        string.Format("Method {0} not found. Wrong channel? Wrong initialized Module?", methodName));
                }

                return retVal;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                throw exception.InnerException;
            }
        }

        /// <summary>
        /// The dynamic method invoker.
        /// </summary>
        /// <param name="channelNumber">
        /// The channel number.
        /// </param>
        /// <param name="methodName">
        /// The method name.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The object of given type.
        /// </returns>
        public T DynamicMethodInvoker<T>(int channelNumber, string methodName, object[] parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dispose methods. Frees all resources.
        /// </summary>
        public void Dispose()
        {
            // method entry log message
            // this.log.Trace("Dispose(...) - running...");

            // unregister push message server
            try
            {
                this.UnregisterPushMessageServer();
                // this.log.Info("Dispose(...) - Push message server unregistered.");
            }
            catch (Exception exception)
            {
                // this.log.Warn("Dispose(...) - Cannot unregister push message server. Error: {0}", exception.Message);
            }

            // close push message processor
            this.pushMessageProcessor.Dispose();
            // this.log.Info("Dispose(...) - Push message processor closed.");

            // close APPCOM protocol layer
            this.appComProtocolLayer.Dispose();
            // this.log.Info("Dispose(...) - APPCOM protocol layer stopped.");

            // close HTTP client
            this.httpClient.Dispose(); 
            // this.log.Info("Dispose(...) - HTTP client stopped.");

            // close push message server
            this.pushMessageServer.Dispose();
            // this.log.Info("Dispose(...) - Push message server stopped.");
            
            // method exit log message
            // this.log.Trace("Dispose(...) - done");

            // delete reference to logger
            // this.log = null;
        }

        /// <summary>
        /// Moves one parameter in header from one region to another
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void DragAndDrop(string itemId, string source, string destination)
        {
            this.ConnectToDeviceByUuid(itemId, source, destination);
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private methods

        /// <summary>
        /// This method enables the terminal notifications.
        /// </summary>
        private void EnableTerminalNotifications()
        {
            // method entry log message
            // this.log.Trace("EnableTerminalNotifications(...) - running...");

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateEnableTerminalNotificationsRequest();

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Trace("EnableTerminalNotifications(...) - done");
        }

        /// <summary>
        /// This method disables the terminal notifications.
        /// </summary>
        private void DisableTerminalNotifications()
        {
            // method entry log message
            // this.log.Trace("DisableTerminalNotifications(...) - running...");

            // create uri
            var uri = this.uriCreator.GetAppComInterfaceUri();

            // create message
            var appComMessage = RequestCreator.CreateDisableTerminalNotificationsRequest();

            // send message
            this.appComProtocolLayer.Post(uri.ToString(), appComMessage);

            // method exit log message
            // this.log.Trace("DisableTerminalNotifications(...) - done");
        }

        #endregion
    }
}
