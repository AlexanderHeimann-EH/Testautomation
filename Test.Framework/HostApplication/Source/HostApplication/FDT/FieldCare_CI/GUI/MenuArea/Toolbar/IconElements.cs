// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.02.2011
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     EnvCurIconElements contains methods to get access to [Envelope Curve] toolbar-icons.
    /// </summary>
    public class IconElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Paths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconElements"/> class which will be used and determines the path of the mdi client
        /// </summary>
        public IconElements()
        {
            this.repository = Paths.Instance;
        }

        #region IconXYZ_Colored

        /// <summary>
        /// Gets Toolbar -> ConnectedColored
        /// </summary>
        public Button ConnectedColored
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo repoItemInfo = this.repository.ConnectedInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Toolbar -> DisconnectedColored
        /// </summary>
        public Button DisconnectedColored
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo repoItemInfo = this.repository.DisconnectedInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Toolbar -> DeviceFunction
        /// </summary>
        public MenuItem DeviceFunctionColored
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo repoItemInfo = this.repository.DeviceFunctionsInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets toolbar -> Create Network
        /// </summary>
        public Button CreateNetwork
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo repoItemInfo = this.repository.CreateNetworkInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
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