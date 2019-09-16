//------------------------------------------------------------------------------
// <copyright file="OpenAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.11.2012
 * Time: 1:11 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Validation;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides function to open module available at [Additional Functions]
    /// </summary>
    public class OpenAdditionalModule : MarshalByRefObject, IOpenAdditionalModule
    {
        // /// <summary>
        // ///     Open module from [Additional Functions Submenu] via menu
        // /// </summary>
        // /// <param name="moduleToOpen">Name of module to open</param>
        // /// <returns>
        // ///     <br>True: If call worked fine</br>
        // ///     <br>False: If an error occurred</br>
        // /// </returns>
        // public string ViaMenu(string moduleToOpen)
        // {
        //    try
        //    {
        //        // Get related menu entry
        //        Element element = (new OpenAdditionalFunctions()).ViaMenu();
        //        // If menu entry is valid and enabled
        //        if (element != null && element.Enabled)
        //        {
        //            bool isFound = false;
        //            IList<Button> moduleList = null;
        //            // Get all available buttons from menu submenu additional functions
        //            moduleList = (new GetAdditionalFunctionModules().Run());
        //            // If there are any modules available
        //            if (moduleList != null && moduleList.Count > 0)
        //            {
        //                // Search for module to open
        //                foreach (Button button in moduleList)
        //                {
        //                    // If module is found
        //                    if (button.Text.Contains(moduleToOpen))
        //                    {
        //                        isFound = true;
        //                        // Activate related menu entry
        //                        button.Click(DefaultValues.locDefaultLocation);
        //                    }
        //                }

        // if (isFound)
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                                "Module [" + moduleToOpen + "] found and activated.");
        //                    return moduleToOpen;
        //                }
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                               "Module [" + moduleToOpen + "] is not found and not activated.");
        //                return "";
        //            }
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No additional modules available.");
        //            return "";
        //        }
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
        //        return "";
        //    }
        //    catch (Exception exception)
        //    {
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        //        return "";
        //    }
        // }

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
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToOpen + "] found and activated.");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToOpen + "] is not found and not activated.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No additional modules available.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
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