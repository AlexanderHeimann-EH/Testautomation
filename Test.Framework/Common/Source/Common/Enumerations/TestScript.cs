// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScript.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The test script.
    /// </summary>
    public enum TestScript
    {
        /// <summary>
        /// Not defined
        /// </summary>
        [XmlEnum(Name = "NotDefined")]
        NotDefined = 0,

        ///// <summary>
        ///// TestSuite: contains TestCase calls
        ///// </summary>
        //[XmlEnum(Name = "TestSuite")]
        //TestSuite = 1,

        /// <summary>
        /// TestCase: contains TestModules calls and functions calls from TestFramework
        /// </summary>
        [XmlEnum(Name = "TestCase")]
        TestCase = 2,

        /// <summary>
        /// TestModule: contains functions calls from TestFramework
        /// </summary>
        [XmlEnum(Name = "TestModule")]
        TestModule = 3
    }
}
