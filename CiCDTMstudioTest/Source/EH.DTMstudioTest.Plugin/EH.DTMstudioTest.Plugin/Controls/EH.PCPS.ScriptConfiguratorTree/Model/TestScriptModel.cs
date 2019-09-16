// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The feature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;

    /// <summary>
    /// Class FeatureModel.
    /// </summary>
    [Serializable]
    public class TestScriptModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The _feature list
        /// </summary>
        private TestScriptCollection testScriptList;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestScriptModel"/> class.
        /// </summary>
        public TestScriptModel()
        {
            this.TestScriptList = new TestScriptCollection();
            this.TestScriptList.CollectionChanged += this.OnChildrenCollectionChanged;
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
        /// Gets or sets the column header1.
        /// </summary>
        /// <value>The column header1.</value>
        public string ColumnHeader1 { get; set; }

        /// <summary>
        /// Gets or sets the column header2.
        /// </summary>
        /// <value>The column header2.</value>
        public string ColumnHeader2 { get; set; }

        /// <summary>
        /// Gets or sets the column header3.
        /// </summary>
        /// <value>The column header3.</value>
        public string ColumnHeader3 { get; set; }

        /// <summary>
        /// Gets or sets the column header4.
        /// </summary>
        /// <value>The column header4.</value>
        public string ColumnHeader4 { get; set; }

        /// <summary>
        /// Gets or sets the column header5.
        /// </summary>
        /// <value>The column header5.</value>
        public string ColumnHeader5 { get; set; }

        /// <summary>
        /// Gets or sets the feature list.
        /// </summary>
        /// <value>The feature list.</value>
        public TestScriptCollection TestScriptList
        {
            get
            {
                return this.testScriptList;
            }

            set
            {
                this.testScriptList = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on children collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newTestScriptList = e.NewItems;

                        foreach (TestScriptItem newTestScript in newTestScriptList)
                        {
                            newTestScript.PropertyChanged += this.OnPropertyChanged;
                        }

                        break;
                    }
            }
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
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var testScript = (TestScriptItem)sender;
            if (testScript != null)
            {
                var testObject = (TestObject)testScript.Tag;

                if (e.PropertyName == "IsChecked")
                {
                    if (testScript.IsChecked != null)
                    {
                        testObject.IsActive = (bool)testScript.IsChecked;
                    }
                    else
                    {
                        testObject.IsActive = false;
                    }
                }
                else if (e.PropertyName == "Name")
                {
                    testObject.Name = testScript.Name;
                }
                else if (e.PropertyName == "Description")
                {
                    testObject.Description = testScript.Description;
                }
            }
        }

        #endregion
    }
}