// ***********************************************************************
// <copyright file="RequestParameters.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements the request parameters for a HTTP request.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Http
{
    /// <summary>
    /// Implements the request parameters for a HTTP request.
    /// </summary>
    internal struct RequestParameters
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameters"/> struct.
        /// </summary>
        /// <param name="port">The port number.</param>
        /// <param name="authenticationRequired">if set to <c>true</c> [authentication required].</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        public RequestParameters(int port, bool authenticationRequired, string user, string password)
            : this()
        {
            this.Port = port;
            this.AuthenticationRequired = authenticationRequired;
            this.User = user;
            this.Password = password;
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets the port number.
        /// </summary>
        /// <value>The port number.</value>
        public int Port { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the authentication is required.
        /// </summary>
        /// <value><c>true</c> if the authentication is required; otherwise, <c>false</c>.</value>
        public bool AuthenticationRequired { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; private set; }

        #endregion

        #region Overriden

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is RequestParameters)
            {
                return this.Equals((RequestParameters)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <remarks>
        /// The hash code is not needed for the time being. To be implemented when needed.
        /// </remarks>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return 1;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines whether the specified <see cref="RequestParameters" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns><c>true</c> if the specified <see cref="RequestParameters" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        private bool Equals(RequestParameters obj)
        {
            return (this.Port == obj.Port) &&
                (this.AuthenticationRequired == obj.AuthenticationRequired) &&
                string.Equals(this.User, obj.User) &&
                string.Equals(this.Password, obj.Password);
        }

        #endregion
    }
}
