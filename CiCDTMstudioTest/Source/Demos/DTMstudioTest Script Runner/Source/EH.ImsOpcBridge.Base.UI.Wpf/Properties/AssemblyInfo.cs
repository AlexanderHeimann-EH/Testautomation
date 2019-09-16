// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

using log4net.Config;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("EH.ImsOpcBridge.Base.UI.Wpf")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(false)]
[assembly: Repository("EH.ImsOpcBridge")]
[assembly: NeutralResourcesLanguage("en")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// In order to begin building localizable applications, set 
// <UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
// inside a <PropertyGroup>.  For example, if you are using US english
// in your source files, set the <UICulture> to en-US.  Then uncomment
// the NeutralResourceLanguage attribute below.  Update the "en-US" in
// the line below to match the UICulture setting in the project file.

// [assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]
[assembly: ThemeInfo(ResourceDictionaryLocation.None, // where theme specific resource dictionaries are located
    // (used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly // where the generic resource dictionary is located
    // (used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]

[module: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "EH.ImsOpcBridge.UI.Wpf.View.BoolToVisibilityConverter", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.View, Justification", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.ViewModel", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.DataTypes", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "XamlGeneratedNamespace", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.Services", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.ViewModelLocators", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.Model", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.TaskbarIcon", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.Interfaces", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.EventArguments", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.Converter", Justification = "OK here.")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.UI.Wpf.Effects", Justification = "OK here.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "EH.ImsOpcBridge.UI.Wpf.TaskbarIcon.TaskbarIconClass.#.cctor()", Justification = "OK here.")]
