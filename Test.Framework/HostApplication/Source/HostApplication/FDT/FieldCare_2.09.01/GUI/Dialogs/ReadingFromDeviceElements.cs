//------------------------------------------------------------------------------
// <copyright file="ReadingFromDeviceElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 11.03.2011
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class describes [Project Browser] in an abstract way.
    ///     Elements could be accessed for using.
    /// </summary>
    public class ReadingFromDeviceElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadingFromDeviceElements"/> class and determines the path of the mdi client
        /// </summary>
        public ReadingFromDeviceElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Reading from device]-Dialog.Button.Cancel-object
        ///     It is needed to cancel upload process
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Cancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.ReadingFromDevice.CancelInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
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
        ///     Gets [Reading from device]-Dialog.Button.ProgressBar-object
        ///     It is needed to get state of upload process
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public ProgressBar ProgressTop
        {
            get
            {
                try
                {
                    ProgressBar progressBar;
                    RepoItemInfo elementInfo = this.repository.ReadingFromDevice.ProgressOnTopInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out progressBar);
                    return progressBar;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Reading from device]-Dialog.Button.ProgressBar-object
        ///     It is needed to get state of upload process
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public ProgressBar ProgressBottom
        {
            get
            {
                try
                {
                    ProgressBar progressBar;
                    RepoItemInfo elementInfo = this.repository.ReadingFromDevice.ProgressOnBottomInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out progressBar);
                    return progressBar;
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