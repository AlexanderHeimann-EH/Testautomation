// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDICommDTMRepoElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20501.GUI
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
    /// Provides access to the GUI elements of the repository 
    /// </summary>
    public class CDICommDTMRepoElements
    {
        #region Members

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly CDICommDTMRepo cdiRepository;

        /// <summary>
        /// Holds the path to the commDTMContainer
        /// </summary>
        private readonly string commDTMContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="CDICommDTMRepoElements"/> class. 
        /// and gets the commDTMContainerPath
        /// </summary>
        public CDICommDTMRepoElements()
        {
            this.cdiRepository = CDICommDTMRepo.Instance;

            this.commDTMContainerPath = CommonFlows.GetCommDtmContainerPath.Run();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the 'CommDTMWindow' element itself
        /// </summary>
        /// /// <returns>
        ///     <br>Element: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Element DTMWindowSelf
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.SelfInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out element);
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
        ///     Gets the 'CommUnitCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox CommUnitCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.CommUnitComboboxInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out combobox);
                    return combobox;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
                
            }
        }

        /// <summary>
        ///     Gets an Ilist of all items in the <see cref="CommUnitCombobox"/>
        /// </summary>
        /// <returns>
        ///     <br>Ilist: if the list can be created</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public IList<ListItem> ComboboxList
        {
            get
            {
                try
                {
                    List list = this.cdiRepository.ComboboxList.Self;
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
        ///     Gets the 'CommUnitButtonOpen' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button CommUnitButtonOpen
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.CommUnitButtonOpenInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out button);
                    return button;
                }
                catch (Exception exception)
                {
                   Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                   return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'BaudRateCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox BaudRateCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.BaudRateComboboxInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out combobox);
                    return combobox;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }

            }
        }

        /// <summary>
        ///     Gets an Ilist of all items in the <see cref="BaudRateCombobox"/>
        /// </summary>
        /// <returns>
        ///     <br>Ilist: if the list can be created</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public IList<ListItem> BaudRateListItems
        {
            get
            {
                try
                {
                    this.cdiRepository.ApplicationArea.BaudRateCombobox.Click();
                    IList<ListItem> dummy = this.cdiRepository.ApplicationArea.BaudRateCombobox.Items;

                    if (dummy != null | dummy.Count > 0)
                    {
                        return dummy;
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
        ///     Gets the 'BaudRateButtonOpen' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button BaudRateButtonOpen
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.BaudRateButtonOpenInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'ButtonRefresh' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonRefresh
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.ButtonRefreshInfo;
                    string path = this.commDTMContainerPath + "/" + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(path, out button);
                    return button;
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
