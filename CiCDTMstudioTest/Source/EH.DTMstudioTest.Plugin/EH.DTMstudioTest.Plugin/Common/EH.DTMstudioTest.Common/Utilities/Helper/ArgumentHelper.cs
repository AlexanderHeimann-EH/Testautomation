// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The argument helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Helper
{
    using System;

    /// <summary>
    /// The argument helper.
    /// </summary>
    public class ArgumentHelper
    {
        /// <summary>
        /// Check if argument "Silent" is used
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsSilent(string[] args)
        {
            foreach (var s in args)
            {
                string buffer = s.ToLower();
                if (buffer.Equals("-s") || buffer.Equals(@"/s"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The is help needed.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsHelpNeeded(string[] args)
        {
            foreach (var s in args)
            {
                string buffer = s.ToLower();
                if (buffer.Equals("-h") || buffer.Equals(@"/h"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The get control document from argument.
        /// </summary>
        /// <param name="argumentss">
        /// The arguments.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetControlDocumentFromArgument(string[] arguments)
        {
            string controlDocument = string.Empty;

            foreach (var argument in arguments)
            {
                string buffer = argument.ToLower();
                if (buffer.Contains(".xml"))
                {
                    controlDocument = argument;
                    
                    // System.Windows.Forms.MessageBox.Show("XML: " + controlDocument);
                }
            }

            return controlDocument;
        }

        /// <summary>
        /// The show help.
        /// </summary>
        public static void ShowHelp()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("/s or -s: \t Starts test project exe in silent mode. A valid \n\t\t configuration.xml is must be available to run the \n\t\t test project.");
            Console.WriteLine("[Path][ControlDocumentName].xml: \t Uses the defined control document \n\t\t for automatic tests.");
        }
    }
}
