// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FcDtmFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The fc dtm file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Model
{
    using System.IO;

    /// <summary>
    /// The fc dtm file.
    /// </summary>
    public class FcDtmFile
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FcDtmFile"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public FcDtmFile(string filePath)
        {
            this.CreateFcDtmFile(filePath);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The name.</value>
        [TranslatableDisplayName(@"NameOfTheFileToRestoreDtmDatasetFrom")]
        public string Name { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The create fc dtm file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void CreateFcDtmFile(string filePath)
        {
            this.Name = Path.GetFileName(filePath);
        }

        #endregion
    }
}
