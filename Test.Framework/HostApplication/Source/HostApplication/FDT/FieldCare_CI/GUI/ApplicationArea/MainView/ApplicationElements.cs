// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.08.2011
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides methods to get access to FieldCare 2.09.00 GUI-controls
    /// </summary>
    public class ApplicationElements
    {
        #region Get GUI components

        /// <summary>
        /// Gets Frame Main Window
        /// </summary>
        public static Form FrameMainWindow
        {
            get
            {
                try
                {
                    Form form;
                    if (Host.Local.TryFindSingle(ApplicationPaths.FrameMainWindow, DefaultValues.iTimeoutShort, out form))
                    {
                        return form;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}