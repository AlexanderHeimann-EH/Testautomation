// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteArrayHandler.cs" company="Endress+Hauser Process Solutions AG">
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
    /// This class can be used to handle, convert and format string representations of byte arrays.
    /// </summary>
    [CLSCompliant(false)]
    public static class ByteArrayHandler
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether two byte arrays are not equal.
        /// </summary>
        /// <param name="left">Left byte array to be compared.</param>
        /// <param name="right">Right byte array to be compared.</param>
        /// <returns>True if the two are different, otherwise false.</returns>
        public static bool AreDifferent(byte[] left, byte[] right)
        {
            return !AreEqual(left, right);
        }

        /// <summary>
        /// Determines whether two byte arrays are equal.
        /// </summary>
        /// <param name="left">Left byte array to be compared.</param>
        /// <param name="right">Right byte array to be compared.</param>
        /// <returns>True if the two are equal, otherwise false.</returns>
        public static bool AreEqual(byte[] left, byte[] right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(@"left");
            }

            if (right == null)
            {
                throw new ArgumentNullException(@"right");
            }

            if (left.LongLength != right.LongLength)
            {
                return false;
            }

            for (long pos = 0; pos < left.LongLength; pos++)
            {
                if (left[pos] != right[pos])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Extracts a sub array of bytes out of a byte array in a string and returns its value in decimal format.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <param name="numberOfBytes">Length of sub array of bytes to be extracted.</param>
        /// <returns>Sub array of bytes to be extracted and formatted as a decimal number.</returns>
        public static uint GetBytesFromByteArrayAsUInt32(string byteArrayValue, int zeroBasedIndex, int numberOfBytes)
        {
            if (numberOfBytes > 4)
            {
                throw new ArgumentException(Resources.ConversionOfUInt32HexadecimalValueFailedLengthGreater4Bytes, @"numberOfBytes");
            }

            return uint.Parse(RemoveHexPrefix(GetBytesFromByteArrayInStringAsHex(byteArrayValue, zeroBasedIndex, numberOfBytes)), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a byte array in a string to its value in decimal format.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <returns>Byte array converted and formatted as a decimal number.</returns>
        public static uint GetBytesFromByteArrayAsUInt32(string byteArrayValue)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }
            
            var numberOfBytes = byteArrayValue.Length / 2;

            // ReSharper disable LocalizableElement
            if (byteArrayValue.StartsWith(@"0x", StringComparison.Ordinal) || byteArrayValue.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                numberOfBytes = numberOfBytes - 1;
            }

            return GetBytesFromByteArrayAsUInt32(byteArrayValue, 0, numberOfBytes);
        }

        /// <summary>
        /// Extracts a sub array of bytes out of a byte array in a string and returns its value in decimal format.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <param name="numberOfBytes">Length of sub array of bytes to be extracted.</param>
        /// <returns>Sub array of bytes to be extracted and formatted as a decimal number.</returns>
        public static string GetBytesFromByteArrayInStringAsDec(string byteArrayValue, int zeroBasedIndex, int numberOfBytes)
        {
            return GetBytesFromByteArrayAsUInt32(byteArrayValue, zeroBasedIndex, numberOfBytes).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Extracts a sub array of bytes out of a byte array in a string. The byte array can be of the format
        /// "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <param name="numberOfBytes">Length of sub array of bytes to be extracted.</param>
        /// <returns>Sub array of bytes to be extracted. The byte gets extracted in the same format as the byte passed in.</returns>
        public static string GetBytesFromByteArrayInStringAsHex(string byteArrayValue, int zeroBasedIndex, int numberOfBytes)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }
            
            var stringBuilder = new StringBuilder();

            if (numberOfBytes < 1)
            {
                throw new ArgumentException(Resources.ConversionOfHexadecimalValueFailedLengthSmaller1Byte, @"numberOfBytes");
            }

            if (zeroBasedIndex < 0)
            {
                throw new ArgumentException(Resources.ConversionOfHexadecimalValueFailedZeroBasedIndexSmaller0, @"zeroBasedIndex");
            }

            // ReSharper disable LocalizableElement
            if (byteArrayValue.StartsWith(@"0x", StringComparison.Ordinal) || byteArrayValue.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                zeroBasedIndex = zeroBasedIndex + 1;
                stringBuilder.Append(byteArrayValue.Substring(0, 2));
            }

            if (byteArrayValue.Length < (2 * zeroBasedIndex) + (2 * numberOfBytes))
            {
                throw new ArgumentException(Resources.ConversionOfHexadecimalValueFailedHexadecimalStringIsTooShort, @"byteArrayValue");
            }

            stringBuilder.Append(byteArrayValue.Substring(2 * zeroBasedIndex, 2 * numberOfBytes));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts the byte array of Profibus IM software revision information to its human
        /// readable version.
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array of the IM software revision.</param>
        /// <returns>Human readable version of Profibus IM software revision.</returns>
        public static string GetIMSoftwareRevisionFromByteArray(string byteArrayValue)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }

            if (byteArrayValue.Length != 8)
            {
                return Resources.GetIMSoftwareRevisionFromByteArrayError;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append((char)GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, 0));
            stringBuilder.Append(GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, 1));
            // ReSharper disable LocalizableElement
            stringBuilder.Append(@".");
            // ReSharper restore LocalizableElement
            stringBuilder.Append(GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, 2));
            // ReSharper disable LocalizableElement
            stringBuilder.Append(@".");
            // ReSharper restore LocalizableElement
            stringBuilder.Append(GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, 3));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts the byte array of a packed ascii string to its human readable version.
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array of the packed ascii string.</param>
        /// <param name="zeroBasedIndex">Zero based index of packed ascii char to start from.</param>
        /// <param name="numberOfBytes">Number of bytes to be read.</param>
        /// <returns>Human readable version of packed ascii string.</returns>
        public static string GetPackedAsciiFromByteArrayAsString(string byteArrayValue, int zeroBasedIndex, int numberOfBytes)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }

            var packedAsciiBytes = new byte[numberOfBytes];

            for (var pos = 0; pos < numberOfBytes; pos++)
            {
                packedAsciiBytes[pos] = GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, zeroBasedIndex + pos);
            }

            var resultString = new StringBuilder();

            var triplets = (ulong)(numberOfBytes / 3);

            for (ulong l = 0; l < triplets; l++)
            {
                var triplet = ((ulong)packedAsciiBytes[(l * 3) + 0] << 16) | ((ulong)packedAsciiBytes[(l * 3) + 1] << 8) | packedAsciiBytes[(l * 3) + 2];

                // Extract the characters
                var unpackedChar = new byte[4];
                unpackedChar[0] = (byte)((triplet & 0x00FC0000) >> 18);
                unpackedChar[1] = (byte)((triplet & 0x0003F000) >> 12);
                unpackedChar[2] = (byte)((triplet & 0x00000FC0) >> 6);
                unpackedChar[3] = (byte)(triplet & 0x0000003F);

                // Unpack the characters
                for (var k = 0; k < 4; k++)
                {
                    // Bit 6 must be set to complement of Bit 5
                    if ((unpackedChar[k] & 0x20) != 0x00)
                    {
                        // Reset Bit 6
                        unpackedChar[k] &= 0xBF;
                    }
                    else
                    {
                        // Set Bit 6
                        unpackedChar[k] |= 0x40;
                    }

                    // Bit 7 must be reset
                    unpackedChar[k] &= 0x7F;
                }

                resultString.Append((char)unpackedChar[0]);
                resultString.Append((char)unpackedChar[1]);
                resultString.Append((char)unpackedChar[2]);
                resultString.Append((char)unpackedChar[3]);
            }

            return resultString.ToString();
        }

        /// <summary>
        /// Extracts a single byte out of a byte array in a string. The byte array can be of the format
        /// "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <returns>Byte to be extracted as byte.</returns>
        public static byte GetSingleByteFromByteArrayInStringAsByte(string byteArrayValue, int zeroBasedIndex)
        {
            return byte.Parse(RemoveHexPrefix(GetBytesFromByteArrayInStringAsHex(byteArrayValue, zeroBasedIndex, 1)), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Extracts a single byte out of a byte array in a string and returns its value in decimal format.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <returns>Byte to be extracted and formatted as a decimal number.</returns>
        public static string GetSingleByteFromByteArrayInStringAsDec(string byteArrayValue, int zeroBasedIndex)
        {
            return GetBytesFromByteArrayInStringAsDec(byteArrayValue, zeroBasedIndex, 1);
        }

        /// <summary>
        /// Extracts a single byte out of a byte array in a string. The byte array can be of the format
        /// "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <returns>Byte to be extracted. The byte gets extracted in the same format as the byte passed in.</returns>
        public static string GetSingleByteFromByteArrayInStringAsHex(string byteArrayValue, int zeroBasedIndex)
        {
            return GetBytesFromByteArrayInStringAsHex(byteArrayValue, zeroBasedIndex, 1);
        }

        /// <summary>
        /// Extracts a single byte out of a byte array in a string and returns its value in decimal format.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <param name="zeroBasedIndex">Zero based index of byte to be extracted.</param>
        /// <returns>Byte to be extracted and formatted as a decimal number.</returns>
        public static uint GetSingleByteFromByteArrayInStringAsUInt32(string byteArrayValue, int zeroBasedIndex)
        {
            return GetBytesFromByteArrayAsUInt32(byteArrayValue, zeroBasedIndex, 1);
        }

        /// <summary>
        /// Builds a string based on a byte array in a string containing ascii values.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation of ascii characters.</param>
        /// <param name="zeroBasedIndex">Zero based index of ascii char to start from.</param>
        /// <param name="numberOfBytes">Number of bytes to be read.</param>
        /// <returns>String built based on the byte array in the string containing ascii values.</returns>
        /// <remarks>Control characters are not processed and as soon as a \0 character is found the building of the string stops.</remarks>
        public static string GetStringFromByteArray(string byteArrayValue, int zeroBasedIndex, int numberOfBytes)
        {
            var stringBuilder = new StringBuilder();

            for (var index = 0; index < numberOfBytes; index++)
            {
                var c = (char)GetSingleByteFromByteArrayInStringAsByte(byteArrayValue, zeroBasedIndex + index);

                if (!char.IsControl(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    if (c == '\0')
                    {
                        break;
                    }
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Builds a string based on a byte array in a string containing ascii values.
        /// The byte array can be of the format "0xabcd...", "0Xabcd..." or "abcd...".
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation of ascii characters.</param>
        /// <returns>String built based on the byte array in the string containing ascii values.</returns>
        /// <remarks>Control characters are not processed and as soon as a \0 character is found the building of the string stops.</remarks>
        public static string GetStringFromByteArray(string byteArrayValue)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }

            var length = byteArrayValue.Length / 2;

            // ReSharper disable LocalizableElement
            if (byteArrayValue.StartsWith(@"0x", StringComparison.Ordinal) || byteArrayValue.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                length = (byteArrayValue.Length - 2) / 2;
            }

            return GetStringFromByteArray(byteArrayValue, 0, length);
        }

        /// <summary>
        /// Removes the optional hexadecimal prefix "0x" or "0X" from a byte array
        /// </summary>
        /// <param name="byteArrayValue">String containing the byte array representation.</param>
        /// <returns>String containing the byte array representation without the leading prefix "0x" or "0X".</returns>
        public static string RemoveHexPrefix(string byteArrayValue)
        {
            if (byteArrayValue == null)
            {
                throw new ArgumentNullException(@"byteArrayValue");
            }

            // ReSharper disable LocalizableElement
            if (byteArrayValue.StartsWith(@"0x", StringComparison.Ordinal) || byteArrayValue.StartsWith(@"0X", StringComparison.Ordinal))
            {
                // ReSharper restore LocalizableElement
                return byteArrayValue.Substring(2);
            }

            return byteArrayValue;
        }

        #endregion
    }
}
