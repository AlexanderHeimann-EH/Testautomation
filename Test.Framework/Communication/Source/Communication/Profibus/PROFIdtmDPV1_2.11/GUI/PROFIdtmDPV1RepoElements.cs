// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PROFIdtmDPV1RepoElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides access to the GUI elements of the repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the GUI elements of the repository 
    /// </summary>
    public class ProfIdtmDpv1RepoElements
    {
        #region Members

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly PROFIdtmDPV1Repo profibusRepository;

        /// <summary>
        /// Holds the path to the communicationDtmContainerPath
        /// </summary>
        private readonly string communicationDtmContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of <see cref="PROFIdtmDPV1Repo"/> class
        /// and gets the commDTMContainerPath
        /// </summary>
        public ProfIdtmDpv1RepoElements()
        {
            this.profibusRepository = PROFIdtmDPV1Repo.Instance;

            this.communicationDtmContainerPath = CommonHostApplicationLayerLoader.CommonFlows.GetCommDtmContainerPath.Run();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the 'ButtonOk' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonOk
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.ButtonOKInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'ButtonCancel' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonCancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.CancelInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'ButtonApply' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonApply
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.ApplyInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'ButtonDefaults' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonDefaults
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.DefaultsInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets an Ilist of all items in a combo box
        /// </summary>
        /// <returns>
        ///     <br>Ilist: if the list can be created</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public IList<ListItem> ComboBoxList
        {
            get
            {
                try
                {
                    List list = this.profibusRepository.ComboboxList.Self;
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
        ///     Gets the 'BoardNameComboBox' object
        /// </summary>
        /// <returns>
        ///     <br>Combo box: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox BoardNameComboBox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.profibusRepository.BoardNameComboboxInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out combobox);
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
        ///     Gets the 'BoardNameComboboxButtonOpen' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button BoardNameComboboxButtonOpen
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.BoardNameComboboxButtonOpenInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'BaudRateComboBox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox BaudRateComboBox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.profibusRepository.BaudRateComboboxInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out combobox);
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
        ///     Gets the 'BaudRateComboBoxButtonOpen' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button BaudRateComboBoxButtonOpen
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.BaudRateComboboxButtonOpenInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'StartAddress' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text StartAddress
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.profibusRepository.StartAddressInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'EndAddress' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text EndAddress
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.profibusRepository.EndAddressInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'HighestStationAddress' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text HighestStationAddress
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.profibusRepository.HighestStationAddressInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'StationAddress' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text StationAddress
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.profibusRepository.StationAddressInfo;
                    Host.Local.TryFindSingle(this.communicationDtmContainerPath + "/" + elementInfo.AbsolutePath, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the 'DialogButtonOk' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonOk
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.DialogBox.ButtonOKInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'DialogButtonClose' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonClose
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.profibusRepository.DialogBox.ButtonCloseInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out button);
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
        ///     Gets the 'DialogMessage' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text DialogMessage
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.profibusRepository.DialogBox.DialogMessageInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out text);
                    return text;
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
