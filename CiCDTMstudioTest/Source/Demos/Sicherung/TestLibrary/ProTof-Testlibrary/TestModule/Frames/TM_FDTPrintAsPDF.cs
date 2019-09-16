/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.04.2012
 * Time: 8:10 
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

namespace ProTof_Testlibrary.TestModule.Frames
{
    /// <summary>
    /// Description of TM_FDTPrintAsPDF.
    /// </summary>
    [TestModule("B0A26180-4FA6-490E-9F15-14A4FD342463", ModuleType.UserCode, 1)]
    public class TM_FDTPrintAsPDF : ITestModule
    {
    	string _reportType = "";
    	[TestVariable("DBC5E884-33FB-4CC3-930E-5203F5E2F515")]
    	public string reportType
    	{
    		get { return _reportType; }
    		set { _reportType = value; }
    	}
    	
    	
    	string _reportName = "";
    	[TestVariable("FC523F53-194C-4FFE-968E-3DE134D01E57")]
    	public string reportName
    	{
    		get { return _reportName; }
    		set { _reportName = value; }
    	}
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_FDTPrintAsPDF()
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
        	Testlibrary.TestModules.Frame.TM_FDTPrintAsPDF.Run(reportType, reportName, true);
        }
    }
}
