// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="DTMFunctions.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DTMFunctions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 14.08.2015
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers
{
    using System.IO;

    /// <summary>
    /// The DTM functions.
    /// </summary>
    public class DTMFunctions
    {
        /// <summary>
        /// Moves a file from a source location to a destination location
        /// </summary>
        /// <param name="sourceFileName">Location of the source file</param>
        /// <param name="destFileName">Location of the destination file</param>
        public void MoveFile(string sourceFileName, string destFileName)
        {
            // TODO: Handle all possible exceptions 
            File.Move(sourceFileName, destFileName);
        }
    }
}
