// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects 
{
    using System;

    /// <summary>
    /// The test case.
    /// </summary>
    [Serializable]
    public class TestCase : TestMethod
    {
        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestCase"/>.
        /// </returns>
        public new TestCase Copy()
        {
            var testObject = new TestCase
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
    }
}
