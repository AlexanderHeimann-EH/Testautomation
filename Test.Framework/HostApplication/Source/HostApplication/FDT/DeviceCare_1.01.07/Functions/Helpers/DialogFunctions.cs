/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.09.2015
 * Time: 10:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

using Ranorex;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    /// <summary>
    /// Description of DialogFunctions.
    /// </summary>
    public class DialogFunctions
	{

        /// <summary>
        /// 
        /// </summary>
        public DialogFunctions()
		{
			timer = new Stopwatch();
			timeOut = TimeSpan.FromMinutes(5);
		}
		
		Stopwatch timer;
       TimeSpan timeOut;
		
		#region DeviceReport
		
		/// <summary>
		/// Clicks the print button in device report dialog
		/// </summary>
		public void ClickPrintButton()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			//in device report dialog
			repo.DCDialog.PrintReport.ButtonPrint.Click();
		}
		
		/// <summary>
		/// Selects the FieldCare printer in the MS print dialog
		/// and closes the dialog with save
		/// </summary>
		/// <returns>True if FC printer is selected</returns>
		public bool SelectFieldCarePrinter()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			//select list entry 'E+H FieldCare'
			repo.Print.EPlusHFieldCare.Click();
			
			if (repo.Print.EPlusHFieldCare.Selected)
			{
				repo.Print.ButtonPrint.Click();
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// Saves a device report with a specific name
		/// </summary>
		/// <param name="name">The name(containing the path) where the file should be saved</param>
		/// <param name="overwrite">True if an existing file should be overwritten. False if existing files should cancel execution</param>
		/// <returns>True if file is believed to be saved</returns>
		public bool SaveReportWithName(string name, bool overwrite)
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			Delay.Milliseconds(1000);
			if (repo.PrintToFile.FileNameText.Visible)
			{
				repo.PrintToFile.FileNameText.TextValue = name;
				
				if (repo.PrintToFile.FileNameText.TextValue == name)
				{
					repo.PrintToFile.ButtonOK.Click();
					
					if (overwrite)
					{
						repo.FDTPrint_FileExistDialog.ButtonOK.Click();
					}
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Waits (timeout 5min) until Device Report is shown
		/// </summary>
		/// <returns>True if the dialog is shown</returns>
		public bool WaitForDeviceReportDialog()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			timer.Reset();
			timer.Start();
			while (repo.DCDialog.Self.Visible == false)
			{
				Delay.Milliseconds(200);
				if (timer.Elapsed == timeOut)
				{
					Report.Failure("The process timed out (> 5min)");
					return false;
				}
			}
			return true;
			//wait until device report is shown
		}
		
		/// <summary>
		/// Waits and validates the MS Print Form
		/// </summary>
		/// <returns>True if dialog is shown</returns>
		public bool IsPrintFormOpen()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			timer.Reset();
			timer.Start();
			//windows print form
			while (repo.Print.Self.Visible == false)
			{
				Delay.Milliseconds(200);
				if (timer.Elapsed == timeOut)
				{
					Report.Failure("The process timed out (> 5min)");
					return false;
				}
			}
			return true;
		}
		
		/// <summary>
		/// Waits (timeout 5min) until FC save dialog is open
		/// </summary>
		/// <returns>True if dialog is shown</returns>
		public bool IsSaveDialogOpen()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			timer.Reset();
			timer.Start();
			
			while(repo.PrintToFile.Self.Visible == false)
			{
				Delay.Milliseconds(200);
				if (timer.Elapsed == timeOut)
				{
					Report.Failure("The process timed out (> 5min)");
					return false;
				}
			}
			return true;
			//FC save dialog
		}
			
		#endregion
			
		#region FDT Restore
		
		/// <summary>
        /// Sets the address textbox to the desired value
        /// </summary>
        /// <param name="path">The path which should be written</param>
        public void SetFilePath(string path)
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           repo.DCDialog.RestoreBrowse.AddressTextbox.TextValue = path;
        }
        
        /// <summary>
        /// Acknowledges the browse dialog with yes
        /// </summary>
        public void AckDialog()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           repo.DCDialog.RestoreBrowse.ButtonGo.Click();
           repo.DCDialog.RestoreBrowse.ButtonOK.Click();
        }
        
        /// <summary>
        /// Acknowledges the "are you sure..." popup with yes
        /// </summary>
        public void AckPopup()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           repo.DeviceCare_MessageBox.ButtonYes.Click();
        }
        
        /// <summary>
        /// Checks if the browse dialog is visible
        /// </summary>
        /// <returns>True if dialog is visible</returns>
        public bool IsBrowseDialogOpen()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           if (repo.DCDialog.Self.Visible & repo.DCDialog.Self.Enabled)
           {
           	Report.Debug("Browse dialog is visible");
           	Report.Info("Browsing for file to restore data...");
           	return true;
           }
           return false;
        }
        
        /// <summary>
        /// Checks if the address text box is correctly set
        /// </summary>
        /// <param name="path">The string to validate for</param>
        /// <returns>True if textbox has correct value</returns>
        public bool IsFilePathSet(string path)
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           if (repo.DCDialog.RestoreBrowse.AddressTextbox.TextValue.Trim() == path.Trim())
           {
           	Report.Debug("Path is set correctly");
           	Report.Success("File found. Starting restore now...");
           	return true;
           }
           return false;
        }
        
        /// <summary>
        /// Checks if the "are you sure" popup is visible
        /// by checking if the header text is "restore device data"
        /// </summary>
        /// <returns>True if popup is visible</returns>
        public bool IsPopupOpen()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           if (repo.DeviceCare_MessageBox.Self.Visible)
           {
           	if (repo.DeviceCare_MessageBox.TitleBar.Text == "Restore device data")
           	{
           		Report.Debug("Popup dialog is visible");
           		return true;
           	}
           }
           return false;
           
        }
		
		
		
		#endregion
	}
}
