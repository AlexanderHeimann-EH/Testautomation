// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Win API struct providing coordinates for a single point.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Win API struct providing coordinates for a single point.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Not needed for structs.")]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        /// <summary>
        /// The x coordinate.
        /// </summary>
        private int x;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct. 
        /// Construct a point of coordinates (x,y).
        /// </summary>
        /// <param name="initialX">
        /// The x.
        /// </param>
        /// <param name="initialY">
        /// The y.
        /// </param>
        public Point(int initialX, int initialY)
        {
            this.x = initialX;
            this.y = initialY;
        }

        /// <summary>
        /// Gets or sets X.
        /// </summary>
        /// <value>The X.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Is OK here.")]
        // ReSharper disable ConvertToAutoProperty
        public int X
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets Y.
        /// </summary>
        /// <value>The Y.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Is OK here.")]
        // ReSharper disable ConvertToAutoProperty
        public int Y
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }
    }
}
