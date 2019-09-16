/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15/10/2013
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Globalization;

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// Description of CheckCurrentTime.
    /// </summary>
    [TestModule("06C494BD-96BE-46D5-AC0C-78B774271CDB", ModuleType.UserCode, 1)]
    public class CheckCurrentTime : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckCurrentTime()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _ActualCulture = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("EEC8E3E7-164E-4F20-9A4C-D6069D319913")]
        public string ActualCulture
        {
           get { return _ActualCulture; }
           set { _ActualCulture = value; }
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
            
            var repo = GUI.DeviceCareApplication.Instance;

            string currentTime = string.Empty;
            string currentTimeOneMinute = string.Empty;
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(_ActualCulture);
            currentTime = System.DateTime.Now.ToShortTimeString();
            currentTimeOneMinute = System.DateTime.Now.AddMinutes(1.0).ToShortTimeString();
               
            if (repo.DeviceCare.StatusArea.Text_CurrentTime.TextValue.Equals(currentTime) || repo.DeviceCare.StatusArea.Text_CurrentTime.TextValue.Equals(currentTimeOneMinute) )
            {
               Report.Success("Current time in DeviceCare is according to SystemTime");
            }
            else
            {
               Report.Failure("Current time in DeviceCare is wrong...Text_CurrentTime="+repo.DeviceCare.StatusArea.Text_CurrentTime.TextValue+" & currentTime="+currentTime);
            }	
       }
	}
}
