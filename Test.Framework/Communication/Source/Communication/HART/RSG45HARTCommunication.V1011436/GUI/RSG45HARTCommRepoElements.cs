using System;
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.GUI
{
    /// <summary>
    /// Provides access to the GUI elements of the repository 
    /// </summary>
    public class RSG45HARTCommRepoElements
    {
        #region Members

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly RSG45HARTCommRepo rsgHartRepository;

        /// <summary>
        /// Holds the path to the commDTMContainer
        /// </summary>
        private readonly string commDTMContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of <see cref="RSG45HARTCommRepo"/> class
        /// and gets the commDTMContainerPath
        /// </summary>
        public RSG45HARTCommRepoElements()
        {
            this.rsgHartRepository = RSG45HARTCommRepo.Instance;

            this.commDTMContainerPath = EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
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
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.ApplyInfo;
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
        ///     Gets the 'StartAddressComboButton' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button StartAddressComboButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.StartAddressCombobox.StartAddressComboButtonInfo;
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
        ///     Gets the 'EndAddressComboButton' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button EndAddressComboButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.EndAddressCombobox.EndAddressComboButtonInfo;
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
        ///     Gets the 'TimeoutComboButton' object
        /// </summary>
        /// <returns>
        ///     <br>Button: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Button TimeoutComboButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.TimeoutCombobox.TimeoutComboButtonInfo;
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
        ///  Gets the 'IPAddress' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text IPAddress
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.IPAddressInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out text);
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
        ///  Gets the 'Port' object
        /// </summary>
        /// <returns>
        ///     <br>Text: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Text Port
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.PortInfo;
                    Host.Local.TryFindSingle(this.commDTMContainerPath + "/" + elementInfo.AbsolutePath, out text);
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
        /// Gets the 'StartAddressCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Element: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Element StartAddressCombobox
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.StartAddressCombobox.SelfInfo;
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
        /// Gets the 'EndAddressCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Element: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Element EndAddressCombobox
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.EndAddressCombobox.SelfInfo;
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
        /// Gets the 'TimeoutCombobox' object
        /// </summary>
        /// <returns>
        ///     <br>Element: if the element is found</br>
        ///     <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Element TimeoutCombobox
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.rsgHartRepository.ParamContainer.TimeoutCombobox.SelfInfo;
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
                    List list = this.rsgHartRepository.ListContainer.List;
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

        #endregion
    }
}
