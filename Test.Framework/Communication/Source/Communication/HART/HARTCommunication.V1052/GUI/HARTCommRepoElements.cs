using System;
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.GUI
{

    /// <summary>
    /// Provides access to the GUI elements of the repository 
    /// </summary>
    public class HARTCommRepoElements
    {

        #region Members

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly HARTCommunicationRepository hartRepository;

        /// <summary>
        /// Holds the path to the commDTMContainer
        /// </summary>
        private readonly string commDTMContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of <see cref="HARTCommunicationRepository"/> class
        /// and gets the commDTMContainerPath
        /// </summary>
        public HARTCommRepoElements()
        {
            this.hartRepository = HARTCommunicationRepository.Instance;

            this.commDTMContainerPath = EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.GetCommDtmContainerPath.Run();
        }

        #endregion

        #region Properties

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
                    RepoItemInfo elementInfo = this.hartRepository.HART_MenuArea.ButtonApplyInfo;
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
                    RepoItemInfo elementInfo = this.hartRepository.HART_MenuArea.ButtonCancelInfo;
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
        ///     Gets the 'ButtonOK' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button ButtonOK
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.hartRepository.HART_MenuArea.ButtonOKInfo;
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
        ///     Gets the 'StartAddressCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox StartAddressCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.hartRepository.HART_ApplicationArea.DTMFramebox.AddressContainer.StartAddressInfo;
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
        ///     Gets the 'EndAddressCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox EndAddressCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.hartRepository.HART_ApplicationArea.DTMFramebox.AddressContainer.EndAddressInfo;
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
        ///     Gets the 'CommunicationInterfaceCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox CommunicationInterfaceCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.hartRepository.HART_ApplicationArea.DTMFramebox.InterfaceContainer.CommunicationInterfaceInfo;
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
        ///     Gets the 'SerialInterfaceCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Combobox: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public ComboBox SerialInterfaceCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.hartRepository.HART_ApplicationArea.DTMFramebox.InterfaceContainer.SerialInterfaceInfo;
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
        ///     Gets an Ilist of all items in a combobox
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
                    List list = this.hartRepository.Listitems.Self;
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
        ///     Gets the 'DialogButtonSave' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonSave
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.hartRepository.DialogBox.ButtonYesInfo;
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
        ///     Gets the 'DialogButtonDiscard' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonDiscard
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.hartRepository.DialogBox.ButtonNoInfo;
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
                    RepoItemInfo elementInfo = this.hartRepository.DialogBox.ButtonCloseInfo;
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
        ///     Gets the 'DialogButtonCancel' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonCancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.hartRepository.DialogBox.ButtonCancelInfo;
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
        #endregion
    }
}
