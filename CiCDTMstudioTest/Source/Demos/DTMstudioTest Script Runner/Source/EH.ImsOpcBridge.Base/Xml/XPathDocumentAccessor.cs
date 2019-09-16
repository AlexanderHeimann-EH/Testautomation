// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XPathDocumentAccessor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Xml
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Xml;
    using System.Xml.XPath;

    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Properties;

    /// <summary>
    /// Contains helper methods to access to a value in an XML document using the XPathDocument class.
    /// </summary>
    public static class XPathDocumentAccessor
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the value specified by the xPath expression from the XML document.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <param name="path">The xPath.</param>
        /// <param name="defaultValue">The default value to return, when value is missing.</param>
        /// <returns>The value of the item specified by the xPath expression.</returns>
        public static string GetValue(IXPathNavigable document, string path, string defaultValue)
        {
            try
            {
                var item = GetItem(document, path);
                if (item != null)
                {
                    return item.Value;
                }
            }
            catch (ArgumentException)
            {
            }
            catch (XPathException)
            {
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the value specified by the xPath expression from the XML document.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <param name="path">The xPath.</param>
        /// <returns>The value of the item specified by the xPath expression.</returns>
        public static string GetValue(IXPathNavigable document, string path)
        {
            var item = GetItem(document, path);
            return item != null ? item.Value : null;
        }

        /// <summary>
        /// Sets the value specified by the xPath expression in the XML document.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <param name="path">The xPath.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>The edited document.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here")]
        public static IXPathNavigable SetValue(IXPathNavigable document, string path, string value)
        {
            if (document == null)
            {
                throw new ArgumentNullException(@"document");
            }

            var navigator = document.CreateNavigator();
            var editableDocument = new XmlDocument();
            editableDocument.LoadXml(navigator.OuterXml);

            var item = GetItem(editableDocument.CreateNavigator(), path);
            item.SetValue(value);

            var editableDocumentReader = new StringReader(editableDocument.OuterXml);
            var editedDocument = new XPathDocument(editableDocumentReader);

            return editedDocument;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the item specified by the xPath expression from the XML document.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <param name="path">The xPath.</param>
        /// <returns>The item specified by the xPath expression.</returns>
        private static XPathNavigator GetItem(IXPathNavigable document, string path)
        {
            if (document == null)
            {
                // ReSharper disable LocalizableElement
                throw new ArgumentException(@"document == null", @"document");

                // ReSharper restore LocalizableElement
            }

            if (path == null)
            {
                // ReSharper disable LocalizableElement
                throw new ArgumentException(@"path == null", @"path");

                // ReSharper restore LocalizableElement
            }

            try
            {
                var documentNavigator = document.CreateNavigator();
                var itemNavigator = documentNavigator.SelectSingleNode(path);
                return itemNavigator;
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CouldNotFindValue_InDocument_, path, document.CreateNavigator().OuterXml);
                throw new BaseException(message, ex);
            }
        }

        #endregion
    }
}
