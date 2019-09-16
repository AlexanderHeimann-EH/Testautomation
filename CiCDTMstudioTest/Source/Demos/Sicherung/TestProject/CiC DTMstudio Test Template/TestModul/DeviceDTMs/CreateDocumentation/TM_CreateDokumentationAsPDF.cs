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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.CreateDocumentation
{
	/// <summary>
    /// Description of CreateDokumentation.
    /// </summary>
    public class TM_CreateDokumentationAsPDF 
    {
    	public static string NumberOfDocuments = "";
    	
    	
    	public static string FileName = "";
		
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
        	int loops = Convert.ToInt32(NumberOfDocuments);
        	for(int counter = 0; counter < loops; counter++)
        	{
        		bool result = false;
        		string file = FileName + "_" + System.DateTime.Now.ToString().Replace(":", ".") + ".pdf";
        		
        		// 2013-01-08: added to avoid invalid characters at filename of file to be created        		
        		file = file.Replace("/", "_");
        		file = file.Replace("\\", "_");
        		
        		result = DeviceFunctionLoader.CoDIA.CreateDocumentation.Flows.SaveAsPDF.Run(file);
        		
        		//result = Testlibrary.TestModules.DeviceDTM.CreateDocumentation.TM_CreateDocumentationtAsPDF.Run(file);
        		
        		if(result)
        		{	
                    //Report.Success("TM_CreateDokumentationAsPDF", "Printout succeeded [" + file + "]");	// AHHIER
                    return true;
                } 
        		else 
        		{	
                    //Report.Failure("TM_CreateDokumentationAsPDF", "Printout failed [" + file + "]");	// AHHIER
                    return false;
                }
        	}

            return false;
        }
    }
}
