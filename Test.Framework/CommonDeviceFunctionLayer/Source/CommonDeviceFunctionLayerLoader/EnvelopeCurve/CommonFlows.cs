// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerLoader.EnvelopeCurve
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.EnvelopeCurve.CommonFlows;

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
        private static readonly string NamespaceEnvelopeCurve;

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
                NamespaceEnvelopeCurve = Configuration.DeviceFunctionNamespace + ".EnvelopeCurve.CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close envelope curve.
        /// </summary>
        /// <value>The close envelope curve.</value>
        public static ICloseEnvelopeCurve CloseEnvelopeCurve
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".CloseEnvelopeCurve") as ICloseEnvelopeCurve;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;                
            }
        }

        /// <summary>
        /// Gets the cyclic reading.
        /// </summary>
        /// <value>The cyclic reading.</value>
        public static ICyclicReading CyclicReading
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".CyclicReading") as ICyclicReading;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the load curves.
        /// </summary>
        /// <value>The load curves.</value>
        public static ILoadCurves LoadCurves
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".LoadCurves") as ILoadCurves;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open envelope curve.
        /// </summary>
        /// <value>The open envelope curve.</value>
        public static IOpenEnvelopeCurve OpenEnvelopeCurve
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".OpenEnvelopeCurve") as IOpenEnvelopeCurve;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the read curves.
        /// </summary>
        /// <value>The read curves.</value>
        public static IReadCurves ReadCurves
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".ReadCurves") as IReadCurves;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the save curves.
        /// </summary>
        /// <value>The save curves.</value>
        public static ISaveCurves SaveCurves
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceEnvelopeCurve + ".SaveCurves") as ISaveCurves;
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