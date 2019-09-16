// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TS_SetupDelivery.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Defines the TS_SetupDelivery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestLibrary
{
    using System.Windows.Forms;

    using TestLibraryCommon;

    /// <summary>
    /// The t s_ setup delivery.
    /// </summary>
    [TestScriptInformation(Enumerations.TestScript.TestStuite, "SetupDelivery", "AboutBox")]
    public class TS_SetupDelivery //: IRun
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            System.Diagnostics.Debug.Print("Hallo ich bin die Run Function!");
            MessageBox.Show("Run");

            return true;
        }
    }
}