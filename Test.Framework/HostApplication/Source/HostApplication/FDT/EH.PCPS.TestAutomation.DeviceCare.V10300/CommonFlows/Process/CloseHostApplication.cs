// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseHostApplication.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of CloseHostApplication.
    /// </summary>
    public class CloseHostApplication : CommonHostApplicationLayerInterfaces.CommonFlows.ICloseHostApplication
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            // instanciate module
            var function = new Functions.ApplicationArea.Page_Home.Page_Home_Functions();
            var processFunctions = new Functions.Helpers.DeviceCareProcessFunctions();
            
            // close frame
            function.CloseFrame();

            // check if frame is closed
            // NOTE: IsFrameClosed(int timeOutInMilliseconds) always needs a timeout parameter. If user timeout shall be omitted, set timeout to 0 or -1 (default 30s is used then)
            if (function.IsFrameClosed(-1))
            {
                // check if process is terminated
                if (function.IsDCProcessTerminated())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing Host Application was successful");
                    return true;
                }
                
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The DeviceCare process is still running");
                CommonInternal.ProcessInformation.PublishProcessSummary(processFunctions.GetDcProcess());
                return false;
            }
            
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame was not successfully closed");
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            // instanciate module
            var function = new Functions.ApplicationArea.Page_Home.Page_Home_Functions();
            var processFunctions = new Functions.Helpers.DeviceCareProcessFunctions();
            
            // close frame
            function.CloseFrame();
            
            // check if frame is closed
            // NOTE: IsFrameClosed(int timeOutInMilliseconds) always needs a timeout parameter. If user timeout shall be omitted, set timeout to 0 or -1 (default 30s is used then)
            if (function.IsFrameClosed(timeoutInMilliseconds))
            {
                // for debugging:
                // simulates that the process is still running in background
                // user has to open devicecare again in that time window
                // Delay.Milliseconds(10000);
                // check if process is terminated
                if (function.IsDCProcessTerminated())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing Host Application was successful");
                    return true;
                }
                
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The DeviceCare process is still running");
                CommonInternal.ProcessInformation.PublishProcessSummary(processFunctions.GetDcProcess());
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame was not successfully closed");
            return false;
        }
    }
}
