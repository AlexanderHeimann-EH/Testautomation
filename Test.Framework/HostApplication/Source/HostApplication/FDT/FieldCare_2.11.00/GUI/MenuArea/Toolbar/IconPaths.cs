// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconPaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.08.2011
 * Time: 12:54 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.MenuArea.Toolbar
{
    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    ///     EnvCurPaths contains paths to get access on [Envelope Curve] toolbar s.
    /// </summary>
    public static class IconPaths
    {
        #region Declaration

        /// <summary>
        /// The icon help string.
        /// </summary>
        private static readonly string IconHelpString;

        /// <summary>
        /// The button help string.
        /// </summary>
        public static string ButtonHelpString;

        /// <summary>
        /// The connected.
        /// </summary>
        public static string Connected;

        /// <summary>
        /// The disconnected.
        /// </summary>
        public static string Disconnected;

        /// <summary>
        /// The device function.
        /// </summary>
        public static string DeviceFunction;

        /// <summary>
        /// The toolbar.
        /// </summary>
        public static string Toolbar;

        #endregion

        /// <summary>
        /// Initializes static members of the <see cref="IconPaths"/> class.
        /// </summary>
        static IconPaths()
        {   
            if (SystemInformation.Is64Bit)
            {
                IconHelpString = "/form[@controlname='MDIParent2']/element[@controlname='barDockControlTop']/element";
            }
            else
            {
                IconHelpString = "/form[@controlname='MDIParent2']/element[@controlname='barDockControlTop']/element";
            }

            ButtonHelpString = @IconHelpString + "/button";

            Connected = @IconHelpString + "[@controltypename='DockedBarControl' and @instance='2']/toolbar/button[@childindex='5' and @pressed='true']";
            Disconnected = @IconHelpString + "[@controltypename='DockedBarControl' and @instance='2']/toolbar/button[@childindex='5' and @pressed='false']";
            DeviceFunction = @IconHelpString + "[@controltypename='DockedBarControl' and @instance='2']/toolbar/menuitem[@childindex='8']";
            Toolbar = @IconHelpString;
        }
    }
}