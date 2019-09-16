// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionState.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The connection state.
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        ///     Connection state is connected
        /// </summary>
        Connected = 1,

        /// <summary>
        ///     Connection state is disconnected
        /// </summary>
        Disconnected,

        /// <summary>
        ///     Connection state is unknown
        /// </summary>
        Unknown,

        /// <summary>
        ///     Connection state is error
        /// </summary>
        Error,

        /// <summary>
        ///     Connection state connecting
        /// </summary>
        Connecting,

        /// <summary>
        ///     Connection state disconnecting
        /// </summary>
        Disconnecting,

        /// <summary>
        ///     Connection state disturbed
        /// </summary>
        Disturbed
    }
}
