// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CompareParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common
{
    /// <summary>
    /// Class CompareParameter.
    /// </summary>
    public class CompareParameter
    {
        #region Fields

        /// <summary>
        /// The offline value.
        /// </summary>
        private readonly string offlineValue;

        /// <summary>
        /// The online value.
        /// </summary>
        private readonly string onlineValue;

        /// <summary>
        /// The parameter name.
        /// </summary>
        private readonly string parameterName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EH.PCPS.TestAutomation.Common.CompareParameter"/> class.
        /// </summary>
        /// <param name="parameterName">
        /// Name of the parameter.
        /// </param>
        /// <param name="offlineValue">
        /// The offline value.
        /// </param>
        /// <param name="onlineValue">
        /// The online value.
        /// </param>
        public CompareParameter(string parameterName, string offlineValue, string onlineValue)
        {
            this.offlineValue = offlineValue;
            this.onlineValue = onlineValue;
            this.parameterName = parameterName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the offline value.
        /// </summary>
        /// <value>The offline value.</value>
        public string OfflineValue
        {
            get
            {
                return this.offlineValue;
            }
        }

        /// <summary>
        /// Gets the online value.
        /// </summary>
        /// <value>The online value.</value>
        public string OnlineValue
        {
            get
            {
                return this.onlineValue;
            }
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        public string ParameterName
        {
            get
            {
                return this.parameterName;
            }
        }

        #endregion
    }
}