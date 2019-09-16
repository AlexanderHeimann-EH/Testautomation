// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_CompareOnlineVsOffline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 27.09.2012
 * Time: 10:06 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.DeviceFunction.CoDIA.Compare
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare;

    /// <summary>
    /// Class TM_CompareOnlineVsOffline.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TM_CompareOnlineVsOffline
// ReSharper restore InconsistentNaming
    {
        #region Public Methods and Operators

        /// <summary>
        /// Execute test module
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Run()
        {
            bool isPassed = true;
            isPassed &= Flows.SelectMode.Run("Compare offline with online");
            isPassed &= Flows.Compare.Run(DefaultValues.DTMUploadTimeout);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare finished successfully.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare finished with errors.");
            }

            return isPassed;
        }

        #endregion
    }
}