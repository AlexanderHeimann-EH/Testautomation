/*
 * Created by Ranorex
 * User: testadmin
 * Date: 17.04.2012
 * Time: 11:11 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.CreateDocumentation
{
	/// <summary>
    /// Description of CreateDokumentation.
    /// </summary>
    [TestModule("12048E7F-94C3-45B2-9B17-925A35CC5538", ModuleType.UserCode, 1)]
    public class TM_CreateDokumentationAsPDF : ITestModule
    {
    	string _numberOfDocuments = "";
    	[TestVariable("E26DA354-7420-4730-90CD-5C6D33A07260")]
    	public string numberOfDocuments
    	{
    		get { return _numberOfDocuments; }
    		set { _numberOfDocuments = value; }
    	}
    	
    	string _fileName = "";
		[TestVariable("3A2CD7D4-D494-4F74-819E-39C1E6EC3ED6")]
		public string fileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CreateDokumentationAsPDF()
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
        	int loops = Convert.ToInt32(numberOfDocuments);
        	for(int counter = 0; counter < loops; counter++)
        	{
        		bool result = false;
        		string file = fileName + "_" + System.DateTime.Now.ToString().Replace(":", ".") + ".pdf";
        		
        		// 2013-01-08: added to avoid invalid characters at filename of file to be created        		
        		file = file.Replace("/", "_");
        		file = file.Replace("\\", "_");
        		
        		result = DeviceFunctionLoader.CoDIA.CreateDocumentation.Flows.SaveAsPDF.Run(file);
        		
        		//result = Testlibrary.TestModules.DeviceDTM.CreateDocumentation.TM_CreateDocumentationtAsPDF.Run(file);
        		
        		if(result)
        		{	Report.Success("TM_CreateDokumentationAsPDF", "Printout succeeded [" + file + "]");	}
        		else 
        		{	Report.Failure("TM_CreateDokumentationAsPDF", "Printout failed [" + file + "]");	}
        	}
        }
    }
}
