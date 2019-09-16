/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 21.08.2015
 * Time: 12:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Protocol
{
    /// <summary>
    /// Description of CDIUSB.
    /// </summary>
    public class CDIUSB
	{
        /// <summary>
        /// The Comm Driver Name
        /// </summary>
		public const string commDriverName = "CDI Communication USB";

        /// <summary>
        /// The Protocol Name
        /// </summary>
		public const string protocolName = "CDI USB";

        /// <summary>
        /// The Version Info
        /// </summary>
		public const string versionInfo = "V1.0.42";

        /// <summary>
        /// The CommDriver Name property
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
