/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:31 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface for function Run Create Network
    /// </summary>
    public interface IRunCreateNetwork
    {
        /// <summary>
        /// Run via menu
        /// </summary>
        /// <returns>
        ///   <br>String: if call worked fine</br>
        ///   <br>Empty string: if an error occurred</br>
        /// </returns>
        string ViaMenu();

        /// <summary>
        /// Run via context
        /// </summary>
        /// <returns>
        ///   <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaContext();
    }
}