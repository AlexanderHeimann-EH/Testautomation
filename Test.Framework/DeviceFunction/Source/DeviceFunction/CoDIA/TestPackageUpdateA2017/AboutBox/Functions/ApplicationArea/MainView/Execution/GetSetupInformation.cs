// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetSetupInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides access to the Setup Information texts in the about box module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides access to the Setup Information texts in the about box module
    /// </summary>
    public class GetSetupInformation : IGetSetupInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Setup Information -> Manufacturer
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Manufacturer()
        {
            string result;
            Element element = new MainViewElements().SetupInformationManufacturer;
            if (element == null)
            {
                result = "The Setup Information-> Manufacturer is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Setup Information -> Name
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Name()
        {
            string result;
            Element element = new MainViewElements().SetupInformationName;
            if (element == null)
            {
                result = "The Setup Information-> Name is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Setup Information -> Version
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Version()
        {
            string result;
            Element element = new MainViewElements().SetupInformationVersion;
            if (element == null)
            {
                result = "The Setup Information-> Version is not accessible";
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