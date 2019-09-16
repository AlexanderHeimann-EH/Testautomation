// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameterValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    /// Gets the value of a specified parameter
    /// </summary>
    public class GetParameterValue : IGetParameterValue
    {
        /// <summary>
        /// Searches for the specified parameter and returns its value
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the parameter
        /// </param>
        /// <returns>
        /// The value of the parameter
        /// </returns>
        public string Run(string pathToParameter)
        {
            Navigation navigationArea = new Navigation();
            navigationArea.SearchAndSelectParameter(pathToParameter);
            Application applicationArea = new Application();
            Unknown element = applicationArea.SearchAndSelectParameter(pathToParameter);
            string result = applicationArea.GetParameterValue(element);
            return result;
        }
    }
}
