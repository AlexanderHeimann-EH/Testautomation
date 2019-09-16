// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSuite.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TestSuite.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;

    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// Class TestSuite.
    /// </summary>
    [Serializable]
    public class TestSuite : TestCollection
    {
        #region Fields

        /// <summary>
        /// The test category.
        /// </summary>
        private TestCategory testCategory;

        /// <summary>
        /// The test focus.
        /// </summary>
        private TestFocus testFocus;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuite"/> class.
        /// </summary>
        public TestSuite()
            : base()
        {
            this.TestFocus = TestFocus.NotDefined;
            this.TestCategory = TestCategory.NotDefined;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the test category.
        /// </summary>
        public TestCategory TestCategory
        {
            get
            {
                return this.testCategory;
            }

            set
            {
                if (this.testCategory == value)
                {
                    return;
                }

                this.testCategory = value;
                this.RaisePropertyChanged("TestCategory");
            }
        }

        /// <summary>
        /// Gets or sets the test focus.
        /// </summary>
        public TestFocus TestFocus
        {
            get
            {
                return this.testFocus;
            }

            set
            {
                if (this.testFocus == value)
                {
                    return;
                }

                this.testFocus = value;
                this.RaisePropertyChanged("TestFocus");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestSuite"/>.
        /// </returns>
        public new TestSuite Copy()
        {
            var testObject = new TestSuite { Description = this.Description, IsActive = this.IsActive, Name = this.Name, DisplayName = this.DisplayName, ToolTip = this.ToolTip, TestDefinition = this.TestDefinition };

            return testObject;
        }

        /// <summary>
        /// The deep copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public TestObject DeepCopy()
        {
            var testSuite = new TestSuite { Description = this.Description, IsActive = this.IsActive, Name = this.Name, DisplayName = this.DisplayName, ToolTip = this.ToolTip, TestDefinition = this.TestDefinition };

            if (this.TestObjects != null)
            {
                testSuite.TestObjects.Copy(this.TestObjects);
            }

            return testSuite;
        }

        #endregion
    }
}