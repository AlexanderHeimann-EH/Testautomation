// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoefficientsOverviewElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to coefficients overview controls within module concentration
    /// </summary>
    public class CoefficientsOverviewElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client path
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoefficientsOverviewElements"/> class.
        /// </summary>
        public CoefficientsOverviewElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text calculated a 0.
        /// </summary>
        public Element TextCalculatedA0
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedA0 = this.concentration.CoefficientsOverview.textCalculatedA0Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedA0.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text calculated a 1.
        /// </summary>
        public Element TextCalculatedA1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedA1 = this.concentration.CoefficientsOverview.textCalculatedA1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedA1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text calculated a 2.
        /// </summary>
        public Element TextCalculatedA2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedA2 = this.concentration.CoefficientsOverview.textCalculatedA2Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedA2.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text calculated a 3. 
        /// </summary>
        public Element TextCalculatedA3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedA3 = this.concentration.CoefficientsOverview.textCalculatedA3Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedA3.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the text calculated a 4.
        /// </summary>
        public Element TextCalculatedA4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedA4 = this.concentration.CoefficientsOverview.textCalculatedA4Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedA4.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text calculated b 1.
        /// </summary>
        public Element TextCalculatedB1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedB1 = this.concentration.CoefficientsOverview.textCalculatedB1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedB1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text calculated b 2.
        /// </summary>
        public Element TextCalculatedB2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedB2 = this.concentration.CoefficientsOverview.textCalculatedB2Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedB2.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text calculated b 3.
        /// </summary>
        public Element TextCalculatedB3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculatedB3 = this.concentration.CoefficientsOverview.textCalculatedB3Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculatedB3.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device a 0.
        /// </summary>
        public Element TextFromDeviceA0
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceA0 = this.concentration.CoefficientsOverview.textFromDeviceA0Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceA0.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device a 1.
        /// </summary>
        public Element TextFromDeviceA1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceA1 = this.concentration.CoefficientsOverview.textFromDeviceA1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceA1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device a 2.
        /// </summary>
        public Element TextFromDeviceA2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceA2 = this.concentration.CoefficientsOverview.textFromDeviceA2Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceA2.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device a 3.
        /// </summary>
        public Element TextFromDeviceA3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceA3 = this.concentration.CoefficientsOverview.textFromDeviceA3Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceA3.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device a 4.
        /// </summary>
        public Element TextFromDeviceA4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceA4 = this.concentration.CoefficientsOverview.textFromDeviceA4Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceA4.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device b 1.
        /// </summary>
        public Element TextFromDeviceB1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceB1 = this.concentration.CoefficientsOverview.textFromDeviceB1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceB1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device b 2.
        /// </summary>
        public Element TextFromDeviceB2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceB2 = this.concentration.CoefficientsOverview.textFromDeviceB2Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceB2.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the text from device b 3.
        /// </summary>
        public Element TextFromDeviceB3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoFromDeviceB3 = this.concentration.CoefficientsOverview.textFromDeviceB3Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoFromDeviceB3.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}