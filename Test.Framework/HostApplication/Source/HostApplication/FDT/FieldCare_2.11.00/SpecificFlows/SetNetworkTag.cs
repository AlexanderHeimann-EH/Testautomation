// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetNetworkTag.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SetNetworkTag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.SpecificFlows
{
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class SetNetworkTag.
    /// </summary>
    public class SetNetworkTag : ISetNetworkTag
    {
        #region Public Methods and Operators

        /// <summary>
        /// Sets the network tag. This works only after a scan.
        /// </summary>
        /// <param name="networkTag">
        /// The network tag.
        /// </param>
        /// <returns>
        /// True if tag has been set, false otherwise.
        /// </returns>
        public bool Run(string networkTag)
        {
            bool result = true;
            Element element = (new NetworkViewElements()).Area;
            if (networkTag == string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Network tag must not be an empty string.");
            }
            else if (element != null)
            {
                Mouse.Click(element);
                Keyboard.Press(Keys.Down);
                Keyboard.Press(Keys.F2);
                Keyboard.Press(networkTag);
                Keyboard.Press(Keys.Enter);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting network tag to: '" + networkTag + "'.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to set network tag");
                result = false;
            }

            return result;
        }

        #endregion
    }
}