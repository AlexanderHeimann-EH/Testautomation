/*
* Created by Ranorex
* User: testadmin
* Date: 23.03.2012
* Time: 2:04 
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers.
*/

namespace ProTof_Testlibrary
{
    using System;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [STAThread]
        public static int Main(string[] args)
        {
            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            int error;

            try
            {
                error = TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception e)
            {
                Report.Error("Unexpected exception occurred: " + e);
                error = -1;
            }

            return error;
        }
    }
}
