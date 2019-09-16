namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.EventHandler
{
    using System;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    using ProtocolStack.LowLevelLayer;

    /// <summary>
    /// Class DisplayContentEventHandler.
    /// </summary>
    public class DisplayContentEventHandler
    {
        #region Fields

        private readonly TddAppComController controller;

        private readonly TaskCompletionSource<bool> tcs;        

        /// <summary>
        /// Gets the push message.
        /// </summary>
        /// <value>The push message.</value>
        public string PushMessage { get; private set; }

        /// <summary>
        /// Gets the node path.
        /// </summary>
        /// <value>The node path.</value>
        public string NodePath { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; private set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayContentEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public DisplayContentEventHandler(TddAppComController controller)
        {
            this.controller = controller;
            this.tcs = new TaskCompletionSource<bool>();
            this.PushMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayContentEventHandler"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="nodePath">The node path.</param>
        /// <param name="value">The value.</param>
        public DisplayContentEventHandler(TddAppComController controller, string nodePath, string value)
        {
            this.controller = controller;
            this.tcs = new TaskCompletionSource<bool>();
            this.PushMessage = string.Empty;
            this.NodePath = nodePath;
            this.Value = value;
        }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Waits async for new display content event.
    /// </summary>
    /// <param name="timeout">The timeout in milliseconds.</param>
    /// <returns>Task&lt;System.String&gt;.</returns>
    public async Task<bool> WaitForNewDisplayContent(int timeout)
        {
            bool result = false;
            this.PushMessage = string.Empty;
            this.CreateEventHandlerForNewPushMessage();

            // wait for task somewhere else
            if (await Task.WhenAny(this.tcs.Task, Task.Delay(timeout)) == this.tcs.Task)
            {
                // task completed within timeout
                result = true;
            }
            else
            {
                // timeout logic
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No update of display content recognized.");                
            }

            return result;

            // wait for task somewhere else
            //await this.tcs.Task;
            //return this.PushMessage;
        }

        /// <summary>
        /// Verifies an display content update has occurred.
        /// </summary>
        /// <returns><c>true</c> if update occurred, <c>false</c> otherwise.</returns>
        public virtual bool Verify()
        {
            return true;
        }

        /// <summary>
        /// Removes the HTML tags from push message.
        /// </summary>
        /// <returns>System.String.</returns>
        public string RemoveHtmlTagsFromString()
        {
            string result;
            string html = this.PushMessage;
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regx = new Regex("<body>(?<theBody>.*)</body>", options);
            Match match = regx.Match(this.PushMessage);

            result = match.Success ? match.Groups["theBody"].Value : html;

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the event handler for new push message.
        /// </summary>
        void CreateEventHandlerForNewPushMessage()
        {
            if (this.controller == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No connection to remote host .");
            }
            else
            {
                this.controller.pushMessageServer.NewPushMessage += new EventHandler<NewHttpPushMessageEventArgs>(this.NewPushMessageReceived);
            }
        }

        /// <summary>
        /// News push message received event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NewHttpPushMessageEventArgs"/> instance containing the event data.</param>
        void NewPushMessageReceived(object sender, NewHttpPushMessageEventArgs e)
        {
            this.PushMessage = e.Message;

            // complete task in event
            this.tcs.TrySetResult(this.Verify());           
        }

        #endregion
    }
}