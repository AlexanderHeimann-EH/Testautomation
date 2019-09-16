// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using EH.DTMstudioTest.Infrastructure.Manager;

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
        public static void Main(string[] args)
        {
            var reflection = new LoadAssambly();
            reflection.LoadTestScriptInformationAssembly(@"P:\EH.PCSW.Testautomation.CiCDTMstudioTest\Source\Demos\Reflection Demo\TestLibrary\bin\Debug\TestLibrary.dll");

            var dataManager = new EHDataManager();
            dataManager.GetAssemblyInfo();
            dataManager.LoadAssemblies();
            dataManager.GetConfiguration();
        }
    }
}
