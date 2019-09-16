//------------------------------------------------------------------------------
// <copyright file="ApplicationElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.03.2012
 * Time: 1:21 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Description of ApplicationElements.
    /// </summary>
    public class ApplicationElements
    {
        /// <summary>
        ///     Application Area -> Page-Up-button
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button PageUpButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageUp, DefaultValues.iTimeoutDefault,
                                             out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Application Area -> Page-Down-button
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button PageDownButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageDown, DefaultValues.iTimeoutDefault,
                                             out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}