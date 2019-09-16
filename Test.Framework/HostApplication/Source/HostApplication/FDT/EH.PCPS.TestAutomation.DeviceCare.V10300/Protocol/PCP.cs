/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 12:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Protocol
{
	/// <summary>
	/// Description of PCP.
	/// </summary>
	public class PCP
	{
        /// <summary>
        /// 
        /// </summary>
		public const string commDriverName = "PCP (Readwin) TXU10/FXA291";

        /// <summary>
        /// 
        /// </summary>
        public const string protocolName = "PCP";

        /// <summary>
        /// 
        /// </summary>
        public const string communicationHardwareName10 = "TXU10";

        /// <summary>
        /// 
        /// </summary>
        public const string communicationHardwareName291 = "FXA291";

        /// <summary>
        /// 
        /// </summary>
        public const string versionInfo = "V1.0.42";
		
        /// <summary>
        /// 
        /// </summary>
		public string CommDriverName
		{
			get { return commDriverName; }
		}

        /// <summary>
        /// 
        /// </summary>
        public string ProtocolName
		{
			get { return protocolName; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string CommunicationHardwareNameTXU10
		{
			get { return communicationHardwareName10; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string CommunicationHardwareNameFXA291
		{
			get { return communicationHardwareName291; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string VersionInfo
		{
			get { return versionInfo; }
		}
	}
}
