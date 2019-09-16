// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestFocus.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The test focus.
    /// </summary>
    public enum TestFocus
    {
        /// <summary>
        /// The not defined.
        /// </summary>
        [XmlEnum(Name = "NotDefined")]
        NotDefined,

        /// <summary>
        /// The parameterization online.
        /// </summary>
        [XmlEnum(Name = "ParameterizationOnline")]
        ParameterizationOnline,

        /// <summary>
        /// The parameterization offline.
        /// </summary>
        [XmlEnum(Name = "ParameterizationOffline")]
        ParameterizationOffline,

        /// <summary>
        /// The envelope curve.
        /// </summary>
        [XmlEnum(Name = "EnvelopeCurve")]
        EnvelopeCurve,

        /// <summary>
        /// The linearization online.
        /// </summary>
        [XmlEnum(Name = "LinearizationOnline")]
        LinearizationOnline,

        /// <summary>
        /// The linearization offline.
        /// </summary>
        [XmlEnum(Name = "LinearizationOffline")]
        LinearizationOffline,

        /// <summary>
        /// The save restore.
        /// </summary>
        [XmlEnum(Name = "SaveRestore")]
        SaveRestore,

        /// <summary>
        /// The create documentation.
        /// </summary>
        [XmlEnum(Name = "CreateDocumentation")]
        CreateDocumentation,

        /// <summary>
        /// The compare.
        /// </summary>
        [XmlEnum(Name = "Compare")]
        Compare,

        /// <summary>
        /// The concentration.
        /// </summary>
        [XmlEnum(Name = "Concentration")]
        Concentration,

        /// <summary>
        /// The extended histo rom.
        /// </summary>
        [XmlEnum(Name = "ExtendedHistoRom")]
        ExtendedHistoRom,

        /// <summary>
        /// The event list.
        /// </summary>
        [XmlEnum(Name = "EventList")]
        EventList,

        /// <summary>
        /// The viscosity.
        /// </summary>
        [XmlEnum(Name = "Viscosity")]
        Viscosity,

        /// <summary>
        /// The about box.
        /// </summary>
        [XmlEnum(Name = "AboutBox")]
        AboutBox
    }
}
