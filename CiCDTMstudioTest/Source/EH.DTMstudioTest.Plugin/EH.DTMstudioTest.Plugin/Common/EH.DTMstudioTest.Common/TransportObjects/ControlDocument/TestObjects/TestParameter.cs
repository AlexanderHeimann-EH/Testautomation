// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.Common.Utilities.Validator;

    /// <summary>
    /// The test parameter.
    /// </summary>
    [Serializable]
    public class TestParameter : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The description.
        /// </summary>
        private string description;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The parameter type.
        /// </summary>
        private string parameterType;

        /// <summary>
        /// The parameter value.
        /// </summary>
        private string parameterValue;

        /// <summary>
        /// The parameter value valid.
        /// </summary>
        private bool parameterValueValid;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestParameter"/> class.
        /// </summary>
        public TestParameter()
        {
            this.ParameterValueValid = false;
            this.parameterType = string.Empty;
            this.name = string.Empty;
            this.description = string.Empty;
            this.parameterType = string.Empty;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

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
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (IsType.IsGenericType(Type.GetType(this.parameterType)))
                {
                    return "List[System.String]"  + " " + this.name;
                }

                return this.parameterType + " " + this.name;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the parameter type.
        /// </summary>
        public string ParameterType
        {
            get
            {
                return this.parameterType;
            }

            set
            {
                this.parameterType = value;
                this.RaisePropertyChanged("ParameterType");
            }
        }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        public string ParameterValue
        {
            get
            {
                return this.parameterValue;
            }

            set
            {
                this.ParameterValueValid = false;

                if (!string.IsNullOrEmpty(value) && !IsType.Is(value, this.ParameterType))
                {
                    throw new ArgumentException("Der Parameter Type stimmt nicht mit der Eingabe überein!");
                }

                if (!string.IsNullOrEmpty(value))
                {
                    this.ParameterValueValid = true;
                }

                this.parameterValue = value;
                this.RaisePropertyChanged("ParameterValue");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether parameter value valid.
        /// </summary>
        public bool ParameterValueValid
        {
            get
            {
                return this.parameterValueValid;
            }

            set
            {
                this.parameterValueValid = value;
                this.RaisePropertyChanged("ParameterValueValid");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestParameter"/>.
        /// </returns>
        public TestParameter Copy()
        {
            return new TestParameter { description = this.Description, parameterType = this.ParameterType, name = this.Name, parameterValue = this.parameterValue, parameterValueValid = this.parameterValueValid };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}