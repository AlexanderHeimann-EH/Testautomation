// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System;

    /// <summary>
    /// The test module.
    /// </summary>
    [Serializable]
    public class TestModule : TestMethod
    {
        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestModule"/>.
        /// </returns>
        public new TestModule Copy()
        {
            var testObject = new TestModule
            {
                Description = this.Description,
                IsActive = this.IsActive,
                Name = this.Name,
                DisplayName = this.DisplayName,
                ToolTip = this.ToolTip,
                AssemblyName = this.AssemblyName,
                AssemblyMethodRefId = this.AssemblyMethodRefId,
                TestDefinition = this.TestDefinition
            };

            if (this.Parameters != null)
            {
                testObject.Parameters.Copy(this.Parameters);
            }

            return testObject;
        }

        #endregion
    }
}
