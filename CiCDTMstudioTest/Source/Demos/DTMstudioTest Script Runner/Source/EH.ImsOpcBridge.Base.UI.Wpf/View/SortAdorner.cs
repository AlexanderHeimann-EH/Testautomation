// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortAdorner.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Adorner to show sorting of a list column
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    /// <summary>
    /// Adorner to show sorting of a list column
    /// </summary>
    public class SortAdorner : Adorner
    {
        #region Constants and Fields

        /// <summary>
        /// The ascending sort sign.
        /// </summary>
        [Localizable(false)]
        private static readonly Geometry AscGeometry = Geometry.Parse("M 0,5 L 10,5 L 5,0 Z");

        /// <summary>
        /// The descending sort sign.
        /// </summary>
        [Localizable(false)]
        private static readonly Geometry DescGeometry = Geometry.Parse("M 0,0 L 10,0 L 5,5 Z");

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SortAdorner"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="dir">The direction.</param>
        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        {
            this.Direction = dir;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Direction.
        /// </summary>
        public ListSortDirection Direction { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The on render.
        /// </summary>
        /// <param name="drawingContext">The drawing context.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (drawingContext == null)
            {
                throw new ArgumentNullException(@"drawingContext");
            }
            
            base.OnRender(drawingContext);

            if (this.AdornedElement.RenderSize.Width < 20)
            {
                return;
            }

            drawingContext.PushTransform(new TranslateTransform(this.AdornedElement.RenderSize.Width - 15, (this.AdornedElement.RenderSize.Height - 5) / 2));
            
            drawingContext.DrawGeometry(Brushes.Black, null, this.Direction == ListSortDirection.Ascending ? AscGeometry : DescGeometry);

            drawingContext.Pop();
        }

        #endregion
    }
}
