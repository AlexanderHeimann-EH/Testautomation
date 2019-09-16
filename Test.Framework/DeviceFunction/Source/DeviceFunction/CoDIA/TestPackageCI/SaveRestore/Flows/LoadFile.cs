// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 29.02.2012
 * Time: 11:03 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Description of LoadFile.
    /// </summary>
    public class LoadFile : MarshalByRefObject, ILoadFile
    {
        #region Public Methods and Operators

        /// <summary>
        /// Start flow
        /// </summary>
        /// <param name="fileName">File to load</param>
        /// <returns><br>True: if call worked fine</br>
        /// <br>False: if an error occurred</br></returns>
        public bool Run(string fileName)
        {
            if (new Selection().Load())
            {
                if (Execution.OpenFileBrowser.Load(fileName))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file");
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File could not be loaded.");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Load dialog could not be opened.");
            return false;
        }

        #endregion
    }
}