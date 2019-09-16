//------------------------------------------------------------------------------
// <copyright file="IsDtmDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/9/2013
 * Time: 3:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.StatusArea.Statusbar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.StatusArea.Statusbar;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Description of IsDtmDisconnected.
    /// </summary>
    public class IsDTMDisconnected : MarshalByRefObject, IIsDTMDisconnected
    {
        /// <summary>
        ///     Determines whether dtm is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusbarElements().ConnectionState;
            if (state == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                return false;
            }
            watch.Start();
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusbarElements().ConnectionState;
                if (state.Equals("Offline"))
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is disconnected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                    return true;
                }
            }
            watch.Stop();
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not disconnected within " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }
    }
}