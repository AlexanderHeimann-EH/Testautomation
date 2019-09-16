/*
 * Created by Ranorex
 * User: testadmin
 * Date: 05.07.2011
 * Time: 8:46 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface for function Open Configuration
    /// </summary>
    public interface IOpenConfiguration
    {
        /// <summary>
        ///     Open via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaMenu();

        /// <summary>
        ///     Open via context
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaContext();
    }
}