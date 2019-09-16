// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.EventList
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.EventList.CommonFlows;

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
        private static readonly string NamespaceEventList;

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
                NamespaceEventList = Configuration.DeviceFunctionNamespace + ".EventList.CommonFlows";

                // Functions

                //// Add here more interfaces
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close event list.
        /// </summary>
        /// <value>The close event list.</value>
        public static ICloseEventList CloseEventList
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEventList + ".CloseEventList") as ICloseEventList;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open event list.
        /// </summary>
        /// <value>The open event list.</value>
        public static IOpenEventList OpenEventList
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEventList + ".OpenEventList") as IOpenEventList;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the read events.
        /// </summary>
        /// <value>The read events.</value>
        public static IReadEvents ReadEvents
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEventList + ".ReadEvents") as IReadEvents;
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