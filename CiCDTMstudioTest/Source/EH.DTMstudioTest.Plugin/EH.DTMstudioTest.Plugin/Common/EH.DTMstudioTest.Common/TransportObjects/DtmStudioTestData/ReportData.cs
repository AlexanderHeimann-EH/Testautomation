// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The report data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;

    /// <summary>
    /// The report data.
    /// </summary>
    [Serializable]
    public class ReportData : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportData"/> class.
        /// </summary>
        public ReportData()
        {
            this.NameOfTester = string.Empty;
            this.ResultOfTest = string.Empty;
            this.DeviceId = string.Empty;
            this.DeviceSerialNumber = string.Empty;
            this.Company = string.Empty;
            this.FirmwareInformation = new FirmwareInformation();
            this.TotalFailedCount = 0;
            this.TotalSuccessCount = 0;

            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ReportData"/> class. 
        /// </summary>
        ~ReportData()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the date of test.
        /// </summary>
        public DateTime DateOfTest { get; set; }

        /// <summary>
        /// Gets or sets the inventory id.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the device serial number.
        /// </summary>
        public string DeviceSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the firmware information.
        /// </summary>
        public FirmwareInformation FirmwareInformation { get; set; }

        /// <summary>
        /// Gets or sets the name of tester.
        /// </summary>
        public string NameOfTester { get; set; }

        /// <summary>
        /// Gets or sets the result of test.
        /// </summary>
        public string ResultOfTest { get; set; }

        /// <summary>
        /// Gets or sets the error count.
        /// </summary>
        public int TotalFailedCount { get; set; }

        /// <summary>
        /// Gets or sets the total success count.
        /// </summary>
        public int TotalSuccessCount { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}