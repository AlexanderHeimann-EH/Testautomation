//------------------------------------------------------------------------------
// <copyright file="ISaveAs.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18.04.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.SaveAsMessage.Execution
{
    /// <summary>
    ///     Description of ISaveAs.
    /// </summary>
    public interface ISaveAs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Yes();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool No();
    }
}