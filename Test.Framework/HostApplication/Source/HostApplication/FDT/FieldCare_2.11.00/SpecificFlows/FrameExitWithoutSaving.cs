//------------------------------------------------------------------------------
// <copyright file="FrameExitWithoutSaving.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15.02.2013
 * Time: 1:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.SpecificFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    /// <summary>
    ///     Workflow FrameExitWithoutSaving.
    /// </summary>
    public class FrameExitWithoutSaving : MarshalByRefObject, IFrameExitWithoutSaving
    {
        /// <summary>
        ///     Run workflow
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run()
        {
            return this.Run(DefaultValues.GeneralTimeout);
        }

        /// <summary>
        ///     Run workflow
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be finished</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            // If save-functionality called successfully
            if ((new RunFrameExit()).ViaMenu())
            {
                this.ConfirmShutdownDtMs();
                this.NoProjectSaving();

                if ((new WaitUntilFrameClosed()).Run(timeOutInMilliseconds))
                {
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Frame is not closed after: " + timeOutInMilliseconds + " Milliseconds");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function RunFrameExit was not successful.");
            return false;
        }

        /// <summary>
        ///     Denies saving project in case of upcoming related message box
        /// </summary>
        private void NoProjectSaving()
        {
            Button buttonSaveProjectNo = (new SaveProjectMessageElements()).No;
            if (buttonSaveProjectNo != null && buttonSaveProjectNo.Enabled)
            {
                buttonSaveProjectNo.Click(DefaultValues.locDefaultLocation);
            }
        }

        /// <summary>
        ///     Confirm shutdown of DTM in case of upcoming related message box
        /// </summary>
        private void ConfirmShutdownDtMs()
        {
            Button buttonShutdownYes = (new ShutdownDtmMessageElements()).Ok;
            if (buttonShutdownYes != null && buttonShutdownYes.Enabled)
            {
                buttonShutdownYes.Click(DefaultValues.locDefaultLocation);
            }
        }
    }
}