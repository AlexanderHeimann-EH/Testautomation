//-----------------------------------------------------------------------
// <copyright file="Encription.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <author>Emilio Schiavi</author>
//-----------------------------------------------------------------------

namespace EH.ImsOpcBridge.Common.Serialization
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>
    /// Class to encrypt / decrypt messages.
    /// </summary>
    public class Encription
    {
        #region Private Fields
        /// <summary>
        /// The private key.
        /// </summary>
        private byte[] key = new byte[] { 27, 9, 174, 177, 118, 105, 228, 208, 228, 240, 190, 216, 93, 2, 22, 190, 77, 175, 106, 47, 97, 82, 238, 220, 193, 181, 85, 118, 12, 211, 17, 107 };

        /// <summary>
        /// The initialization vector.
        /// </summary>
        private byte[] iv = new byte[] { 19, 82, 13, 27, 3, 218, 219, 125, 186, 180, 144, 220, 236, 26, 119, 120 };
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the private key.
        /// </summary>
        /// <value>The private key.</value>
        public byte[] Key
        {
            get { return this.key; }
        }

        /// <summary>
        /// Gets the initialization vector.
        /// </summary>
        /// <value>The initialization vector.</value>
        public byte[] IV
        {
            get { return this.iv; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Encrypts the specified input string.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>The encrypted string.</returns>
        public string Encrypt(string inputString)
        {
            try
            {
                byte[] encrypted = this.EncryptStringToBytes(inputString);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Decrypts the specified input string.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>The decrypted string</returns>
        public string Decrypt(string inputString)
        {
            try
            {
                byte[] encrypted = Convert.FromBase64String(inputString);
                return this.DecryptStringFromBytes(encrypted);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Encrypts the string to bytes.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>The encrypted byte array.</returns>
        private byte[] EncryptStringToBytes(string plainText)
        {
            byte[] encrypted;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = this.Key;
                rijAlg.IV = this.IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Write all data to the stream.
                            sw.Write(plainText);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decrypts the string from bytes.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns>The decrypted string.</returns>
        private string DecryptStringFromBytes(byte[] cipherText)
        {
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = this.Key;
                rijAlg.IV = this.IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = sr.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        #endregion
    }
}
