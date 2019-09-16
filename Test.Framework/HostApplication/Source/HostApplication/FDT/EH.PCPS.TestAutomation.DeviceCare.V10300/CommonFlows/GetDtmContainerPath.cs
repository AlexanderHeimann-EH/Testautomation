// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="GetDTMContainerPath.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of GetDTMContainerPath.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 07.10.2015
 * Time: 18:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.GUI;

    using Ranorex.Core.Repository;

    /// <summary>
    /// The get DTM container path.
    /// </summary>
    public class GetDtmContainerPath : IGetDtmContainerPath
    {
        /// <summary>
        /// The DTM container repository.
        /// </summary>
        private readonly DTMContainerRepo dtmContainerRepository = DTMContainerRepo.Instance;

        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Run()
        {
            try
            {
                RepoItemInfo infoMdiClient = this.dtmContainerRepository.DTMContainerNewInfo;
                return infoMdiClient.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}
