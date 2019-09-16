/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 07.10.2015
 * Time: 18:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Reporting;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of GetCommDTMContainerPath.
    /// </summary>
    public class GetCommDTMContainerPath : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IGetCommDtmContainerPath
    {        
        private readonly GUI.CommDTMContainerRepo commDTMContainer = GUI.CommDTMContainerRepo.Instance;
        
        /// <summary>
        /// 
        /// </summary>
        public string Run()
        {
            try
            {
                RepoItemInfo info = this.commDTMContainer.CommDTMContainer.SelfInfo;
                return info.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
               Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }
    }
}
