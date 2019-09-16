//------------------------------------------------------------------------------
// <copyright file="EvaluationInfoElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.07.2011
 * Time: 11:01 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of EvaluationInfoElements.
    /// </summary>
    public class EvaluationInfoElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluationInfoElements"/> class and determines the path of the mdi client
        /// </summary>
        public EvaluationInfoElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Evaluation Info]-Dialog.Button.Ok-object
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Ok
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.EvalutionInfo.OkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
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