//------------------------------------------------------------------------------
// <copyright file="OpenUpdateDTMCatalogue.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 28.01.2011
 * Time: 3:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class Open Update DTM Catalogue.
    /// </summary>
    internal class OpenUpdateDtmCatalogue : MarshalByRefObject, IOpenUpdateDtmCatalogue
    {
        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool ViaMenu()
        {
            try
            {
                Element element = (new RunDtmCatalogue()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    Button menuEntry = (new Elements()).EntryUpdate;
                    if (menuEntry != null && menuEntry.Enabled)
                    {
                        menuEntry.Click(DefaultValues.locDefaultLocation);
                        Form updateCatalogue = (new UpdateDtmCatalogueElements()).UpdateCatalogue;
                        if (updateCatalogue != null)
                        {
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UpdateCatalogue not started");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not accessible.");
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