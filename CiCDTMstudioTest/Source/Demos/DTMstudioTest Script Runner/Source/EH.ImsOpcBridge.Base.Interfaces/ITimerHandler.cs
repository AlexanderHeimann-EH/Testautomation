// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimerHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of the timer manager class, which handles a set of timers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of the timer manager class, which handles a set of timers.
    /// </summary>
    public interface ITimerHandler : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Event, which is fired whenever a timer of the timer handler is started, stopped,
        /// elapses, fires a tick or is killed.
        /// </summary>
        event EventHandler<TimerEventArgs> TimerEvent;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the collection of the names of all timers the timer handler contains
        /// </summary>
        Dictionary<string, ITimer>.KeyCollection Names { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns whether the timer handler contains a timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if the timer handler contains a timer with the specified name. False if it doesn't.</returns>
        bool ContainsTimer(string name);

        /// <summary>
        /// Creates a new timer.
        /// </summary>
        /// <param name="name">Name of the timer to create.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool CreateTimer(string name, TimeSpan timeSpan, PropertyCollection properties, bool autoStart);

        /// <summary>
        /// Get property collection for elapsing timer of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>Property collection holding data, which the consumer wants to analyze when the timer elapses.</returns>
        PropertyCollection GetTimerElapseProperties(string name);

        /// <summary>
        /// Get property collection for ticks of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>Property collection holding data, which the consumer wants to analyze when the timer tick is fired.</returns>
        PropertyCollection GetTimerTickProperties(string name);

        /// <summary>
        /// Returns whether the timer with the corresponding name is running.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True, if the timer is running. False, if it is not running.</returns>
        bool IsTimerRunning(string name);

        /// <summary>
        /// Kills the timer with the corresponding name. This methods stops the thread handling the timer events.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool KillTimer(string name);

        /// <summary>
        /// Sets the values of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to set.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the timer elapses.</param>
        /// <param name="autoStart">If true, the timer starts automatically. If false, the timer starts as soon as StartTimer() is called.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool SetTimer(string name, TimeSpan timeSpan, PropertyCollection properties, bool autoStart);

        /// <summary>
        /// Sets the ticker of the timer with the corresponding name. A ticker usually fires
        /// in a periodical way before a timer elapses.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <param name="timeSpan">Timespan by which the ticker should fire.</param>
        /// <param name="properties">Properties, which hold information the consumer wants to analyze when the ticker fires.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool SetTimerTicker(string name, TimeSpan timeSpan, PropertyCollection properties);

        /// <summary>
        /// Starts the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to start.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StartTimer(string name);

        /// <summary>
        /// Set the timespan by which the timer with the corresponding name should elapse
        /// and starts the timer.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <param name="timeSpan">Timespan by which the timer should elapse.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StartTimer(string name, TimeSpan timeSpan);

        /// <summary>
        /// Stops the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer to stop.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StopTimer(string name);

        /// <summary>
        /// Stops the ticker of the timer with the corresponding name.
        /// </summary>
        /// <param name="name">Name of the timer.</param>
        /// <returns>True if operation was successful, false if operation failed.</returns>
        bool StopTimerTicker(string name);

        #endregion
    }
}
