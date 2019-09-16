// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    /// Contains interfaces to access frame application area
    /// </summary>
    public class Execution
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
        /// Initializes static members of the <see cref="Execution"/> class. 
        ///     Connect interfaces to DLL version related implementation
        /// </summary>
        static Execution()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.MenuArea.Toolbar.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the open add device.
        /// </summary>
        public static IOpenAddDevice OpenAddDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenAddDevice") as IOpenAddDevice;
            }
        }

        /// <summary>
        /// Gets the open FDT print.
        /// </summary>
        public static IOpenFdtPrint OpenFdtPrint
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenFdtPrint") as IOpenFdtPrint;
            }
        }

        /// <summary>
        /// Gets the open print setup.
        /// </summary>
        public static IOpenPrintSetup OpenPrintSetup
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenPrintSetup") as IOpenPrintSetup;
            }
        }

        /// <summary>
        /// Gets the open project load.
        /// </summary>
        public static IOpenProjectLoad OpenProjectLoad
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenProjectLoad") as IOpenProjectLoad;
            }
        }

        /// <summary>
        /// Gets the open project new.
        /// </summary>
        public static IOpenProjectNew OpenProjectNew
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenProjectNew") as IOpenProjectNew;
            }
        }

        /// <summary>
        /// Gets the run connect.
        /// </summary>
        public static IRunConnect RunConnect
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunConnect") as IRunConnect;
            }
        }

        /// <summary>
        /// Gets the run create network.
        /// </summary>
        public static IRunCreateNetwork RunCreateNetwork
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunCreateNetwork") as IRunCreateNetwork;
            }
        }

        /// <summary>
        /// Gets the run delete device.
        /// </summary>
        public static IRunDeleteDevice RunDeleteDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunDeleteDevice") as IRunDeleteDevice;
            }
        }

        /// <summary>
        /// Gets the run disconnect.
        /// </summary>
        public static IRunDisconnect RunDisconnect
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunDisconnect") as IRunDisconnect;
            }
        }

        /// <summary>
        /// Gets the run FDT read from device.
        /// </summary>
        public static IRunFdtReadFromDevice RunFdtReadFromDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunFdtReadFromDevice") as IRunFdtReadFromDevice;
            }
        }

        /// <summary>
        /// Gets the run FDT write to device.
        /// </summary>
        public static IRunFdtWriteToDevice RunFdtWriteToDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunFdtWriteToDevice") as IRunFdtWriteToDevice;
            }
        }

        /// <summary>
        /// Gets the run project save.
        /// </summary>
        public static IRunProjectSave RunProjectSave
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunProjectSave") as IRunProjectSave;
            }
        }

        #endregion
    }
}