//------------------------------------------------------------------------------
// <copyright file="ApplicationPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Provide paths for setup wizard navigation
    /// </summary>
    public static class ApplicationPaths
    {
        #region Declaration

        /// <summary>
        ///     Help-String
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        ///     Provides path to application area within module Parameterization
        /// </summary>
        public static readonly string Area;

        /// <summary>
        ///     Provides path to DTMDisplayArea area within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaDtmDisplayArea;

        /// <summary>
        /// The str appl area dtm display area scroll container.
        /// </summary>
        public static readonly string StrApplAreaDtmDisplayAreaScrollContainer;

        /// <summary>
        /// The str appl area navi next page.
        /// </summary>
        public static readonly string strApplAreaNaviNextPage;

        /// <summary>
        ///     Provides path to parameter label area within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterLabel;

        /// <summary>
        ///     Provides path to parameter unit within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterUnit;

        /// <summary>
        ///     Provides path to parameter state within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterState;

        /// <summary>
        ///     Provides path to parameter editor within module Parameterization
        /// </summary>
        /// 
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaComboEdit;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to parameter checkbox within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaCheck;

        /// <summary>
        ///     Provides path to parameter textedit within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterEditFieldValue;

        /// <summary>
        ///     Provides path to parameter combobox within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterComboBoxValue;

        /// <summary>
        ///     Provides path to parameter checkbox within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaParameterCheckBoxValue;

        /// <summary>
        ///     Provides path to combobox list within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaComboBoxList;

        /// <summary>
        ///     Provides path to vertical scrollbar within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaVerticalScrollBar;

        /// <summary>
        ///     Provides path to button line up within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaVScrollBarLineUp;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to button line down within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaVScrollBarLineDown;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to button page up within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaVScrollBarPageUp;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to button page down within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaVScrollBarPageDown;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to scrollbar indicator within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaVScrollBarIndicator;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to horizontal scrollbar within module Parameterization
        /// </summary>
        public static readonly string StrApplAreaHoricontalScrollBar;

        /// <summary>
        ///     Provides path to button line up within scrollbar
        /// </summary>
// ReSharper disable NotAccessedField.Global
        public static string StrApplAreaHScrollBarLineUp;
// ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Provides path to button line down within scrollbar
        /// </summary>
// ReSharper disable UnusedMember.Global
        public static string StrApplAreaHScrollBarLineDown;
// ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to button page up within scrollbar
        /// </summary>
// ReSharper disable UnusedMember.Global
        public static string StrApplAreaHScrollBarPageUp;
// ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to button page down within scrollbar
        /// </summary>
// ReSharper disable UnusedMember.Global
        public static string StrApplAreaHScrollBarPageDown;
// ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to scrollbar indicator within scrollbar
        /// </summary>
// ReSharper disable UnusedMember.Global
        public static string StrApplAreaHScrollBarIndicator;
// ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to the control which determines whether its online or offline parameterization
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public static string StrApplAreaIsOnlineParam;
        // ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to the control which determines whether its online or offline parameterization
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public static string StrApplAreaIsOfflineParam;
        // ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to the control which determines whether its online or offline parameterization
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public static string StrApplAreaIsOnlineParamNoPages;
        // ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Provides path to the control which determines whether its online or offline parameterization
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public static string StrApplAreaIsOfflineParamNoPages;
        // ReSharper restore UnusedMember.Global

        #endregion

        /// <summary>
        /// Initializes static members of the <see cref="ApplicationPaths"/> class. 
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static ApplicationPaths()
        {
            GUIHelpString = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();

            // Paths for Application Area within Parameterization
            Area = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']";

            StrApplAreaDtmDisplayArea = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']";
            
            StrApplAreaIsOnlineParam = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element[@controlname~'nline']";
            StrApplAreaIsOfflineParam = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element[@controlname~'ffline']";

            StrApplAreaIsOnlineParamNoPages = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container[@controlname~'nline']";
            StrApplAreaIsOfflineParamNoPages = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container[@controlname~'ffline']";

            StrApplAreaParameterLabel = "descendant::element[@controlname~'Label']/text";
            StrApplAreaParameterUnit = "descendant::element[@controlname='CONTROLNAME']";
            StrApplAreaParameterState = "descendant::element[@controlname='CONTROLNAME']";
            StrApplAreaComboEdit = "descendant::element[@controlname='CONTROLNAME']";
            StrApplAreaComboBoxList = @"/form/element/list/listitem";
            StrApplAreaCheck = "descendant::container[@controlname='CONTROLNAME']";
            StrApplAreaParameterEditFieldValue = "descendant::element[@controlname='CONTROLNAME']/text[@childindex='1']";
            StrApplAreaParameterComboBoxValue = "descendant::element[@controlname='CONTROLNAME']/text";
            StrApplAreaParameterCheckBoxValue = "descendant::container[@controlname='CONTROLNAME']/descendant::element/checkbox";

            StrApplAreaVerticalScrollBar = @GUIHelpString +
                                           "/container/container[@controlname='DtmDisplayArea']//scrollbar[@accessiblename='scroll bar']";
            StrApplAreaVScrollBarLineUp = StrApplAreaVerticalScrollBar + "/button[@accessiblename='Line Up']";
            StrApplAreaVScrollBarLineDown = StrApplAreaVerticalScrollBar + "/button[@accessiblename='Line Down']";
            StrApplAreaVScrollBarPageUp = StrApplAreaVerticalScrollBar + "/button[@accessiblename='Page Up']";
            StrApplAreaVScrollBarPageDown = StrApplAreaVerticalScrollBar + "/button[@accessiblename='Page Down']";
            StrApplAreaVScrollBarIndicator = StrApplAreaVerticalScrollBar + "/button[@accessiblename='Position']";

            StrApplAreaHoricontalScrollBar = @GUIHelpString +
                                             "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element/container/container/container/container/scrollbar[@childindex='0']";
            StrApplAreaHScrollBarLineUp = StrApplAreaHoricontalScrollBar + "/button[@accessiblename='Column Left']";
            StrApplAreaHScrollBarLineDown = StrApplAreaHoricontalScrollBar + "/button[@accessiblename='Page Left']";
            StrApplAreaHScrollBarPageUp = StrApplAreaHoricontalScrollBar + "/button[@accessiblename='Position']";
            StrApplAreaHScrollBarPageDown = StrApplAreaHoricontalScrollBar + "/button[@accessiblename='Page Right']";
            StrApplAreaHScrollBarIndicator = StrApplAreaHoricontalScrollBar + "/button[@accessiblename='Column Right']";

            strApplAreaNaviNextPage = GUIHelpString + "//container[@controlname='DtmDisplayArea']/container[@controlname='GuiBarControl']//toolbar[@accessiblename='Bar']/button[@accessibledescription='Next Page']";
        }
    }
}