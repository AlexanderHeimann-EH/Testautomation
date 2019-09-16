// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestObject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright ? Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The test object.
    /// </summary>
    [Serializable]
    public class TestObject : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The description.
        /// </summary>
        private string description;

        /// <summary>
        /// The display name.
        /// </summary>
        private string displayName;

        /// <summary>
        /// The guid.
        /// </summary>
        private string guid;

        /// <summary>
        /// The is active.
        /// </summary>
        private bool isActive;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The parent.
        /// </summary>
        private TestObject parent;

        private TestDefinition testDefinition;

        /// <summary>
        /// The full namespace.
        /// </summary>
        private string toolTip;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObject"/> class.
        /// </summary>
        public TestObject()
        {
            this.Guid = System.Guid.NewGuid().ToString();
            this.isActive = false;
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
                if (this.description == value)
                {
                    return;
                }

                this.description = value;
                this.ToolTip = this.description;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (this.displayName != string.Empty && this.displayName != null)
                {
                    return this.displayName;
                }

                return this.Name;
            }

            set
            {
                if (this.displayName == value)
                {
                    return;
                }

                this.displayName = value;
                this.RaisePropertyChanged("DisplayName");
            }
        }

        /// <summary>
        /// Gets or sets the guid.
        /// </summary>
        public string Guid
        {
            get
            {
                return this.guid;
            }

            set
            {
                if (this.guid == value)
                {
                    return;
                }

                this.guid = value;
                this.RaisePropertyChanged("Guid");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return this.isActive;
            }

            set
            {
                if (value == this.isActive)
                {
                    return;
                }

                this.isActive = value;
                this.RaisePropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        [XmlIgnore]
        public TestObject Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                if (this.parent == value)
                {
                    return;
                }

                this.parent = value;
                this.RaisePropertyChanged("Parent");
            }
        }

        public TestDefinition TestDefinition
        {
            get
            {
                return this.testDefinition;
            }

            set
            {
                if (this.testDefinition == value)
                {
                    return;
                }

                this.testDefinition = value;
                this.RaisePropertyChanged("TestDefinition");
            }
        }

        /// <summary>
        /// Gets or sets the full namespace.
        /// </summary>
        public string ToolTip
        {
            get
            {
                return this.toolTip;
            }

            set
            {
                if (value == this.toolTip)
                {
                    return;
                }

                this.toolTip = value;

                this.RaisePropertyChanged("ToolTip");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public TestObject Copy()
        {
            var testObject = new TestObject
            {
                Description = this.Description,
                IsActive = this.IsActive,
                Name = this.Name,
                DisplayName = this.DisplayName,
                ToolTip = this.ToolTip,
                TestDefinition = this.TestDefinition
            };

            return testObject;
        }

        /// <summary>
        /// The get property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyChangedEventHandler"/>.
        /// </returns>
        public PropertyChangedEventHandler GetPropertyChanged()
        {
            return this.PropertyChanged;
        }

        /// <summary>
        /// The has property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasPropertyChanged()
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.RaisePropertyChanged(e.PropertyName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.HasPropertyChanged())
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}