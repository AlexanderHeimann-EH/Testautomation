//------------------------------------------------------------------------------
// <copyright file="EvaluationInfoPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 05.11.2010
 * Time: 9:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     Providess paths for frame dialogs and GUI-elements
    /// </summary>
    public static class EvaluationInfoPaths
    {
        #region Declaration

        /// <summary>
        ///     Help-Strings
        /// </summary>
        private static readonly string strButtonHelpString;

        /// <summary>
        ///     Path to button OK at dialog Evaluation Info at Frame
        /// </summary>
        public static string strEvaluationOk;

        /// <summary>
        ///     Path to button Close at dialog Evaluation Info at Frame
        /// </summary>
        public static string strEvaluationClose;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static EvaluationInfoPaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
            }
            else
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
            }

            // Evaluation Info Dialog at FieldCare Startup
            strEvaluationOk = @strButtonHelpString + "[@controlid='202']";
            strEvaluationClose = @"/form/titlebar/button[@childindex='0']/../../text[@caption='IDI_ICON_QUESTION']";

            #endregion
        }
    }
}