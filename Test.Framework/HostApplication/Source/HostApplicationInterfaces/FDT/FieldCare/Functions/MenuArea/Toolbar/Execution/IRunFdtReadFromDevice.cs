/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:32 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution
{
    /// <summary>
    ///     Interface for function Run FDT Read From Device
    /// </summary>
    public interface IRunFdtReadFromDevice
    {
        /// <summary>
        ///     Run via icon
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaIcon();
    }
}