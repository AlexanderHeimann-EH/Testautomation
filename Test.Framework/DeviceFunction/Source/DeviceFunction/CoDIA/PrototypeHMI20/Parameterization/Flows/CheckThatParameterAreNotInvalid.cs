// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatParameterAreNotInvalid.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckThatParameterAreNotInvalid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Flows
{
    using System.Collections.Generic;
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;

    /// <summary>
    /// Class CheckThatParameterAreNotInvalid.cs.
    /// </summary>
    public class CheckThatParameterAreNotInvalid : ICheckThatParameterAreNotInvalid
    {
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameterList">
        /// The parameter list.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(List<string> parameterList)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Method is not implemented yet.");
            return true;
        }

        /// <summary>
        /// Examines the status of all parameter the DTM contains. Reports every parameter with the status 'Invalid';
        /// </summary>
        /// <returns>
        /// <c>true</c> if no parameter is found with status 'Invalid', <c>false</c> otherwise.
        /// </returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Method is not implemented yet.");
            return true;
        }

        #endregion
    }
}