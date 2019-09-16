// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Submenu.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11.11.2010
 * Time: 10:41 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.GUI.MenuArea.MenuBar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Submenu contains methods to handle mouse movement in case of using submenus.
    /// </summary>
    public class Submenu
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Paths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Submenu"/> class and determines the path of the mdi client
        /// </summary>
        public Submenu()
        {
            this.repository = Paths.Instance;
        }

        /// <summary>
        ///     Moves mouse directly to right direction to avoid movement from one control's
        ///     center to another. In case of moving diagonally, this could cause focusing a
        ///     wrong control, if mouse is moved over an wrong controls edge.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool MoveToRight()
        {
            try
            {
                Container buttonContainer;
                RepoItemInfo repoItemInfo = this.repository.MenuContainerInfo;
                if (Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutMedium, out buttonContainer))
                {
                    buttonContainer.MoveTo(DefaultValues.locDefaultLocation);
                }

                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}