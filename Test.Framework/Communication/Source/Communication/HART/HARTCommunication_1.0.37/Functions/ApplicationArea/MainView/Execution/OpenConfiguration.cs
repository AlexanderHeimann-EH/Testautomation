//------------------------------------------------------------------------------
// <copyright file="Openconfiguration.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 25.11.2010
 * Time: 10:26 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HARTCommunication.V1037.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.HartComm.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Start [DTM Configuration]-functionality
    /// </summary>
    public class OpenConfiguration : MarshalByRefObject, IOpenConfiguration
    {
        //		/// <summary>
        //		/// Static Constructor provide FieldCare-Interfaces
        //		/// </summary>
        //		static OpenConfiguration()
        //		{
        //			Loader.Frame.LoadImplementation();
        //		}

        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool ViaMenu()
        {
            try
            {
                if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenConfiguration.ViaMenu())
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }


        /// <summary>
        ///     Start via related context-menu
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaContext()
        {
            try
            {
                // TODO: Context-Menu-Aufruf implementieren
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}