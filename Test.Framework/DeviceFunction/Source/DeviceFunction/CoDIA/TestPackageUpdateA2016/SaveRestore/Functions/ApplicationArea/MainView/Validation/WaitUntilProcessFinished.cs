// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitUntilProcessFinished.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Description of WaitUntilProcessFinished.
    /// </summary>
    public class WaitUntilProcessFinished : MarshalByRefObject, IWaitUntilProcessFinished
    {
        #region Public Methods and Operators

        /// <summary>
        /// Waits until Save / Restore is finished, by watching the progress bar
        ///     Waiting is non-optional and will raise exceptions, if nothing is found.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time within module should be ready
        /// </param>
        /// <returns>
        /// <br>True: if process finished in time</br>
        ///     <br>False: if process not finished in time</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (new IsProcessActive().Run())
            {
                if (watch.ElapsedMilliseconds > timeOutInMilliseconds)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save/Restore process did not finish within " + timeOutInMilliseconds + " milliseconds");
                    watch.Stop();
                    return false;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save/Restore process finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            return true;
        }

        #endregion
    }
}