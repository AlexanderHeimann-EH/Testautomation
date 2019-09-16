// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircularProgress.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Spinning Busy Indicator Control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    /// <summary>
    /// Spinning Busy Indicator Control.
    /// </summary>
    public partial class CircularProgress
    {
        #region Constants and Fields

        /// <summary>
        /// Spinning Speed. Default is 60, that's one rotation per second.
        /// </summary>
        public static readonly DependencyProperty RotationsPerMinuteProperty = DependencyProperty.Register("RotationsPerMinute", typeof(double), typeof(CircularProgress), new PropertyMetadata(60.0));

        /// <summary>
        /// Startup time in milliseconds, default is a second.
        /// </summary>
        public static readonly DependencyProperty StartupDelayProperty = DependencyProperty.Register("StartupDelay", typeof(int), typeof(CircularProgress), new PropertyMetadata(1000));

        /// <summary>
        /// Timer for the Animation.
        /// </summary>
        private readonly DispatcherTimer animationTimer;

        /// <summary>
        /// The position to show.
        /// </summary>
        private int positionToShow;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularProgress"/> class.
        /// </summary>
        public CircularProgress()
        {
            this.positionToShow = -2;
            this.InitializeComponent();

            this.animationTimer = new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the spinning speed. Default is 60, that's one rotation per second.
        /// </summary>
        /// <value>The rotations per minute.</value>
        public double RotationsPerMinute
        {
            get
            {
                return (double)this.GetValue(RotationsPerMinuteProperty);
            }

            set
            {
                this.SetValue(RotationsPerMinuteProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the startup time in milliseconds, default is a second.
        /// </summary>
        /// <value>The startup delay.</value>
        public int StartupDelay
        {
            get
            {
                return (int)this.GetValue(StartupDelayProperty);
            }

            set
            {
                this.SetValue(StartupDelayProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Apply a single rotation transformation.
        /// </summary>
        /// <param name="sender">Sender of the Event: the Animation Timer.</param>
        /// <param name="e">Event arguments.</param>
        private void HandleAnimationTick(object sender, EventArgs e)
        {
            this.C0.Opacity = Math.Max(0, this.C0.Opacity - 0.15);
            this.C1.Opacity = Math.Max(0, this.C1.Opacity - 0.15);
            this.C2.Opacity = Math.Max(0, this.C2.Opacity - 0.15);
            this.C3.Opacity = Math.Max(0, this.C3.Opacity - 0.15);
            this.C4.Opacity = Math.Max(0, this.C4.Opacity - 0.15);
            this.C5.Opacity = Math.Max(0, this.C5.Opacity - 0.15);
            this.C6.Opacity = Math.Max(0, this.C6.Opacity - 0.15);
            this.C7.Opacity = Math.Max(0, this.C7.Opacity - 0.15);
            this.C8.Opacity = Math.Max(0, this.C8.Opacity - 0.15);
            this.C9.Opacity = Math.Max(0, this.C9.Opacity - 0.15);

            Math.DivRem(this.positionToShow + 1, 10, out this.positionToShow);
            switch (9 - this.positionToShow)
            {
                case 0:
                    this.C0.Opacity = 1.0;
                    break;
                case 1:
                    this.C1.Opacity = 1.0;
                    break;
                case 2:
                    this.C2.Opacity = 1.0;
                    break;
                case 3:
                    this.C3.Opacity = 1.0;
                    break;
                case 4:
                    this.C4.Opacity = 1.0;
                    break;
                case 5:
                    this.C5.Opacity = 1.0;
                    break;
                case 6:
                    this.C6.Opacity = 1.0;
                    break;
                case 7:
                    this.C7.Opacity = 1.0;
                    break;
                case 8:
                    this.C8.Opacity = 1.0;
                    break;
                case 9:
                    this.C9.Opacity = 1.0;
                    break;
            }
        }

        /// <summary>
        /// Control was loaded: distribute circles.
        /// </summary>
        /// <param name="sender">Sender of the Event: I wish I knew.</param>
        /// <param name="e">Event arguments.</param>
        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            this.SetPosition(this.C0, 0.0);
            this.SetPosition(this.C1, 1.0);
            this.SetPosition(this.C2, 2.0);
            this.SetPosition(this.C3, 3.0);
            this.SetPosition(this.C4, 4.0);
            this.SetPosition(this.C5, 5.0);
            this.SetPosition(this.C6, 6.0);
            this.SetPosition(this.C7, 7.0);
            this.SetPosition(this.C8, 8.0);
            this.SetPosition(this.C9, 9.0);
        }

        /// <summary>
        /// Control was unloaded: stop spinning.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void HandleUnloaded(object sender, RoutedEventArgs e)
        {
            this.StopSpinning();
        }

        /// <summary>
        /// Visibility property was changed: start or stop spinning.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void HandleVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Don't give the developer a headache.
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            bool isVisible = (bool)e.NewValue;

            if (isVisible)
            {
                this.StartDelay();
            }
            else
            {
                this.StopSpinning();
            }
        }

        /// <summary>
        /// Calculate position of a circle.
        /// </summary>
        /// <param name="ellipse">The circle.</param>
        /// <param name="sequence">Sequence number of the circle.</param>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Ok here.")]
        private void SetPosition(Ellipse ellipse, double sequence)
        {
            var pos = 50 + (Math.Sin(Math.PI * ((0.2 * sequence) + 1)) * 50.0);
            ellipse.SetValue(Canvas.LeftProperty, pos);

            pos = 50 + (Math.Cos(Math.PI * ((0.2 * sequence) + 1)) * 50.0);
            ellipse.SetValue(Canvas.TopProperty, pos);
        }

        /// <summary>
        /// Startup Delay.
        /// </summary>
        private void StartDelay()
        {
            // Startup
            this.animationTimer.Interval = new TimeSpan(0, 0, 0, 0, this.StartupDelay);
            this.animationTimer.Tick += this.StartSpinning;
            this.animationTimer.Start();
        }

        /// <summary>
        /// Start Spinning.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event Arguments.</param>
        private void StartSpinning(object sender, EventArgs e)
        {
            this.animationTimer.Stop();
            this.animationTimer.Tick -= this.StartSpinning;

            // 60 secs per minute, 1000 millisecs per sec, 10 rotations per full circle:
            this.animationTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)(6000 / this.RotationsPerMinute));
            this.animationTimer.Tick += this.HandleAnimationTick;
            this.animationTimer.Start();
            ////this.Opacity = 1;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        /// <summary>
        /// The control became invisible: stop spinning (animation consumes CPU).
        /// </summary>
        private void StopSpinning()
        {
            this.animationTimer.Stop();
            this.animationTimer.Tick -= this.HandleAnimationTick;
            ////this.Opacity = 0;

            Mouse.OverrideCursor = null;
        }

        #endregion
    }
}
