//------------------------------------------------------------------------------
// <copyright file="IModuleOpeningAndClosing.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// The ModuleOpeningAndClosing interface.
    /// </summary>
    public interface IModuleOpeningAndClosing
    {
        /// <summary>
        ///     Check if number of opened modules has decreased
        /// </summary>
        /// <param name="moduleName">Name of module to check</param>
        /// <returns>
        ///     <br>True: if module is already open</br>
        ///     <br>False: if module is not already opened</br>
        /// </returns>
        bool IsModuleAlreadyOpened(string moduleName);

        /// <summary>
        ///     Check if number of opened modules has decreased
        /// </summary>
        /// <param name="numberOfOpenedModules">Number of already opened modules</param>
        /// <returns>
        ///     <br>True: if module is open</br>
        ///     <br>False: if module is not open</br>
        /// </returns>
        bool IsModuleClosed(int numberOfOpenedModules);

        /// <summary>
        ///     Check if number of opened modules has increased
        /// </summary>
        /// <param name="numberOfOpenedModules">Number of already opened modules</param>
        /// <returns>
        ///     <br>True: if module is open</br>
        ///     <br>False: if module is not open</br>
        /// </returns>
        bool IsModuleOpened(int numberOfOpenedModules);

        /// <summary>
        /// Validation if module is closed within a specified time
        /// </summary>
        /// <param name="numberOfOpenedModules">
        /// Number of already opened modules
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time within module must be closed
        /// </param>
        /// <returns>
        /// <br>True: if module is closed</br>
        ///     <br>False: if module is not closed</br>
        /// </returns>
        bool WaitUntilModuleIsClosed(int numberOfOpenedModules, int timeOutInMilliseconds);

        /// <summary>
        /// Validation if module is opened within a specified time
        /// </summary>
        /// <param name="numberOfOpenedModules">
        /// Number of already opened modules
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time within module should be opened
        /// </param>
        /// <returns>
        /// <br>True: if module is opened in time</br>
        ///     <br>False: if module is not opened in time</br>
        /// </returns>
        bool WaitUntilModuleIsOpen(int numberOfOpenedModules, int timeOutInMilliseconds);
    }
}