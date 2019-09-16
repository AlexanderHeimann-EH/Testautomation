/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 2/9/2015
 * Time: 10:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools.CodeModules
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of CreateSystemSummary.
    /// </summary>
    [TestModule("2ACB5810-331D-4D64-8CF8-BF5EBBCA97A1", ModuleType.UserCode, 1)]
    public class CreateSystemSummary : ITestModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSystemSummary"/> class. 
        /// Constructs a new instance.
        /// </summary>
        public CreateSystemSummary()
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
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Report.SystemSummary();
        }
    }
}
