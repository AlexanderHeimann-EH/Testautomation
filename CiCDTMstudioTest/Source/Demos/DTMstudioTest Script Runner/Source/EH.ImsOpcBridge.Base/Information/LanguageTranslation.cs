// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageTranslation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Information
{
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.Helpers;

    /// <summary>
    /// The language translation.
    /// </summary>
    public static class LanguageTranslation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the display name of the language.
        /// </summary>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>The display name of the language.</returns>
        public static string GetLanguageDisplayName(CultureInfo cultureInfo)
        {
            var baseCultureInfo = cultureInfo;
            while (!string.IsNullOrEmpty(baseCultureInfo.Parent.Name))
            {
                baseCultureInfo = baseCultureInfo.Parent;
            }

            // ReSharper disable LocalizableElement
            var language = new TranslatableString(string.Format(CultureInfo.InvariantCulture, @"LanguageName_{0}", baseCultureInfo.TwoLetterISOLanguageName), @"EH.ImsOpcBridge.Properties.Resources", Assembly.GetExecutingAssembly().FullName);

            // ReSharper restore LocalizableElement
            return language.ToString();
        }

        #endregion
    }
}
