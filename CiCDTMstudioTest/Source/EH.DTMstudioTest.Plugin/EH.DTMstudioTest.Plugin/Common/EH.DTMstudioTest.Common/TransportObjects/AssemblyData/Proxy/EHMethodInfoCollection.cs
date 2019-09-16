// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHMethodInfoCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Defines the EHMethodInfoCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// The eh method info collection.
    /// </summary>
    [Serializable]
    public class EhMethodInfoCollection : List<EhMethodInfo>
    {
        public EhMethodInfoCollection()
        {
        }

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="EhMethodInfoCollection"/>.
        /// </returns>
        public EhMethodInfoCollection Copy()
        {
            var result = new EhMethodInfoCollection();

            foreach (EhMethodInfo ehMethodInfo in this)
            {
                result.Add(ehMethodInfo.Copy());
            }

            return result;
        }

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
                var serializer = new XmlSerializer(typeof(EhMethodInfoCollection));
                tr = new StreamReader(configFile);
                var ehMethodInfoCollection = (EhMethodInfoCollection)serializer.Deserialize(tr);

                foreach (var methodInfo in ehMethodInfoCollection)
                {
                    this.Add(methodInfo);
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

                    var s = new XmlSerializer(typeof(EhMethodInfoCollection));
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