// ***********************************************************************
// <copyright file="FisScheduler.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Organizes a scheduler for the data send to the FIS Server.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Fis
{
    using System;

    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Organizes a scheduler for the data send to the FIS Server.
    /// </summary>
    internal class FisScheduler
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FisScheduler"/> class.
        /// </summary>
        public FisScheduler()
        {
            this.TimeScheduleExpired = new TimeScheduleExpiredHandler[]
                                           {
                                               this.TimeSchedule1MinExpired,
                                               this.TimeSchedule2MinExpired,
                                               this.TimeSchedule5MinExpired,
                                               this.TimeSchedule10MinExpired,
                                               this.TimeSchedule15MinExpired,
                                               this.TimeSchedule30MinExpired,
                                               this.TimeSchedule1HExpired,
                                               this.TimeSchedule2HExpired,
                                               this.TimeSchedule3HExpired,
                                               this.TimeSchedule4HExpired,
                                               this.TimeSchedule6HExpired,
                                               this.TimeSchedule8HExpired,
                                               this.TimeSchedule12HExpired,
                                               this.TimeSchedule24HExpired
                                           };

            this.LastTime = DateTime.Now;
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate TimeScheduleExpiredHandler
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private delegate bool TimeScheduleExpiredHandler(DateTime now);

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the time schedule expired.
        /// </summary>
        /// <value>The time schedule expired.</value>
        private TimeScheduleExpiredHandler[] TimeScheduleExpired { get; set; }

        /// <summary>
        /// Gets or sets the last time.
        /// </summary>
        /// <value>The last time.</value>
        private DateTime LastTime { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether data to FIS should be sent now. This method compares the last time with now and checks whether
        /// in this transition we have hit the exact time when data should be sent to the FIS server.
        /// </summary>
        /// <param name="time">The planned time.</param>
        /// <returns><c>true</c> if data to FIS should be sent now, <c>false</c> otherwise.</returns>
        public bool TimeToSendData(FisTimeSchedules time)
        {
            // Compares last time to now according to the FIS time schedule.
            var now = DateTime.Now;
            var index = (int)time;
            var result = false;

            if (0 <= index && index < this.TimeScheduleExpired.Length)
            {
                result = this.TimeScheduleExpired[index](now);
            }
            else
            {
                // This would be an internal fatal error!!!
                Logger.FatalFormat(this, "Time to send data to FIS internal fatal error, the received FisTimeSchedules as index is out of range, value: ", index);
            }

            this.LastTime = now;
            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule1MinExpired(DateTime now)
        {
            // We must have crossed the minute boundary.
            return this.LastTime.Minute != now.Minute;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule2MinExpired(DateTime now)
        {
            // We must have crossed the 2-minute boundary.
            return this.LastTime.Minute != now.Minute && now.Minute % 2 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule5MinExpired(DateTime now)
        {
            // We must have crossed the 5-minute boundary.
            return this.LastTime.Minute != now.Minute && now.Minute % 5 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule10MinExpired(DateTime now)
        {
            // We must have crossed the 10-minute boundary.
            return this.LastTime.Minute != now.Minute && now.Minute % 10 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule15MinExpired(DateTime now)
        {
            // We must have crossed the 15-minute boundary.
            return this.LastTime.Minute != now.Minute && now.Minute % 15 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule30MinExpired(DateTime now)
        {
            // We must have crossed the 30-minute boundary.
            return this.LastTime.Minute != now.Minute && now.Minute % 30 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule1HExpired(DateTime now)
        {
            // We must have crossed the 1-hour boundary.
            return this.LastTime.Hour != now.Hour;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule2HExpired(DateTime now)
        {
            // We must have crossed the 2-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 2 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule3HExpired(DateTime now)
        {
            // We must have crossed the 3-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 3 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule4HExpired(DateTime now)
        {
            // We must have crossed the 4-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 4 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule6HExpired(DateTime now)
        {
            // We must have crossed the 6-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 6 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule8HExpired(DateTime now)
        {
            // We must have crossed the 8-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 8 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule12HExpired(DateTime now)
        {
            // We must have crossed the 12-hour boundary.
            return this.LastTime.Hour != now.Hour && now.Hour % 12 == 0;
        }

        /// <summary>
        /// Checks whether a time schedule has expired.
        /// </summary>
        /// <param name="now">The current time.</param>
        /// <returns><c>true</c> if the time schedule has expired, <c>false</c> otherwise.</returns>
        private bool TimeSchedule24HExpired(DateTime now)
        {
            // We must have crossed the 1-day boundary.
            return this.LastTime.Day != now.Day;
        }

        #endregion
    }
}
