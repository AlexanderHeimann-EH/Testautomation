// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestParameterCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test parameter list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Class TestParameterCollection.
    /// </summary>
    public class TestParameterCollection : ObservableCollection<TestParameter>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <param name="testParameterCollection">
        /// The test parameter collection.
        /// </param>
        public void Copy(TestParameterCollection testParameterCollection)
        {
            if (this.Count > 0)
            {
                this.Clear();
            }

            foreach (var item in testParameterCollection)
            {
                this.Add(item.Copy());
            }
        }

        #endregion
    }
}