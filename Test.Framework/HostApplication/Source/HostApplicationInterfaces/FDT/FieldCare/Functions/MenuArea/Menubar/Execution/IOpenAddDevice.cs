/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 10:57 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface of function Open Add Device
    /// </summary>
    public interface IOpenAddDevice
    {
        /// <summary>
        ///     Open dialog via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaMenu();

        /// <summary>
        ///     Open dialog via context
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaContext();
    }
}