//------------------------------------------------------------------------------
// <copyright file="MAPDiscardEditing.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.MenuArea.Menubar;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;

    /// <summary>
    /// Description of MAPDiscardEditing.
    /// </summary>
    public class MAPDiscardEditing : IMAPDiscardEditing
    {
        /// <summary>
        ///     Discard MAP editing
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run()
        {
            try
            {
                if (Validation.IsEditMapActive.IsActive())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Map is in edit mode");
                    if ((new RunDiscardMAPEditing()).ViaMenu())
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP editing is discarded");
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not Executiond.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is not in Edit MAP mode.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}