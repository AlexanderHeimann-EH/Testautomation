//------------------------------------------------------------------------------
// <copyright file="IsFrameAvailable.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 16:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.ApplicationArea.MainView.Validation
{
    using System;

    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Class IsFrameAvailable.
    /// </summary>
    public class IsFrameAvailable : MarshalByRefObject, IIsFrameAvailable
    {
        /// <summary>
        ///     Check if Frame Application Main Form is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        public bool Run()
        {
            if ((new ApplicationAreaElements()).FrameMainWindow != null)
            {
                return true;
            }

            return false;
        }
    }
}