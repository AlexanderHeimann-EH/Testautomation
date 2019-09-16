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
namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;

    /// <summary>
    ///     Description of GetDTMContainerPath.
    /// </summary>
    public class GetDtmContainerPath
    {
        #region Fields

        /// <summary>
        /// Create an instance of the repository which will be used
        /// </summary>
        private readonly DeviceCareApplication repo = DeviceCareApplication.Instance;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the path of the DTM Container(mdi client) from the DTMContainer repository of the actually used frame
        /// </summary>
        /// <returns>
        ///     string: with the absolute path of the DTM Container
        ///     null: if an error occurred
        /// </returns>
        public string Run()
        {
            Logging.Enter(typeof(GetDtmContainerPath), MethodBase.GetCurrentMethod().Name);

            try
            {
                return this.repo.ApplicationArea.DTMContainerInfo.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return null;
            }
        }

        #endregion
    }
}