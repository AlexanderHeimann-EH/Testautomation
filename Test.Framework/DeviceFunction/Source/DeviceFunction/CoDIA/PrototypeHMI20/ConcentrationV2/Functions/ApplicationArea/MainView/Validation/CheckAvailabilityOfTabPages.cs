// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckAvailabilityOfTabPages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckAvailabilityOfTabPages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class CheckAvailabilityOfTabPages.
    /// </summary>
    public class CheckAvailabilityOfTabPages : ICheckAvailabilityOfTabPages
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether base settings tab page is available.
        /// </summary>
        /// <returns><c>true</c> if base settings tab page is available; otherwise, <c>false</c>.</returns>
        public bool IsBaseSettingsTabPageAvailable()
        {
            bool result = true;
            Element element = new ContainerElements().TabPageBaseSettings;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page BaseSettings' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Base Settings' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Base Settings' is available.");
                }
            }

            return result;
        }

        /// <summary>
        /// is the reference values tab page available.
        /// </summary>
        /// <returns><c>true</c> if true, <c>false</c> otherwise.</returns>
        public bool IsReferenceValuesTabPageAvailable()
        {
            bool result = true;
            Element element = new ContainerElements().TabPageReferenceValues;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page ReferenceValues' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Reference Values' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Reference Values' is available.");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether liquid properties tab page is available.
        /// </summary>
        /// <returns><c>true</c> if liquid properties tab page is available; otherwise, <c>false</c>.</returns>
        public bool IsLiquidPropertiesTabPageAvailable()
        {
            bool result = true;
            Element element = new ContainerElements().TabPageLiquidProperties;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page LiquidProperties' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Liquid Properties' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Liquid Properties' is available.");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether coefficient overview tab page is available.
        /// </summary>
        /// <returns><c>true</c> if coefficient overview tab page is available; otherwise, <c>false</c>.</returns>
        public bool IsCoefficientOverviewTabPageAvailable()
        {
            bool result = true;
            Element element = new ContainerElements().TabPageCoefficientsOverview;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page CoefficientsOverview' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Coefficienst Overview' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Coefficients Overview' is available.");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether expert results tab page is available.
        /// </summary>
        /// <returns><c>true</c> if expert results tab page is available; otherwise, <c>false</c>.</returns>
        public bool IsExpertResultsTabPageAvailable()
        {
            bool result = true;
            Element element = new ContainerElements().TabPageCoefficientsOverview;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page ExpertResults' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Expert Results' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Expert Results' is available.");
                }
            }

            return result;
        }

        #endregion
    }
}