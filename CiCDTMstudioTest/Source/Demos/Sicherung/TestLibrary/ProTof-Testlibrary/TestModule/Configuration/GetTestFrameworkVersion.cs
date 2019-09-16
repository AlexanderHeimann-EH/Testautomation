/*
 * Created by Ranorex
 * User: testadmin
 * Date: 03.08.2012
 * Time: 1:24 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ProTof_Testlibrary.TestModule.Configuration
{
    using System;
    using System.IO;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of GetTestFrameworkVersion.
    /// </summary>
    [TestModule("8EDD1723-C153-4238-B9AC-A23DD2715335", ModuleType.UserCode, 1)]
    public class GetTestFrameworkVersion : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GetTestFrameworkVersion()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            string pathToDLL = "../../../DLL/";
            string[] fileList = Directory.GetFiles(pathToDLL);
            foreach(string filePath in fileList)
            {
            	System.Reflection.Assembly assembly = null;
            	assembly = System.Reflection.Assembly.LoadFrom(filePath);
            	
            	string[] separator = {", "};
            	string[] nameParts = assembly.GetName().ToString().Split(separator, StringSplitOptions.None);
            	
            	foreach(string part in nameParts)
            	{
            		Report.Info(part);
            	}
            	Report.Info("Last modiefied:" + "\t" + System.IO.File.GetLastWriteTime(filePath).ToString());
            	Report.Info("------------------------------");
            }
        }
    }
}
