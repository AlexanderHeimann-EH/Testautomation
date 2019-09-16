//------------------------------------------------------------------------------
// <copyright file="FindDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 6:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.FindDevice.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.FindDevice.Execution;

    using Ranorex;

    /// <summary>
    ///     This class describes dialog [Find] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class FindDevice : MarshalByRefObject, IFindDevice
    {
        /// <summary>
        ///     Search for specified device
        /// </summary>
        /// <param name="deviceName">FDT device type name of device to search for</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool EnterDevice(string deviceName)
        {
            try
            {
                Text searchField = (new FindDeviceElements()).SearchText;
                if (searchField != null && searchField.Enabled)
                {
                    searchField.Click(DefaultValues.locDefaultLocation);
                    searchField.TextValue = deviceName;
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Field to enter device name is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Find next specified device
        /// </summary>
        /// <param name="deviceName">FDT device type name of device to search for</param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool FindNext(string deviceName)
        {
            try
            {
                Button find = (new FindDeviceElements()).Find;
                if (find != null && find.Enabled)
                {
                    find.Click(DefaultValues.locDefaultLocation);
                    Button confirmError = (new OpenUnavailableProjectMessageElements()).Ok;
                    if (confirmError == null)
                    {
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device [" + deviceName + "]" + " does not exist.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button find is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Open help
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool OpenHelp()
        {
            try
            {
                Button help = (new FindDeviceElements()).Help;
                if (help != null && help.Enabled)
                {
                    help.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button Help is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
       
        /// <summary>
        ///     Find specified device
        /// </summary>
        /// <param name="deviceName">Name of device to find</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Find(string deviceName)
        {
            try
            {
                if (this.EnterDevice(deviceName))
                {
                    if (this.FindNext(deviceName))
                    {
                        if (this.Cancel())
                        {
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[Find Device]-Dialog could not be closed");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "It is not possible to search for the specified device");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device name could not be entered");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        ///     Cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                Button button = (new FindDeviceElements()).Cancel;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button Cancel is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}