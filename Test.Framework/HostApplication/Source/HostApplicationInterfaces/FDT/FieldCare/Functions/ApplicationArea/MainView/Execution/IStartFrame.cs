/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:34 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    ///     Description of IStartFrame.
    /// </summary>
    public interface IStartFrame
    {
        /// <summary>
        /// The field care.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool FieldCare();

        /// <summary>
        /// The field care.
        /// </summary>
        /// <param name="strApplicationPath">
        /// The str application path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool FieldCare(string strApplicationPath);

        /// <summary>
        /// The field care.
        /// </summary>
        /// <param name="strApplicationPath">
        /// The str application path.
        /// </param>
        /// <param name="timeOutInSeconds">
        /// The time out in seconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool FieldCare(string strApplicationPath, int timeOutInSeconds);
    }
}