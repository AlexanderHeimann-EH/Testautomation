﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("EH.ImsOpcBridge.DataContracts", ClrNamespace="EH.ImsOpcBridge.DataContracts")]

namespace EH.ImsOpcBridge.DataContracts
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Authentication", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class Authentication : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string UserField;
        
        private string PasswordField;
        
        private bool ActiveField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public bool Active
        {
            get
            {
                return this.ActiveField;
            }
            set
            {
                this.ActiveField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Gateway", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class Gateway : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string ModelField;
        
        private string SerialNumberField;
        
        private string ActivationKeyField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Model
        {
            get
            {
                return this.ModelField;
            }
            set
            {
                this.ModelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string SerialNumber
        {
            get
            {
                return this.SerialNumberField;
            }
            set
            {
                this.SerialNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public string ActivationKey
        {
            get
            {
                return this.ActivationKeyField;
            }
            set
            {
                this.ActivationKeyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OpcItems", Namespace="EH.ImsOpcBridge.DataContracts", ItemName="opcItem")]
    public class OpcItems : System.Collections.Generic.List<EH.ImsOpcBridge.DataContracts.OpcItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpcItem", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class OpcItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NameField;
        
        private string ItemIdField;
        
        private EH.ImsOpcBridge.DataContracts.OpcItems ChildrenField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string ItemId
        {
            get
            {
                return this.ItemIdField;
            }
            set
            {
                this.ItemIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public EH.ImsOpcBridge.DataContracts.OpcItems Children
        {
            get
            {
                return this.ChildrenField;
            }
            set
            {
                this.ChildrenField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpcServerItem", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class OpcServerItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NameField;
        
        private string ClassIdField;
        
        private string IpAddressField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string ClassId
        {
            get
            {
                return this.ClassIdField;
            }
            set
            {
                this.ClassIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public string IpAddress
        {
            get
            {
                return this.IpAddressField;
            }
            set
            {
                this.IpAddressField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplyCareSettings", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class SupplyCareSettings : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private EH.ImsOpcBridge.DataContracts.Authentication AuthenticationField;
        
        private long PortField;
        
        private long SamplingRateField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long Port
        {
            get
            {
                return this.PortField;
            }
            set
            {
                this.PortField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long SamplingRate
        {
            get
            {
                return this.SamplingRateField;
            }
            set
            {
                this.SamplingRateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConfiguredMeasurementItem", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class ConfiguredMeasurementItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string ValueField;
        
        private EH.ImsOpcBridge.DataContracts.MappingTypes MappingTypeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public EH.ImsOpcBridge.DataContracts.MappingTypes MappingType
        {
            get
            {
                return this.MappingTypeField;
            }
            set
            {
                this.MappingTypeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MappingTypes", Namespace="EH.ImsOpcBridge.DataContracts")]
    public enum MappingTypes : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        StaticType = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OpcValueType = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OpcTimestampType = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OpcQualityType = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConfiguredMeasurement", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class ConfiguredMeasurement : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem DeviceIdField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem SensorIdField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem UnitField;
        
        private EH.ImsOpcBridge.DataContracts.CommonFormatDataTypes DataTypeField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem TimestampField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem QualityField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem ValueField;
        
        private bool ActiveField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem DeviceId
        {
            get
            {
                return this.DeviceIdField;
            }
            set
            {
                this.DeviceIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem SensorId
        {
            get
            {
                return this.SensorIdField;
            }
            set
            {
                this.SensorIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem Unit
        {
            get
            {
                return this.UnitField;
            }
            set
            {
                this.UnitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public EH.ImsOpcBridge.DataContracts.CommonFormatDataTypes DataType
        {
            get
            {
                return this.DataTypeField;
            }
            set
            {
                this.DataTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem Timestamp
        {
            get
            {
                return this.TimestampField;
            }
            set
            {
                this.TimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=5)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem Quality
        {
            get
            {
                return this.QualityField;
            }
            set
            {
                this.QualityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=6)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurementItem Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public bool Active
        {
            get
            {
                return this.ActiveField;
            }
            set
            {
                this.ActiveField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonFormatDataTypes", Namespace="EH.ImsOpcBridge.DataContracts")]
    public enum CommonFormatDataTypes : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ByteType = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ShortType = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UnsignedShortType = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IntType = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UnsignedIntType = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LongType = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UnsignedLongType = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FloatType = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DoubleType = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IEEE754_32Type = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IEEE754_64Type = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DecimalType = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BooleanType = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        StringType = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DateTimeType = 14,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RuntimeMeasurement", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class RuntimeMeasurement : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long RequestIndexField;
        
        private string DeviceIdField;
        
        private string SensorIdField;
        
        private string UnitField;
        
        private string DataTypeField;
        
        private string TimestampField;
        
        private string QualityField;
        
        private string ValueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long RequestIndex
        {
            get
            {
                return this.RequestIndexField;
            }
            set
            {
                this.RequestIndexField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string DeviceId
        {
            get
            {
                return this.DeviceIdField;
            }
            set
            {
                this.DeviceIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public string SensorId
        {
            get
            {
                return this.SensorIdField;
            }
            set
            {
                this.SensorIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public string Unit
        {
            get
            {
                return this.UnitField;
            }
            set
            {
                this.UnitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public string DataType
        {
            get
            {
                return this.DataTypeField;
            }
            set
            {
                this.DataTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=5)]
        public string Timestamp
        {
            get
            {
                return this.TimestampField;
            }
            set
            {
                this.TimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=6)]
        public string Quality
        {
            get
            {
                return this.QualityField;
            }
            set
            {
                this.QualityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=7)]
        public string Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ConfiguredMeasurements", Namespace="EH.ImsOpcBridge.DataContracts", ItemName="configuredMeasurement")]
    public class ConfiguredMeasurements : System.Collections.Generic.List<EH.ImsOpcBridge.DataContracts.ConfiguredMeasurement>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="RuntimeMeasurements", Namespace="EH.ImsOpcBridge.DataContracts", ItemName="runtimeMeasurement")]
    public class RuntimeMeasurements : System.Collections.Generic.List<EH.ImsOpcBridge.DataContracts.RuntimeMeasurement>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="DiagnosticsMessages", Namespace="EH.ImsOpcBridge.DataContracts", ItemName="message")]
    public class DiagnosticsMessages : System.Collections.Generic.List<string>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OpcServerItems", Namespace="EH.ImsOpcBridge.DataContracts", ItemName="opcServerItem")]
    public class OpcServerItems : System.Collections.Generic.List<EH.ImsOpcBridge.DataContracts.OpcServerItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InternetAddress", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class InternetAddress : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string UrlField;
        
        private long PortField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Url
        {
            get
            {
                return this.UrlField;
            }
            set
            {
                this.UrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public long Port
        {
            get
            {
                return this.PortField;
            }
            set
            {
                this.PortField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FisSettings", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class FisSettings : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool EnabledField;
        
        private EH.ImsOpcBridge.DataContracts.InternetAddress InternetAddressField;
        
        private EH.ImsOpcBridge.DataContracts.Authentication AuthenticationField;
        
        private EH.ImsOpcBridge.DataContracts.FisTimeSchedules TimeScheduleField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool Enabled
        {
            get
            {
                return this.EnabledField;
            }
            set
            {
                this.EnabledField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.InternetAddress InternetAddress
        {
            get
            {
                return this.InternetAddressField;
            }
            set
            {
                this.InternetAddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public EH.ImsOpcBridge.DataContracts.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public EH.ImsOpcBridge.DataContracts.FisTimeSchedules TimeSchedule
        {
            get
            {
                return this.TimeScheduleField;
            }
            set
            {
                this.TimeScheduleField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FisTimeSchedules", Namespace="EH.ImsOpcBridge.DataContracts")]
    public enum FisTimeSchedules : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule1min = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule2min = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule5min = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule10min = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule15min = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule30min = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule1h = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule2h = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule3h = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule4h = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule6h = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule8h = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule12h = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TimeSchedule24h = 13,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProxySettings", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class ProxySettings : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool EnabledField;
        
        private EH.ImsOpcBridge.DataContracts.InternetAddress InternetAddressField;
        
        private EH.ImsOpcBridge.DataContracts.Authentication AuthenticationField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool Enabled
        {
            get
            {
                return this.EnabledField;
            }
            set
            {
                this.EnabledField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.InternetAddress InternetAddress
        {
            get
            {
                return this.InternetAddressField;
            }
            set
            {
                this.InternetAddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public EH.ImsOpcBridge.DataContracts.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Configuration", Namespace="EH.ImsOpcBridge.DataContracts")]
    public partial class Configuration : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private EH.ImsOpcBridge.DataContracts.Authentication AuthenticationField;
        
        private EH.ImsOpcBridge.DataContracts.Gateway GatewayField;
        
        private EH.ImsOpcBridge.DataContracts.SupplyCareSettings SupplyCareSettingsField;
        
        private EH.ImsOpcBridge.DataContracts.FisSettings FisSettingsField;
        
        private EH.ImsOpcBridge.DataContracts.ProxySettings ProxySettingsField;
        
        private EH.ImsOpcBridge.DataContracts.ConfiguredMeasurements ConfiguredMeasurementsField;
        
        private string CurrentLanguageField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.Gateway Gateway
        {
            get
            {
                return this.GatewayField;
            }
            set
            {
                this.GatewayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public EH.ImsOpcBridge.DataContracts.SupplyCareSettings SupplyCareSettings
        {
            get
            {
                return this.SupplyCareSettingsField;
            }
            set
            {
                this.SupplyCareSettingsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public EH.ImsOpcBridge.DataContracts.FisSettings FisSettings
        {
            get
            {
                return this.FisSettingsField;
            }
            set
            {
                this.FisSettingsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public EH.ImsOpcBridge.DataContracts.ProxySettings ProxySettings
        {
            get
            {
                return this.ProxySettingsField;
            }
            set
            {
                this.ProxySettingsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=5)]
        public EH.ImsOpcBridge.DataContracts.ConfiguredMeasurements ConfiguredMeasurements
        {
            get
            {
                return this.ConfiguredMeasurementsField;
            }
            set
            {
                this.ConfiguredMeasurementsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=6)]
        public string CurrentLanguage
        {
            get
            {
                return this.CurrentLanguageField;
            }
            set
            {
                this.CurrentLanguageField = value;
            }
        }
    }
}