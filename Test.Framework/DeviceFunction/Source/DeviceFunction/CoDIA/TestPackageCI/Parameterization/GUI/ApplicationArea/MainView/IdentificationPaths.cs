//------------------------------------------------------------------------------
// <copyright file="IdentificationPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 14.04.2011
 * Time: 7:15 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Description of IdentificationPaths.
    /// </summary>
    public static class IdentificationPaths
    {
        #region Declaration

        /// <summary>
        ///     Help-string for GUI
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        ///     Help-string for parameter
        /// </summary>
        private static readonly string ParameterHelpString;

        /// <summary>
        ///     Path to access whole area of identification area
        /// </summary>
        public static readonly string Area;

        /// <summary>
        ///     Path to access a parameter label within identification area
        /// </summary>
        public static readonly string StrIdenAreaParameterLabel;

        /// <summary>
        ///     Path to access a parameter unit within identification area
        /// </summary>
        public static readonly string StrIdenAreaParameterUnit;

        /// <summary>
        ///     Path to access a parameter value within identification area
        /// </summary>
        public static readonly string StrIdenAreaParameterValue;

        /// <summary>
        ///     Path to access a parameter state within identification area
        /// </summary>
        public static readonly string StrIdenAreaParameterState;

        /// <summary>
        ///     Path to access a parameter element within identification area
        /// </summary>
// ReSharper disable UnusedMember.Global
        public static string StrIdenAreaParameterElement;
// ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Path to access a parameter text edit within identification area
        /// </summary>
        public static readonly string StrIdenAreaParameterEdit;

        #endregion

        ///// <summary>
        /////     Static constructor to load operating system dependent path
        ///// </summary>
        //static IdentificationPaths()
        //{
        //    #region Initializations

        //    if (SystemInformation.Is64Bit)
        //    {
        //        GUIHelpString =
        //            "/form[@controlname='MDIParent2']/element/form/element/container/container/container[@controlname='DtmIdentificationArea']";
        //        ParameterHelpString =
        //            "/form[@controlname='MDIParent2']/element/form/element/container/container/container[@controlname='DtmIdentificationArea']/container/container/container/container/container/";
        //    }
        //    else
        //    {
        //        GUIHelpString =
        //            "/form[@controlname='MDIParent2']/element/form/container/container/container/container[@controlname='DtmIdentificationArea']";
        //        ParameterHelpString =
        //            "/form[@controlname='MDIParent2']/element/form/container/container/container/container[@controlname='DtmIdentificationArea']/container/container/container/container/container/";
        //    }

        //    // Paths for Identification Area within Parameterization
        //    Area = @GUIHelpString;
        //    StrIdenAreaParameterLabel = @GUIHelpString + "/descendant::element/text[text~'CONTROLNAME']";
        //    StrIdenAreaParameterUnit = @GUIHelpString + "/descendant::element[@controlname='CONTROLNAME']/text";
        //    StrIdenAreaParameterValue = @GUIHelpString + "/descendant::element[@controlname='CONTROLNAME']/text";
        //    StrIdenAreaParameterState = @GUIHelpString + "/descendant::element[@controlname='CONTROLNAME']/";
        //    StrIdenAreaParameterEdit = ParameterHelpString + "element[@controlname~'Label' and @visible='true']";

        //    #endregion
        //}

        /// <summary>
        /// Initializes static members of the <see cref="IdentificationPaths"/> class. 
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static IdentificationPaths()
        {
            GUIHelpString = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();

            // Paths for Identification Area within Parameterization
            Area = @GUIHelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']";
            ParameterHelpString =
                        "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']/container/container/container/container/container/";
            StrIdenAreaParameterLabel = @Area + "/descendant::element/text[text~'CONTROLNAME']";
            StrIdenAreaParameterUnit = @Area + "/descendant::element[@controlname='CONTROLNAME']/text";
            StrIdenAreaParameterValue = @Area + "/descendant::element[@controlname='CONTROLNAME']/text";
            StrIdenAreaParameterState = @Area + "/descendant::element[@controlname='CONTROLNAME']/";
            StrIdenAreaParameterEdit = @GUIHelpString + ParameterHelpString + "element[@controlname~'Label' and @visible='true']";
        }
    }
}