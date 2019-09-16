//------------------------------------------------------------------------------
// <copyright file="GetComboBoxList.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20/03/2013
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides function to get and store all items of a specified parameters combobox
    /// </summary>
    public class GetComboBoxList : MarshalByRefObject, IGetComboBoxList
    {
        /// <summary>
        ///     Searches and selects a specified parameter and stores its combobox values
        /// </summary>
        /// <param name="pathToParameter"></param>
        /// <returns>
        ///     <br>Parameter: if call workd fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public string[] Run(string pathToParameter)
        {
            return this.Run(pathToParameter, true);
        }

        /// <summary>
        ///     Searches and selects a specified parameter and stores its combobox values
        /// </summary>
        /// <param name="pathToParameter">Like "Export//Diagnostics//Data logging//Assign channel 1 (41):"</param>
        /// <param name="withTreeTracing">Enables / disables tree tracing</param>
        /// <returns>
        ///     String[] with all combobox items if call worked fine
        ///     null if an error occurred
        /// </returns>
        public string[] Run(string pathToParameter, bool withTreeTracing)
        {
            try
            {
                string[] seperator = {"//"};
                string[] pathParts = pathToParameter.Split(seperator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];
                if (withTreeTracing)
                {
                    if ((new Navigation()).SearchAndSelectParameter(pathToParameter))
                    {
                        //parameter found
                        string[] result = new Application().GetList(parameterName);
                        return result;
                    }
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                   "Parameter [" + parameterName + "] not found");
                    return null;
                }
                string[] endResult = new Application().GetList(parameterName);
                return endResult;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}