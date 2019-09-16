﻿//------------------------------------------------------------------------------
// <copyright file="CheckGUIAfterOpeningOrDeleting.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Provides methods to check GUI after opening module or deleting HISTOROM data
    /// </summary>
    public class CheckGUIAfterOpeningOrDeleting : ICheckGUIAfterOpeningOrDeleting
    {
        /// <summary>
        ///     Method to check whether event list + statistic results are empty
        /// </summary>
        /// <returns>
        ///     true: if they are empty
        ///     false: if they are not empty or an error occurred
        /// </returns>
        public bool Run()
        {
            if (new RunSelectTab().Run(0))
            {
                // tab table opened
                if (new EventlistOperations().IsEventlistEmpty())
                {
                    // eventlist is empty, check statistic results now
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist is empty");

                    if (new RunSelectTab().Run(2))
                    {
                        // tab statistic selected succesfully
                        if (new StatisticResults().HasStatisticTabValues())
                        {
                            // statistic tab contains values
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                "Eventlist and statistic results contain values");
                            return false;
                        }

                        // statistic tab is empty 
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Eventlist and Statistic results are empty");
                        return true;
                    }

                    // failed to open tab statistic
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab statistic");
                    return false;
                }

                // eventlist is not empty
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist contains values ");
                return false;
            }

            // tab table could not be opened
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab table");
            return false;
        }
    }
}