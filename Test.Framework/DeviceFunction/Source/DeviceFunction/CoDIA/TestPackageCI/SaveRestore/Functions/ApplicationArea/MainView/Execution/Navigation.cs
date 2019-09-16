// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Navigation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Navigation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Description of Navigation.
    /// </summary>
    public class Navigation : INavigation
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Clicks button Back
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Back()
        {
            Element button = new NavigationElements().BtnBack;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        /// Clicks button Finish
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool Finish()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014.");
            return false;
        }

        /// <summary>
        /// Clicks button Next
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool Next()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014.");
            return false;
        }

        /// <summary>
        ///     Clicks button Restore
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Restore()
        {
            Element button = new NavigationElements().BtnRestore;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        ///     Clicks button Save
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Save()
        {
            Element button = new NavigationElements().BtnSave;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        ///     Clicks button Start
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Start()
        {
            Element button = new NavigationElements().BtnStart;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        #endregion
    }
}