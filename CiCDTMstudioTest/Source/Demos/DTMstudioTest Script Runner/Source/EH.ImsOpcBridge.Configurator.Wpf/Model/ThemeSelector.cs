// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeSelector.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Handling dynamically switching themes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Handling dynamically switching themes.
    /// </summary>
    public class ThemeSelector : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The current theme dictionary property.
        /// </summary>
        public static readonly DependencyProperty CurrentThemeDictionaryProperty = DependencyProperty.RegisterAttached("CurrentThemeDictionary", typeof(Uri), typeof(ThemeSelector), new UIPropertyMetadata(null, CurrentThemeDictionaryChanged));

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the current theme dictionary.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>the Uri of the current theme dictionary</returns>
        public static Uri GetCurrentThemeDictionary(DependencyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(@"obj");
            }

            return (Uri)obj.GetValue(CurrentThemeDictionaryProperty);
        }

        /// <summary>
        /// Set the current theme dictionary.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        public static void SetCurrentThemeDictionary(DependencyObject obj, Uri value)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(@"obj");
            }

            obj.SetValue(CurrentThemeDictionaryProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Apply a theme.
        /// </summary>
        /// <param name="targetElement">The target element.</param>
        /// <param name="dictionaryUri">The theme dictionary uri.</param>
        private static void ApplyTheme(FrameworkElement targetElement, Uri dictionaryUri)
        {
            if (targetElement == null)
            {
                return;
            }

            ThemeDictionary themeDictionary = null;
            if (dictionaryUri != null)
            {
                themeDictionary = new ThemeDictionary();
                themeDictionary.Source = dictionaryUri;

                // add the new dictionary to the collection of merged dictionaries of the target object  
                targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary);
            }

            // find if the target element already has a theme applied  
            List<ThemeDictionary> existingDictionaries = (from dictionary in targetElement.Resources.MergedDictionaries.OfType<ThemeDictionary>() select dictionary).ToList();

            // remove the existing dictionaries  
            foreach (ThemeDictionary eachThemeDictionary in existingDictionaries)
            {
                if (themeDictionary == eachThemeDictionary)
                {
                    continue; // don't remove the newly added dictionary  
                }

                targetElement.Resources.MergedDictionaries.Remove(eachThemeDictionary);
            }
        }

        /// <summary>
        /// The current theme dictionary changed.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The e.</param>
        private static void CurrentThemeDictionaryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as FrameworkElement;
            if (element != null)
            {
                // works only on FrameworkElement objects  
                ApplyTheme(element, GetCurrentThemeDictionary(obj));
            }
        }

        #endregion
    }
}
