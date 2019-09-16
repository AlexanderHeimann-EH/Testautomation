// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetDTMContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 6/12/2013
 * Time: 10:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.DeviceCare.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    ///     Description of IGetDTMContainer.
    /// </summary>
    public interface IGetDtmContainerPath
    {
        /// <summary>
        ///     Gets the path of the DTM Container(mdi client) from the FrameBasePath repository of the actually used frame
        /// </summary>
        /// <returns>
        ///     string: with the absolute path of the DTM Container
        ///     null: if an error occurred
        /// </returns>
        string GetMDIClientPath();
    }
}