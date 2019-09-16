// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Serializer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements a serializer class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;

    /// <summary>
    /// Class Serializer
    /// </summary>
    public class Serializer
    {
        #region Public Methods and Operators

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="x">The x.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool Deserialize(Type type, string fileName, out object x, out Exception exception)
        {
            FileStream fs = null;
            XmlDictionaryReader reader = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open);
                reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(type);
                x = ser.ReadObject(reader);
                reader.Close();
                fs.Close();
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                // Try to clean everything.
                try
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                catch (Exception)
                {
                    // Do nothing.
                }

                x = null;
                exception = ex;
                return false;
            }
        }

        /// <summary>
        /// Serializes the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool Serialize(object x, string fileName, out Exception exception)
        {
            FileStream fs = null;
            XmlDictionaryWriter writer = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                writer = XmlDictionaryWriter.CreateTextWriter(fs);
                DataContractSerializer ser = new DataContractSerializer(x.GetType());
                ser.WriteObject(writer, x);
                writer.Close();
                fs.Close();
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                // Try to clean everything.
                try
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }

                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                catch (Exception)
                {
                    // Do nothing.
                }

                exception = ex;
                return false;
            }
        }

        #endregion
    }
}