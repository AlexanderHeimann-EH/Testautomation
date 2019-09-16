// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertiesPageReport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The DT project properties page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// The DT project properties page.
    /// </summary>
    [ComVisible(true)]
    [Guid(GuidList.guidPropertiesPageReportString)]
    public class PropertiesPageReport : SettingsPage
    {
        #region Fields

        /// <summary>
        /// The device serial number.
        /// </summary>
        private string reportOutputDirectory;

        /// <summary>
        /// The enum value.
        /// </summary>
        private string enumValue;


        private DateTime dateOfTest;

        private string defaultFileName;

        private List<string> listOfStrings;

        private bool useBoolean;

        private HashSet<string> useHashSet;

        private HashSet<string> selectedHashItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesPageReport"/> class. 
        /// </summary>
        public PropertiesPageReport()
        {
            this.Name = "Report Properties";
            this.enumValue = Days.Fri.ToString();
            this.dateOfTest = DateTime.Today;
            this.listOfStrings = new List<string>();
            this.listOfStrings.Add("first");
            this.listOfStrings.Add("second");
            this.useBoolean = true;
            this.useHashSet = new HashSet<string>();
            this.defaultFileName = "Neue Datei";
        }

        #endregion

        /// <summary>
        /// The days.
        /// </summary>
        public enum Days { Sat, Sun, Mon, Tue, Wed, Thu, Fri }  


        #region Public Properties

        /// <summary>
        /// Gets or sets the communication device.
        /// </summary>
        [DisplayName(@"Output Directory")]
        [Description("Report")]
        [Category("Report")]
        public string ReportOutputDirectory
        {
            get
            {
                return this.reportOutputDirectory;
            }

            set
            {
                this.reportOutputDirectory = value;
                this.IsDirty = true;
            }
        }


        /// <summary>
        /// Gets or sets the enumeration days.
        /// </summary>
        [DisplayName(@"Days")]
        [Description("Days")]
        [Category("Report")]
        public Days EnumerationDays
        {
            get
            {
                Days onlyUseItHere;
                if (Enum.TryParse(this.enumValue, true, out onlyUseItHere))
                {
                    return onlyUseItHere;
                }

                return Days.Sat;
            }

            set
            {
                this.enumValue = value.ToString();
                this.IsDirty = true;
            }
        }


        /// <summary>
        /// Gets or sets the test output assembly.
        /// </summary>
        [DisplayName(@"Date of test")]
        [Description("Date of test")]
        [Category("Report")]
        public DateTime DateOfTest
        {
            get
            {
                return this.dateOfTest;
            }

            set
            {
                this.dateOfTest = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the default file name.
        /// </summary>
        [DisplayName(@"TypeConverter")]
        [Description("Date of test")]
        [TypeConverter(typeof(MyTypeConverter))]
        [Category("Report")]
        public string DefaultFileName
        {
            get { return this.defaultFileName; }
            set { this.defaultFileName = value; }
        }


        /// <summary>
        /// Gets or sets the test output assembly.
        /// </summary>
        [DisplayName(@"List<string>")]
        [Description("List<string>")]
        [Category("Report")]
        public List<string> ListOfStrings
        {
            get
            {
                return this.listOfStrings;
            }

            set
            {
                this.listOfStrings = value;
                this.IsDirty = true;
            }
        }


        /// <summary>
        /// Gets or sets the test output assembly.
        /// </summary>
        [DisplayName(@"UseABoolean")]
        [Description("UseABoolean")]
        [Category("Report")]
        public bool UseABoolean
        {
            get
            {
                return this.useBoolean;
            }

            set
            {
                this.useBoolean = value;
                this.IsDirty = true;
            }
        }

        public struct MyStruct
        {
            public List<string> values;

            public MyStruct(List<string> input)
            {
                values = input;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The apply changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected override int ApplyChanges()
        {
            var result = VSConstants.S_OK;

            var projectMgr = this.ProjectMgr as DTTestProjectNode;
            try
            {
                if (projectMgr != null)
                {
                    var isDirty = false;

                    if (projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ReportOutputPath != this.reportOutputDirectory)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ReportOutputPath = this.reportOutputDirectory;
                        isDirty = true;
                    }

                    if (isDirty)
                    {
                        projectMgr.SaveConfiguration();
                    }

                    this.IsDirty = false;
                }
                else
                {
                    result = VSConstants.S_FALSE;
                }
            }
            catch (Exception)
            {
                result = VSConstants.S_FALSE;
            }

            return result;
        }

        /// <summary>
        /// The bind properties.
        /// </summary>
        protected override void BindProperties()
        {
            var projectMgr = this.ProjectMgr as DTTestProjectNode;
            if (projectMgr != null)
            {
                this.reportOutputDirectory = projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ReportOutputPath;
            }
        }

        #endregion
    }
}