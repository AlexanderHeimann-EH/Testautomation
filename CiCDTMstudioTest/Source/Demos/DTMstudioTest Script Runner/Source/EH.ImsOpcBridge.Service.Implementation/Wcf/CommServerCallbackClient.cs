﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EH.ImsOpcBridge.Wcf.Interfaces;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ICommServerCallbackChannel : ICommServerCallback, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class CommServerCallbackClient : System.ServiceModel.ClientBase<ICommServerCallback>, ICommServerCallback
{
    
    public CommServerCallbackClient()
    {
    }
    
    public CommServerCallbackClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CommServerCallbackClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CommServerCallbackClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CommServerCallbackClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void OnLoadConfigurationResponse(System.Guid invokeId, EH.ImsOpcBridge.DataContracts.Configuration configuration, uint error, string errorMessage)
    {
        base.Channel.OnLoadConfigurationResponse(invokeId, configuration, error, errorMessage);
    }
    
    public void OnSaveConfigurationResponse(System.Guid invokeId, uint error, string errorMessage)
    {
        base.Channel.OnSaveConfigurationResponse(invokeId, error, errorMessage);
    }
    
    public void OnImportConfigurationResponse(System.Guid invokeId, EH.ImsOpcBridge.DataContracts.Configuration configuration, uint error, string errorMessage)
    {
        base.Channel.OnImportConfigurationResponse(invokeId, configuration, error, errorMessage);
    }
    
    public void OnExportConfigurationResponse(System.Guid invokeId, uint error, string errorMessage)
    {
        base.Channel.OnExportConfigurationResponse(invokeId, error, errorMessage);
    }
    
    public void OnReadLocalOpcServersResponse(System.Guid invokeId, EH.ImsOpcBridge.DataContracts.OpcServerItems opcServers, uint error, string errorMessage)
    {
        base.Channel.OnReadLocalOpcServersResponse(invokeId, opcServers, error, errorMessage);
    }
    
    public void OnReadOpcAddressSpaceResponse(System.Guid invokeId, EH.ImsOpcBridge.DataContracts.OpcItem addressSpace, uint error, string errorMessage)
    {
        base.Channel.OnReadOpcAddressSpaceResponse(invokeId, addressSpace, error, errorMessage);
    }
    
    public void OnStartMonitorResponse(System.Guid invokeId, uint error, string errorMessage)
    {
        base.Channel.OnStartMonitorResponse(invokeId, error, errorMessage);
    }
    
    public void OnStopMonitorResponse(System.Guid invokeId, uint error, string errorMessage)
    {
        base.Channel.OnStopMonitorResponse(invokeId, error, errorMessage);
    }

    public void OnRuntimeMeasurementsIndication(EH.ImsOpcBridge.DataContracts.RuntimeMeasurements measurements)
    {
        base.Channel.OnRuntimeMeasurementsIndication(measurements);
    }

    public void OnDiagnosticsResponse(System.Guid invokeId, EH.ImsOpcBridge.DataContracts.DiagnosticsMessages diagnosticsMessages, uint error, string errorMessage)
    {
        base.Channel.OnDiagnosticsResponse(invokeId, diagnosticsMessages, error, errorMessage);
    }

    public void OnFisRegistrationResponse(System.Guid invokeId, uint error, string errorMessage)
    {
        base.Channel.OnFisRegistrationResponse(invokeId, error, errorMessage);
    }

    public void OnDiagnosticsIndication(EH.ImsOpcBridge.DataContracts.DiagnosticsMessages diagnosticsMessages)
    {
        base.Channel.OnDiagnosticsIndication(diagnosticsMessages);
    }
}
