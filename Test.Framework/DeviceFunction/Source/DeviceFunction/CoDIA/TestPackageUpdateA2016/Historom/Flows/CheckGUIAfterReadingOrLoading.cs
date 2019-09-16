//------------------------------------------------------------------------------
// <copyright file="CheckGUIAfterReadingOrLoading.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Provides methods to check GUI after reading
    /// </summary>
    public class CheckGUIAfterReadingOrLoading : ICheckGUIAfterReadingOrLoading
    {
        /// <summary>
        ///     Method to check whether event list contains values after reading
        /// </summary>
        /// <returns>
        ///     true: if they contain values
        ///     false: if they are empty or an error occurred
        /// </returns>
        public bool Run()
        {
            if (new RunSelectTab().Run(0))
            {
                // tab table opened
                if (new EventlistOperations().IsEventlistEmpty())
                {
                    // eventlist is empty
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist is empty");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist contain values");
                return true;
            }

            // tab table could not be opened
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab table");
            return false;
        }
    }
}