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
    public static class DtmMessagesPath
    {
        #region Declaration

        /// <summary>
        ///     Path to string Message from area DTM Messages
        /// </summary>
        public static string strMessagePath;

        public static string strTable;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static DtmMessagesPath()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                strTable =
                    "/form[@controlname='MDIParent2']/container[@caption='DTM messages']/container/element/table[@class='ListView20WndClass']";
                strMessagePath = strTable + @"/row";
            }
            else
            {
                strTable =
                    "/form[@controlname='MDIParent2']/container[@caption='DTM messages']/container/element/table[@class='ListView20WndClass']";
                strMessagePath = strTable + @"/row";
            }

            // Evaluation Info Dialog at FieldCare Startup

            #endregion
        }
    }
}