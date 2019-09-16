// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects
{
    using System.Collections.Specialized;

    /// <summary>
    /// The test collection.
    /// </summary>
    public class TestCollection : TestObject
    {
        #region Fields

        /// <summary>
        /// The test methods.
        /// </summary>
        private TestObjectCollection testObjects;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCollection"/> class.
        /// </summary>
        public TestCollection()
        {
            this.TestObjects = new TestObjectCollection();
            this.TestObjects.CollectionChanged += this.OnCollectionChanged;
            this.IsActive = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the test methods.
        /// </summary>
        public TestObjectCollection TestObjects
        {
            get
            {
                return this.testObjects;
            }

            set
            {
                if (this.testObjects != value)
                {
                    this.testObjects = value;
                    this.RaisePropertyChanged("TestObjects");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newTestObject = e.NewItems;

                        foreach (TestObject testObject in newTestObject)
                        {
                            testObject.Parent = this;

                            testObject.PropertyChanged += this.OnPropertyChanged;
                        }

                        break;
                    }
            }

            this.RaisePropertyChanged("OnTestMethodsCollectionChanged");
        }

        #endregion
    }
}
