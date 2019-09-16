// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDICommDTMRepoElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.GUI
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
        /// The text ip address.
        /// </summary>
        private static Text textIpAddress;

        /// <summary>
        /// The text port.
        /// </summary>
        private static Text textPort;

        /// <summary>
        /// The combo box found devices.
        /// </summary>
        private static ComboBox comboBoxFoundDevices;

        /// <summary>
        /// The combo box timeout.
        /// </summary>
        private static ComboBox comboBoxTimeout;

        /// <summary>
        /// The button found devices.
        /// </summary>
        private static Button buttonFoundDevices;

        /// <summary>
        /// The button timeout.
        /// </summary>
        private static Button buttonTimeout;

        /// <summary>
        /// Holds the instance of the repository which will be used
        /// </summary>
        private readonly CDICommDTMRepo cdiRepository;
        
        /// <summary>
        /// Holds the path to the commDtmContainer
        /// </summary>
        private readonly string commDtmContainerPath;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="CDICommDTMRepoElements"/> class. 
        /// and gets the communication DTMContainerPath
        /// </summary>
        public CDICommDTMRepoElements()
        {
            this.cdiRepository = CDICommDTMRepo.Instance;
            this.commDtmContainerPath = CommonFlows.GetCommDtmContainerPath.Run();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the 'Communication DTM Window' element itself
        /// </summary>
        /// <returns>
        /// <br>Element: if the element is found</br>
        /// <br>Null: if the element was not found or otherwise returned an error</br>
        /// </returns>
        public Element DtmWindowSelf
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.cdiRepository.ApplicationArea.SelfInfo;
                    Host.Local.TryFindSingle(this.commDtmContainerPath + "/" + elementInfo.AbsolutePath, out element);
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
        /// Gets a list of all items in the combo boxes of this graphical user interface
        /// </summary>
        /// <returns>
        /// <br>Ilist: if the list can be created</br>
        /// <br>Null: if the element was not found or otherwise returned an error</br>
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text ip-address.
        /// </summary>
        public Text TextIpAddress
        {
            get
            {
                try
                {
                    this.GetTextElements();
                    return textIpAddress;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the combo box found devices.
        /// </summary>
        public ComboBox ComboboxFoundDevices
        {
            get
            {
                try
                {
                    this.GetComboBoxElements();
                    return comboBoxFoundDevices;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the button found devices.
        /// </summary>
        public Button ButtonFoundDevices
        {
            get
            {
                try
                {
                    this.GetButtonElements();
                    return buttonFoundDevices;
                }
                catch (Exception exception)
                {
                   Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                   return null;
                }
            }
        }

        /// <summary>
        /// Gets the items found devices.
        /// </summary>
        public IList<ListItem> ItemsFoundDevices
        {
            get
            {
                try
                {
                    this.cdiRepository.ApplicationArea.ButtonFoundDevices.Click();
                    IList<ListItem> dummy = this.cdiRepository.ApplicationArea.ComboboxFoundDevices.Items;

                    if (dummy != null | dummy.Count > 0)
                    {
                        return dummy;
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
        /// Gets the text port.
        /// </summary>
        public Text TextPort
        {
            get
            {
                try
                {
                    this.GetTextElements();
                    return textPort;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the combo box time out.
        /// </summary>
        public ComboBox ComboBoxTimeOut
        {
            get
            {
                try
                {
                    this.GetComboBoxElements();
                    return comboBoxTimeout;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the button timeout.
        /// </summary>
        public Button ButtonTimeout
        {
            get
            {
                try
                {
                    this.GetButtonElements();
                    return buttonTimeout;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the items time out.
        /// </summary>
        public IList<ListItem> ItemsTimeOut
        {
            get
            {
                try
                {
                    this.cdiRepository.ApplicationArea.ButtonTimeout.Click();
                    IList<ListItem> dummy = this.cdiRepository.ApplicationArea.ComboboxTimeout.Items;

                    if (dummy != null || dummy.Count > 0)
                    {
                        return dummy;
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

        #endregion

        #region private methods

        /// <summary>
        /// Get unidentifiable text elements from CDI Communication DTM GUI TCP IP
        /// </summary>
        private void GetTextElements()
        {
            RepoItemInfo textInfo   = this.cdiRepository.ApplicationArea.TextInfo;
            string pathToText       = this.commDtmContainerPath + "/" + textInfo.AbsolutePath;
            IList<Text> textList    = Host.Local.Find<Text>(pathToText);

            if (textList != null && textList.Count >= 2)
            {
                int yaxisOfListElementOne = ((Element)textList[0]).ScreenLocation.Y;
                int yaxisOfListElementTwo = ((Element)textList[1]).ScreenLocation.Y;

                if (yaxisOfListElementOne < yaxisOfListElementTwo)
                {
                    textIpAddress = textList[0];
                    textPort = textList[1];
                }
                else
                {
                    textIpAddress = textList[1];
                    textPort = textList[0];
                }
            }
        }

        /// <summary>
        /// Get unidentifiable combobox elements from CDI Communication DTM GUI TCP IP
        /// </summary>
        private void GetComboBoxElements()
        {
            RepoItemInfo comboboxInfo       = this.cdiRepository.ApplicationArea.ComboBoxInfo;
            string pathToComboBox           = this.commDtmContainerPath + "/" + comboboxInfo.AbsolutePath;
            IList<ComboBox> comboboxList    = Host.Local.Find<ComboBox>(pathToComboBox);
            
            if (comboboxList != null && comboboxList.Count == 2)
            {
                int yaxisOfListElementOne = ((Element)comboboxList[0]).ScreenLocation.Y;
                int yaxisOfListElementTwo = ((Element)comboboxList[1]).ScreenLocation.Y;

                if (yaxisOfListElementOne < yaxisOfListElementTwo)
                {
                    comboBoxFoundDevices = comboboxList[0];
                    comboBoxTimeout = comboboxList[1];
                }
                else
                {
                    comboBoxFoundDevices = comboboxList[1];
                    comboBoxTimeout = comboboxList[0];
                }
            }
        }

        /// <summary>
        /// Get unidentifiable button elements from CDI Communication DTM GUI TCP IP
        /// </summary>
        private void GetButtonElements()
        {
            RepoItemInfo buttonInfo     = this.cdiRepository.ApplicationArea.ButtonInfo;
            string pathToButton         = this.commDtmContainerPath + "/" + buttonInfo.AbsolutePath;
            IList<Button> buttonList    = Host.Local.Find<Button>(pathToButton);

            if (buttonList != null && buttonList.Count == 2)
            {
                int yaxisOfListElementOne = ((Element)buttonList[0]).ScreenLocation.Y;
                int yaxisOfListElementTwo = ((Element)buttonList[1]).ScreenLocation.Y;

                if (yaxisOfListElementOne < yaxisOfListElementTwo)
                {
                    buttonFoundDevices = buttonList[0];
                    buttonTimeout = buttonList[1];
                }
                else
                {
                    buttonFoundDevices = buttonList[1];
                    buttonTimeout = buttonList[0];
                }
            }
        }

        #endregion
    }
}
