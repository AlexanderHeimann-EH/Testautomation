// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsType.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The is type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Utilities.Validator
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The is type.
    /// </summary>
    public static class IsType
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Is(this string input, string targetType)
        {
            try
            {
                var isType = Type.GetType(targetType);
                if (IsArray(isType) || IsGenericType(isType))
                {
                    return true;
                }

                Convert.ChangeType(input, isType);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The is.
        /// </summary>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsArray(Type targetType)
        {
            if (targetType.IsArray)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The is generic type.
        /// </summary>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsGenericType(Type targetType)
        {
            if (targetType.IsGenericType)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}