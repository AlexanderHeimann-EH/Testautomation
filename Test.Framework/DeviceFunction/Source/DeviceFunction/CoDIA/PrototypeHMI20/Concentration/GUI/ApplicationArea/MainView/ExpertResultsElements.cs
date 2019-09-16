// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpertResultsElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to tab expert results within module concentration
    /// </summary>
    public class ExpertResultsElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client path
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        ///  MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpertResultsElements"/> class.
        /// </summary>
        public ExpertResultsElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the combo box diagram. 
        /// </summary>
        public Element ComboBoxDiagram
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoComboboxDiagram = this.concentration.ExpertResults.comboBoxDiagramInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoComboboxDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the image diagram.
        /// </summary>
        public Element ImageDiagram
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoImageDiagram = this.concentration.ExpertResults.imageDiagramInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoImageDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}