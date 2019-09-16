/*
 * Created by Ranorex
 * User: testadmin
 * Date: 03/12/2013
 * Time: 15:26
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
using System.IO;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
	/// <summary>
	/// Description of ConfigureConnectionWizardFile.
	/// </summary>
	[TestModule("A392A001-BD12-4FBF-86BD-2B28DD442E7C", ModuleType.UserCode, 1)]
	public class ConfigureConnectionWizardFile : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public ConfigureConnectionWizardFile()
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
			
			string path = @"C:\ProgramData\Endress+Hauser\PamSuitePaDADeviceConfiguration\Shared\ConnectionWizardConfig.xml";
			
			string automID = "automIdHart";
			
			/*
			    		<Item name="simulation DTM HART" stringId="" automationId="automIdSimulationHART" imageSource="" selectedImageSource="">
							<Actions>
									</Parameters>
								</Action>
							</Actions>
						</Item>
			 * */
			
			string newItem = "<Item name=\"simulation DTM HART\" stringId=\"\" automationId=\"automIdSimulationHART\" imageSource=\"\" selectedImageSource=\"\">\r\n<Actions>\r\n<Action name=\"AddToProject\">\r\n<Parameters>\r\n<Parameter name=\"DtmDeviceType\" value=\"HART Simulation CommDTM\"/>\r\n</Parameters></Action></Actions></Item>";
			
			int countedLines = 0;
			using (StreamReader countReader = new StreamReader(path))
			{
				while (!countReader.ReadLine().Contains(automID))
				{
					countedLines++;
				}
			}
			
			AppendLine(path, countedLines+4, newItem, false);
			
			System.IO.File.Copy(path, path+".keep");
		}
		
		//Code von tsql.de
		/// <summary>
		/// Schreibt den übergebenen Text in eine definierte Zeile.
		///</summary>
		///<param name="sFilename">Pfad zur Datei</param>
		///<param name="iLine">Zeilennummer</param>
		///<param name="sLines">Text für die übergebene Zeile</param>
		///<param name="bReplace">Text in dieser Zeile überschreiben (t) oder einfügen (f)</param>
		public void AppendLine(String sFilename, int iLine, string sLines, bool bReplace)
		{
			string sContent = "";
			string[] delimiterstring = { "\r\n" };
			
			if (File.Exists(sFilename))
			{
				StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
				sContent = myFile.ReadToEnd();
				myFile.Close();
			}
			
			string[] sCols = sContent.Split(delimiterstring, StringSplitOptions.None);
			
			if (sCols.Length >= iLine)
			{
				if (!bReplace)
					sCols[iLine - 1] = sLines + "\r\n" + sCols[iLine - 1];
				else
					sCols[iLine - 1] = sLines;
				
				sContent = "";
				for (int x = 0; x < sCols.Length-1; x++)
				{
					sContent += sCols[x] + "\r\n";
				}
				sContent += sCols[sCols.Length-1];
				
			}
			else
			{
				for (int x = 0; x < iLine - sCols.Length; x++)
					sContent += "\r\n";
				
				sContent += sLines;
			}
			
			
			StreamWriter mySaveFile = new StreamWriter(sFilename);
			mySaveFile.Write(sContent);
			mySaveFile.Close();
		}
	}
}
