// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowPos.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The swp.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    // ReSharper disable InconsistentNaming
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The window messages.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed. Suppression is OK here.")]
    public enum WM
    {
        /// <summary>
        /// The none.
        /// </summary>
        None = 0, 

        /// <summary>
        /// The getminmaxinfo.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "GETMINMAXINFO", Justification = @"OK.")]
        GETMINMAXINFO = 0x0024, 

        /// <summary>
        /// The windowposchanging.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "WINDOWPOSCHANGING", Justification = @"OK.")]
        WINDOWPOSCHANGING = 0x0046, 

        /// <summary>
        /// The moving.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOVING", Justification = @"OK.")]
        MOVING = 0x0216, 

        /// <summary>
        /// The keydown.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYDOWN", Justification = @"OK.")]
        KEYDOWN = 0x0100
    }

    /// <summary>
    /// The windowpos.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = @"OK.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "WINDOWPOS", Justification = @"OK.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        /// <summary>
        /// The hwnd.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "hwnd", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible", Justification = @"OK.")]
        public IntPtr hwnd;

        /// <summary>
        /// The hwnd insert after.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "hwnd", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible", Justification = @"OK.")]
        public IntPtr hwndInsertAfter;

        /// <summary>
        /// The x.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = @"OK.")]
        public int x;

        /// <summary>
        /// The y.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = @"OK.")]
        public int y;

        /// <summary>
        /// The cx.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        public int cx;

        /// <summary>
        /// The cy.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        public int cy;

        /// <summary>
        /// The flags.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = @"OK.")]
        public int flags;
    }

    /// <summary>
    /// The swp.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:CodeAnalysisSuppressionMustHaveJustification", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SWP")]
    public static class SWP
    {
        #region Static Fields

        /// <summary>
        /// The asyncwindowpos.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ASYNCWINDOWPOS", Justification = @"OK.")]
        public static readonly int ASYNCWINDOWPOS = 0x4000;

        /// <summary>
        /// The defererase.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DEFERERASE", Justification = @"OK.")]
        public static readonly int DEFERERASE = 0x2000;

        /// <summary>
        /// The drawframe.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DRAWFRAME", Justification = @"OK.")]
        public static readonly int DRAWFRAME = 0x0020;

        /// <summary>
        /// The framechanged.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "FRAMECHANGED", Justification = @"OK.")]
        public static readonly int FRAMECHANGED = 0x0020;

        /// <summary>
        /// The hidewindow.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HIDEWINDOW", Justification = @"OK.")]
        public static readonly int HIDEWINDOW = 0x0080;

        /// <summary>
        /// The noactivate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOACTIVATE", Justification = @"OK.")]
        public static readonly int NOACTIVATE = 0x0010;

        /// <summary>
        /// The nocopybits.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOCOPYBITS", Justification = @"OK.")]
        public static readonly int NOCOPYBITS = 0x0100;

        /// <summary>
        /// The nomove.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOMOVE", Justification = @"OK.")]
        public static readonly int NOMOVE = 0x0002;

        /// <summary>
        /// The noownerzorder.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOOWNERZORDER", Justification = @"OK.")]
        public static readonly int NOOWNERZORDER = 0x0200;

        /// <summary>
        /// The noredraw.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOREDRAW", Justification = @"OK.")]
        public static readonly int NOREDRAW = 0x0008;

        /// <summary>
        /// The noreposition.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOREPOSITION", Justification = @"OK.")]
        public static readonly int NOREPOSITION = 0x0200;

        /// <summary>
        /// The nosendchanging.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOSENDCHANGING", Justification = @"OK.")]
        public static readonly int NOSENDCHANGING = 0x0400;

        /// <summary>
        /// The nosize.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOSIZE", Justification = @"OK.")]
        public static readonly int NOSIZE = 0x0001;

        /// <summary>
        /// The nozorder.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOZORDER", Justification = @"OK.")]
        public static readonly int NOZORDER = 0x0004;

        /// <summary>
        /// The showwindow.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SHOWWINDOW", Justification = @"OK.")]
        public static readonly int SHOWWINDOW = 0x0040;

        #endregion
    }

    // ReSharper restore InconsistentNaming
}
