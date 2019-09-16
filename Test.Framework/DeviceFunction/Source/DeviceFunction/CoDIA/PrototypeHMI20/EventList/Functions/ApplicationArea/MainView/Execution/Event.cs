// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.EventList.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EventList.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Represents an event from  the event list containing strings for event number, description , operation hours etc.
    /// </summary>
    public class Event : IEvent
    {
        #region Fields

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

        #region Constructors and Destructors

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
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string EventName
        {
            get
            {
                return this.eventName;
            }

            set
            {
                this.eventName = value;
            }
        }

        /// <summary>
        /// Gets or sets the event number.
        /// </summary>
        public string EventNumber
        {
            get
            {
                return this.eventNumber;
            }

            set
            {
                this.eventNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the operation hours.
        /// </summary>
        public string OperationHours
        {
            get
            {
                return this.operationHours;
            }

            set
            {
                this.operationHours = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds all properties to one String
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            string result = this.eventNumber + " ||" + " " + this.date + " ||" + " " + this.operationHours + " ||" + " " + this.eventName + " ||" + " " + this.description;
            return result;
        }

        #endregion
    }
}