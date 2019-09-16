// -----------------------------------------------------------------------
// <copyright file="XmlSerialization.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// -----------------------------------------------------------------------


namespace EH.DTMstudioTest.Common.Utilities.Serialization
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using EH.DTMstudioTest.Common.Utilities.Serialization.Attributes;

    /// <summary>
    /// Implements xml serialization.
    /// </summary>
    public static class XmlSerialization
    {
        #region Public Methods

        /// <summary>
        /// Deserializes an object from a file. No exception is thrown here, default data is returned whenever anything goes wrong.
        /// </summary>
        /// <param name="fileName">
        /// The full path.
        /// </param>
        /// <param name="type">
        /// The object type to deserialize.
        /// </param>
        /// <param name="exception">
        /// An exception in case of anything went wrong.
        /// </param>
        /// <param name="serializeIfDataNotFound">
        /// A value indicating whether to serialize the default data if file not found.
        /// </param>
        /// <returns>
        /// The deserialized object. A null object in case of errors.
        /// </returns>
        public static object XmlDeserializeObject(string fileName, Type type, out Exception exception, bool serializeIfDataNotFound)
        {
            object result = null;

            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                TextReader tr = null;
                try
                {
                    var serializer = new XmlSerializer(type);
                    tr = new StreamReader(fileName);
                    result = serializer.Deserialize(tr);
                    OnDeserialized(result);
                    tr.Close();
                    exception = null;
                    return result;
                }
                catch (Exception ex)
                {
                    exception = ex;
                    if (tr != null)
                    {
                        tr.Close();
                    }
                }
            }
            else
            {
                exception = new FileNotFoundException(string.Format("File {0} not found.", fileName));
            }

            try
            {
                // Deserialize not successfull, take the default data.
                var constructorInfo = type.GetConstructor(new Type[0]);
                if (constructorInfo != null)
                {
                    var arrayMemberInfo = type.FindMembers(
                        MemberTypes.Method,
                        BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance,
                        new MemberFilter(DelegateToSearchCriteria),
                        typeof(DefaultDataSetterAttribute));

                    if (arrayMemberInfo.Length > 0)
                    {
                        result = constructorInfo.Invoke(new object[0]);
                        type.InvokeMember(arrayMemberInfo[0].Name, BindingFlags.InvokeMethod, null, result, new object[0]);

                        // Serialize on demand.
                        if (serializeIfDataNotFound)
                        {
                            XmlSerializeObject(fileName, result);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        /// <summary>
        /// Serializes an object to a file. No exception is throw here.
        /// </summary>
        /// <param name="fileName">The full path.</param>
        /// <param name="x">The object to serialize.</param>
        public static void XmlSerializeObject(string fileName, object x)
        {
                if (!string.IsNullOrEmpty(fileName) && !ReferenceEquals(x, null))
                {
                    var s = new XmlSerializer(x.GetType());
                    var f = new FileStream(fileName, FileMode.Create);
                    var n = new XmlSerializerNamespaces();
                    n.Add(string.Empty, string.Empty);
                    s.Serialize(f, x, n);
                    f.Close();
                }
        }

        /// <summary>
        /// Serializes an object to a file. No exception is throw here.
        /// </summary>
        /// <param name="fileName">
        /// The full path.
        /// </param>
        /// <param name="x">
        /// The object to serialize.
        /// </param>
        /// <param name="n">
        /// The n.
        /// </param>
        public static void XmlSerializeObject(string fileName, object x, XmlSerializerNamespaces n)
        {
            if (!string.IsNullOrEmpty(fileName) && !ReferenceEquals(x, null))
            {
                var s = new XmlSerializer(x.GetType());
                var f = new FileStream(fileName, FileMode.Create);
                s.Serialize(f, x, n);
                f.Close();
            }
        }

        /// <summary>
        /// The to color.
        /// </summary>
        /// <param name="thisValue">
        /// The this value.
        /// </param>
        /// <returns>
        /// The <see cref="Color"/>.
        /// </returns>
        public static Color ToColor(this string thisValue)
        {
            Color color = Color.FromName(thisValue);
            if (!color.IsKnownColor)
            {
                try
                {
                    // try to convert from hex format: aarrggbb
                    int iResult = Convert.ToInt32(thisValue, 16);
                    color = Color.FromArgb(iResult >> 24 & 0xff, iResult >> 16 & 0xff, iResult >> 8 & 0xff, iResult & 0xff);
                }
                catch { }
            }
            return color;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Called after deserialization.
        /// </summary>
        /// <param name="obj">The deserialized object.</param>
        private static Exception OnDeserialized(object obj)
        {
            if (obj != null)
            {
                try
                {
                    var arrayMemberInfo = obj.GetType().FindMembers(
                        MemberTypes.Method,
                        BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance,
                        new MemberFilter(DelegateToSearchCriteria),
                        typeof(OnDeserializedAttribute));

                    if (arrayMemberInfo.Length > 0)
                    {
                        obj.GetType().InvokeMember(arrayMemberInfo[0].Name, BindingFlags.InvokeMethod, null, obj, new object[] { null });
                    }
                }
                catch (Exception exception)
                {
                    return exception;
                }
            }
            return null; 
        }

        /// <summary>
        /// Delegates to search a method by its attributes.
        /// </summary>
        /// <param name="objMemberInfo">
        /// The obj member info.
        /// </param>
        /// <param name="objSearch">
        /// The obj search.
        /// </param>
        /// <returns>
        /// True if the method is the expected one.
        /// </returns>
        private static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, object objSearch)
        {
            // Compare against expected attribute.
            var attributes = objMemberInfo.GetCustomAttributes(true);

            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == (Type)objSearch)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
