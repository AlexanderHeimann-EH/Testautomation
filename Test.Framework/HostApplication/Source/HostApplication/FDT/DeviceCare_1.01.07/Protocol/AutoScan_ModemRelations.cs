// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="AutoScan_ModemRelations.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of AutoScan_ModemRelations.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.09.2015
 * Time: 13:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Protocol
{
    using Ranorex;

    /// <summary>
    /// Description of AutoScan_ModemRelations.
    /// </summary>
    public class AutoScan_ModemRelations
    {
        /// <summary>
        /// The get communication driver name.
        /// </summary>
        /// <param name="modemName">
        /// The modem name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetCommDriverName(string modemName)
        {
            return _GetCommDriver(modemName);
        }

        /// <summary>
        /// The _ get communicaiton driver.
        /// </summary>
        /// <param name="_modemName">
        /// The _modem name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string _GetCommDriver(string _modemName)
        {
            if (_modemName.Contains(HART.commHardwareFXA195))
            {
                return HART.commDriver;
            }
            else if (_modemName.Contains(HART.commHardwareMactek))
            {
                return HART.commDriver;
            }
            else if (_modemName.Contains(HART.commHardwareVector))
            {
                return HART.commDriver;
            }
            else if (_modemName.Contains(CDIFXA291.communicationHardwareName291))
            {
                return CDIFXA291.commDriverName;
            }
            else if (_modemName.Contains(CDIUSB.protocolName))
            {
                return CDIUSB.commDriverName;
            }
            else if (_modemName.Contains(PCP.communicationHardwareName10))
            {
                return PCP.commDriverName;
            }

            Report.Failure("The modem is not recognized as a supported communication unit for automatic scanning.");
            return null;
        }
    }
}
