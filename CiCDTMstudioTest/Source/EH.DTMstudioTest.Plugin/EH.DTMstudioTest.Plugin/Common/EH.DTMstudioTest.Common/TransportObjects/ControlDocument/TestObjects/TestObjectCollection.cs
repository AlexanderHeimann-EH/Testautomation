// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestObjectCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test folder collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The test folder collection.
    /// </summary>
    public class TestObjectCollection : ObservableCollection<TestObject>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public static TestObject CopyTestObject(TestObject testObject)
        {
            if (testObject != null)
            {
                if (testObject.GetType() == typeof(TestFolder))
                {
                    var testObjectCopy = testObject as TestFolder;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestCase))
                {
                    var testObjectCopy = testObject as TestCase;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestMethod))
                {
                    var testObjectCopy = testObject as TestMethod;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestModule))
                {
                    var testObjectCopy = testObject as TestModule;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestObject))
                {
                    return testObject.Copy();
                }

                if (testObject.GetType() == typeof(TestSuite))
                {
                    var testObjectCopy = testObject as TestSuite;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The deep copy test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public static TestObject DeepCopyTestObject(TestObject testObject)
        {
            if (testObject != null)
            {
                if (testObject.GetType() == typeof(TestFolder))
                {
                    var testObjectCopy = testObject as TestFolder;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.DeepCopy();
                    }
                }

                if (testObject.GetType() == typeof(TestCase))
                {
                    var testObjectCopy = testObject as TestCase;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestMethod))
                {
                    var testObjectCopy = testObject as TestMethod;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestModule))
                {
                    var testObjectCopy = testObject as TestModule;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestObject))
                {
                    return testObject.Copy();
                }

                if (testObject.GetType() == typeof(TestSuite))
                {
                    var testObjectCopy = testObject as TestSuite;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.DeepCopy();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The copy.
        /// </summary>
        /// <param name="collectionChanged">
        /// The collection changed.
        /// </param>
        public void Copy(TestObjectCollection collectionChanged)
        {
            if (this.Count > 0)
            {
                this.Clear();
            }

            foreach (var testScript in collectionChanged)
            {
                this.Add(DeepCopyTestObject(testScript));
            }
        }

        #endregion
    }
}