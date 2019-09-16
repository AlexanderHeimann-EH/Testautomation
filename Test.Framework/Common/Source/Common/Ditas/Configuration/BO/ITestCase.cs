//------------------------------------------------------------------------------
// <copyright file="ITestCase.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01/12/2014
 * Time: 10:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.BO
{
    /// <summary>
    /// Description of ITestCase.
    /// </summary>
    public interface ITestCase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        string PreCondition { get; set; }

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        string PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int ID { get; set; }
    }
}
