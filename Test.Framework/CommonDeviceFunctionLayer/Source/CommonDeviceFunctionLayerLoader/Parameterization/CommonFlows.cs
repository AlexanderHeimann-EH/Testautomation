// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.Parameterization
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.Parameterization.CommonFlows;

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
        private static readonly string NamespaceParameterization;

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
                NamespaceParameterization = Configuration.DeviceFunctionNamespace + ".Parameterization.CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close parameterization.
        /// </summary>
        /// <value>The close parameterization.</value>
        public static ICloseParameterization CloseParameterization
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceParameterization + ".CloseParameterization") as ICloseParameterization;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get parameter.
        /// </summary>
        /// <value>The get parameter.</value>
        public static IGetParameter GetParameter
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceParameterization + ".GetParameter") as IGetParameter;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open parameterization.
        /// </summary>
        /// <value>The open parameterization.</value>
        public static IOpenParameterization OpenParameterization
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceParameterization + ".OpenParameterization") as IOpenParameterization;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the set parameter.
        /// </summary>
        /// <value>The set parameter.</value>
        public static ISetParameter SetParameter
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceParameterization + ".SetParameter") as ISetParameter;
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