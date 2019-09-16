//------------------------------------------------------------------------------
// <copyright file="IWaitUntilFrameClosed.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 16:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWaitUntilFrameClosed
    {
        /// <summary>
        ///     Wait until Frame is closed
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be finished</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        /// </returns>
        bool Run(int timeOutInMilliseconds);
    }
}