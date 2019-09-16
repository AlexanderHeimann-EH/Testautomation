// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 03/03/2014
 * Time: 12:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    /// <summary>
    /// Description of Device.
    /// </summary>
    public class Device
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the communication.
        /// </summary>
        public string Communication { get; set; }

        /// <summary>
        /// Gets or sets the diseh path.
        /// </summary>
        public string DISEHPath { get; set; }

        /// <summary>
        /// Gets or sets the family.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the firmware.
        /// </summary>
        public string Firmware { get; set; }

        /// <summary>
        /// Gets or sets the iid.
        /// </summary>
        public int IID { get; set; }

        /// <summary>
        /// Gets or sets the meas tech.
        /// </summary>
        public string MeasTech { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        public string Revision { get; set; }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        #endregion
    }
}