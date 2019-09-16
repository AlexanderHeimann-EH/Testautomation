// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Delegate for event handler to stop a timer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Delegate for event handler to stop a timer
    /// </summary>
    /// <returns>Returns whether stopping the timer succeeded</returns>
    public delegate bool EventHandlerStopTimer();

    /// <summary>
    /// Argument class for Timer events
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Hint containing information about the timer and its actual event.
        /// </summary>
        private readonly TimerHint hint;

        /// <summary>
        /// Delegate for event handler to stop the timer, which sent the event.
        /// </summary>
        private readonly EventHandlerStopTimer stopTimerDelegate;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="hint">The hint.</param>
        /// <param name="stopTimerDelegate">The stop timer delegate.</param>
        public TimerEventArgs(TimerHint hint, EventHandlerStopTimer stopTimerDelegate)
        {
            this.hint = hint;
            this.stopTimerDelegate = stopTimerDelegate;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the hint containing information about the timer and its actual event.
        /// </summary>
        public TimerHint Hint
        {
            get
            {
                return this.hint;
            }
        }

        /// <summary>
        /// Gets the human readable message containing information about the timer event.
        /// </summary>
        public string Message
        {
            get
            {
                var message = new StringBuilder();

                message.Append(@"(");
                message.Append(this.hint.Message);
                message.Append(string.Format(CultureInfo.InvariantCulture, @", stopTimerDelegate: {0}", this.stopTimerDelegate));
                message.Append(@")");
                return message.ToString();
            }
        }

        /// <summary>
        /// Gets the delegate for event handler to stop the timer, which sent the event.
        /// </summary>
        public EventHandlerStopTimer StopTimerDelegate
        {
            get
            {
                return this.stopTimerDelegate;
            }
        }

        #endregion
    }
}
