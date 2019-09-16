/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01/07/2014
 * Time: 10:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


using Ranorex;
using Ranorex.Core.Testing;
namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
    /// <summary>
    /// Description of SetCodeModuleFunctionsDTMRange.
    /// </summary>
    [TestModule("D07B45CC-CE8F-420C-B21E-53D4B3E14C4D", ModuleType.UserCode, 1)]
	public class SetCodeModuleFunctionsDTMRange : ITestModule
	{
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public SetCodeModuleFunctionsDTMRange()
		{
			// Do not delete - a parameterless constructor is required!
		}

	    /// <summary>
	    /// 
	    /// </summary>
	    [TestVariable("A0AF019F-3ECB-4536-B3E7-0FCCFBFE66A4")]
		public string AutomIDDataRange { get; set; } = "1";

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
			
			var CurrentTestCase= TestSuite.Current.GetTestCase("CheckDevicDTM");
			
		    var rangeSelected =DataRange.TryParse(AutomIDDataRange);
		
		
		    Report.Info ( rangeSelected.ToString());
		    if (rangeSelected != null)
		    {
		    CurrentTestCase.DataContext.SetRange(DataRange.TryParse(AutomIDDataRange));
		    }
		}
	}
}
