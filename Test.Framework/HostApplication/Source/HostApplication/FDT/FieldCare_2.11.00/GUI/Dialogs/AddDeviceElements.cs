//------------------------------------------------------------------------------
// <copyright file="AddDeviceElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 1:39 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of class AddDeviceElements
    /// </summary>
    public class AddDeviceElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDeviceElements"/> class which will be used and determines the path of the mdi client
        /// </summary>
        public AddDeviceElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Add Device]-Dialog.Button.Ok-object
        ///     It is needed to confirm selection and close dialog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Ok
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.AddDevice.OkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Add Device]-Dialog.Button.Cancel-object
        ///     It is needed to avoid a selection and close dialog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Cancel
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.AddDevice.CancelInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        
        /// <summary>
        ///     Gets [Add Device]-Dialog.Button.Help-object
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Help
        {
            get
            {
                // ---------------------------------------------------------------------
                // EC 2016-09-30: Obsolete - Not supported by FieldCare 2.11.00 any more
                // ---------------------------------------------------------------------
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button [Help] is not supported by FieldCare 2.11.00 any more");
                return null;
            }
        }

        /// <summary>
        /// Gets [Add Device]-Dialog.Button.Filter-object
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Filter
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.AddDevice.FilterInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets [Add Device]-Dialog.Text.Manufacturer-object
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ManufacturerFilter
        {
            get
            {
                try
                {
                    Text element;
                    RepoItemInfo elementInfo = this.repository.AddDevice.ManufacturerInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets [Add Device]-Dialog.Text.Device-object
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text DeviceFilter
        {
            get
            {
                try
                {
                    Text element;
                    RepoItemInfo elementInfo = this.repository.AddDevice.DeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets [Add Device]-Dialog.Button.Close-object
        ///     It is needed to close dialog
        /// </summary>
        /// <param name="strDeviceName">
        /// The Device Name.
        /// </param>
        /// <returns>
        /// <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Cell Device(string strDeviceName)
        {
            try
            {
                RepoItemInfo elementInfo = this.repository.AddDevice.NameInfo;

                IList<Cell> cellDevices = Host.Local.Find<Cell>(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                if (cellDevices != null)
                {
                    if (cellDevices.Count > 0)
                    {
                        foreach (var cellDevice in cellDevices)
                        {
                            if (cellDevice.Text.Contains(strDeviceName))
                            {
                                return cellDevice;
                            }
                        }
                    }
                }
                
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device [" + strDeviceName + "] not found.");
                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}