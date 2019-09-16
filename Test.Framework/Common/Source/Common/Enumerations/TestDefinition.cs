// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDefinition.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The test definition.
    /// </summary>
    public enum TestDefinition
    {
        /// <summary>
        /// The predefined.
        /// </summary>
        [XmlEnum(Name = "Predefined")]
        Predefined = 0,

        /// <summary>
        /// The user defined.
        /// </summary>
        [XmlEnum(Name = "UserDefined")]
        UserDefined = 1
    }
}
