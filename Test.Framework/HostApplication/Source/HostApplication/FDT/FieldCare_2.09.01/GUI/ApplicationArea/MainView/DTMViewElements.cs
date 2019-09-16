//------------------------------------------------------------------------------
// <copyright file="DTMViewElements.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView
{
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.Common;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of DTMView
    /// </summary>
    public class DtmViewElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly DtmViewPaths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DtmViewElements"/> class determines the path of the mdi client
        /// </summary>
        public DtmViewElements()
        {
            this.repository = DtmViewPaths.Instance;
        }

        /// <summary>
        /// Gets module area control
        /// </summary>
        public Element ModuleArea
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.DTMViewPaths.MDIClientInfo;
                Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets Return list of opened modules
        /// </summary>
        public IList<Form> Modules
        {
            get
            {
                RepoItemInfo elementInfo = this.repository.DTMViewPaths.MDIClientChildFormsInfo;
                IList<Form> moduleList = Host.Local.Find<Form>(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                if (moduleList.Count > 0)
                {
                    return moduleList;
                }

                return null;
            }
        }
    }
}