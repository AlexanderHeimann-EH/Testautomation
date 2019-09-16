// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterType.cs" company="Endress+Hauser Process Solutions AG">
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
    /// <summary>
    /// The parameter type.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        ///     Parameter type is text
        /// </summary>
        Text = 1,

        /// <summary>
        ///     Parameter type is enumeration
        /// </summary>
        Enumeration,

        /// <summary>
        ///     Parameter type is bit enumeration
        /// </summary>
        BitEnumeration,

        /// <summary>
        ///     Parameter type is unknown
        /// </summary>
        Unknown
    }
}
