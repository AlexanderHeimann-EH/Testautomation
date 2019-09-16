// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetAllParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;

    using Ranorex;

    /// <summary>
    /// Class GetAllParameter.
    /// </summary>
    public class GetAllParameter : IGetAllParameter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Parameter> Run()
        {
            try
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This function is not implemented");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}