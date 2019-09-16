/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.03.2012
 * Time: 2:45 
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

namespace ProTof_Testlibrary
{
    /// <summary>
    /// Description of TM_ProjectLoadViaTextField.
    /// </summary>
    [TestModule("E9055294-2631-4C51-947E-A9A08777CA56", ModuleType.UserCode, 1)]
    public class TM_ProjectLoadViaTextField : ITestModule
    {
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ProjectLoadViaTextField()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        string _projectName = "";
    	[TestVariable("BED45BEF-4E20-4C1B-A19A-E6887BAF303A")]
    	public string projectName
    	{
    		get { return _projectName; }
    		set { _projectName = value; }
    	}
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
           	Testlibrary.TestModules.Frame.TM_ProjectLoadViaTextField.Run(projectName);
        }
    }
}
