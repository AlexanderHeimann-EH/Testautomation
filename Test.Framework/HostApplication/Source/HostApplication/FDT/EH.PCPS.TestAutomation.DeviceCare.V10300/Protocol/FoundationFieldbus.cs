/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Protocol
{
	/// <summary>
	/// Description of FoundationFieldbus.
	/// </summary>
	public class FoundationFieldbus
    {
        /// <summary>
        /// 
        /// </summary>
		public const string commDriver = "FF H1 CommDTM";
        
        /// <summary>
        /// 
        /// </summary>
        public const string protocolName = "FDT FIELDBUS FF H1";
        
        /// <summary>
        /// 
        /// </summary>
        public const string communicationHardwareName = "NI USB";

        /// <summary>
        /// 
        /// </summary>
        public const string versionInfo = "V1.0.42";

        /// <summary>
        /// 
        /// </summary>
        public string CommunicationDriverName
		{
			get { return commDriver; }
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
        public string CommunicationHardwareName
		{
			get { return communicationHardwareName; }
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
