//------------------------------------------------------------------------------
// <copyright file="TestStatus.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 16/09/2014
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.Common
{
    /// <summary>
    /// Description of TestStatus.
    /// </summary>
    public static class TestStatus
    {
        /// <summary>
        /// The status.
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The config not copied.
            /// </summary>
            ConfigNotCopied,

            /// <summary>
            /// The running.
            /// </summary>
            Running,

            /// <summary>
            /// The finished.
            /// </summary>
            Finished,

            /// <summary>
            /// The timeout.
            /// </summary>
            Timeout
        };
    }
}
