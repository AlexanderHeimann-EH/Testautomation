// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Action.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Provides functions for action area at module Compare
    /// </summary>
    public class Action : IAction
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Cancels comparing by clicking related button
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CancelCompare()
        {
            try
            {
                Button button = new ActionElements().ButtonCancel;
                bool success;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click();
                    success = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible.");
                    Log.Screenshot();
                    success = false;
                }

                return success;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Starts comparing by clicking related button
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool StartCompare()
        {
            try
            {
                Button button = new ActionElements().ButtonCompare;
                bool success;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click();
                    success = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button not not accessible.");
                    success = false;
                }

                return success;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}