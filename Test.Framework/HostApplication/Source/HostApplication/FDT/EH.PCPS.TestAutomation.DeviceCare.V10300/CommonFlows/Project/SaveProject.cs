// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SaveProject.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Description of SaveProject.
    /// </summary>
    public class SaveProject : ISaveProject
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");
            
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string projectName)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");
            
            return false;
        }
    }
}
