// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureReferenceValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureReferenceValues : IConfigureReferenceValues
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs the specified carrier type.
        /// </summary>
        /// <param name="carrierType">Type of the carrier.</param>
        /// <param name="referenceTemperature">The reference temperature.</param>
        /// <param name="densityUnit">The density unit.</param>
        /// <param name="carrierLinearExpansionCoefficient">The carrier linear expansion coefficient.</param>
        /// <param name="carrierSquareExpansionCoefficientTarget">The carrier square expansion coefficient target.</param>
        /// <param name="carrierReferenceDensity">The carrier reference density.</param>
        /// <param name="targetLinearExpansionCoefficient">The target linear expansion coefficient.</param>
        /// <param name="targetSquareExpansionCoefficientTarget">The target square expansion coefficient target.</param>
        /// <param name="targetReferenceDensity">The target reference density.</param>
        /// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        public bool Run(string carrierType, string referenceTemperature, string densityUnit, string carrierLinearExpansionCoefficient, string carrierSquareExpansionCoefficientTarget, string carrierReferenceDensity, string targetLinearExpansionCoefficient, string targetSquareExpansionCoefficientTarget, string targetReferenceDensity)
        {
            bool result = true;
            var referenceValues = new ReferenceValues();

            if ((new Container()).SelectTabReferenceValues() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Base settings].");
            }
            else
            {
                if (this.IsValid(carrierType))
                {
                    referenceValues.CarrierType = carrierType;

                    if (referenceValues.CarrierType != carrierType)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring reference values [Water Based] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.CarrierType + " != " + carrierType);
                        result = false;
                    }
                }

                if (this.IsValid(referenceTemperature))
                {
                    referenceValues.ReferenceTemperature = referenceTemperature;

                    if (referenceValues.ReferenceTemperature != referenceTemperature)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Liquid Type] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.ReferenceTemperature + " != " + referenceTemperature);
                        result = false;
                    }
                }

                if (this.IsValid(densityUnit))
                {
                    referenceValues.DensityUnit = densityUnit;

                    if (referenceValues.DensityUnit != densityUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [User Profile] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.DensityUnit + " != " + densityUnit);
                        result = false;
                    }
                }

                if (this.IsValid(carrierLinearExpansionCoefficient))
                {
                    referenceValues.LinearExpansionCoefficientCarrier = carrierLinearExpansionCoefficient;

                    if (referenceValues.LinearExpansionCoefficientCarrier != carrierLinearExpansionCoefficient)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Reference Temperature] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.LinearExpansionCoefficientCarrier + " != " + carrierLinearExpansionCoefficient);
                        result = false;
                    }
                }

                if (this.IsValid(carrierSquareExpansionCoefficientTarget))
                {
                    referenceValues.SugarExpansionCoefficientCarrier = carrierSquareExpansionCoefficientTarget;

                    if (referenceValues.SugarExpansionCoefficientCarrier != carrierSquareExpansionCoefficientTarget)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Mineral Content] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.SugarExpansionCoefficientCarrier + " != " + carrierSquareExpansionCoefficientTarget);
                        result = false;
                    }
                }

                if (this.IsValid(carrierReferenceDensity))
                {
                    referenceValues.ReferenceDensityCarrierFluid = carrierReferenceDensity;

                    if (referenceValues.ReferenceDensityCarrierFluid != carrierReferenceDensity)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Mineral Content] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.ReferenceDensityCarrierFluid + " != " + carrierReferenceDensity);
                        result = false;
                    }
                }

                if (this.IsValid(targetLinearExpansionCoefficient))
                {
                    referenceValues.LinearExpansionCoefficientTarget = targetLinearExpansionCoefficient;

                    if (referenceValues.LinearExpansionCoefficientTarget != targetLinearExpansionCoefficient)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Reference Temperature] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.LinearExpansionCoefficientTarget + " != " + targetLinearExpansionCoefficient);
                        result = false;
                    }
                }

                if (this.IsValid(targetSquareExpansionCoefficientTarget))
                {
                    referenceValues.SugarExpansionCoefficientTarget = targetSquareExpansionCoefficientTarget;

                    if (referenceValues.SugarExpansionCoefficientTarget != targetSquareExpansionCoefficientTarget)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Mineral Content] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.SugarExpansionCoefficientTarget + " != " + targetSquareExpansionCoefficientTarget);
                        result = false;
                    }
                }

                if (this.IsValid(targetReferenceDensity))
                {
                    referenceValues.ReferenceDensityTargetFluid = targetReferenceDensity;

                    if (referenceValues.ReferenceDensityTargetFluid != targetReferenceDensity)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Mineral Content] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceValues.ReferenceDensityTargetFluid + " != " + targetReferenceDensity);
                        result = false;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValid(string value)
        {
            if (value.Length > 0 && !value.Equals(" "))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}