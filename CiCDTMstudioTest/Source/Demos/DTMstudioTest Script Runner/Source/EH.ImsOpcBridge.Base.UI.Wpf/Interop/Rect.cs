// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rect.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The winapi compatible rect class.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    [SuppressMessage("Microsoft.Naming", "CA1708:IdentifiersShouldDifferByMoreThanCase", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed. Suppression is OK here.")]
    public struct Rect
    {
        /// <summary>
        /// The empty.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1203:ConstantsMustAppearBeforeFields", Justification = "Reviewed. Suppression is OK here.")]
        public static readonly Rect Empty = new Rect();

        /// <summary>
        /// The left.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "Reviewed. Suppression is OK here.")]
        public int left;

        /// <summary>
        /// The top.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "Reviewed. Suppression is OK here.")]
        public int top;

        /// <summary>
        /// The right.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "Reviewed. Suppression is OK here.")]
        public int right;

        /// <summary>
        /// The bottom.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "Reviewed. Suppression is OK here.")]
        public int bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect" /> struct.
        /// Win32
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        public Rect(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect" /> struct.
        /// </summary>
        /// <param name="sourceRect">The rect SRC.</param>
        public Rect(Rect sourceRect)
        {
            this.left = sourceRect.left;
            this.top = sourceRect.top;
            this.right = sourceRect.right;
            this.bottom = sourceRect.bottom;
        }

        /// <summary>
        /// Gets Width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return Math.Abs(this.right - this.left);
            }

            // Abs needed for BIDI OS
        }

        /// <summary>
        /// Gets Height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return this.bottom - this.top;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsEmpty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get
            {
                // BUGBUG : On Bidi OS (hebrew arabic) left > right
                return this.left >= this.right || this.top >= this.bottom;
            }
        }

        /// <summary>
        /// Gets or sets Left.
        /// </summary>
        /// <value>The left.</value>
        // ReSharper disable ConvertToAutoProperty
        public int Left
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// Gets or sets Top.
        /// </summary>
        /// <value>The top.</value>
        // ReSharper disable ConvertToAutoProperty
        public int Top
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.top;
            }

            set
            {
                this.top = value;
            }
        }

        /// <summary>
        /// Gets or sets Right.
        /// </summary>
        /// <value>The right.</value>
        // ReSharper disable ConvertToAutoProperty
        public int Right
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.right;
            }

            set
            {
                this.right = value;
            }
        }

        /// <summary>
        /// Gets or sets Bottom.
        /// </summary>
        /// <value>The bottom.</value>
        // ReSharper disable ConvertToAutoProperty
        public int Bottom
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.bottom;
            }

            set
            {
                this.bottom = value;
            }
        }

        /// <summary>
        /// Determine if 2 Rect are equal (deep compare)
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Rect rect1, Rect rect2)
        {
            return rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom;
        }

        /// <summary>
        /// Determine if 2 Rect are different(deep compare)
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Rect rect1, Rect rect2)
        {
            return !(rect1 == rect2);
        }

        /// <summary>
        /// Determine if 2 Rect are equal (deep compare)
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The equals.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Rect))
            {
                return false;
            }

            return this == (Rect)obj;
        }

        /// <summary>
        /// Return the HashCode for this struct (not garanteed to be unique)
        /// </summary>
        /// <returns>The get hash code.</returns>
        public override int GetHashCode()
        {
            return this.left.GetHashCode() + this.top.GetHashCode() + this.right.GetHashCode() + this.bottom.GetHashCode();
        }

        /// <summary>
        /// Return a user friendly representation of this struct
        /// </summary>
        /// <returns>The to string.</returns>
        public override string ToString()
        {
            if (this == Empty)
            {
                return "Rect {Empty}";
            }

            return "Rect { left : " + this.left + " / top : " + this.top + " / right : " + this.right + " / bottom : " + this.bottom + " }";
        }
    }
}
