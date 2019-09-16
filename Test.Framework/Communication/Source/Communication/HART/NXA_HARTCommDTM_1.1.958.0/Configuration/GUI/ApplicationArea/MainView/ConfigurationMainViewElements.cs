// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationMainViewElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the elements of the NXA 820 configuration
    /// </summary>
    public class ConfigurationMainViewElements
    {
        #region Fields

        /// <summary>
        /// MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// Repository and mdi client
        /// </summary>
        private readonly ConfigurationMainViewRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationMainViewElements"/> class. 
        /// </summary>
        public ConfigurationMainViewElements()
        {
            this.repository = ConfigurationMainViewRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets button apply
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element ApplyButton
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.buttonApplyInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets combo box "Communication timeout"
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element CommunicationTimeout
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.comboBoxCommunicationTimeoutInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets combo box "EndScanAddress"
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element EndScanAddress
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.comboBoxEndScanAddressInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets the listItems of the combo boxes
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets EditControl "NXA 820 IP address" 
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element Nxa820IpAddress
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.editControlNXA820IPAdressInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets EditControl "NXA 820 port" 
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element Nxa820Port
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.editControlNXA820PortInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets EditControl "Password"
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element Password
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.editControlPasswordInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets combo box "start scan address"
        /// </summary>
        /// <returns>
        /// Button: if the element is found
        /// Null: if the element is not found or an other error occurred
        /// </returns>
        public Element StartScanAddress
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.comboBoxStartScanAddressInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets EditControl "tank identification" 
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element is not found or an other error occurred</br>
        /// </returns>
        public Element TankIdentification
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.editControlTankIdentificationInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}