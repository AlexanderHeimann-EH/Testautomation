// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.ApplicationArea.MainView;

    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of GetDTMContainerPath.
    /// </summary>
    public class GetDtmContainerPath : IGetDtmContainerPath
    {
        /// <summary>
        /// The DTM container.
        /// </summary>
        private readonly DtmContainer dtmContainer = DtmContainer.Instance;

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
            // return Execution.GetDtmContainerPath.GetMDIClientPath();
            try
            {
                RepoItemInfo infoMdiClient = this.dtmContainer.DTMContainerInfo;
                return infoMdiClient.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}