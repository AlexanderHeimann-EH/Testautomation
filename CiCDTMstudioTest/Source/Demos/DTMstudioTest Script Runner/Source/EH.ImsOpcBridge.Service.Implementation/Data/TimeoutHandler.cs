// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeoutHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements a timeout handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Data
{
    using System;

    /// <summary>
    /// Implements a timeout handler.
    /// </summary>
    public struct TimeoutHandler
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutHandler"/> struct.
        /// </summary>
        /// <param name="interval">The interval in milliseconds.</param>
        public TimeoutHandler(int interval)
            : this()
        {
            this.Interval = interval;
            this.SetCurrentTime();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the last expired time.
        /// </summary>
        /// <value>The last expired time.</value>
        private int LastExpiredTime { get; set; }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        private int Interval { get; set; }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Sets the current time.
        /// </summary>
        public void SetCurrentTime()
        {
            this.LastExpiredTime = Environment.TickCount & int.MaxValue;
        }

        /// <summary>
        /// Checks whether the timeout is expired.
        /// </summary>
        /// <returns><c>true</c> if the timeout is expired, <c>false</c> otherwise</returns>
        public bool IsExpired()
        {
            return ((Environment.TickCount - this.LastExpiredTime) & int.MaxValue) >= this.Interval;
        }

        #endregion
    }
}
