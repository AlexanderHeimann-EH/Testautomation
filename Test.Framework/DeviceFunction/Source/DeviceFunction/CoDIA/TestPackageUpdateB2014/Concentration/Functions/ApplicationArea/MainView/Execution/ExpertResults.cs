// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpertResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for tab expert results within module concentration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.ApplicationArea.MainView;

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
        public string DensityCalibration { get; set; }

        /// <summary>
        ///  Gets property diagram
        /// </summary>
        public string Diagram
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new ExpertResultsElements()).ComboBoxDiagram);
            }
        }

        /// <summary>
        /// Gets or sets the field density adjustment.
        /// </summary>
        public string FieldDensityAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the sensor.
        /// </summary>
        public string Sensor { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets or sets the diagram.
        /// </summary>
        string IExpertResults.Diagram { get; set; }

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