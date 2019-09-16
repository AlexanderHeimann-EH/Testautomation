// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDialogResult.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class file dialog result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Interfaces
{
    using System.IO;

    /// <summary>
    /// Class FileDialogResult
    /// </summary>
    public class FileDialogResult
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDialogResult"/> class.
        /// </summary>
        /// <param name="resultMessage">The result message.</param>
        /// <param name="fileInfo">The file info.</param>
        public FileDialogResult(ResultMessage resultMessage, FileInfo fileInfo)
        {
            this.ResultMessage = resultMessage;
            this.FileInfo = fileInfo;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the file info.
        /// </summary>
        /// <value>The file info.</value>
        public FileInfo FileInfo { get; private set; }

        /// <summary>
        /// Gets the result message.
        /// </summary>
        /// <value>The result message.</value>
        public ResultMessage ResultMessage { get; private set; }

        #endregion
    }
}