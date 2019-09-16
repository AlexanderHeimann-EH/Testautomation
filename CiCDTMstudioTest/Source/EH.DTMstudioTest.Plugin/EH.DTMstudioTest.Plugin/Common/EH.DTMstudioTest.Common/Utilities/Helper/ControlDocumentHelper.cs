// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlDocumentHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Helper
{
    using System.IO;

    /// <summary>
    /// The control document helper.
    /// </summary>
    public class ControlDocumentHelper
    {
        /// <summary>
        /// The control document name.
        /// </summary>
        private const string ControlDocumentName = @"\ControlDocument.xml";

        /// <summary>
        /// The get control document.
        /// </summary>
        /// <param name="controlDocument">
        /// The control Document.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetControlDocument(string controlDocument)
        {
            // if no control document within arguments, use default control document
            if (controlDocument.Equals(string.Empty))
            {
                controlDocument = Directory.GetCurrentDirectory() + ControlDocumentName;

                // System.Windows.Forms.MessageBox.Show("XML: " + controlDocument);
            }
            else if (controlDocument.Contains(":"))
            {
                // if absolute path and control document is within arguments, check for existence
                // if control document does not exist on given location, use default control document
                if (!File.Exists(controlDocument))
                {
                    controlDocument = Directory.GetCurrentDirectory() + @"\" + ControlDocumentName;
                    
                    // System.Windows.Forms.MessageBox.Show("XML: " + controlDocument);
                }
            }
            else
            {
                controlDocument = Directory.GetCurrentDirectory() + @"\" + controlDocument;

                // System.Windows.Forms.MessageBox.Show("XML: " + controlDocument);
            }

            return controlDocument;
        }
    }
}
