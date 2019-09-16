//------------------------------------------------------------------------------
// <copyright file="ReadWithoutWaiting.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    ///     Flow: Reading event list without waiting until reading is finished
    /// </summary>
    public class ReadWithoutWaiting : IReadWithoutWaiting
    {
        /// <summary>
        /// Read the event list via icon, checks if reading has started (timeout = iTimeoutLong)
        /// </summary>
        /// <returns>
        /// true: if call was successful
        /// false: if an error occurred
        /// </returns>
        public bool RunViaIcon()
        {
            try
            {
                if (new IsDTMConnected().Run())
                {
                    if (new RunRead().ViaIcon())
                    {
                        if (new EventlistOperations().IsReadStarted(DefaultValues.iTimeoutLong))
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading started");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading did not start");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read icon could not be clicked");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM not connected! ");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}