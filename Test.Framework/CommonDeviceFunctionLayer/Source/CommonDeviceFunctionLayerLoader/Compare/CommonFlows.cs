// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.Compare
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.Compare.CommonFlows;

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
        private static readonly string NamespaceCompare;

        #endregion

        // Add here more interfaces definitions
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="CommonFlows"/> class. 
        /// </summary>
        static CommonFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.DeviceFunction;
                NamespaceCompare = Configuration.DeviceFunctionNamespace + ".Compare.CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close compare.
        /// </summary>
        /// <value>The close compare.</value>
        public static ICloseCompare CloseCompare
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCompare + ".CloseCompare") as ICloseCompare;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                
            }
        }

        /// <summary>
        /// Gets the compare data.
        /// </summary>
        /// <value>The compare data.</value>
        public static ICompareData CompareData
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCompare + ".CompareData") as ICompareData;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                
            }
        }

        /// <summary>
        /// Gets the open compare.
        /// </summary>
        /// <value>The open compare.</value>
        public static IOpenCompare OpenCompare
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceCompare + ".OpenCompare") as IOpenCompare;
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