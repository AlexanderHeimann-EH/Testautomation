// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="ConfigureConnectionOption.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Set connection type to assistant or automatic
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Set connection type to assistant or automatic
    /// </summary>
    [TestModule("88AD209B-90F4-42E2-9A89-17CAA8AF501B", ModuleType.UserCode, 1)]
    public class ConfigureConnectionOption : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigureConnectionOption()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _ConnectionType = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("75601F6B-4C32-4637-A533-7B1496F5ABEE")]
        public string ConnectionType
        {
           get { return _ConnectionType; }
           set { _ConnectionType = value; }
        }
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            IList<TestCaseNode>testCases = TestSuite.Current.SelectedRunConfig.GetActiveTestCases();
                
            foreach (TestCaseNode testcase in testCases)
            {
                if (ConnectionType == "Automatic")
                {
               	    if (testcase.Name == "AssistantConnection" )
               	    {
               	        testcase.Checked = false;
                    }
                    if (testcase.Name == "AutomaticConnection" )
                    {
                        testcase.Checked = true;
                    }
                }

              	if (ConnectionType == "Assistant")
                {
                    if (testcase.Name == "AssistantConnection" )
                    {
                        testcase.Checked = true;
                    }
                    if (testcase.Name == "AutomaticConnection" )
                    {
                        testcase.Checked = false;
                    }
                }
            }
        }
    }
}
