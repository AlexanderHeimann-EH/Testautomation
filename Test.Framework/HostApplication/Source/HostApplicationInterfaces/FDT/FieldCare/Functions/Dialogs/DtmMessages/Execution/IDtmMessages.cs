//------------------------------------------------------------------------------
// <copyright file="IDtmMessages.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 04.07.2011
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.DtmMessages.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Provides methods for interface DTMMessages
    /// </summary>
    public interface IDtmMessages
    {
                /// <summary>
        /// Gets all dtm messages.
        /// </summary>
        /// <value>The get all user messages.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        List<string> GetAllDtmMessages { get; }

        /// <summary>
        ///     Property to get newest message at DTMMessages Area
        /// </summary>
        String strGetNewestUserMessage { get; }
    }
}