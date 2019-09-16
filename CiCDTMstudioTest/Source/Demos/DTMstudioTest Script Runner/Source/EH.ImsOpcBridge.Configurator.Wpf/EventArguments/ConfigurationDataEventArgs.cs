// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The Configruation data event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;

    using EH.ImsOpcBridge.DataContracts;
    
    /// <summary>
    /// Class ConfigurationDataEventArgs
    /// </summary>
    public class ConfigurationDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDataEventArgs"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public ConfigurationDataEventArgs(Configuration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Configuration Configuration { get; set; }

        #endregion
    }
}