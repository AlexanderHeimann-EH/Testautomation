// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppComController.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of AppComController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Class AppComController.
    /// </summary>
    public static class AppComController
    {
        #region Static Fields

        /// <summary>
        /// The controller
        /// </summary>
        private static TddAppComController controller;        

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>The controller.</value>
        public static TddAppComController Controller
        {
            get
            {
                return controller;
            }

            private set
            {
                controller = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Connects the specified remote host.
        /// </summary>
        /// <param name="remoteHost">The remote host.</param>
        /// <param name="remotePort">The remote port.</param>
        /// <param name="pushMessageServerHost">The push message server host.</param>
        /// <param name="pushMessageServerPort">The push message server port.</param>
        /// <returns><c>true</c> if connected, <c>false</c> otherwise.</returns>
        public static bool Connect(string remoteHost, ushort remotePort, string pushMessageServerHost, ushort pushMessageServerPort)
        {
            try
            {
                bool result = false;

                if (Controller != null)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host is already connected.");
                }
                else
                {
                    Controller = new TddAppComController(remoteHost, remotePort, pushMessageServerHost, pushMessageServerPort);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Establishing connection to remote host.");
                    if (Controller == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Establishing connection to remote host failed!!!");
                    }
                    else
                    {
                        result = true;
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection to remote host established.");
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Establishing connection failed. " + e);
                return false;
            }               
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <returns><c>true</c> if disconnected, <c>false</c> otherwise.</returns>
        public static bool Disconnect()
        {
            try
            {                                
                if (Controller != null)
                {
                    Controller.UnregisterPushMessageServer();
                    Controller.Dispose();
                    Controller = null;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Disconnecting from remote host.");
                return true;
            }
            catch (Exception e)
            {

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Disconnecting failed. " + e);
                return false;
            }
            
        }

        /// <summary>
        /// Gets the display content.
        /// </summary>
        /// <returns>The display content xml.</returns>
        public static string GetDisplayContent()
        {
            try
            {
                string result = string.Empty;

                if (Controller != null)
                {                    
                    //string html = Controller.GetDisplayContent();                                    
                    //RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
                    //Regex regx = new Regex("<body>(?<theBody>.*)</body>", options);
                    //Match match = regx.Match(html);

                    //if (match.Success)
                    //{
                    //    result = match.Groups["theBody"].Value;
                    //}
                    //else
                    //{
                    //    result = html;
                    //}

                    result = Controller.GetDisplayContent();
                }
                else
                {                    
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host not available. Please connect first.");                    
                }

                return result;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Getting display content failed. " + e);
                return string.Empty;
            }
        }


        #endregion
    }
}