/*
 * Created by Ranorex
 * User: testadmin
 * Date: 31.08.2011
 * Time: 07:35 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    using Ranorex.Core;

    /// <summary>
    ///     Interface for function Run File
    /// </summary>
    public interface IRunFile
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <returns>
        ///     <br>Element: if element was found and clicked</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        Element ViaMenu();
    }
}