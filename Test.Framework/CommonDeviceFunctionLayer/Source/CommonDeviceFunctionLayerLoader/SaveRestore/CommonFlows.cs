// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.SaveRestore
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.SaveRestore.CommonFlows;

    /// <summary>
    /// The common flows.
    /// </summary>
    public class CommonFlows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace host application.
        /// </summary>
        private static readonly string NamespaceSaveRestore;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="CommonFlows"/> class. 
        /// </summary>
        static CommonFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceSaveRestore = Configuration.HostApplicationNamespace + ".SaveRestore.CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close save restore.
        /// </summary>
        /// <value>The close save restore.</value>
        public static ICloseSaveRestore CloseSaveRestore
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".CloseSaveRestore") as ICloseSaveRestore;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open save restore.
        /// </summary>
        /// <value>The open save restore.</value>
        public static IOpenSaveRestore OpenSaveRestore
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".OpenSaveRestore") as IOpenSaveRestore;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the restore with download.
        /// </summary>
        /// <value>The restore with download.</value>
        public static IRestoreWithDownload RestoreWithDownload
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".RestoreWithDownload") as IRestoreWithDownload;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the restore without download.
        /// </summary>
        /// <value>The restore without download.</value>
        public static IRestoreWithoutDownload RestoreWithoutDownload
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".RestoreWithoutDownload") as IRestoreWithoutDownload;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the save with upload.
        /// </summary>
        /// <value>The save with upload.</value>
        public static ISaveWithUpload SaveWithUpload
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".SaveWithUpload") as ISaveWithUpload;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the save without upload.
        /// </summary>
        /// <value>The save without upload.</value>
        public static ISaveWithoutUpload SaveWithoutUpload
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceSaveRestore + ".SaveWithoutUpload") as ISaveWithoutUpload;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        #endregion
    }
}