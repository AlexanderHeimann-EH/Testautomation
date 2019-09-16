// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCategory.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 07.07.2015
 * Time: 12:59 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Enumerations
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The test category.
    /// </summary>
    public enum TestCategory
    {
        /// <summary>
        /// The not defined.
        /// </summary>
        [XmlEnum(Name = "NotDefined")]
        NotDefined,

        /// <summary>
        /// The setup delivery.
        /// </summary>
        [XmlEnum(Name = "SetupDelivery")]
        SetupDelivery,

        /// <summary>
        /// The regression.
        /// </summary>
        [XmlEnum(Name = "Regression")]
        Regression,

        /// <summary>
        /// The performance.
        /// </summary>
        [XmlEnum(Name = "Performance")]
        Performance,

        /// <summary>
        /// The about box.
        /// </summary>
        [XmlEnum(Name = "DeviceTypeAcceptance")]
        DeviceTypeAcceptance
    }
}
