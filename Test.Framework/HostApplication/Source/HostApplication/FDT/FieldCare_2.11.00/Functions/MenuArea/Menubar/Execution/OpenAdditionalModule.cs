// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.11.2016
 * Time: 1:11 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Validation;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///  Provides function to open module available at [Additional Functions]
    /// </summary>
    public class OpenAdditionalModule : MarshalByRefObject, IOpenAdditionalModule
    {   
        /// <summary>
        ///     Open module from [Additional Functions Submenu] via menu
        /// </summary>
        /// <param name="moduleToOpen">Name of module to open</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaMenu(string moduleToOpen)
        {
            try
            {
                // Get related menu entry
                Element element = (new OpenAdditionalFunctions()).ViaMenu();

                // If menu entry is valid and enabled
                if (element != null && element.Enabled)
                {
                    bool isFound = false;
                    IList<Button> moduleList;

                    // Get all available buttons from menu submenu additional functions
                    moduleList = new GetAdditionalFunctionModules().Run();
                    
                    // If there are any modules available
                    if (moduleList != null && moduleList.Count > 0)
                    {
                        // Search for module to open
                        foreach (Button button in moduleList)
                        {
                            // If module is found
                            if (button.Text.Contains(moduleToOpen))
                            {
                                isFound = true;

                                // Activate related menu entry
                                button.Click(DefaultValues.locDefaultLocation);
                            }
                        }

                        if (isFound)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToOpen + "] found and activated.");
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToOpen + "] is not found and not activated.");
                        return false;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No additional modules available.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
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