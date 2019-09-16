// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerHint.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Enumeration of timer event types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Enumeration of timer event types.
    /// </summary>
    public enum TimerEventType
    {
        /// <summary>
        /// Timer event is representing a tick fired.
        /// </summary>
        Tick = 0, 

        /// <summary>
        /// Timer event is representing a timer elapsed.
        /// </summary>
        Elapsed = 1, 

        /// <summary>
        /// Timer event is representing a timer stopped.
        /// </summary>
        Stopped = 2, 

        /// <summary>
        /// Timer event is representing a timer started.
        /// </summary>
        Started = 3, 

        /// <summary>
        /// Timer event is representing a timer killed.
        /// </summary>
        Killed = 4
    }

    /// <summary>
    /// Timer hint class containing information about a timer including a related event
    /// of that timer.
    /// </summary>
    public class TimerHint : IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// Type of the timer event.
        /// </summary>
        private readonly TimerEventType eventType;

        /// <summary>
        /// Name of the timer.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Properties of the timer event.
        /// </summary>
        private readonly PropertyCollection properties;

        /// <summary>
        /// Remaining time until the timer elapses.
        /// </summary>
        private readonly TimeSpan remainingTime;

        /// <summary>
        /// Disposed flag.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerHint"/> class.
        /// </summary>
        /// <param name="remainingTime">The remaining time.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="name">The name.</param>
        /// <param name="properties">The properties.</param>
        public TimerHint(TimeSpan remainingTime, TimerEventType eventType, string name, PropertyCollection properties)
        {
            this.remainingTime = remainingTime;
            this.eventType = eventType;
            this.name = name;
            this.properties = properties;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerHint"/> class.
        /// Constructor
        /// </summary>
        /// <param name="remainingTime">The remaining time.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="name">The name.</param>
        public TimerHint(TimeSpan remainingTime, TimerEventType eventType, string name)
        {
            this.remainingTime = remainingTime;
            this.eventType = eventType;
            this.name = name;
            this.properties = new PropertyCollection();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TimerHint"/> class.
        /// Destructor
        /// </summary>
        ~TimerHint()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the timer event.
        /// </summary>
        public TimerEventType EventType
        {
            get
            {
                return this.eventType;
            }
        }

        /// <summary>
        /// Gets a human readable message containing information about the timer.
        /// </summary>
        public string Message
        {
            get
            {
                var message = new StringBuilder();

                message.Append(string.Format(CultureInfo.InvariantCulture, @"(name: {0}, ", this.name));
                message.Append(string.Format(CultureInfo.InvariantCulture, @"hint: {0}, ", this.eventType.ToString()));
                message.Append(string.Format(CultureInfo.InvariantCulture, @"remaining: {0}, ", this.remainingTime));
                message.Append(@"properties: [");

                var pos = 0;
                foreach (string key in this.properties.Keys)
                {
                    if (pos > 0)
                    {
                        message.Append(@", ");
                    }

                    message.Append(string.Format(CultureInfo.InvariantCulture, @"('{0}', {1})", key, this.properties[key]));
                    pos++;
                }

                message.Append(@"])");
                return message.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the timer.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the properties of the timer event.
        /// </summary>
        public PropertyCollection Properties
        {
            get
            {
                return this.properties;
            }
        }

        /// <summary>
        /// Gets the remaining time until the timer elapses.
        /// </summary>
        public TimeSpan RemainingTime
        {
            get
            {
                return this.remainingTime;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Clones the timer hint instance.
        /// </summary>
        /// <returns>New timer hint instance with all members set to the same values.</returns>
        public TimerHint Clone()
        {
            return new TimerHint(this.remainingTime, this.eventType, this.name, (PropertyCollection)this.properties.Clone());
        }

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        #endregion
    }
}
