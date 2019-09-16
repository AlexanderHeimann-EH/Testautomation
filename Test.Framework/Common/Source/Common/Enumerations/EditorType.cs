// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorType.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Different editor types
    /// </summary>
    public enum EditorType
    {
        /// <summary>
        ///     Editor type is combo box
        /// </summary>
        ComboBox = 1,

        /// <summary>
        ///     Editor type is edit field
        /// </summary>
        EditField,

        /// <summary>
        ///     Editor type is check box
        /// </summary>
        CheckBox,

        /// <summary>
        ///     Editor type is unknown
        /// </summary>
        Unknown,

        /// <summary>
        ///     Editor type is read only edit field
        /// </summary>
        EditFieldReadOnly
    }
}
