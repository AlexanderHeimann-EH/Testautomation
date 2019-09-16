// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestFolder.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TestFolder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;

    /// <summary>
    /// Class TestFolder.
    /// </summary>
    [Serializable]
    public class TestFolder : TestCollection
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFolder"/> class.
        /// </summary>
        public TestFolder() 
            : base()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestCase"/>.
        /// </returns>
        public new TestFolder Copy()
        {
            var testFolder = new TestFolder { Description = this.Description, IsActive = this.IsActive, Name = this.Name, DisplayName = this.DisplayName, ToolTip = this.ToolTip, TestDefinition = this.TestDefinition };

            return testFolder;
        }

        /// <summary>
        /// The deep copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public TestObject DeepCopy()
        {
            var testFolder = new TestFolder { Description = this.Description, IsActive = this.IsActive, Name = this.Name, DisplayName = this.DisplayName, ToolTip = this.ToolTip, TestDefinition = this.TestDefinition };

            if (this.TestObjects != null)
            {
                testFolder.TestObjects.Copy(this.TestObjects);
            }

            return testFolder;
        }

        #endregion
    }
}