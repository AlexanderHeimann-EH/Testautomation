// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDomainCore.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The app domain core.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace MySpace
{
    /// <summary>
    /// The app domain core.
    /// </summary>
    internal class AppDomainCore
    {
        /// <summary>
        /// The default appdomain name.
        /// </summary>
        private readonly string defaultAppdomainName;

        /// <summary>
        /// The default app domain.
        /// </summary>
        private AppDomain defaultAppDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainCore"/> class. 
        /// creates an instance of Appdomain in the Specified Name
        /// </summary>
        /// <param name="appDoaminName">
        /// </param>
        public AppDomainCore(string appDoaminName)
        {
            defaultAppdomainName = appDoaminName;
            LoadAppDomain();
        }

        /// <summary>
        /// Gets the Currently Active Appdomain
        /// </summary>
        public AppDomain DefaultAppDomain
        {
            get { return defaultAppDomain; }
        }

        /// <summary>
        /// Gets the default appdomain name.
        /// </summary>
        public string DefaultAppdomainName
        {
            get { return defaultAppdomainName; }
        }

        /// <summary>
        /// The load app domain.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool LoadAppDomain()
        {
            // Construct and initialize settings for a second AppDomain.
            var ads = new AppDomainSetup();

            // Create the second AppDomain.
            defaultAppDomain = AppDomain.CreateDomain(DefaultAppdomainName, null, ads);

            /* this statement makes the App to copy the Dll to an alternative location and loads form there 
             * and thus leaves the original file's locking for replacement.*/
            defaultAppDomain.SetShadowCopyFiles();
            return true;
        }

        /// <summary>
        /// Clears the currently used Application domain if exists.
        /// </summary>
        /// <returns>Boolean regarding operation sucessfull or not</returns>
        private bool ClearAppDomain()
        {
            try
            {
                AppDomain.Unload(DefaultAppDomain);
                defaultAppDomain = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="AppDomainCore"/> class. 
        /// </summary>
        ~AppDomainCore()
        {
            ClearAppDomain();
        }
    }
}