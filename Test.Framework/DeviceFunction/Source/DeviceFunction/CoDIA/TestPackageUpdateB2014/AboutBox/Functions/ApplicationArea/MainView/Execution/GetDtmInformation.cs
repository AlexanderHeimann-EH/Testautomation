// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDtmInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides access to the DTM Information texts in the about box module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides access to the DTM Information texts in the about box module
    /// </summary>
    public class GetDtmInformation : IGetDtmInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// DTM Information -> Date
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Date()
        {
            string result;
            Element element = new MainViewElements().DtmInformationDate;
            if (element == null)
            {
                result = "The DTM Information-> Date is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// DTM Information -> Name
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Name()
        {
            string result;
            Element element = new MainViewElements().DtmInformationName;
            if (element == null)
            {
                result = "The DTM Information-> Name is not accessible";
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// DTM Information -> Version
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Version()
        {
            string result;
            Element element = new MainViewElements().DtmInformationVersion;
            if (element == null)
            {
                result = "The DTM Information-> Version is not accessible";
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