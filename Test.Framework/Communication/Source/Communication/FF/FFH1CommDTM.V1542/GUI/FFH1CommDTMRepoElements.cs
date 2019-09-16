using System;
using System.Reflection;
using System.Collections.Generic;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.GUI
{
    /// <summary>
    /// Provides access to the GUI elements of the repository 
    /// </summary>
    public class FFH1CommDTMRepoElements
    {
        #region Members

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly FFH1CommDTMRepo ffRepository;

        /// <summary>
        /// Holds the path to the commDTMContainer
        /// </summary>
        private readonly string commDTMContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of <see cref="FFH1CommDTMRepo"/> class
        /// and gets the commDTMContainerPath
        /// </summary>
        public FFH1CommDTMRepoElements()
        {
            this.ffRepository = FFH1CommDTMRepo.Instance;

            this.commDTMContainerPath = EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.GetCommDtmContainerPath.Run();
        }

        #endregion

        #region Properties

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
                    RepoItemInfo elementInfo = this.ffRepository.ApplicationArea.ButtonOKInfo;
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
                    RepoItemInfo elementInfo = this.ffRepository.ApplicationArea.ButtonCancelInfo;
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
        public ComboBox LinkNameCombobox
        {
            get
            {
                try
                {
                    ComboBox combobox;
                    RepoItemInfo elementInfo = this.ffRepository.ApplicationArea.LinkNameComboboxInfo;
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
        ///     Gets the 'LinkNameComboboxButtonOpen' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button LinkNameComboboxButtonOpen
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.ffRepository.ApplicationArea.LinkNameComboboxButtonOpenInfo;
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
                    List list = this.ffRepository.List1000.Self;
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
                    RepoItemInfo elementInfo = this.ffRepository.CommDTMDialog.ButtonCloseInfo;
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
        ///     Gets the 'DialogButtonOK' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button DialogButtonOK
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.ffRepository.CommDTMDialog.ButtonOKInfo;
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
        ///     Gets the 'DialogMessageBox' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text DialogMessageBox
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.ffRepository.CommDTMDialog.DialogMessageInfo;
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
