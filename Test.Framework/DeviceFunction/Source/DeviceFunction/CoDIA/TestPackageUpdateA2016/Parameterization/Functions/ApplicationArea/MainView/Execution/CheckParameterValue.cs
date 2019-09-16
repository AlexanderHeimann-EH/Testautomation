// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckParameterValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 21.03.2012
 * Time: 1:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides functions for application area within module Parameterization
    /// </summary>
    public class CheckParameterValue : MarshalByRefObject, ICheckParameterValue
    {
        #region Public Methods and Operators

        /// <summary>
        /// Function check parameter value
        /// </summary>
        /// <param name="pathToParameter">
        /// Name and path of parameter to check. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="parameterValue">
        /// Expected value
        /// </param>
        /// <returns>
        /// <br>True: if call worded fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string pathToParameter, string parameterValue)
        {
            try
            {
                return (new Application()).CheckForParameterValue(pathToParameter, parameterValue);
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