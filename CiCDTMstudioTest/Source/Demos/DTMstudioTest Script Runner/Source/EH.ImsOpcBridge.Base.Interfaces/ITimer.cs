// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of the class which represents and manages a specific timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Data;

    /// <summary>
    /// Interface of the class which represents and manages a specific timer.
    /// </summary>
    public interface ITimer : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// Gets the property collection for elapsing timer.
        /// </summary>
        /// <value>The elapse properties.</value>
        PropertyCollection ElapseProperties { get; }

        /// <summary>
        /// Gets the time when timer will elapse.
        /// </summary>
        /// <value>The end time.</value>
        DateTime EndTime { get; }

        /// <summary>
        /// Gets a value indicating whether the timer is running.
        /// </summary>
        /// <value><c>true</c> if this instance is timer running; otherwise, <c>false</c>.</value>
        bool IsTimerRunning { get; }

        /// <summary>
        /// Gets the time when timer has been started.
        /// </summary>
        /// <value>The start time.</value>
        DateTime StartTime { get; }

        /// <summary>
        /// Gets the property collection for timer ticks.
        /// </summary>
        PropertyCollection TickProperties { get; }

        /// <summary>
        /// Gets the timespan by which the timer tick fires. Set this to 0 to switch off timer ticks.
        /// </summary>
        /// <value>The tick time span.</value>
        TimeSpan TickTimeSpan { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Kills the timer. This methods stops the thread handling the timer events.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool KillTimer();

        /// <summary>
        /// Sets the timer.
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool SetTimer(TimeSpan timeSpanToSet, PropertyCollection properties, bool autoStart);

        /// <summary>
        /// Sets the ticker of a timer. A ticker usually fires in a periodical way before a timer elapses.
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the ticker should fire.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the ticker fires.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool SetTicker(TimeSpan timeSpanToSet, PropertyCollection properties);

        /// <summary>
        /// Starts the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StartTimer();

        /// <summary>
        /// Set the timespan by which the timer should elapse and starts the timer
        /// </summary>
        /// <param name="timeSpanToSet">Timespan by which the timer should elapse.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StartTimer(TimeSpan timeSpanToSet);

        /// <summary>
        /// Stops the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StopTimer();

        /// <summary>
        /// Stops the ticker of the timer.
        /// </summary>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StopTicker();

        #endregion
    }
}
