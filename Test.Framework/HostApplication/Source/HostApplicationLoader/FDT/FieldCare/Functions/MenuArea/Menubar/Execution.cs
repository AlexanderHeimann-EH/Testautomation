// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Execution.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains interfaces to access frame application area
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

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
        /// </summary>
        static Execution()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceForFrames = Configuration.HostApplicationNamespace + ".Functions.MenuArea.Menubar.Execution";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close additional module.
        /// </summary>
        public static ICloseAdditionalModule CloseAdditionalModule
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".CloseAdditionalModule") as ICloseAdditionalModule;
            }
        }

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
        /// Gets the open additional functions.
        /// </summary>
        public static IOpenAdditionalFunctions OpenAdditionalFunctions
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenAdditionalFunctions") as IOpenAdditionalFunctions;
            }
        }

        /// <summary>
        /// Gets the open additional module.
        /// </summary>
        public static IOpenAdditionalModule OpenAdditionalModule
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenAdditionalModule") as IOpenAdditionalModule;
            }
        }

        /// <summary>
        /// Gets the open configuration.
        /// </summary>
        public static IOpenConfiguration OpenConfiguration
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenConfiguration") as IOpenConfiguration;
            }
        }

        /// <summary>
        /// Gets the open display DTM catalogue.
        /// </summary>
        public static IOpenDisplayDtmCatalogue OpenDisplayDtmCatalogue
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenDisplayDtmCatalogue") as IOpenDisplayDtmCatalogue;
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
        /// Gets the open find device.
        /// </summary>
        public static IOpenFindDevice OpenFindDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenFindDevice") as IOpenFindDevice;
            }
        }

        /// <summary>
        /// Gets the open find next device.
        /// </summary>
        public static IOpenFindNextDevice OpenFindNextDevice
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenFindNextDevice") as IOpenFindNextDevice;
            }
        }

        /// <summary>
        /// Gets the open function.
        /// </summary>
        public static IOpenFunction OpenFunction
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenFunction") as IOpenFunction;
            }
        }

        /// <summary>
        /// Gets the open offline parameterization.
        /// </summary>
        public static IOpenOfflineParameterization OpenOfflineParameterization
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenOfflineParameterization") as IOpenOfflineParameterization;
            }
        }

        /// <summary>
        /// Gets the open online parameterization.
        /// </summary>
        public static IOpenOnlineParameterization OpenOnlineParameterization
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenOnlineParameterization") as IOpenOnlineParameterization;
            }
        }

        /// <summary>
        /// Gets the open options.
        /// </summary>
        public static IOpenOptions OpenOptions
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenOptions") as IOpenOptions;
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
        /// Gets the open project save as.
        /// </summary>
        public static IOpenProjectSaveAs OpenProjectSaveAs
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenProjectSaveAs") as IOpenProjectSaveAs;
            }
        }

        /// <summary>
        /// Gets the open update DTM catalogue.
        /// </summary>
        public static IOpenUpdateDtmCatalogue OpenUpdateDtmCatalogue
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".OpenUpdateDtmCatalogue") as IOpenUpdateDtmCatalogue;
            }
        }

        /// <summary>
        /// Gets the run close all windows.
        /// </summary>
        public static IRunCloseAllWindows RunCloseAllWindows
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunCloseAllWindows") as IRunCloseAllWindows;
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
        /// Gets the run device function.
        /// </summary>
        public static IRunDeviceFunction RunDeviceFunction
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunDeviceFunction") as IRunDeviceFunction;
            }
        }

        /// <summary>
        /// Gets the run device operation.
        /// </summary>
        public static IRunDeviceOperation RunDeviceOperation
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunDeviceOperation") as IRunDeviceOperation;
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
        /// Gets the run DTM catalogue.
        /// </summary>
        public static IRunDtmCatalogue RunDtmCatalogue
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunDtmCatalogue") as IRunDtmCatalogue;
            }
        }

        /// <summary>
        /// Gets the run edit.
        /// </summary>
        public static IRunEdit RunEdit
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunEdit") as IRunEdit;
            }
        }

        /// <summary>
        /// Gets the run extras.
        /// </summary>
        public static IRunExtras RunExtras
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunExtras") as IRunExtras;
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
        /// Gets the run file.
        /// </summary>
        public static IRunFile RunFile
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunFile") as IRunFile;
            }
        }

        /// <summary>
        /// Gets the run frame exit.
        /// </summary>
        public static IRunFrameExit RunFrameExit
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunFrameExit") as IRunFrameExit;
            }
        }

        /// <summary>
        /// Gets the run help.
        /// </summary>
        public static IRunHelp RunHelp
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunHelp") as IRunHelp;
            }
        }

        /// <summary>
        /// Gets the run log off.
        /// </summary>
        public static IRunLogOff RunLogOff
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunLogOff") as IRunLogOff;
            }
        }

        /// <summary>
        /// Gets the run project close.
        /// </summary>
        public static IRunProjectClose RunProjectClose
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunProjectClose") as IRunProjectClose;
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

        /// <summary>
        /// Gets the run scanning tools.
        /// </summary>
        public static IRunScanningTools RunScanningTools
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunScanningTools") as IRunScanningTools;
            }
        }

        /// <summary>
        /// Gets the run select module.
        /// </summary>
        public static IRunSelectModule RunSelectModule
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunSelectModule") as IRunSelectModule;
            }
        }

        /// <summary>
        /// Gets the run tools.
        /// </summary>
        public static IRunTools RunTools
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunTools") as IRunTools;
            }
        }

        /// <summary>
        /// Gets the run view.
        /// </summary>
        public static IRunView RunView
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunView") as IRunView;
            }
        }

        /// <summary>
        /// Gets the run window.
        /// </summary>
        public static IRunWindow RunWindow
        {
            get
            {
                return LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceForFrames + ".RunWindow") as IRunWindow;
            }
        }

        #endregion
    }
}