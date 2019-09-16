//------------------------------------------------------------------------------
// <copyright file="AddDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.11.2010
 * Time: 6:27 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.AddDevice.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.AddDevice.Execution;

    using Ranorex;

    /// <summary>
    ///     This class describes dialog [Add Device] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class AddDevice : MarshalByRefObject, IAddDevice
    {
        /// <summary>
        ///     Click [Add Device]-Dialog.Device
        /// </summary>
        /// <param name="strDeviceName">Device name to select</param>
        /// <returns>
        ///     <br>Cell: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool SelectDevice(string strDeviceName)
        {
            try
            {
                (new AddDeviceElements()).Device(strDeviceName).Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Click [Add Device]-Dialog.Button.Ok
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            try
            {
                (new AddDeviceElements()).Ok.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        ///     Click [Add Device]-Dialog.Button.Cancel
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                (new AddDeviceElements()).Cancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Click [Add Device]-Dialog.Button.Help
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool OpenHelp()
        {
            try
            {
                (new AddDeviceElements()).Help.Click(DefaultValues.locDefaultLocation);
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