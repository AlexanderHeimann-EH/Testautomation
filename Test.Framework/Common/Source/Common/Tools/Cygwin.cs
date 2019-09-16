// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cygwin.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2011
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Janosch Spillmann
 * Date: 01/02/2012
 * Version: 1.0
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System.Diagnostics;

    using Ranorex;

    /// <summary>
    /// This Cygwin Class is to group all Cygwin function methods in one class.
    /// </summary>
    public static class Cygwin
    {
        /// <summary>
        /// Starts the cygwin.
        /// </summary>
        /// <param name="cygwinPath">The cygwin path.</param>
        public static void StartCygwin(string cygwinPath)
        {
            Process.Start(cygwinPath);
        }

        /// <summary>
        /// Enters the command in cygwin.
        /// </summary>
        /// <param name="command">The command.</param>
        public static void EnterCommandInCygwin(string command)
        {
            // Next two lines were not needed, cause the cygwin console is anyway in front.
            // Form cygwinConsole = "/form[@title='~']";
            // cygwinConsole.Activate();
            char[] characterArray = command.ToCharArray();
            foreach (char c in characterArray)
            {
                Keyboard.Press(c);
            } 

            Keyboard.Press(System.Windows.Forms.Keys.Enter);
        }
    }
}
