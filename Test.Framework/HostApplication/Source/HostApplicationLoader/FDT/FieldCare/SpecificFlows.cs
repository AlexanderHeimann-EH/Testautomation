// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecificFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame Flows
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    /// <summary>
    ///     Contains interfaces to access frame Flows
    /// </summary>
    public class SpecificFlows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace communication.
        /// </summary>
        private static readonly string NamespaceForFrames;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="SpecificFlows"/> class.
        /// </summary>
        static SpecificFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".SpecificFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the create network.
        /// </summary>
        /// <value>The create network.</value>
        public static ISetNetworkTag SetNetworkTag
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".SetNetworkTag") as ISetNetworkTag;
            }
        }

        /// <summary>
        /// Gets the create network.
        /// </summary>
        /// <value>The create network.</value>
        public static ICreateNetwork CreateNetwork
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".CreateNetwork") as ICreateNetwork;
            }
        }

        /// <summary>
        /// Gets the FDT download.
        /// </summary>
        public static IFdtDownload FdtDownload
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".FdtDownload") as IFdtDownload;
            }
        }

        /// <summary>
        /// Gets the FDT print as PDF.
        /// </summary>
        public static IFdtPrintAsPdf FdtPrintAsPdf
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".FdtPrintAsPdf") as IFdtPrintAsPdf;
            }
        }

        /// <summary>
        /// Gets the FDT upload.
        /// </summary>
        public static IFdtUpload FdtUpload
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".FdtUpload") as IFdtUpload;
            }
        }

        /// <summary>
        /// Gets the focus network view.
        /// </summary>
        public static IFocusNetworkView FocusNetworkView
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".FocusNetworkView") as IFocusNetworkView;
            }
        }

        /// <summary>
        /// Gets the frame exit without saving.
        /// </summary>
        /// <value>The frame exit without saving.</value>
        public static IFrameExitWithoutSaving FrameExitWithoutSaving
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".FrameExitWithoutSaving") as IFrameExitWithoutSaving;
            }
        }

        /// <summary>
        /// Gets the project close.
        /// </summary>
        /// <value>The project close.</value>
        public static IProjectClose ProjectClose
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".ProjectClose") as IProjectClose;
            }
        }

        /// <summary>
        /// Gets the project load.
        /// </summary>
        /// <value>The project load.</value>
        public static IProjectLoad ProjectLoad
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".ProjectLoad") as IProjectLoad;
            }
        }

        /// <summary>
        /// Gets the project new empty.
        /// </summary>
        /// <value>The project new empty.</value>
        public static IProjectNewEmpty ProjectNewEmpty
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".ProjectNewEmpty") as IProjectNewEmpty;
            }
        }

        /// <summary>
        /// Gets the project save.
        /// </summary>
        /// <value>The project save.</value>
        public static IProjectSave ProjectSave
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".ProjectSave") as IProjectSave;
            }
        }

        /// <summary>
        /// Gets the project save as.
        /// </summary>
        /// <value>The project save as.</value>
        public static IProjectSaveAs ProjectSaveAs
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".ProjectSaveAs") as IProjectSaveAs;
            }
        }

        /// <summary>
        /// Gets the update DTM catalog.
        /// </summary>
        /// <value>The update DTM catalog.</value>
        public static IUpdateDtmCatalog UpdateDtmCatalog
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".UpdateDtmCatalog") as IUpdateDtmCatalog;
            }
        }

        /// <summary>
        /// Gets the update DTM catalog.
        /// </summary>
        /// <value>The update DTM catalog.</value>
        public static IPrintDeviceInformation PrintDeviceInformation
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".PrintDeviceInformation") as IPrintDeviceInformation;
            }
        }

        #endregion
    }
}