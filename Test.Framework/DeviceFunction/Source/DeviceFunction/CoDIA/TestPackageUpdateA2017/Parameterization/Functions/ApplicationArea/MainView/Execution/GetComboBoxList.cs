// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetComboBoxList.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20/03/2013
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Provides function to get and store all items of a specified parameters combobox
    /// </summary>
    public class GetComboBoxList : IGetComboBoxList
    {
        /// <summary>
        /// Searches and selects a specified parameter and stores its combobox values
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="T:string[]"/>.
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
                bool result;
                Navigation navigationArea = new Navigation();
                result = navigationArea.SearchAndSelectParameter(pathToParameter);
                if (result)
                {
                    Application applicationArea = new Application();
                    Unknown element = applicationArea.SearchAndSelectParameter(pathToParameter);
                    string[] comboBoxList = applicationArea.GetList(element);
                    return comboBoxList;    
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No Combo Box List Items available."); 
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}