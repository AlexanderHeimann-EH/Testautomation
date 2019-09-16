//------------------------------------------------------------------------------
// <copyright file="WriteToDeviceSuccess.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 20.04.2012
 * Time: 6:27 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.WriteToDeviceSuccessMessage.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.WriteToDeviceSuccessMessage.Execution;

    using Ranorex;

    /// <summary>
    ///     This class describes dialog [Write to device success] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class WriteToDeviceSuccess : MarshalByRefObject, IWriteToDeviceSuccess
    {
        /// <summary>
        ///     Click [Write to device success]-Message.Ok
        /// </summary>
        /// <returns>
        ///     <br>Cell: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool OK()
        {
            try
            {
                Button button = (new WriteToDeviceSuccessMessageElements()).Ok;
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