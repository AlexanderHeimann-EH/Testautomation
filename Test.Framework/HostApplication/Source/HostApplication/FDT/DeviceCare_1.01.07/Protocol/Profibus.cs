/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 12:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Protocol
{
	/// <summary>
	/// Description of Profibus.
	/// </summary>
	public class Profibus
	{
		/// <summary>
		/// 
		/// </summary>
		public const string commDriver = "PROFIdtm DPV1";
		
        /// <summary>
		/// 
		/// </summary>
		public const string protocolName = "Profibus DP/V1";
		
        /// <summary>
		/// 
		/// </summary>
		public const string communicationHardwareNamePcmcia = "Softing PCMCIA";
		
        /// <summary>
		/// 
		/// </summary>
		public const string communicationHardwareNameUsb = "Softing USB";
		
        /// <summary>
		/// 
		/// </summary>
		public const string versionInfo = "V1.0.42";
		
        /// <summary>
        /// 
        /// </summary>
		public string CommDriver {
			get { return commDriver; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string ProtocolName {
			get { return protocolName; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string CommunicationHardwareNamePcmcia {
			get { return communicationHardwareNamePcmcia; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string CommunicationHardwareNameUsb {
			get { return communicationHardwareNameUsb; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string VersionInfo {
			get { return versionInfo; }
		}
	}
}
