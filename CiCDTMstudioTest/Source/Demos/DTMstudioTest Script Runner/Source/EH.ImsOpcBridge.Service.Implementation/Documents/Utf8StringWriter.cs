// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utf8StringWriter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the UTF-8 string writer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Documents
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Implements the UTF-8 string writer.
    /// </summary>
    internal class Utf8StringWriter : StringWriter
    {
        #region Overriden

        /// <summary>
        /// Gets the <see cref="T:System.Text.Encoding" /> in which the output is written.
        /// </summary>
        /// <value>The encoding.</value>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        #endregion
    }
}
