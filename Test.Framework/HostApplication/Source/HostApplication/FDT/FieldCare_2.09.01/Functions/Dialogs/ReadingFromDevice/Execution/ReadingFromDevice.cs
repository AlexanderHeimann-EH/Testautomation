//------------------------------------------------------------------------------
// <copyright file="ReadingFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.ReadingFromDevice.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReadingFromDevice.Execution;

    using Ranorex;

    /// <summary>
    ///     ReadingFromDevice provides functions to use the dialog
    /// </summary>
    public class ReadingFromDevice : MarshalByRefObject, IReadingFromDevice
    {
        /// <summary>
        ///     Gets current progress bar value in percent
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public double ProgressBarValuePercent
        {
            get
            {
                try
                {
                    return 100 * (new ReadingFromDeviceElements()).ProgressBottom.Value
                           / ((new ReadingFromDeviceElements()).ProgressBottom.MinValue
                              - (new ReadingFromDeviceElements()).ProgressBottom.MaxValue);
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return -1;
                }
            }
        }

        /// <summary>
        ///     In reading from device, cancel upload process
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                (new ReadingFromDeviceElements()).Cancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}