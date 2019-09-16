//------------------------------------------------------------------------------
// <copyright file="AboutBoxMainViewElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.AboutBox.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the GUI Elements of the About Box
    /// </summary>
    public class AboutBoxMainViewElements
    {
        #region members

        /// <summary>
        /// MDI client path 
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly AboutBoxMainViewRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBoxMainViewElements"/> class.
        /// </summary>
        public AboutBoxMainViewElements()
        {
            this.repository = AboutBoxMainViewRepository.Instance;
            this.mdiClientPath = Execution.GetDtmContainerPath.GetMDIClientPath();
        }

        #endregion

        #region properties

        /// <summary>
        ///     Gets Copy to clip board button 
        /// </summary>
        /// <returns>
        ///     <br>Button: if the button is found</br>
        ///     <br>Null: if the button is not found or an other error occurred</br>
        /// </returns>
        public Element ButtonCopyToClipboard
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.buttonCopyToClipboardInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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