//------------------------------------------------------------------------------
// <copyright file="ActionElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EventList.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods to get access to controls of action area within module event list
    /// </summary>
    public class ActionElements
    {
        #region members

        /// <summary>
        /// The event list.
        /// </summary>
        private readonly Controls eventList;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public ActionElements()
        {
            this.eventList = Controls.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets button Refresh
        /// </summary>
        public Button Refresh
        {
            get
            {
                try
                {
                    Button button;
                    string basePath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
                    RxPath pathToItem = this.eventList.RefreshInfo.AbsolutePath;
                    string path = basePath + pathToItem;
                    Host.Local.TryFindSingle(path, DefaultValues.iTimeoutLong, out button);
                    if (button != null)
                    {
                        return button;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button not found");
                    return null;
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