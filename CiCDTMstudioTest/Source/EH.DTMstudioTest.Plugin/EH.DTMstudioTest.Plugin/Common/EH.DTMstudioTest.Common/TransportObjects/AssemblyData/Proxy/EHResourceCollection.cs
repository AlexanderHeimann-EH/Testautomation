// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHResourceCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh test suite collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// The eh test suite collection.
    /// </summary>
    [Serializable]
    public class EhResourceCollection : List<EhResourceInfo>
    {
        public EhResourceCollection()
        {
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the root namespace.
        /// </summary>
        public string RootNamespace { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        public void Load(string configFile)
        {
            this.Clear();
            TextReader tr = null;

            try
            {
                var serializer = new XmlSerializer(typeof(EhResourceCollection));
                tr = new StreamReader(configFile);
                var ehResourceCollection = (EhResourceCollection)serializer.Deserialize(tr);

                foreach (var resource in ehResourceCollection)
                {
                    this.Add(resource);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (tr != null)
                {
                    tr.Close();
                }
            }
        }

        /// <summary>
        /// Called when [serialization].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public void OnSerialization(object sender)
        {
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="configFile">
        /// The config file.
        /// </param>
        public void Save(string configFile)
        {
            FileStream f = null;

            if (this.Count > -1)
            {
                try
                {
                    if (File.Exists(configFile))
                    {
                        File.Delete(configFile);
                    }

                    var s = new XmlSerializer(typeof(EhResourceCollection));
                    f = new FileStream(configFile, FileMode.OpenOrCreate);
                    var n = new XmlSerializerNamespaces();
                    n.Add(string.Empty, string.Empty);
                    this.OnSerialization(n);
                    s.Serialize(f, this, n);
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (f != null)
                    {
                        f.Close();
                    }
                }
            }
        }

        #endregion
    }
}