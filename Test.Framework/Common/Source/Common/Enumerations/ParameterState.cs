// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterState.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The parameter state.
    /// </summary>
    public enum ParameterState
    {
        /// <summary>
        ///     Parameter is insecure
        /// </summary>
        Insecure = 1, 

        /// <summary>
        ///     Parameter is invalid
        /// </summary>
        Invalid,

        /// <summary>
        ///     Parameter is valid
        /// </summary>
        Valid, 

        /// <summary>
        ///     Parameter modification is valid
        /// </summary>
        Modified, 

        /// <summary>
        ///     Parameter is dynamic
        /// </summary>
        Dynamic1,

        /// <summary>
        ///     Parameter is dynamic
        /// </summary>
        Dynamic2,

        /// <summary>
        ///     Parameter is out of range
        /// </summary>
        ModifiedOutOfRange, 

        /// <summary>
        ///     Parameter has invalid format
        /// </summary>
        ModifiedInvalidFormat,

        /// <summary>
        ///     Parameter value is wrong
        /// </summary>
        ModifiedWrong,

        /// <summary>
        ///     Parameter not written
        /// </summary>
        WriteFailed,

        /// <summary>
        ///     Parameter state is not recognized
        /// </summary>
        NotRecognized
    }
}