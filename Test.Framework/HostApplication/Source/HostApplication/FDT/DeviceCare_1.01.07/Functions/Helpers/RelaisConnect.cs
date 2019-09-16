/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18/06/2014
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Ranorex;
using Ranorex.Core.Testing;
//using CommonCodeModules;
//using CommonMethods;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    /// <summary>
    /// Description of ConnectRelays.
    /// </summary>

    [TestModule("98E08E74-ADD8-4963-AB29-B1E4D3D06EE7", ModuleType.UserCode, 1)]
	public class RelaisConnect : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public RelaisConnect()
		{
			// Do not delete - a parameterless constructor is required!
		}

        /// <summary>
        /// 
        /// </summary>
		string _relais = "";

        /// <summary>
        /// 
        /// </summary>
		[TestVariable("1FA4BBDC-5CA7-46DF-A4A1-9F4117B0912A")]
		public string relais
		{
			get { return _relais; }
			set { _relais = value; }
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
			
			bool result = false;
			Common.Relay.RelayAccessMethodsDeditec.SetAll(0,0, out result);
			string[] relaisArray = relais.Split('-');
			uint[] intRelaisArray = Array.ConvertAll<string, uint>(relaisArray, uint.Parse);
			Common.Relay.RelayAccessMethodsDeditec.SetMultiple(0, 1, intRelaisArray, out result);

		}
	}
}
