// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="DialogFunctions.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DialogFunctions.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Ranorex;

    /// <summary>
	/// Description of DialogFunctions.
	/// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
    public class DialogFunctions
	{
        /// <summary>
        /// The timer.
        /// </summary>
        private Stopwatch timer;

        /// <summary>
        /// The time out.
        /// </summary>
        private TimeSpan timeOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogFunctions"/> class.
        /// </summary>
        public DialogFunctions()
        {
            this.timer = new Stopwatch();
            this.timeOut = TimeSpan.FromMinutes(5);
        }

        #region DeviceReport
		
		/// <summary>
		/// Clicks the print button in device report dialog
		/// </summary>
		public void ClickPrintButton()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
            // in device report dialog
			repo.Dialog.PrintPreview.ButtonPrint.Click();
		}
		
		/// <summary>
		/// Selects the FieldCare printer in the MS print dialog
		/// and closes the dialog with save
		/// </summary>
		/// <returns>True if FC printer is selected</returns>
		public bool SelectFieldCarePrinter()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
            // select list entry 'E+H FieldCare'
			repo.Dialog.Print.EPlusHFieldCare.Click();
			
			if (repo.Dialog.Print.EPlusHFieldCare.Selected)
			{
				repo.Dialog.Print.ButtonPrint.Click();
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
			if (repo.Dialog.PrintToFile.FileNameText.Visible)
			{
				repo.Dialog.PrintToFile.FileNameText.TextValue = name;
				
				if (repo.Dialog.PrintToFile.FileNameText.TextValue == name)
				{
					repo.Dialog.PrintToFile.ButtonOK.Click();
					
					if (overwrite)
					{
						repo.Dialog.OverwriteExistingFdtPrintFile.ButtonOK.Click();
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
			
			this.timer.Reset();
			this.timer.Start();
			while (repo.Dialog.PrintPreview.Form.Visible == false)
			{
				Delay.Milliseconds(200);
				if (this.timer.Elapsed == this.timeOut)
				{
					Report.Failure("The process timed out (> 5min)");
					return false;
				}
			}

            // wait until device report is shown
			return true;
		}
		
		/// <summary>
		/// Waits and validates the MS Print Form
		/// </summary>
		/// <returns>True if dialog is shown</returns>
		public bool IsPrintFormOpen()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			this.timer.Reset();
			this.timer.Start();
			
            // windows print form
			while (repo.Dialog.Print.Form.Visible == false)
			{
				Delay.Milliseconds(200);
				if (this.timer.Elapsed == this.timeOut)
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
			this.timer.Reset();
			this.timer.Start();

		    while (repo.Dialog.PrintToFile.Form.Visible == false)
		    {
		        Delay.Milliseconds(200);
				if (this.timer.Elapsed == this.timeOut)
				{
					Report.Failure("The process timed out (> 5min)");
					return false;
				}
			}

            // FC save dialog
			return true;
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
           
           repo.Dialog.RestoreDeviceData.AddressTextbox.TextValue = path;
        }
        
        /// <summary>
        /// Acknowledges the browse dialog with yes
        /// </summary>
        public void AckDialog()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           repo.Dialog.RestoreDeviceData.ButtonGo.Click();
           repo.Dialog.RestoreDeviceData.ButtonOK.Click();
        }
        
        /// <summary>
        /// Acknowledges the "are you sure..." popup with yes
        /// </summary>
        public void AckPopup()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           repo.Dialog.ConfirmRestoreDeviceData.ButtonYes.Click();
        }
        
        /// <summary>
        /// Checks if the browse dialog is visible
        /// </summary>
        /// <returns>True if dialog is visible</returns>
        public bool IsBrowseDialogOpen()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            if (repo.Dialog.RestoreDeviceData.Form.Visible & repo.Dialog.RestoreDeviceData.Form.Enabled)
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
            if (repo.Dialog.RestoreDeviceData.AddressTextbox.TextValue.Trim() == path.Trim())
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
            if (repo.Dialog.ConfirmRestoreDeviceData.Form.Visible)
            {
                if (repo.Dialog.ConfirmRestoreDeviceData.TitleBar.TextValue == "Restore device data")
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
