//------------------------------------------------------------------------------
// <copyright file="WaitUntilFrameDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 17:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Toolbar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation;

    using Ranorex;

    /// <summary>
    /// Class WaitUntilFrameDisconnected.
    /// </summary>
    public class WaitUntilFrameDisconnected : MarshalByRefObject, IWaitUntilFrameDisconnected
    {
        /// <summary>
        ///     Wait until GUI connection is established and shown by GUI
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be finished</param>
        /// <returns>True if connection is established, False if not</returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (!(new IsDisconnected()).Run())
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection is not disabled after: >" + DefaultValues.GeneralTimeout + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection disabled.");
            }

            return result;
        }
    }
}