//------------------------------------------------------------------------------
// <copyright file="OpenFunction.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//-------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Validation;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Opens a device function via menu
    /// </summary>
    public class OpenFunction : IOpenFunction
    {
        /// <summary>
        /// Starts execution
        /// </summary>
        /// <param name="functionToOpen">
        /// Function which will be opened
        /// </param>
        /// <returns>
        /// true if the function is opened
        /// false if an error occurred
        /// </returns>
        public bool ViaMenu(string functionToOpen)
        {
            bool result = false;

            // Select submenu Device Functions
            Element element = (new RunDeviceFunction()).ViaMenu();
            if (element == null || !element.Enabled)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "The submenu device functions is not accessible or not enabled. Check the Ranorex path in the repository");
            }
            else
            {
                // Get all available buttons from menu submenu device functions
                IList<Button> moduleList = (new GetAdditionalFunctionModules()).Run();

                // If there aren't any modules available
                if (moduleList == null || moduleList.Count <= 0)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "No modules available. Check which modules should be available or check the Ranorex path in the repository");
                }
                else
                {
                    // Search for function to open
                    foreach (Button button in moduleList)
                    {
                        // If function is found
                        if (button.Text.Contains(functionToOpen))
                        {
                            result = true;

                            // Activate related menu entry
                            button.Click();
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
