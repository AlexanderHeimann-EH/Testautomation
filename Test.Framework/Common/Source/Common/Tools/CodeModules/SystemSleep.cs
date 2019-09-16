/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15/11/2011
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools.CodeModules
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of SystemSleep.
    /// </summary>
    [TestModule("D6AAB7E1-BE50-42DD-8E10-8AB6BBFA3C37", ModuleType.UserCode, 1)]
    public class SystemSleep : ITestModule
    {
        /// <summary>
        /// System Sleep for 'n' milliseconds
        /// </summary>
        
        int millisecs = 10000;
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("FC509D03-CF1C-42F7-8013-74004A8D8520")]
        public int Millisecs
        {
          get { return this.millisecs; }
          set { this.millisecs = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public SystemSleep()
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
            
            System.Threading.Thread.Sleep(this.millisecs);
        }
    }
}
