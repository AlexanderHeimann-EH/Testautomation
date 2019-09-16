// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmDelete.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.11.2010
 * Time: 6:27 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.ConfirmDeleteMessage.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ConfirmDeleteMessage.Execution;

    using Ranorex;

    /// <summary>
    ///     This class describes dialog [Add Device] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class ConfirmDelete : MarshalByRefObject, IConfirmDelete
    {
        /// <summary>
        ///     Click [Confirm Delete]-Message.Yes
        /// </summary>
        /// <returns>
        ///     <br>Cell: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool Yes()
        {
            try
            {
                Button button = (new ConfirmDeleteMessageElements()).Yes;
                if (button != null)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Click [Confirm Delete]-Message.No
        /// </summary>
        /// <returns>
        ///     <br>Cell: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool No()
        {
            try
            {
                Button button = (new ConfirmDeleteMessageElements()).No;
                if (button != null)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}