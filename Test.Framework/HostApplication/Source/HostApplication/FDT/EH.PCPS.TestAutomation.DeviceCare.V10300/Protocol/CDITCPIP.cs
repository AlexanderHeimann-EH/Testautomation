/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 12:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Protocol
{
    /// <summary>
    /// Description of CDITCPIP.
    /// </summary>
    public class CDITCPIP
	{
        /// <summary>
        /// The comm Driver Name
        /// </summary>
		public const string commDriverName = "CDI Communication TCP/IP";

        /// <summary>
        /// The Protocol Name
        /// </summary>
		public const string protocolName = "CDI TCP/IP";

        /// <summary>
        /// Comm Driver Name
        /// </summary>
		public const string versionInfo = "V1.0.42";
		
        /// <summary>
        /// The Comm Driver Name property
        /// </summary>
		public string CommDriverName
		{
			get { return commDriverName; }
		}

        /// <summary>
        /// The Protocol Name property
        /// </summary>
		public string ProtocolName
		{
			get { return protocolName; }
		}

        /// <summary>
        /// The Version Info property
        /// </summary>
		public string VersionInfo
		{
			get { return versionInfo; }
		}
	}
}
