//------------------------------------------------------------------------------
// <copyright file="Paths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.08.2011
 * Time: 12:54 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

namespace FieldCare_2._09._01.GUI.MenuArea.Toolbar
{
    /// <summary>
    ///     EnvCurPaths contains paths to get access on [Envelope Curve] toolbar s.
    /// </summary>
    public static class IconPaths
    {
        #region Declaration

        private static readonly string IconHelpString;
        public static string ButtonHelpString;

        public static string Connected;
        public static string Disconnected;
        public static string DeviceFunction;

        public static string Toolbar;

        #endregion

        static IconPaths()
        {
            #region Initialization

            if (SystemInformation.Is64Bit)
            {
                IconHelpString = "/form[@controlname='MDIParent2']/element[@controlname='barDockControlTop']/element";
            }
            else
            {
                IconHelpString = "/form[@controlname='MDIParent2']/element[@controlname='barDockControlTop']/element";
            }

            ButtonHelpString = @IconHelpString + "/button";

            Connected = @IconHelpString +
                        "[@controltypename='DockedBarControl' and @instance='2']/toolbar/button[@childindex='5' and @pressed='true']";
            Disconnected = @IconHelpString +
                           "[@controltypename='DockedBarControl' and @instance='2']/toolbar/button[@childindex='5' and @pressed='false']";
            DeviceFunction = @IconHelpString +
                             "[@controltypename='DockedBarControl' and @instance='2']/toolbar/menuitem[@childindex='8']";

            Toolbar = @IconHelpString;

            #endregion
        }
    }
}