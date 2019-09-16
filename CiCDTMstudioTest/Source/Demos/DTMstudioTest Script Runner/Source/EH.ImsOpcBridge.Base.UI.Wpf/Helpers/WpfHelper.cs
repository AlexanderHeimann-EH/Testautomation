// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The wpf helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Helpers
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The WPF helper.
    /// </summary>
    public static class WpfHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Searches child of Type T in visual tree of a given parent control.
        /// </summary>
        /// <typeparam name="T">Type of visual child</typeparam>
        /// <param name="parentObj">The parent object.</param>
        /// <returns>The <see cref="T" />.</returns>
        public static T FindVisualChild<T>(DependencyObject parentObj) where T : DependencyObject
        {
            if (parentObj != null)
            {
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parentObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(parentObj, i);
                    if (child is T)
                    {
                        return (T)child;
                    }

                    var childItem = FindVisualChild<T>(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
