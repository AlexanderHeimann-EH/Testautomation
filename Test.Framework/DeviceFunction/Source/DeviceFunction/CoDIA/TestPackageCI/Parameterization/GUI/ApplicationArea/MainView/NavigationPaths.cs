//------------------------------------------------------------------------------
// <copyright file="NavigationPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Description of NavigationPaths.
    /// </summary>
    public static class NavigationPaths
    {
        /// <summary>
        ///     Gui help string
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        ///     Ranorex paths for Navigation Area within Parameterization
        /// </summary>
        public static readonly string Area;

        /// <summary>
        ///     Ranorex path to Tree Columns
        /// </summary>
        public static readonly string StrNaviAreaTreeColumns;

        /// <summary>
        /// The str navi area tree data panel.
        /// </summary>
        public static readonly string StrNaviAreaTreeDataPanel;

        /// <summary>
        ///     Ranorex path to Page Tab
        /// </summary>
        public static readonly string StrNaviAreaPageTab;

        /// <summary>
        ///     Ranorex path to Tree
        /// </summary>
        public static readonly string StrNaviAreaTree;

        /// <summary>
        /// The str navi area tree visible.
        /// </summary>
        public static readonly string StrNaviAreaTreeCollapsed;

        /// <summary>
        ///     Ranorex path to Tree item Parameter T
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaTreeItemParameterT;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to Tree item Parameter
        /// </summary>
        public static readonly string StrNaviAreaTreeItemParameter;

        /// <summary>
        ///     Ranorex path to vertical scrollbar
        /// </summary>
        public static readonly string StrNaviAreaVerticalScrollBar;

        /// <summary>
        ///     Ranorex path to vertical scrollbar line up
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaVScrollBarLineUp;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to vertical scrollbar line down
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaVScrollBarLineDown;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        /// The str navi area vertical scroll bar element.
        /// </summary>
        public static readonly string StrNaviAreaVerticalScrollBarElement;

        /// <summary>
        ///     Ranorex path to vertical scrollbar page up
        /// </summary>
        public static readonly string StrNaviAreaVScrollBarPageUp;

        /// <summary>
        ///     Ranorex path to vertical scrollbar page down
        /// </summary>
        public static readonly string StrNaviAreaVScrollBarPageDown;

        /// <summary>
        ///     Ranorex path to vertical scrollbar indicator
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaVScrollBarIndicator;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to horizontal scrollbar
        /// </summary>
        public static readonly string StrNaviAreaHoricontalScrollBar;

        /// <summary>
        ///     Ranorex path to horizontal scrollbar column left
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaHScrollBarColumnLeft;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to horizontal scrollbar column right
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaHScrollBarColumnRight;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to horizontal scrollbar page left
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaHScrollBarPageLeft;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to horizontal scrollbar page right
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaHScrollBarPageRight;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to horizontal scrollbar indicator
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrNaviAreaHScrollBarIndicator;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        ///     Ranorex path to protector
        /// </summary>
        // ReSharper disable NotAccessedField.Global
        public static string StrModuleDTMOnlineProtector;

        /// <summary>
        /// The str navi area navigation tree.
        /// </summary>
        public static string StrNaviAreaNavigationTree;

        // ReSharper restore NotAccessedField.Global

        /// <summary>
        /// Initializes static members of the <see cref="NavigationPaths"/> class. 
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static NavigationPaths()
        {
            GUIHelpString = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();

            Area = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']";
            StrNaviAreaTreeColumns = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Header Panel']";
            StrNaviAreaTreeDataPanel = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']";
            StrNaviAreaPageTab = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/tabpagelist/tabpage[@accessibledefaultaction='Switch']";
            StrNaviAreaNavigationTree = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree";

            // EC: strNaviAreaTree = generic path to all tree items
//            StrNaviAreaTree = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']/treeitem";
            StrNaviAreaTree = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']/treeitem[@accessiblename~'Navigation_']";
            StrNaviAreaTreeCollapsed = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']/treeitem[@accessiblestate~'Collapsed']";
            StrNaviAreaTreeItemParameterT = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']/treeitem[@visible='True']/cell[@text~'TREEITEM']/../";
            StrNaviAreaTreeItemParameter = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/tree/container[@accessiblename='Data Panel']/treeitem[@visible='True']/cell[TREEITEMPARTS]/../";
            StrNaviAreaVerticalScrollBarElement = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/element[@controltypename='VTLScrollBar']";
            StrNaviAreaVerticalScrollBar = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/element[@controltypename='VTLScrollBar']/scrollbar";
            StrNaviAreaVScrollBarLineUp = StrNaviAreaVerticalScrollBar + "/button[@accessiblename='Line Up']";
            StrNaviAreaVScrollBarLineDown = StrNaviAreaVerticalScrollBar + "/button[@accessiblename='Line Down']";
            StrNaviAreaVScrollBarPageUp = StrNaviAreaVerticalScrollBar + "/button[@accessiblename='Page Up']";
            StrNaviAreaVScrollBarPageDown = StrNaviAreaVerticalScrollBar + "/button[@accessiblename='Page Down']";
            StrNaviAreaVScrollBarIndicator = StrNaviAreaVerticalScrollBar + "/indicator[@accessiblename='Position']";

            StrNaviAreaHoricontalScrollBar = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmNavigationArea']/element/container/element/element[@controltypename='HTLScrollBar']/scrollbar";
            StrNaviAreaHScrollBarColumnLeft = StrNaviAreaHoricontalScrollBar + "/button[@accessiblename='Column Left']";
            StrNaviAreaHScrollBarPageLeft = StrNaviAreaHoricontalScrollBar + "/button[@accessiblename='Page Left']";
            StrNaviAreaHScrollBarColumnRight = StrNaviAreaHoricontalScrollBar + "/button[@accessiblename='Column Right']";
            StrNaviAreaHScrollBarPageRight = StrNaviAreaHoricontalScrollBar + "/button[@accessiblename='Page Right']";
            StrNaviAreaHScrollBarIndicator = StrNaviAreaHoricontalScrollBar + "/indicator[@accessiblename='Position']";

            // Paths for 
            StrModuleDTMOnlineProtector = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/picture[@controltypename='DtmOnlineProtector']";
        }
    }
}