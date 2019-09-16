// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for closing a project
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.CloseProject;

    using Ranorex;

    /// <summary>
    ///     Provides methods for closing a project
    /// </summary>
    public class CloseProject : MarshalByRefObject, ICloseProject
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Closes the project without saving it
        /// </summary>
        /// <returns>true: if project is closed; false: if an error occurred</returns>
        public bool Run()
        {
            bool result = false;
            if ((new RunProjectClose()).ViaMenu() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be closed");
            }
            else
            {
                // dirty ;-)
                Thread.Sleep(3000);
                if (Validation.ClosingInProgressDialog.WaitUntilClosingFinished(DefaultValues.iTimeoutModules) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be closed");
                }
                else
                {
                    // If save-message box appears
                    Button saveNo = (new SaveProjectMessageElements()).No;
                    if (saveNo != null)
                    {
                        saveNo.Click(DefaultValues.locDefaultLocation);
                    }

                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}