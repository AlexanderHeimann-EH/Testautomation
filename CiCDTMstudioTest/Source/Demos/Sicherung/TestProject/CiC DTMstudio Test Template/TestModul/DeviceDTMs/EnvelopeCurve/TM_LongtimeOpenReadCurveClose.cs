/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 3:40 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.EnvelopeCurve
{
    /// <summary>
    /// Description of TM_.
    /// </summary>
    [TestModule("7C1F1F67-1770-4D9E-8654-DF33BDF3280D", ModuleType.UserCode, 1)]
    public class TM_LongtimeOpenReadCurveClose : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_LongtimeOpenReadCurveClose()
        {
            // Do not delete - a parameterless constructor is required!
        }
        string _numberOfLoops = "100";
        [TestVariable("B7AFEA6D-0EA1-487C-B6D5-C164F8B84AC0")]
        public string numberOfLoops
        {
        	get { return _numberOfLoops; }
        	set { _numberOfLoops = value; }
        }
        

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	bool isPassed = true;
			
        	for(int counter = 0; counter < Convert.ToInt32(numberOfLoops); counter++)
			{
				Report.Info("Loop:", (counter+1).ToString() + " of " + numberOfLoops);
				isPassed &= DeviceFunctionLoader.CoDIA.EnvelopeCurve.Flows.OpenModuleOnline.Run();
				isPassed &= DeviceFunctionLoader.CoDIA.EnvelopeCurve.Flows.CurveReadingSingle.RunViaIcon(true);
				isPassed &= DeviceFunctionLoader.CoDIA.EnvelopeCurve.Flows.SaveCurveAs.RunViaMenu(System.DateTime.Now.ToString("yyyyMMdHHmmss"), true, false);
				isPassed &= DeviceFunctionLoader.CoDIA.EnvelopeCurve.Flows.CloseModule.Run();
			}
			
			if(isPassed){ Report.Success("TC_LongtimeOpenReadCurveClose", "Testcase passed."); }
			else { Report.Failure("TC_LongtimeOpenReadCurveClose", "Testcase failed."); }
        }
    }
}
