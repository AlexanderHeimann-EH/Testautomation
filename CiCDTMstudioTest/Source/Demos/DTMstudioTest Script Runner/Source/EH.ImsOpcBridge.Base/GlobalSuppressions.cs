// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="GlobalSuppressions.cs">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EH.ImsOpcBridge.WinApi", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SWP", Scope = "type", Target = "EH.ImsOpcBridge.WinApi.SWP", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Scope = "member", Target = "EH.ImsOpcBridge.WinApi.NativeMethods.#SetCursorPos(System.Int32,System.Int32)", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Scope = "member", Target = "EH.ImsOpcBridge.WinApi.NativeMethods.#SetCursorPos(System.Int32,System.Int32)", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "pt", Scope = "member", Target = "EH.ImsOpcBridge.WinApi.MINMAXINFO.#ptReserved", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "EH.ImsOpcBridge.Helpers.NativeMethods.ShowWindow(System.IntPtr,System.Int32)", Scope = "member", Target = "EH.ImsOpcBridge.Helpers.SingletonApplication.#BringRunningApplicatonToFront()", Justification = "OK.")]
[assembly: SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "EH.ImsOpcBridge.Helpers.NativeMethods.SetForegroundWindow(System.IntPtr)", Scope = "member", Target = "EH.ImsOpcBridge.Helpers.SingletonApplication.#BringRunningApplicatonToFront()", Justification = "OK.")]
