// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PAMTool.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11/6/2013
 * Time: 8:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    /// <summary>
    /// Description of PAMTool.
    /// </summary>
    public class PAMTool
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        #endregion
    }
}