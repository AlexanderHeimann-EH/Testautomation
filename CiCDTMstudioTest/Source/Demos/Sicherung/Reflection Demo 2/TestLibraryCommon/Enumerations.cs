//------------------------------------------------------------------------------
// <copyright file="Enum.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15.03.2011
 * Time: 12:59 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestLibraryCommon
{
    /// <summary>
    /// Provides differen enumerations
    /// </summary>
    public class Enumerations
    {
        public enum TestScript
        {
            /// <summary>
            /// TestSuite: contains TestCase calls
            /// </summary>
            TestStuite = 1, 

            /// <summary>
            /// TestCase: contains TestModules calls and functions calls from TestFramework
            /// </summary>
            TestCase = 2,

            /// <summary>
            /// TestModule: contains functions calls from TestFramework
            /// </summary>
            TestModule = 3
        }
    }
}