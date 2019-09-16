// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HexConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.Globalization;
    using System.Text;

    using EH.ImsOpcBridge.Properties;

    /// <summary>
    /// Helper class for conversions from and to strings representing hexadecimal values.
    /// </summary>
    [CLSCompliant(false)]
    public static class HexConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Formats a byte array as a series of hexadecimal values in a string. The
        /// hexadecimal values returned do not include any prefix.
        /// </summary>
        /// <param name="byteArray">Byte array to be formatted in a string.</param>
        /// <returns>String representing the values of the byte array as a series of hexadecimal values in a string.</returns>
        public static string ByteArrayToString(byte[] byteArray)
        {
            if (byteArray == null)
            {
                throw new ArgumentNullException(@"byteArray");
            }
            
            var stringBuilder = new StringBuilder();

            foreach (var b in byteArray)
            {
                // ReSharper disable LocalizableElement
                stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0:X}", b).PadLeft(2, '0'));

                // ReSharper restore LocalizableElement
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a hexadecimal representation in a string to its decimal representation.
        /// </summary>
        /// <param name="value">String containing a hexadecimal representation of a value.</param>
        /// <returns>String representing the same number as the input value formatted as decimal value.</returns>
        public static string ConvertHexToInt(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(@"value");
            }

            string trimmedValue;

            // ReSharper disable LocalizableElement
            if (value.StartsWith(@"0x", StringComparison.Ordinal) || value.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                trimmedValue = value.Substring(2).Trim();
            }
            else
            {
                trimmedValue = value.Trim();
            }

            if (string.IsNullOrEmpty(trimmedValue))
            {
                return string.Empty;
            }

            try
            {
                // ReSharper disable LocalizableElement
                var intValue = string.Format(CultureInfo.InvariantCulture, @"{0}", ulong.Parse(trimmedValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture));

                // ReSharper restore LocalizableElement
                return intValue;
            }
            catch (FormatException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts an integer from an input string to a string representing the same number
        /// in hexadecimal format. The hexadecimal number includes the prefix "0x".
        /// </summary>
        /// <param name="value">Input string containing the integer value.</param>
        /// <param name="numberOfBytes">Number of bytes, the hexadecimal output string should be formatted to.</param>
        /// <returns>String representing the same number as the input string formatted as hexadecimal value.</returns>
        public static string ConvertIntToHex(string value, int numberOfBytes)
        {
            ulong uintResult;

            if (ulong.TryParse(value, out uintResult))
            {
                return ConvertIntToHex(uintResult, numberOfBytes);
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts an unsigned integer to a string representing the same number
        /// in hexadecimal format. The hexadecimal number includes the prefix "0x".
        /// </summary>
        /// <param name="value">Unsigned integer value to be converted.</param>
        /// <param name="numberOfBytes">Number of bytes, the hexadecimal output string should be formatted to.</param>
        /// <returns>String representing the same number as the input value formatted as hexadecimal value.</returns>
        public static string ConvertIntToHex(ulong value, int numberOfBytes)
        {
            if (numberOfBytes > int.MaxValue / 2)
            {
                throw new ArgumentOutOfRangeException("numberOfBytes", Resources.ConversionOfIntegerToHexadecimalStringFailedNumberOfBytes);
            }

            var formatString = new StringBuilder();

            // ReSharper disable LocalizableElement
            formatString.Append(@"{0,");
            formatString.Append(numberOfBytes * 2);
            formatString.Append(@":X}");

            var hexValue = string.Format(CultureInfo.InvariantCulture, formatString.ToString(), value);
            hexValue = hexValue.Replace(@" ", @"0");
            hexValue = hexValue.Insert(0, @"0x");

            // ReSharper restore LocalizableElement
            return hexValue;
        }

        /// <summary>
        /// Reformats a hexadecimal representation in a string to a new length of bytes. The
        /// hexadecimal number returned includes the prefix "0x".
        /// </summary>
        /// <param name="value">String containing a hexadecimal representation of a value.</param>
        /// <param name="numberOfBytes">Number of bytes, the hexadecimal output string should be formatted to.</param>
        /// <returns>String representing the same number as the input value formatted as hexadecimal value of the corresponding length of bytes.</returns>
        public static string ReformatHex(string value, int numberOfBytes)
        {
            if (value == null)
            {
                throw new ArgumentNullException(@"value");
            }

            if (numberOfBytes > int.MaxValue / 2)
            {
                throw new ArgumentOutOfRangeException("numberOfBytes", Resources.ReformatOfHexadecimalStringFailedNumberOfBytes);
            }

            var formatString = new StringBuilder();

            // ReSharper disable LocalizableElement
            formatString.Append(@"{0,");
            formatString.Append(numberOfBytes * 2);
            formatString.Append(@":X}");

            // ReSharper restore LocalizableElement
            string trimmedValue;

            // ReSharper disable LocalizableElement
            if (value.StartsWith(@"0x", StringComparison.Ordinal) || value.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                trimmedValue = value.Substring(2).Trim();
            }
            else
            {
                trimmedValue = value.Trim();
            }

            // ReSharper disable LocalizableElement
            var hexValue = string.Format(CultureInfo.InvariantCulture, formatString.ToString(), ulong.Parse(trimmedValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
            hexValue = hexValue.Replace(@" ", @"0");
            hexValue = hexValue.Insert(0, @"0x");

            // ReSharper restore LocalizableElement
            return hexValue;
        }

        /// <summary>
        /// Converts a series of hexadecimal values in a string to a byte array.  The
        /// hexadecimal values passed in should not contain any prefixes.
        /// </summary>
        /// <param name="byteArray">Series of hexadecimal values in a string to be converted.</param>
        /// <returns>Byte array containing the bytes read from the input string.</returns>
        public static byte[] StringToByteArray(string byteArray)
        {
            if (byteArray == null)
            {
                throw new ArgumentNullException(@"byteArray");
            }

            var bt = new byte[byteArray.Length / 2];

            for (var i = 0; i < byteArray.Length; i = i + 2)
            {
                var s2 = byteArray.Substring(i, 2);
                bt[i / 2] = Convert.ToByte(s2, 16);
            }

            return bt;
        }

        #endregion
    }
}
