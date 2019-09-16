//------------------------------------------------------------------------------
// <copyright file="OpenFunction.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    ///     Provides methods for opening device functions
    /// </summary>
    public class OpenFunction : MarshalByRefObject, IOpenFunction
    {
        /// <summary>
        ///     Opens specified function
        /// </summary>
        /// <param name="functionName">Device function to open</param>
        /// <returns>true: if function is opened; false: if an error occurred</returns>
        public bool Run(string functionName)
        {
            bool result = false;

            if (
                HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenFunction.ViaMenu(
                    functionName))
            {
                result = true;
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening " + functionName + " failed");
            }

            return result;
        }
    }
}