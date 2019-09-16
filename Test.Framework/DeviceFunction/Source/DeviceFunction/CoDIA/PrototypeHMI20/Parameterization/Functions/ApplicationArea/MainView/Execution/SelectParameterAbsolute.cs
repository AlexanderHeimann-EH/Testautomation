namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class SelectParameterAbsolute.
    /// </summary>
    public class SelectParameterAbsolute : ISelectParameterAbsolute
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects a parameter with an absolute path
        /// </summary>
        /// <param name="pathToParameter">The path to parameter.</param>
        /// <returns><c>true</c> if selected, <c>false</c> otherwise.</returns>
        public bool Run(string pathToParameter)
        {
            var result = true;            
            string[] separator = { "//" };
            string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
            if (pathParts.Length <= 0)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Path to parameter '" + pathToParameter + "' is not valid or empty.");
                result = false;
            }
            else
            {
                var select = new SelectParameter();

                if (pathToParameter.Contains("Offline"))
                {
                    select.Run("OfflineDeviceMenu");
                }
                else if (pathToParameter.Contains("Online"))
                {                   
                    select.Run("OnlineDeviceMenu");
                }

                foreach (var pathPart in pathParts)
                {
                    result = select.Run(pathPart);
                }
            }

            return result;
        }

        #endregion
    }
}