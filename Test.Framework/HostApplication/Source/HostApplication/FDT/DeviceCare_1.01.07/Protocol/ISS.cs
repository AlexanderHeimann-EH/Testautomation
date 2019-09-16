/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 12:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Protocol
{
    /// <summary>
    /// Description of ISS.
    /// </summary>
    public class ISS
	{
        /// <summary>
        /// 
        /// </summary>
        public const string commDriverName = "Flow Communication FXA193/291";

        /// <summary>
        /// 
        /// </summary>
        public const string protocolName = "ISS";

        /// <summary>
        /// 
        /// </summary>
        public const string communicationHardwareName193 = "FXA193";

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
        public string CommunicationHardwareNameFXA193
		{
			get { return communicationHardwareName193; }
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
