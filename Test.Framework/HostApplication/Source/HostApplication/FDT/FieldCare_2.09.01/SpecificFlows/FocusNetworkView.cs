//------------------------------------------------------------------------------
// <copyright file="FocusNetworkView.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.09.2011
 * Time: 09:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.SpecificFlows
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Description of FocusNetwork.
    /// </summary>
    public class FocusNetworkView : MarshalByRefObject, IFocusNetworkView
    {
        /// <summary>
        ///     Flow: Focus Network View
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            Element element = (new NetworkViewElements()).Area;
            if (element != null)
            {
                element.Focus();
                for (int counter = 0; counter < 4; counter++)
                {
                    Keyboard.Press(Keys.PageUp);
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[Network View] is in focus.");
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not focus [Network View]");
            return false;
        }
    }
}