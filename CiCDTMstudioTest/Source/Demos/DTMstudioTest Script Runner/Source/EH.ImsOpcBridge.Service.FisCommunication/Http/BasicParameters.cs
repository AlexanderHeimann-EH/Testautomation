// ***********************************************************************
// <copyright file="BasicParameters.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements the basic parameters to be used in a HTTP request.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.FisCommunication.Http
{
    /// <summary>
    /// Implements the basic parameters to be used in a HTTP request.
    /// </summary>
    public struct BasicParameters
    {
        /// <summary>
        /// The request URI.
        /// </summary>
        private readonly string requestUri;

        /// <summary>
        /// The authentication required.
        /// </summary>
        private readonly bool authenticationRequired;

        /// <summary>
        /// The user.
        /// </summary>
        private readonly string user;

        /// <summary>
        /// The password.
        /// </summary>
        private readonly string password;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicParameters" /> struct.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="authenticationRequired">if set to <c>true</c> [authentication required].</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        public BasicParameters(string requestUri, bool authenticationRequired, string user, string password)
            : this()
        {
            this.requestUri = requestUri;
            this.authenticationRequired = authenticationRequired;
            this.user = user;
            this.password = password;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the request URI.
        /// </summary>
        /// <value>The request URI.</value>
        public string RequestUri
        {
            get
            {
                return this.requestUri;
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User
        {
            get
            {
                return this.user;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return this.password;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [authentication required].
        /// </summary>
        /// <value><c>true</c> if [authentication required]; otherwise, <c>false</c>.</value>
        public bool AuthenticationRequired
        {
            get
            {
                return this.authenticationRequired;
            }
        }

        #endregion
    }
}
