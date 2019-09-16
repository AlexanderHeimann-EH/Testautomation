/*
 * Created by Ranorex
 * User: Anja Döbele
 * Date: 06/08/2014
 * Time: 08:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools.CodeModules
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Reads the version information of a file.
    /// </summary>
    [TestModule("7E917D44-E501-466B-8F92-77E0203F4647", ModuleType.UserCode, 1)]
    public class GetVersionInfo : ITestModule
    {
        
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GetVersionInfo()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string PathToFile = "";
        
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("7F648DD2-24AA-4551-BAC2-24EAEF386F78")]
        public string pathToFile
        {
            get { return this.PathToFile; }
            set { this.PathToFile = value; }
        }
        
        string File = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("2460CFF0-6E57-406A-A19B-D1927E44088B")]
        public string file
        {
            get { return this.File; }
            set { this.File = value; }
        }
        
        /// <summary>
        /// Optional variable to save the value within a Test Suite variable!
        /// If you set it to an empty string or leave it unbound, the value will not be saved in any variable!
        /// </summary>
        string TestSuiteVariableToSaveValue = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("72E58082-9E46-4854-80D5-4E9F90B8ED88")]
        public string testSuiteVariableToSaveValue
        {
            get { return this.TestSuiteVariableToSaveValue; }
            set { this.TestSuiteVariableToSaveValue = value; }
        }
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(this.PathToFile+this.File);
            
            string version = fvi.ProductVersion.ToString();
            if (this.testSuiteVariableToSaveValue != "")
            {
                TestSuite.Current.Parameters[this.testSuiteVariableToSaveValue] = version;
                Report.Info("Variable: " + this.testSuiteVariableToSaveValue + " set to the value: " + TestSuite.Current.Parameters[this.testSuiteVariableToSaveValue]);
            }
            
            Report.Info("The version number of the file " + this.PathToFile + this.File + " is: " + version);
        }
    }
}
