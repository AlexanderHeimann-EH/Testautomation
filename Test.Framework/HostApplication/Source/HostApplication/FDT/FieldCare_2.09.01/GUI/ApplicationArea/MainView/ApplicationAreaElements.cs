// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationAreaElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.08.2011
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides methods to get access to FieldCare 2.09.00 GUI-controls
    /// </summary>
    public class ApplicationAreaElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly NetworkViewPaths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationAreaElements"/> class and determines the path of the mdi client
        /// </summary>
        public ApplicationAreaElements()
        {
            this.repository = NetworkViewPaths.Instance;
        }
        
        #region Get GUI components

        /// <summary>
        /// Gets Frame Main Window
        /// </summary>
        public Form FrameMainWindow
        {
            get
            {
                try
                {
                    Form form;
                    RepoItemInfo elementInfo = this.repository.NetworkViewInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out form);
                    return form;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}