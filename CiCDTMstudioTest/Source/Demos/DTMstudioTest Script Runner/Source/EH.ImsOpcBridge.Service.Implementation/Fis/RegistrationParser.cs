// ***********************************************************************
// <copyright file="RegistrationParser.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements a parser for the registration response.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Fis
{
    using System;
    using System.Xml;

    using EH.ImsOpcBridge.Service.Implementation.Documents;

    /// <summary>
    /// Implements a parser for the registration response.
    /// </summary>
    internal class RegistrationParser
    {
        #region Fields

        /// <summary>
        /// The XML body
        /// </summary>
        private readonly string xmlBody;

        /// <summary>
        /// The expected model
        /// </summary>
        private readonly string expectedModel;

        /// <summary>
        /// The expected serial number
        /// </summary>
        private readonly string expectedUid;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationParser" /> class.
        /// </summary>
        /// <param name="xmlBody">The XML body.</param>
        /// <param name="expectedModel">The expected model.</param>
        /// <param name="expectedUid">The expected serial number.</param>
        public RegistrationParser(string xmlBody, string expectedModel, string expectedUid)
        {
            this.xmlBody = xmlBody;
            this.expectedModel = expectedModel;
            this.expectedUid = expectedUid;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the XML body.
        /// </summary>
        /// <value>The XML body.</value>
        public string XmlBody
        {
            get
            {
                return this.xmlBody;
            }
        }

        /// <summary>
        /// Gets the expected model.
        /// </summary>
        /// <value>The expected model.</value>
        public string ExpectedModel
        {
            get
            {
                return this.expectedModel;
            }
        }

        /// <summary>
        /// Gets the expected serial number.
        /// </summary>
        /// <value>The expected serial number.</value>
        public string ExpectedUid
        {
            get
            {
                return this.expectedUid;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Extracts user and password from the response from the FIS server. This method also compares whether the received model and serial number are the expected ones.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pw">The pw.</param>
        /// <returns><c>true</c> if all the out values are not null, <c>false</c> otherwise.</returns>
        public bool ExtractUserPassword(out string user, out string pw)
        {
            string receivedModel, receivedUid;
            var result = false;

            if (this.ParseResponse(out receivedModel, out receivedUid, out user, out pw))
            {
                result = this.ExpectedModel.Equals(receivedModel) && this.ExpectedUid.Equals(receivedUid);
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Parses the response from the FIS server.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="uid">The gateway serial number.</param>
        /// <param name="user">The user.</param>
        /// <param name="pw">The pw.</param>
        /// <returns><c>true</c> if all the out values are not null, <c>false</c> otherwise.</returns>
        private bool ParseResponse(out string model, out string uid, out string user, out string pw)
        {
            model = uid = user = pw = null;
            var result = false;

            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(this.XmlBody);
                model = this.ReadAttribute(doc, CommonFormat.FisRegistrationResponseModelPath);
                uid = this.ReadAttribute(doc, CommonFormat.FisRegistrationResponseModelUid);
                user = this.ReadNodeValue(doc, CommonFormat.FisRegistrationResponseAuthUser);
                pw = this.ReadNodeValue(doc, CommonFormat.FisRegistrationResponseAuthPassword);

                result = model != null && uid != null && user != null && pw != null;
            }
            catch (Exception exception)
            {
            }

            return result;
        }

        /// <summary>
        /// Reads the specified attribute.
        /// </summary>
        /// <param name="doc">The XML document.</param>
        /// <param name="path">The query path.</param>
        /// <returns>A non empty string if successful, otherwise null.</returns>
        private string ReadAttribute(XmlDocument doc, string path)
        {
            string value = null;

            try
            {
                var node = doc.SelectSingleNode(path);
                if (node != null)
                {
                    var val = node.Value;
                    if (!string.IsNullOrEmpty(val))
                    {
                        value = val;
                    }
                }
            }
            catch (Exception exception)
            {
                value = null;
            }

            return value;
        }

        /// <summary>
        /// Reads the specified node value.
        /// </summary>
        /// <param name="doc">The XML document.</param>
        /// <param name="path">The query path.</param>
        /// <returns>A non empty string if successful, otherwise null.</returns>
        private string ReadNodeValue(XmlDocument doc, string path)
        {
            string value = null;

            try
            {
                var node = doc.SelectSingleNode(path);
                if (node != null)
                {
                    var val = node.InnerText;
                    val = val.Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        value = val;
                    }
                }
            }
            catch (Exception exception)
            {
                value = null;
            }

            return value;
        }

        #endregion
    }
}
