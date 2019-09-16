//------------------------------------------------------------------------------
// <copyright file="MainPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.08.2011
 * Time: 13:02 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Provides paths to FieldCare 2.09.00 areas
    /// </summary>
    public static class ApplicationPaths
    {
        #region Declaration

        /// <summary>
        ///     Provides path to main window object
        /// </summary>
        public static string FrameMainWindow;

        /// <summary>
        ///     Help-String
        /// </summary>
        public static string HelpString;

        #endregion

        /// <summary>
        ///     Static constructor
        /// </summary>
        static ApplicationPaths()
        {
            #region Initialization

            // if (global::Common.SystemInformation.is64Bit)
            //{
            //    HelpString	= "/form[@processname='FMPFrame']/element[@controltypename='MdiClient']/form/element";
            //}
            //else
            //{
            //    HelpString	= "/form[@processname='FMPFrame']/element[@controltypename='MdiClient']/form/container";
            //}

            FrameMainWindow = @"/form[@Processname='FMPFrame']";

            #endregion
        }
    }
}