// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class FeatureCollection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Class TestScriptCollection.
    /// </summary>
    public class TestScriptCollection : ObservableCollection<TestScriptItem>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds the ascending.
        /// </summary>
        /// <param name="testScript">
        /// The testScript.
        /// </param>
        public void AddAscending(TestScriptItem testScript)
        {
            // Comparison<string> comparison = new Comparison<string>((s1, s2) => { return String.Compare(s1, s2); });
            if (this.Count == 0)
            {
                // If collection is empty, just add
                this.Add(testScript);
            }
            else
            {
                bool inserted = false;
                for (int i = 0; i < this.Count; i++)
                {
                    var result = string.Compare(this[i].ToString(), testScript.ToString());
                    if (result >= 1)
                    {
                        this.Insert(i, testScript);
                        inserted = true;
                        break;
                    }
                }

                if (!inserted)
                {
                    // If no position was found, add at the end
                    this.Add(testScript);
                }
            }
        }

        /// <summary>
        /// The copy.
        /// </summary>
        /// <param name="testScriptCollection">
        /// The test script collection.
        /// </param>
        public void Copy(TestScriptCollection testScriptCollection)
        {
            if (this.Count > 0)
            {
                this.Clear();
            }

            foreach (var testScript in testScriptCollection)
            {
                this.Add(testScript.Copy());
            }
        }

        #endregion
    }
}