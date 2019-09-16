// -----------------------------------------------------------------------
// <copyright file="Configure.cs" company="Endress+Hauser Process Solutions AG">
// Endress+Hauser
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Flows;
    using EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides methods for configuring the NXA820 CommDTM
    /// </summary>
    public class Configure : IConfigure
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="ip">
        /// The IP.
        /// </param>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="tankId">
        /// The tank id.
        /// </param>
        /// <param name="startAddress">
        /// The start address.
        /// </param>
        /// <param name="endAddress">
        /// The end address.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(
            string ip,
            string port,
            string password,
            string tankId,
            string startAddress,
            string endAddress,
            string timeout)
        {
            string[] parameter = { ip, port, password, tankId, startAddress, endAddress, timeout };
            Element[] elements =
                {
                    new ConfigurationMainViewElements().Nxa820IpAddress,
                    new ConfigurationMainViewElements().Nxa820Port,
                    new ConfigurationMainViewElements().Password,
                    new ConfigurationMainViewElements().TankIdentification,
                    new ConfigurationMainViewElements().StartScanAddress,
                    new ConfigurationMainViewElements().EndScanAddress,
                    new ConfigurationMainViewElements().CommunicationTimeout
                };
            bool result = true;
            int counter = 0;

            // Set every parameter, skip if empty
            foreach (var param in parameter)
            {
                if (param != string.Empty)
                {
                    result &=
                        CommunicationLoader.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Execution
                                           .SetParameter.SetParameterValue(elements[counter], param);
                }

                counter++;
            }

            // Apply changes 
            if (CommunicationLoader.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Execution.Apply.Run()
                == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Applying changes failed, are all paramter correct?");
                result = false;
            }

            return result;
        }
    }
}
