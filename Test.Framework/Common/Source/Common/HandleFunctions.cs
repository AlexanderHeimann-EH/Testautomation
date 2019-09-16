// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandleFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.07.2011
 * Time: 8:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Description of Common.
    /// </summary>
    public static class HandleFunctions
    {
        /// <summary>
        /// Gets the handle of an element
        /// </summary>
        /// <param name="element">Element to get handle from</param>
        /// <returns>Returns the handle of an valid object or an Zero-handle in case of errors.</returns>
        public static IntPtr GetHandle(Element element)
        {
            try
            {
                return (new NativeWindow(element)).Handle;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Get a Zero-handle.
        /// </summary>
        /// <returns>Returns an Zero-handle.</returns>
        public static IntPtr GetZeroHandle()
        {
            return IntPtr.Zero;
        }
    }
}