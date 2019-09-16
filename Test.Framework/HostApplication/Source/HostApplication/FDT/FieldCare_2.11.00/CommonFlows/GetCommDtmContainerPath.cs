// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCommDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetCommDtmContainerPath.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System.Diagnostics.CodeAnalysis;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class GetCommDtmContainerPath.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class GetCommDtmContainerPath : IGetCommDtmContainerPath
    {
        #region Public Methods and Operators

        /// <summary>
        /// Provides the host application specific CommDm container Ranorex path.         
        /// </summary>
        /// <returns>
        /// string: The CommDtm container path
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string Run()
        {
            return Execution.GetCommDtmContainerPath.Run();
        }

        #endregion
    }
}