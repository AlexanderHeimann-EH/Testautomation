// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ReferenceValues.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.ApplicationArea.MainView;

    /// <summary>
    /// Class ReferenceValues.
    /// </summary>
    public class ReferenceValues : IReferenceValues
    {
        /// <summary>
        /// Gets or sets the linear expansion coefficient target.
        /// </summary>
        /// <value>The linear expansion coefficient target.</value>
        public string LinearExpansionCoefficientTarget
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldLinearExpansionCoefficientTarget);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldLinearExpansionCoefficientTarget, value);
            }
        }

        /// <summary>
        /// Gets or sets the linear expansion coefficient carrier.
        /// </summary>
        /// <value>The linear expansion coefficient carrier.</value>
        public string LinearExpansionCoefficientCarrier
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldLinearExpansionCoefficientCarrier);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldLinearExpansionCoefficientCarrier, value);
            }
        }

        /// <summary>
        /// Gets or sets the sugar expansion coefficient carrier.
        /// </summary>
        /// <value>The sugar expansion coefficient carrier.</value>
        public string SugarExpansionCoefficientCarrier
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldSugarExpansionCoefficientCarrier);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldSugarExpansionCoefficientCarrier, value);
            }
        }

        /// <summary>
        /// Gets or sets the sugar expansion coefficient target.
        /// </summary>
        /// <value>The sugar expansion coefficient target.</value>
        public string SugarExpansionCoefficientTarget
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldSugarExpansionCoefficientTarget);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldSugarExpansionCoefficientTarget, value);
            }
        }

        /// <summary>
        /// Gets or sets the reference temperature.
        /// </summary>
        /// <value>The reference temperature.</value>
        public string ReferenceTemperature
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldReferenceTemperature);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldReferenceTemperature, value);
            }
        }

        /// <summary>
        /// Gets or sets the reference density carrier fluid.
        /// </summary>
        /// <value>The reference density carrier fluid.</value>
        public string ReferenceDensityCarrierFluid
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldReferenceDensityCarrierFluid);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldReferenceDensityCarrierFluid, value);
            }
        }

        /// <summary>
        /// Gets or sets the reference density target fluid.
        /// </summary>
        /// <value>The reference density target fluid.</value>
        public string ReferenceDensityTargetFluid
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).EditFieldReferenceDensityTargetFluid);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).EditFieldReferenceDensityTargetFluid, value);
            }
        }

        /// <summary>
        /// Gets or sets the density unit.
        /// </summary>
        /// <value>The density unit.</value>
        public string DensityUnit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ReferenceValuesElements()).ComboBoxDensityUnit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ReferenceValuesElements()).ComboBoxDensityUnit, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the carrier.
        /// </summary>
        /// <value>The type of the carrier.</value>
        public string CarrierType
        {
            get
            {
                var result = string.Empty;
                var repository = new ReferenceValuesElements();
                var yes = repository.ListItemCarrierTypeYes;
                var no = repository.ListItemCarrierTypeNo;

                if (yes == null || no == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Radio buttons for carrier type selection are null.");
                }
                else if (yes.Selected)
                {
                    result = "Yes";
                }
                else
                {
                    result = "No";
                }

                return result;
            }

            set
            {
                var repository = new ReferenceValuesElements();
                var yes = repository.ListItemCarrierTypeYes;
                var no = repository.ListItemCarrierTypeNo;

                if (yes == null || no == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Radio buttons for carrier type selection are null.");
                }
                else if (value.ToLower() == "yes")
                {
                    yes.Click();
                }
                else
                {
                    no.Click();
                }
            }
        }
    }
}
