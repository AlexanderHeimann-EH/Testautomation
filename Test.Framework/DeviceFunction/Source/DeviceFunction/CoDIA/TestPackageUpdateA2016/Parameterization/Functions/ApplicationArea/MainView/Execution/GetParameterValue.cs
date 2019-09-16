// -----------------------------------------------------------------------
// <copyright file="GetParameterValue.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common;
    using Common.Tools;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

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
            string result = string.Empty;
            Parameter parameter = new GetParameter().Run(pathToParameter);
            if (parameter == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " could not be found");
            }
            else
            {
                result = parameter.ParameterValue;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " is found");
            }

            return result;
        }
    }
}
