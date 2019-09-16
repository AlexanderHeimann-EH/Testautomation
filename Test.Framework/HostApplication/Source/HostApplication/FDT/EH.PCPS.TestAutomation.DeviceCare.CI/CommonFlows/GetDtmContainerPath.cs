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

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    
    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The get DTM container path.
    /// </summary>
    public class GetDtmContainerPath : IGetDtmContainerPath
    {   
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Run()
        {
            Logging.Enter(typeof(GetDtmContainerPath), MethodBase.GetCurrentMethod().Name);

            try
            {
                return new Functions.ApplicationArea.MainView.Execution.GetDtmContainerPath().Run();
            }
            catch (Exception exception)
            {
                Reporting.Error(exception.Message);
                return null;
            }
        }
    }
}
