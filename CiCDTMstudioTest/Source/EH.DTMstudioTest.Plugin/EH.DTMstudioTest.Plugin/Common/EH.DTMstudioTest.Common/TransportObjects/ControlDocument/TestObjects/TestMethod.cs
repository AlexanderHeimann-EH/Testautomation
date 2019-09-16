// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMethod.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright ? Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test method.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;
    using System.Collections.Specialized;
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The test method.
    /// </summary>
    [Serializable]
    public class TestMethod : TestObject
    {
        #region Fields

        /// <summary>
        /// The assembly method ref id.
        /// </summary>
        private string assemblyMethodRefId;

        /// <summary>
        /// The assembly name.
        /// </summary>
        private string assemblyName;

        private TestScript customAttributTestScript;

        /// <summary>
        /// The parameter.
        /// </summary>
        private TestParameterCollection parameters;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestMethod"/> class.
        /// </summary>
        public TestMethod()
        {
            this.Parameters = new TestParameterCollection();
            this.Parameters.CollectionChanged += this.OnParametersCollectionChanged;
            this.IsActive = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the ref id.
        /// </summary>
        public string AssemblyMethodRefId
        {
            get
            {
                return this.assemblyMethodRefId;
            }

            set
            {
                if (value == this.assemblyMethodRefId)
                {
                    return;
                }

                this.assemblyMethodRefId = value;
                this.RaisePropertyChanged("AssemblyMethodRefId");
            }
        }

        /// <summary>
        /// Gets or sets the assembly name.
        /// </summary>
        public string AssemblyName
        {
            get
            {
                return this.assemblyName;
            }

            set
            {
                if (value == this.assemblyName)
                {
                    return;
                }

                this.assemblyName = value;
                this.RaisePropertyChanged("AssemblyName");
            }
        }

        /// <summary>
        /// Gets or sets the attribut test script.
        /// </summary>
        public TestScript CustomAttributTestScript
        {
            get
            {
                return this.customAttributTestScript;
            }
            set
            {
                if (this.customAttributTestScript == value)
                {
                    return;
                }

                this.customAttributTestScript = value;
                this.RaisePropertyChanged("CustomAttributTestScript");
            }
        }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        public TestParameterCollection Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                if (value == this.parameters)
                {
                    return;
                }

                this.parameters = value;
                this.RaisePropertyChanged("Parameters");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestMethod"/>.
        /// </returns>
        public new TestMethod Copy()
        {
            var testObject = new TestMethod
            {
                Description = this.Description,
                IsActive = this.IsActive,
                Name = this.Name,
                DisplayName = this.DisplayName,
                ToolTip = this.ToolTip,
                assemblyName = this.AssemblyName,
                AssemblyMethodRefId = this.AssemblyMethodRefId,
                TestDefinition = this.TestDefinition
            };

            if (this.Parameters != null)
            {
                testObject.Parameters.Copy(this.Parameters);
            }

            return testObject;
        }

        /// <summary>
        /// The on parameters collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void OnParametersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newFeatureList = e.NewItems;

                        foreach (TestParameter testParameter in newFeatureList)
                        {
                            testParameter.PropertyChanged += this.OnPropertyChanged;
                        }

                        break;
                    }
            }

            this.RaisePropertyChanged("Parameters");
        }

        #endregion
    }
}