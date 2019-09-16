//------------------------------------------------------------------------------
// <copyright file="DiagramElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.GUI.ApplicationArea.MainView
{
    using System;
    using System.Drawing;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides elements of area Diagram within module Envelope Curve
    /// </summary>
    public class DiagramElements
    {
        #region members

        /// <summary>
        /// The controls.
        /// </summary>
        private readonly Controls controls;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElements"/> class.
        /// </summary>
        public DiagramElements()
        {
            this.controls = Controls.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Get GUI components

        /// <summary>
        /// Gets the progress bar area.
        /// </summary>
        public Container ProgressbarArea
        {
            get
            {
                try
                {
                    Container container;
                    RepoItemInfo containerInfo = this.controls.ProgressbarContainerInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + containerInfo.AbsolutePath, DefaultValues.iTimeoutLong, out container);
                    return container;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the curve area.
        /// </summary>
        public Container CurveArea
        {
            get
            {
                try
                {
                    Container container;
                    RepoItemInfo containerInfo = this.controls.CurveContainerInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + containerInfo.AbsolutePath, DefaultValues.iTimeoutLong, out container);
                    return container;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the curve data number.
        /// </summary>
        public Element CurveDataNumber
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.controls.CurveDataNumberInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region Get GUI Samples

        /// <summary>
        /// Gets the progress bar.
        /// </summary>
        public Bitmap Progressbar
        {
            get
            {
                try
                {
                    return Diagram.progressbar;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the grid yellow.
        /// </summary>
        public Bitmap GridYellow
        {
            get
            {
                try
                {
                    return Diagram.grid_yellow_small;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the grid green.
        /// </summary>
        public Bitmap GridGreen
        {
            get
            {
                try
                {
                    return Diagram.grid_green_small;
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