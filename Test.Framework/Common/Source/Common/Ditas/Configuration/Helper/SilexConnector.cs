// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SilexConnector.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 04/03/2015
 * Time: 10:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.Helper
{
    using System.Diagnostics;
    using System.IO;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment;

    /// <summary>
    /// Description of SilexConnector.
    /// </summary>
    public class SilexConnector
    {
        /// <summary>
        /// The ip.
        /// </summary>
        private static string ip = string.Empty;

        /// <summary>
        /// Initializes static members of the <see cref="SilexConnector"/> class.
        /// </summary>
        static SilexConnector()
        {                        
            ip = TestRunFacade.GetModemIPAddress();
        }

        /// <summary>
        /// The action.
        /// </summary>
        public enum Action
        {
            /// <summary>
            /// The connect.
            /// </summary>
            Connect,

            /// <summary>
            /// The disconnect.
            /// </summary>
            Disconnect
        };

        /// <summary>
        /// The perform on device.
        /// </summary>
        /// <param name="deviceName">
        /// The device name.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool PerformOnDevice(string deviceName, Action action)
        {
            bool success = false;
            
            string fullDeviceName = GetFullDeviceName(deviceName);
            
            if (fullDeviceName != string.Empty)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.FileName = "cmd.exe";
                    
                if (action == Action.Connect)
                {                
                    startInfo.Arguments = @"/C pushd " + Directory.GetCurrentDirectory() + " && dscon /C /I" + ip + " /P" + fullDeviceName;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;
                    
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    
                    process.WaitForExit();
                    process.Close();
                    
                    if (output.Contains("Connection succeeded"))
                    {
                        success = true;    
                    }
                }
                else if (action == Action.Disconnect)
                {                
                    startInfo.Arguments = @"/C pushd "  + Directory.GetCurrentDirectory() + " && dscon /D /I" + ip + " /P" + fullDeviceName;        
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;
                    
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    
                    process.WaitForExit();
                    process.Close();
                    
                    if (output.Contains("Disconnection succeeded."))
                    {
                        success = true;    
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// The get full device name.
        /// </summary>
        /// <param name="deviceName">
        /// The device name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetFullDeviceName(string deviceName)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C pushd " + Directory.GetCurrentDirectory() + " && dscon /L /I" + ip;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;

            process.Start();
            string output;
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                if (output.ToLower().Contains(deviceName))
                {
                    int start = output.IndexOf("[", System.StringComparison.Ordinal) + 1;
                    int end = output.IndexOf("]", start, System.StringComparison.Ordinal);

                    deviceName = output.Substring(start, end - start);
                    break;
                }
            }

            process.WaitForExit();
            process.Close();
            return deviceName;
        }
    }
}
