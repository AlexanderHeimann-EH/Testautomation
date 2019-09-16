//------------------------------------------------------------------------------
// <copyright file="IGetMessageLog.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for GetMessageLog
    /// </summary>
    public interface IGetMessageLog
    {
	/// <summary>
	/// Get latest messages
	/// </summary>
	/// <returns>List with messages</returns>
        List<string> Run();
    }
}
