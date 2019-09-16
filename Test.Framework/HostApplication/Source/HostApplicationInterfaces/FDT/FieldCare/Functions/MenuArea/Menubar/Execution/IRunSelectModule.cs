/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:39 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Description of IRunSelectModule.
    /// </summary>
    public interface IRunSelectModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        bool ViaMenu(string moduleName);
    }
}