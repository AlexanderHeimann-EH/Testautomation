//------------------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.GUI.StatusArea.Stausbar
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of status bar elements 
    /// </summary>
    public class StatusbarElements
    {
        #region members

        /// <summary>
        /// MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        ///  Repository which will be used
        /// </summary>
        private readonly ChangeDeviceAddress.GUI.StatusArea.Statusbar.StatusbarElementsRepository repository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class. 
        /// </summary>
        public StatusbarElements()
        {
            this.mdiClientPath = Execution.GetDtmContainerPath.GetMDIClientPath();
            this.repository = ChangeDeviceAddress.GUI.StatusArea.Statusbar.StatusbarElementsRepository.Instance;
        }

        #region properties

        /// <summary>
        ///  Gets StatusArea -> Connection state
        /// </summary>
        /// <returns>
        ///     <br>string: if call worked</br>
        ///     <br>empty string: if an error occurred</br>
        /// </returns>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.StatusbarItemConnectionStateInfo;
                Host.Local.TryFindSingle(
                    this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                if (element == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text ConnectionState is null");
                    return string.Empty;
                }

                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        #endregion
    }
}