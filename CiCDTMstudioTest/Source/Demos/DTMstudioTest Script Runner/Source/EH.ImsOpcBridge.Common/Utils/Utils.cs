// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="Utils.cs">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Common.Utils
{
    using System;
    using System.Configuration;
    using System.Reflection;

    /// <summary>
    /// Implements various utilities.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Reads the application settings.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="value">The returned value.</param>
        /// <returns><c>true</c> if the requested value was found, <c>false</c> otherwise.</returns>
        public static bool ReadAppSettings(string key, string defaultValue, out string value)
        {
            var result = false;
            value = defaultValue;

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] != null)
                {
                    value = settings[key].Value;
                    result = true;
                }
            }
            catch (Exception)
            {
                // Nothing to do.
            }

            return result;
        }

        /// <summary>
        /// Converts the specified string value to a long within limits.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <param name="min">The minimum accepted.</param>
        /// <param name="max">The maximum accepted.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The requested number, default if anything went wrong.</returns>
        public static long ToLong(string stringValue, long min, long max, long defaultValue)
        {
            var retValue = defaultValue;
            long tmpValue;
            if (long.TryParse(stringValue, out tmpValue))
            {
                if (min <= tmpValue && tmpValue <= max)
                {
                    retValue = tmpValue;
                }
            }

            return retValue;
        }
    }
}
