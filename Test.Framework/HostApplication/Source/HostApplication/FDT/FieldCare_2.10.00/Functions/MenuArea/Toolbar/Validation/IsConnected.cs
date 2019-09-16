// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 17:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.Functions.MenuArea.Toolbar.Validation
{
    using System;

    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation;

    using Ranorex;

    /// <summary>
    /// Class IsConnected.
    /// </summary>
    public class IsConnected : MarshalByRefObject, IIsConnected
    {
        /// <summary>
        ///     Check if frame-device-connection is active
        /// </summary>
        /// <returns>True if connection is established, False if not</returns>
        public bool Run()
        {
            Button icon = (new IconElements()).ConnectedColored;
            if (icon != null && icon.Enabled)
            {
                return true;
            }

            return false;
        }
    }
}