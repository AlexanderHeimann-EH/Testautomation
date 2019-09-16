// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCommDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetCommDtmContainerPath.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core.Repository;

    /// <summary>
    /// Class GetCommDtmContainerPath.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class GetCommDtmContainerPath : IGetCommDtmContainerPath
    {
        #region Fields

        /// <summary>
        /// Create an instance of the repository which will be used
        /// </summary>
        private readonly DtmContainer dtmContainerRepository = DtmContainer.Instance;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the path of the CommDtm Container of the actually used frame
        /// </summary>
        /// <returns>
        ///     string: with the absolute path of the CommDtm Container
        ///     null: if an error occurred
        /// </returns>
        public string Run()
        {
            try
            {
                RepoItemInfo info = this.dtmContainerRepository.CommDTMContainerInfo;
                return info.AbsolutePath.ToString();
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        #endregion
    }
}