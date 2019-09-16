// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDTMContainerPath.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 10:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of GetDTMContainerPath.
    /// </summary>
    public class GetDtmContainerPath : IGetDtmContainerPath
    {
        #region Fields

        /// <summary>
        /// Create an instance of the repository which will be used
        /// </summary>
        private readonly DtmContainer dtmContainerRepository = DtmContainer.Instance;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the path of the DTM Container(mdi client) from the DTMContainer repository of the actually used frame
        /// </summary>
        /// <returns>
        ///     string: with the absolute path of the DTM Container
        ///     null: if an error occurred
        /// </returns>
        public string GetMDIClientPath()
        {
            try
            {
                RepoItemInfo infoMdiClient = this.dtmContainerRepository.DTMContainerInfo;
                return infoMdiClient.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}