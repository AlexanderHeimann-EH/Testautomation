// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceDataReceiver.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ServiceDataReceiver
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class ServiceDataReceiver
    /// </summary>
    public class ServiceDataReceiver : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="ServiceDataReceiver"/> class.
        /// </summary>
        ~ServiceDataReceiver()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when [configuration response].
        /// </summary>
        public event EventHandler<ConfigurationDataEventArgs> ConfigurationResponse;

        /// <summary>
        /// Occurs when [read opc address space response].
        /// </summary>
        public event EventHandler<AddressSpaceDataEventArgs> ReadOpcAddressSpaceResponse;
        
        /// <summary>
        /// Occurs when [opc servers response].
        /// </summary>
        public event EventHandler<ServerDataEventArgs> OpcServersResponse;

        /// <summary>
        /// Occurs when [runtime measurements response].
        /// </summary>
        public event EventHandler<RuntimeMeasurementsDataEventArgs> RuntimeMeasurementsResponse;

        /// <summary>
        /// Occurs when [service error response].
        /// </summary>
        public event EventHandler<ServiceErrorDataEventArgs> ServiceErrorResponse;

        /// <summary>
        /// Occurs when [service error response].
        /// </summary>
        public event EventHandler<EventArgs> SaveConfigurationResponse;
        
        /// <summary>
        /// Occurs when [fis registration response].
        /// </summary>
        public event EventHandler<EventArgs> FisRegistrationResponse;
        
        /// <summary>
        /// Occurs when [diagnostics response].
        /// </summary>
        public event EventHandler<DiagnosticsDataEventArgs> DiagnosticsResponse;

        /// <summary>
        /// Occurs when [diagnostics indication response].
        /// </summary>
        public event EventHandler<DiagnosticsDataEventArgs> DiagnosticsIndicationResponse;
        
        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Loads the configuration response completed.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public void LoadConfigurationResponseCompleted(Configuration configuration)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<Configuration>(this.HandleLoadConfigurationResponse), configuration);
        }

        /// <summary>
        /// Opc the servers response completed.
        /// </summary>
        /// <param name="opcServers">The opc servers.</param>
        public void OpcServersResponseCompleted(OpcServerItems opcServers)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<OpcServerItems>(this.HandleOpcServersResponse), opcServers);
        }

        /// <summary>
        /// Reads the opc address space completed.
        /// </summary>
        /// <param name="addressSpace">The address space.</param>
        public void ReadOpcAddressSpaceResponseCompleted(OpcItem addressSpace)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<OpcItem>(this.HandleReadOpcAddressSpaceResponse), addressSpace);
        }
        
        /// <summary>
        /// Services the error response completed.
        /// </summary>
        /// <param name="serviceErrorData">The service error data.</param>
        public void ServiceErrorResponseCompleted(string serviceErrorData)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<string>(this.HandleServiceErrorResponse), serviceErrorData);
        }
        
        /// <summary>
        /// Runtimes the measurements completed.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        public void RuntimeMeasurementsCompleted(RuntimeMeasurements runtimeMeasurements)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<RuntimeMeasurements>(this.HandleRuntimeMeasurementsResponse), runtimeMeasurements);
        }

        /// <summary>
        /// Saves the configuration response completed.
        /// </summary>
        public void SaveConfigurationResponseCompleted()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action(this.HandleSaveConfigurationResponse));
        }

        /// <summary>
        /// Fis the registration response completed.
        /// </summary>
        public void FisRegistrationResponseCompleted()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action(this.HandleFisRegistrationResponse));
        }
        
        /// <summary>
        /// Diagnostics response completed.
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        public void DiagnosticsResponseCompleted(DiagnosticsMessages diagnosticsMessages)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<DiagnosticsMessages>(this.HandleDiagnosticsResponse), diagnosticsMessages);
        }

        /// <summary>
        /// Diagnostics the indication response completed.
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        public void DiagnosticsIndicationResponseCompleted(DiagnosticsMessages diagnosticsMessages)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, new Action<DiagnosticsMessages>(this.HandleDiagnosticsIndicationResponse), diagnosticsMessages);
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Handles the load configuration response.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private void HandleLoadConfigurationResponse(Configuration configuration)
        {
            this.OnLoadConfigurationResponse(configuration);
        }

        /// <summary>
        /// Handles the opc servers response.
        /// </summary>
        /// <param name="opcServers">The opc servers.</param>
        private void HandleOpcServersResponse(OpcServerItems opcServers)
        {
            this.OnOpcServersResponse(opcServers);
        }

        /// <summary>
        /// Handles the read opc address space response.
        /// </summary>
        /// <param name="addressSpace">The address space.</param>
        private void HandleReadOpcAddressSpaceResponse(OpcItem addressSpace)
        {
            this.OnReadOpcAddressSpaceResponse(addressSpace);
        }
        
        /// <summary>
        /// Handles the service error response.
        /// </summary>
        /// <param name="serviceErrorData">The service error data.</param>
        private void HandleServiceErrorResponse(string serviceErrorData)
        {
            this.OnServiceErrorResponse(serviceErrorData);
        }
        
        /// <summary>
        /// Handles the runtime measurements response.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        private void HandleRuntimeMeasurementsResponse(RuntimeMeasurements runtimeMeasurements)
        {
            this.OnRuntimeMeasurementsResponse(runtimeMeasurements);
        }

        /// <summary>
        /// Handles the save configuration response.
        /// </summary>
        private void HandleSaveConfigurationResponse()
        {
            this.OnSaveConfigurationResponse();
        }

        /// <summary>
        /// Handles the fis registration response.
        /// </summary>
        private void HandleFisRegistrationResponse()
        {
            this.OnFisRegistrationResponse();
        }
        
        /// <summary>
        /// Handles the diagnostics response.
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        private void HandleDiagnosticsResponse(DiagnosticsMessages diagnosticsMessages)
        {
            this.OnDiagnosticsResponse(diagnosticsMessages);
        }

        /// <summary>
        /// Handles the diagnostics indication response.
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        private void HandleDiagnosticsIndicationResponse(DiagnosticsMessages diagnosticsMessages)
        {
            this.OnDiagnosticsIndicationResponse(diagnosticsMessages);
        }

        /// <summary>
        /// Called when [service error response].
        /// </summary>
        /// <param name="serviceErrorData">The service error data.</param>
        private void OnServiceErrorResponse(string serviceErrorData)
        {
            var serviceErrorResponse = this.ServiceErrorResponse;

            if (serviceErrorResponse != null)
            {
                serviceErrorResponse(this, new ServiceErrorDataEventArgs(serviceErrorData));
            }
        }
        
        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        private void OnSaveConfigurationResponse()
        {
            var saveConfigurationResponse = this.SaveConfigurationResponse;

            if (saveConfigurationResponse != null)
            {
                saveConfigurationResponse(this, new EventArgs());
            }
        }

        /// <summary>
        /// Called when [fis registration response].
        /// </summary>
        private void OnFisRegistrationResponse()
        {
            var fisRegistrationResponse = this.FisRegistrationResponse;

            if (fisRegistrationResponse != null)
            {
                fisRegistrationResponse(this, new EventArgs());
            }
        }
        
        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private void OnLoadConfigurationResponse(Configuration configuration)
        {
            var configurationResponse = this.ConfigurationResponse;

            if (configurationResponse != null)
            {
                configurationResponse(this, new ConfigurationDataEventArgs(configuration));
            }
        }

        /// <summary>
        /// Called when [opc servers response].
        /// </summary>
        /// <param name="opcServerItems">The opc server items.</param>
        private void OnOpcServersResponse(List<OpcServerItem> opcServerItems)
        {
            var opcServersResponse = this.OpcServersResponse;

            if (opcServersResponse != null)
            {
                opcServersResponse(this, new ServerDataEventArgs(opcServerItems));
            }
        }

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="addressSpace">The address space.</param>
        private void OnReadOpcAddressSpaceResponse(OpcItem addressSpace)
        {
            var readOpcAddressSpaceResponse = this.ReadOpcAddressSpaceResponse;

            if (readOpcAddressSpaceResponse != null)
            {
                readOpcAddressSpaceResponse(this, new AddressSpaceDataEventArgs(addressSpace));
            }
        }
        
        /// <summary>
        /// Called when [runtime measurements response].
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        private void OnRuntimeMeasurementsResponse(List<RuntimeMeasurement> runtimeMeasurements)
        {
            var runtimeMeasurementsResponse = this.RuntimeMeasurementsResponse;

            if (runtimeMeasurementsResponse != null)
            {
                runtimeMeasurementsResponse(this, new RuntimeMeasurementsDataEventArgs(runtimeMeasurements));
            }
        }

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        private void OnDiagnosticsResponse(DiagnosticsMessages diagnosticsMessages)
        {
            var diagnosticsResponse = this.DiagnosticsResponse;

            if (diagnosticsResponse != null)
            {
                diagnosticsResponse(this, new DiagnosticsDataEventArgs(diagnosticsMessages));
            }
        }

        /// <summary>
        /// Called when [diagnostics indication response].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        private void OnDiagnosticsIndicationResponse(DiagnosticsMessages diagnosticsMessages)
        {
            var diagnosticsIndicationResponse = this.DiagnosticsIndicationResponse;

            if (diagnosticsIndicationResponse != null)
            {
                diagnosticsIndicationResponse(this, new DiagnosticsDataEventArgs(diagnosticsMessages));
            }
        }
        
        #endregion
    }
}