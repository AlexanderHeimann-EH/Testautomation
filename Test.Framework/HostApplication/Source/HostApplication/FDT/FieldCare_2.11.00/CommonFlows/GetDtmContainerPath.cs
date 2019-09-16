// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System.Diagnostics.CodeAnalysis;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    /// <summary>
    ///     Description of GetDTMContainerPath.
    /// </summary>
    public class GetDtmContainerPath : IGetDtmContainerPath
    {
        #region Public Methods and Operators

        /// <summary>
        /// Provides the host application specific DTM container Ranorex path. 
        /// To work with the actual device functions in this framework, the path needs to include the container "ControlAXSourcingSite" for Device Care and the container "GuiTransparentProxy" for FieldCare.
        /// </summary>
        /// <returns>
        /// string: The DTM container path
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string Run()
        {
            return Execution.GetDtmContainerPath.GetMDIClientPath();
        }

        #endregion
    }
}