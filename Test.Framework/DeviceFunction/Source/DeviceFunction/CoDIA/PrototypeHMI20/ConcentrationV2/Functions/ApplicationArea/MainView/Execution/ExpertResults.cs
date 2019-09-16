// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpertResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for tab expert results within module concentration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for tab expert results within module concentration
    /// </summary>
    public class ExpertResults : IExpertResults
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the density calibration.
        /// </summary>
        /// <value>The density calibration.</value>
        public string DensityCalibration
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ExpertResultsElements()).ComboBoxDensityCalibration);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ExpertResultsElements()).ComboBoxDensityCalibration, value);
            }
        }

        /// <summary>
        /// Gets or sets the diagram.
        /// </summary>
        /// <value>The diagram.</value>
        public string Diagram
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ExpertResultsElements()).ComboBoxDiagram);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ExpertResultsElements()).ComboBoxDiagram, value);
            }
        }

        /// <summary>
        /// Gets or sets the field density adjustment.
        /// </summary>
        /// <value>The field density adjustment.</value>
        public string FieldDensityAdjustment
        {
            get
            {
                var result = string.Empty;
                var repository = new ExpertResultsElements();
                var yes = repository.ListItemFieldDensityYes;
                var no = repository.ListItemFieldDensityNo;

                if (yes == null || no == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Radio buttons for Field density adjustment are null.");
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
                var repository = new ExpertResultsElements();
                var yes = repository.ListItemFieldDensityYes;
                var no = repository.ListItemFieldDensityNo;

                if (yes == null || no == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Radio buttons for Field density adjustment are null.");
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

        /// <summary>
        /// Gets or sets the sensor.
        /// </summary>
        /// <value>The sensor.</value>
        public string Sensor
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ExpertResultsElements()).ComboBoxSensor);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new ExpertResultsElements()).ComboBoxSensor, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Get diagram image
        /// </summary>
        /// <returns>
        ///     <br>True: if screenshot could be made</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool GetDiagramImage()
        {
            Element element = (new ExpertResultsElements()).ImageDiagram;
            if (element != null)
            {
                Log.Screenshot();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element not available.");
            return false;
        }

        #endregion
    }
}