// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckAvailabilityOfTabPages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckAvailabilityOfTabPages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.GUI.ApplicationArea.MainView;

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
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Tab page CoefficientOverview' is null.");
                result = false;
            }
            else
            {
                string state = element.GetAttributeValueText("AccessibleState");
                if (state == "Unavailable")
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Coefficient Overview' is not available.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab page 'Coefficient Overview' is available.");
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