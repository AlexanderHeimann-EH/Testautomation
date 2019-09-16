// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDeviceTypeInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides access to the Device Type Information texts in the about box module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides access to the Device Type Information texts in the about box module
    /// </summary>
    public class GetDeviceTypeInformation : IGetDeviceTypeInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Device Type Information -> Date
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Date()
        {
            string result;
            Element element = new MainViewElements().DeviceTypeInformationDate;
            if (element == null)
            {
                result = "The Device Type Information-> Date is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Device Type Information -> Name
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Name()
        {
            string result;
            Element element = new MainViewElements().DeviceTypeInformationName;
            if (element == null)
            {
                result = "The Device Type Information-> Name is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Device Type Information -> Version
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Version()
        {
            string result;
            Element element = new MainViewElements().DeviceTypeInformationVersion;
            if (element == null)
            {
                result = "The Device Type Information-> Version is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        #endregion
    }
}