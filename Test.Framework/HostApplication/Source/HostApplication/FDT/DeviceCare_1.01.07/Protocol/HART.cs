/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 10:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Protocol
{
	/// <summary>
	/// Description of HART.
	/// </summary>
	public class HART
	{
        /// <summary>
        /// 
        /// </summary>
		public const string commDriver = "HART Communication";

        /// <summary>
        /// 
        /// </summary>
        public const string protocolName = "HART";

        /// <summary>
        /// 
        /// </summary>
        public const string commHardwareMactek = "VIATOR";

        /// <summary>
        /// 
        /// </summary>
        public const string commHardwareFXA195 = "FXA195";

        /// <summary>
        /// 
        /// </summary>
        public const string commHardwareVector = "Vector InfoTech HART";

        /// <summary>
        /// 
        /// </summary>
        public const string versionInfo = "V1.0.42";

        /// <summary>
        /// 
        /// </summary>
        public const bool isServiceInterface = false;
        
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
        public string CommunicationHardwareMactek
		{
			get { return commHardwareMactek; }
		}

        /// <summary>
        /// 
        /// </summary>
        public string CommunicationHardwareFXA195
		{
			get { return commHardwareFXA195; }
		}

        /// <summary>
        /// 
        /// </summary>
        public string CommunicationHardwareVector
		{
			get { return commHardwareVector; }
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
