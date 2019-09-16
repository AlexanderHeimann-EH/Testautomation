// ***********************************************************************
// <copyright file="RequestParameters.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements the request parameters for a HTTP request.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.FisCommunication.Http
{
    /// <summary>
    /// Implements the request parameters for a HTTP request.
    /// </summary>
    public struct RequestParameters
    {
        /// <summary>
        /// The basic parameters.
        /// </summary>
        private readonly BasicParameters basicParameters;

        /// <summary>
        /// The proxy required flag
        /// </summary>
        private readonly bool proxyRequired;

        /// <summary>
        /// The proxy parameters
        /// </summary>
        private readonly BasicParameters proxyParameters;

        /// <summary>
        /// The method
        /// </summary>
        private readonly string method;

        /// <summary>
        /// The content type
        /// </summary>
        private readonly string contentType;

        /// <summary>
        /// The web timeout.
        /// </summary>
        private readonly int webTimeout;

        /// <summary>
        /// The body.
        /// </summary>
        private readonly string body;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameters" /> struct.
        /// </summary>
        /// <param name="basicParameters">The basic parameters.</param>
        /// <param name="proxyRequired">if set to <c>true</c> [proxy required].</param>
        /// <param name="proxyParameters">The proxy parameters.</param>
        /// <param name="method">The method.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="webTimeout">The web timeout.</param>
        /// <param name="body">The body.</param>
        public RequestParameters(BasicParameters basicParameters, bool proxyRequired, BasicParameters proxyParameters, string method, string contentType, int webTimeout, string body)
            : this()
        {
            this.basicParameters = basicParameters;
            this.proxyRequired = proxyRequired;
            this.proxyParameters = proxyParameters;
            this.method = method;
            this.contentType = contentType;
            this.webTimeout = webTimeout;
            this.body = body;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the basic parameters.
        /// </summary>
        /// <value>The basic parameters.</value>
        public BasicParameters BasicParameters
        {
            get
            {
                return this.basicParameters;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [proxy required].
        /// </summary>
        /// <value><c>true</c> if [proxy required]; otherwise, <c>false</c>.</value>
        public bool ProxyRequired
        {
            get
            {
                return this.proxyRequired;
            }
        }

        /// <summary>
        /// Gets the proxy parameters.
        /// </summary>
        /// <value>The proxy parameters.</value>
        public BasicParameters ProxyParameters
        {
            get
            {
                return this.proxyParameters;
            }
        }

        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <value>The method.</value>
        public string Method
        {
            get
            {
                return this.method;
            }
        }

        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType
        {
            get
            {
                return this.contentType;
            }
        }

        /// <summary>
        /// Gets the web timeout.
        /// </summary>
        /// <value>The web timeout.</value>
        public int WebTimeout
        {
            get
            {
                return this.webTimeout;
            }
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body
        {
            get
            {
                return this.body;
            }
        }

        #endregion
    }
}
