// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsParameterAvailable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsParameterAvailable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsParameterAvailable.
    /// </summary>
    public class IsParameterAvailable : IIsParameterAvailable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates, whether a specified parameter exists in current display content.
        /// </summary>        
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns><c>true</c> if parameter is available, <c>false</c> otherwise.</returns>
        public bool Run(string parameterId)
        {
            string displayContent = AppComController.GetDisplayContent();
            var result = false;
            if (displayContent.Contains(parameterId))
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is available.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is not available.");
            }

            return result;
        }



        #endregion
    }
}