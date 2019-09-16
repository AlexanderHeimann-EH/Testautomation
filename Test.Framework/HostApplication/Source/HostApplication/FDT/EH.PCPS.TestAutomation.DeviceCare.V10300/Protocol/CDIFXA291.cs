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
    /// Description of CDIFXA291.
    /// </summary>
    public class CDIFXA291
	{
        /// <summary>
        /// The comm driver name
        /// </summary>
        public const string commDriverName = "CDI Communication FXA291";

        /// <summary>
        /// The protocol name
        /// </summary>
		public const string protocolName = "CDI";

        /// <summary>
        /// The communication Hardware name 10
        /// </summary>
		public const string communicationHardwareName10 = "TXU10";

        /// <summary>
        /// The communication Hardware name 291
        /// </summary>
		public const string communicationHardwareName291 = "FXA291";

        /// <summary>
        /// The version info
        /// </summary>
		public const string versionInfo = "V1.0.42";

        /// <summary>
        /// The Comm Driver Name Property
        /// </summary>
		public string CommDriverName
        {
            get { return commDriverName; }
        }

        /// <summary>
        /// The Protocol Name Property
        /// </summary>
		public string ProtocolName
        {
            get { return protocolName; }
        }

        /// <summary>
        /// The Communication Hardware Name TXU10 Property
        /// </summary>
		public string CommunicationHardwareNameTXU10
        {
            get { return communicationHardwareName10; }
        }

        /// <summary>
        /// The Communication Hardware Name FXA291 Property
        /// </summary>
		public string CommunicationHardwareNameFXA291
        {
            get { return communicationHardwareName291; }
        }

        /// <summary>
        /// The Version Info Property
        /// </summary>
		public string VersionInfo
        {
            get { return versionInfo; }
        }
    }
}
