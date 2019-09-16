//------------------------------------------------------------------------------
// <copyright file="NetworkViewElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 03.12.2010
 * Time: 7:15 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of NetworkView
    /// </summary>
    public class NetworkViewElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly NetworkViewPaths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkViewElements"/> class and determines the path of the mdi client
        /// </summary>
        public NetworkViewElements()
        {
            this.repository = NetworkViewPaths.Instance;
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        public Element Area
        {
            get
            {
                try 
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.NetworkViewInfo;
                    System.Diagnostics.Debug.Print(elementInfo.AbsolutePath.ToString());
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                } 
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}