//------------------------------------------------------------------------------
// <copyright file="ChangeDTMAddressMainViewElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the elements of the change DTM address module
    /// </summary>
    public class ChangeDTMAddressMainViewElements
    {
        #region members

        /// <summary>
        /// Repository and mdiClient
        /// </summary>
        private readonly ChangeDTMAddressMainViewRepository repository;

        /// <summary>
        ///  Path of the MDI client
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDTMAddressMainViewElements"/> class. 
        /// </summary>
        public ChangeDTMAddressMainViewElements()
        {
            this.repository = ChangeDTMAddressMainViewRepository.Instance;
            this.mdiClientPath =
                HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution.GetDtmContainerPath
                                     .GetMDIClientPath();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the refresh button
        /// </summary>
        public Element RefreshButton
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.RefreshInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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
        /// Gets the change button
        /// </summary>
        public Element ChangeButton
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.ChangeInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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
        /// Gets the device address combo box
        /// </summary>
        public Element ChangeDeviceAddressComboBox
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.ChangeDeviceAddressComboBoxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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
        /// Gets combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                try
                {
                    List list = this.repository.comboBoxList;
                    if (list != null && list.Items.Count > 0)
                    {
                        return list.Items;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Creates a list of all devices shown in the change DTM address module
        /// </summary>
        /// <returns>
        /// List containing tree items representing the devices
        /// </returns>
        public IList<TreeItem> DeviceList()
        {
            RepoItemInfo treeItemInfo = this.repository.treeItemDeviceListInfo;
            string path = this.mdiClientPath + "/" + treeItemInfo.AbsolutePath;
            IList<TreeItem> list = Host.Local.Find<TreeItem>(path);
            if (list == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "The device list treeItem elements are null. Check the Ranorex Path in the repository");
                return null;
            }

            return list;
        }

        #endregion
    }
}
