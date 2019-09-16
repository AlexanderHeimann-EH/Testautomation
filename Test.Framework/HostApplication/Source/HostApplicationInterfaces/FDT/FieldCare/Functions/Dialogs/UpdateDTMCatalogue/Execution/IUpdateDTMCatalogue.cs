/*
 * Created by Ranorex
 * User: testadmin
 * Date: 08.03.2012
 * Time: 12:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution
{
    /// <summary>
    ///     Description of IUpdateDTMCatalogue.
    /// </summary>
    public interface IUpdateDTMCatalogue
    {
        /// <summary>
        ///     Cancel Update Catalog
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Confirm Update dialig
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Confirm();

        /// <summary>
        ///     Confirm Help dialig
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Help();

        /// <summary>
        ///     Press Move Button
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Move();

        /// <summary>
        ///     Start update
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Update();

        /// <summary>
        ///     Select new on left side
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool SelectNewOnLeft(bool shouldFindNewDevice, int maxMinutesSinceDtmWasInstalled);
    }
}