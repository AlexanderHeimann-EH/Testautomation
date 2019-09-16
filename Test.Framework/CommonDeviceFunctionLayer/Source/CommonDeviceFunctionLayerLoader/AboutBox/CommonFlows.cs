// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.AboutBox
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.AboutBox.CommonFlows;

    /// <summary>
    /// The common flows.
    /// </summary>
    public class CommonFlows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace host application
        /// </summary>
        private static readonly string NamespaceAboutBox;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="CommonFlows"/> class. 
        /// </summary>
        static CommonFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.DeviceFunction;
                NamespaceAboutBox = Configuration.DeviceFunctionNamespace + ".AboutBox.CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close about box.
        /// </summary>
        /// <value>The close about box.</value>
        public static ICloseAboutBox CloseAboutBox
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceAboutBox + ".CloseAboutBox") as ICloseAboutBox;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                
            }
        }

        /// <summary>
        /// Gets the copy data.
        /// </summary>
        /// <value>The copy data.</value>
        public static ICopyData CopyData
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceAboutBox + ".CopyData") as ICopyData;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                   
            }
        }

        /// <summary>
        /// Gets the open about box.
        /// </summary>
        /// <value>The open about box.</value>
        public static IOpenAboutBox OpenAboutBox
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceAboutBox + ".OpenAboutBox") as IOpenAboutBox;
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