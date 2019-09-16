//------------------------------------------------------------------------------
// <copyright file="IWaitUntilFrameConnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 17:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWaitUntilFrameConnected
    {
        /// <SUMMARY>
        ///     WAIT UNTIL GUI CONNECTION IS ESTABLISHED AND SHOWN BY GUI
        /// </SUMMARY>
        /// <PARAM NAME="timeOutInMilliseconds">TIME UNTIL ACTION MUST BE FINISHED</PARAM>
        /// <RETURNS>TRUE IF CONNECTION IS ESTABLISHED, FALSE IF NOT</RETURNS>
        bool Run(int timeOutInMilliseconds);
    }
}