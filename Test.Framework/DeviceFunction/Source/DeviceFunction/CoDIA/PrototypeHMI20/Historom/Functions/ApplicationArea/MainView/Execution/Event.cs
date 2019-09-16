//------------------------------------------------------------------------------
// <copyright file="Event.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Represents an event from  the event list containing strings for event number, description , operation hours etc.
    /// </summary>
    public class Event : IEvent
    {
        #region members

        /// <summary>
        /// The channel 1.
        /// </summary>
        private string channel1;

        /// <summary>
        /// The channel 2.
        /// </summary>
        private string channel2;

        /// <summary>
        /// The channel 3.
        /// </summary>
        private string channel3;

        /// <summary>
        /// The channel 4.
        /// </summary>
        private string channel4;

        /// <summary>
        /// The date.
        /// </summary>
        private string date;

        /// <summary>
        /// The description.
        /// </summary>
        private string description;

        /// <summary>
        /// The _event name.
        /// </summary>
        private string eventName;

        /// <summary>
        /// The event number.
        /// </summary>
        private string eventNumber;

        /// <summary>
        /// The operation hours.
        /// </summary>
        private string operationHours;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event()
        {
            this.eventNumber = string.Empty;
            this.date = string.Empty;
            this.operationHours = string.Empty;
            this.eventName = string.Empty;
            this.description = string.Empty;
            this.channel1 = string.Empty;
            this.channel2 = string.Empty;
            this.channel3 = string.Empty;
            this.channel4 = string.Empty;
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets or sets the event number.
        /// </summary>
        public string EventNumber
        {
            get { return this.eventNumber; }
            set { this.eventNumber = value; }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// Gets or sets the operation hours.
        /// </summary>
        public string OperationHours
        {
            get { return this.operationHours; }
            set { this.operationHours = value; }
        }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string EventName
        {
            get { return this.eventName; }
            set { this.eventName = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the channel 1.
        /// </summary>
        public string Channel1
        {
            get { return this.channel1; }
            set { this.channel1 = value; }
        }

        /// <summary>
        /// Gets or sets the channel 2.
        /// </summary>
        public string Channel2
        {
            get { return this.channel2; }
            set { this.channel2 = value; }
        }

        /// <summary>
        /// Gets or sets the channel 3.
        /// </summary>
        public string Channel3
        {
            get { return this.channel3; }
            set { this.channel3 = value; }
        }

        /// <summary>
        /// Gets or sets the channel 4.
        /// </summary>
        public string Channel4
        {
            get { return this.channel4; }
            set { this.channel4 = value; }
        }

        /// <summary>
        /// Adds all properties to one String
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            string result = this.eventNumber + " ||" + " " + this.date + " ||" + " " + this.operationHours + " ||" + " " + this.eventName +
                            " ||" + " " + this.description + " ||" + " " + this.channel1 + " ||" + " " + this.channel2 + " ||" + " " +
                            this.channel3 + " ||" + " " + this.channel4;
            return result;
        }

        #endregion
    }
}