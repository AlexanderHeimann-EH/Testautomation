// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ApplicationElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Description of ApplicationElements.
    /// </summary>
    public class ApplicationElements
    {
        #region Public Properties

        /// <summary>
        /// Gets the vertical scrollbar.
        /// </summary>
        /// <value>The vertical scrollbar.</value>
        public ScrollBar VerticalScrollbar
        {
            get
            {
                try
                {
                    ScrollBar buffer;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaVerticalScrollBar, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the page down button.
        /// </summary>
        /// <value>The page down button.</value>
        public Button PageDownButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaVScrollBarPageDown, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the page up button.
        /// </summary>
        /// <value>The page up button.</value>
        public Button PageUpButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaVScrollBarPageUp, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the line down.
        /// </summary>
        /// <value>The line down.</value>
        public Button LineDown
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaVScrollBarLineDown, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the line down.
        /// </summary>
        /// <value>The line down.</value>
        public Button LineUp
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaVScrollBarLineUp, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the tab control element within the module. This element can be used to determine whether the module is the online or offline parameterization
        /// </summary>
        /// <value>The element.</value>
        public Element TabControlOnlineParameterization
        {
            get
            {
                try
                {
                    Element element;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaIsOnlineParam, DefaultValues.iTimeoutShort, out element);
                    if (element == null)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element Tab control OnlineDeviceMenu not found. Trying to find Container OnlineDeviceMenu (no pages).");
                        Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaIsOnlineParamNoPages, DefaultValues.iTimeoutShort, out element);

                        if (element == null)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Online Parameterization is closed and cannot be found.");
                        }
                    }
                    
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
        /// Gets the tab control element within the module. This element can be used to determine whether the module is the online or offline parameterization
        /// </summary>
        /// <value>The element.</value>
        public Element TabControlOfflineParameterization
        {
            get
            {
                try
                {
                    Element element;
                    Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaIsOfflineParam, DefaultValues.iTimeoutShort, out element);
                    if (element == null)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element Tab control OfflineDeviceMenu not found. Trying to find Container OfflineDeviceMenu (no pages).");
                        Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaIsOfflineParamNoPages, DefaultValues.iTimeoutShort, out element);
                    }

                    if (element == null)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Offline Parameterization is closed and cannot be found.");
                    }

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
        /// Gets the combo box list items.
        /// </summary>
        public IList<ListItem> ComboBoxListItems
        {
            get
            {
                try
                {
                    IList<ListItem> listItems;
                    listItems = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList);
                    if (listItems == null)
                    {   
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("There are no list items available"));
                        return null;
                    }

                    return listItems;
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