// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventBehaviorFactory.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class EventBehaviorFactory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.EventArguments
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Class EventBehaviorFactory
    /// </summary>
    public static class EventBehaviorFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates the command execution event behavior.
        /// </summary>
        /// <param name="routedEvent">The routed event.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="ownerType">Type of the owner.</param>
        /// <returns>DependencyProperty. xxx </returns>
        public static DependencyProperty CreateCommandExecutionEventBehavior(RoutedEvent routedEvent, string propertyName, Type ownerType)
        {
            DependencyProperty property = DependencyProperty.RegisterAttached(propertyName, typeof(ICommand), ownerType, new PropertyMetadata(null, new ExecuteCommandOnRoutedEventBehavior(routedEvent).PropertyChangedHandler));

            return property;
        }

        #endregion

        /// <summary>
        /// Class ExecuteCommandBehavior
        /// </summary>
        internal abstract class ExecuteCommandBehavior
        {
            #region Fields

            /// <summary>
            /// The _property
            /// </summary>
            private DependencyProperty property;

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Properties the changed handler.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
            public void PropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                // the first time the property changes,
                // make a note of which property we are supposed
                // to be watching
                if (this.property == null)
                {
                    this.property = e.Property;
                }

                object oldValue = e.OldValue;
                object newValue = e.NewValue;

                this.AdjustEventHandlers(sender, oldValue, newValue);
            }

            #endregion

            #region Methods

            /// <summary>
            /// Adjusts the event handlers.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="oldValue">The old value.</param>
            /// <param name="newValue">The new value.</param>
            protected abstract void AdjustEventHandlers(DependencyObject sender, object oldValue, object newValue);

            /// <summary>
            /// Handles the event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            protected void HandleEvent(object sender, EventArgs e)
            {
                var dp = sender as DependencyObject;
                if (dp == null)
                {
                    return;
                }

                var command = dp.GetValue(this.property) as ICommand;

                if (command == null)
                {
                    return;
                }

                if (command.CanExecute(e))
                {
                    command.Execute(e);
                }
            }

            #endregion
        }

        /// <summary>
        /// Class ExecuteCommandOnRoutedEventBehavior
        /// </summary>
        private class ExecuteCommandOnRoutedEventBehavior : ExecuteCommandBehavior
        {
            #region Fields

            /// <summary>
            /// The _routed event
            /// </summary>
            private readonly RoutedEvent routedEvent;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ExecuteCommandOnRoutedEventBehavior"/> class.
            /// </summary>
            /// <param name="routedEvent">The routed event.</param>
            public ExecuteCommandOnRoutedEventBehavior(RoutedEvent routedEvent)
            {
                this.routedEvent = routedEvent;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Adjusts the event handlers.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="oldValue">The old value.</param>
            /// <param name="newValue">The new value.</param>
            protected override void AdjustEventHandlers(DependencyObject sender, object oldValue, object newValue)
            {
                var element = sender as UIElement;
                if (element == null)
                {
                    return;
                }

                if (oldValue != null)
                {
                    element.RemoveHandler(this.routedEvent, new RoutedEventHandler(this.EventHandler));
                }

                if (newValue != null)
                {
                    element.AddHandler(this.routedEvent, new RoutedEventHandler(this.EventHandler));
                }
            }

            /// <summary>
            /// Events the handler.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
            private void EventHandler(object sender, RoutedEventArgs e)
            {
                this.HandleEvent(sender, e);
            }

            #endregion
        }
    }
}
