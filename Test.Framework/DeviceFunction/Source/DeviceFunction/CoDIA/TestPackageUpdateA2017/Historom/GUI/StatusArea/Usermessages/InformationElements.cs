// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.StatusArea.Usermessages
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
    ///     Provides access to the status information text in the down left corner of the HISTOROM module
    /// </summary>
    public class InformationElements
    {
        #region Fields

        /// <summary>
        /// The HISTOROM.
        /// </summary>
        private readonly UsermessageElements historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public InformationElements()
        {
            this.historom = UsermessageElements.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the module specific user messages displayed within the status bar
        /// </summary>
        public string InfoText
        {
            get
            {
                try
                {
                    Element text;
                    RepoItemInfo textInfo = this.historom.InfoTextInfo;
                    string pathToItem = this.mdiClientPath + textInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out text);
                    if (text == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "User messages info text is null");
                        return null;
                    }

                    return text.GetAttributeValueText("AccessibleValue");
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return string.Empty;
                }
            }
        }

        #endregion
    }
}