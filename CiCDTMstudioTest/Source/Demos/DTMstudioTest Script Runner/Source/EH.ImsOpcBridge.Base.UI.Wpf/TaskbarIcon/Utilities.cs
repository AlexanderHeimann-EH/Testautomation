// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.TaskbarIcon
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.ImsOpcBridge.UI.Wpf.Interop;
    using EH.ImsOpcBridge.UI.Wpf.Properties;

    /// <summary>
    /// Utilities and extension methods.
    /// </summary>
    public static class Utilities
    {
        #region Constants and Fields

        /// <summary>
        /// The sync root.
        /// </summary>
        public static readonly object SyncRoot = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the application is currently in design mode.
        /// </summary>
        public static bool IsDesignMode
        {
            get
            {
                return (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates an transparent window without dimension that can be used to temporarily obtain focus and/or be used as a window message sink.
        /// </summary>
        /// <returns>Empty window.</returns>
        public static Window CreateHelperWindow()
        {
            return new Window { Width = 0, Height = 0, ShowInTaskbar = false, WindowStyle = WindowStyle.None, AllowsTransparency = true, Opacity = 0 };
        }

        /// <summary>
        /// Executes a given command if its <see cref="ICommand.CanExecute"/> method indicates it can run.
        /// </summary>
        /// <param name="command">The command to be executed, or a null reference.</param>
        /// <param name="commandParameter">An optional parameter that is associated with the command.</param>
        /// <param name="target">The target element on which to raise the command.</param>
        public static void ExecuteIfEnabled(this ICommand command, object commandParameter, IInputElement target)
        {
            if (command == null)
            {
                return;
            }

            var rc = command as RoutedCommand;
            if (rc != null)
            {
                // routed commands work on a target
                if (rc.CanExecute(commandParameter, target))
                {
                    rc.Execute(commandParameter, target);
                }
            }
            else if (command.CanExecute(commandParameter))
            {
                command.Execute(commandParameter);
            }
        }

        /// <summary>
        /// Gets a <see cref="BalloonIconStates"/> enumeration value that matches a given <see cref="BalloonIcon"/> .
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>Get the BalloonIconStates.</returns>
        public static BalloonIconStates GetBalloonState(this BalloonIcon icon)
        {
            switch (icon)
            {
                case BalloonIcon.None:
                    return BalloonIconStates.None;
                case BalloonIcon.Info:
                    return BalloonIconStates.Info;
                case BalloonIcon.Warning:
                    return BalloonIconStates.Warning;
                case BalloonIcon.Error:
                    return BalloonIconStates.Error;
                default:
                    throw new ArgumentOutOfRangeException("icon");
            }
        }

        /// <summary>
        /// Checks a list of candidates for equality to a given reference value.
        /// </summary>
        /// <typeparam name="T">Is a T instance.</typeparam>
        /// <param name="value">The evaluated value.</param>
        /// <param name="candidates">A list of possible values that are regarded valid.</param>
        /// <returns>True if one of the submitted <paramref name="candidates"/> matches the evaluated value. If the <paramref name="candidates"/> parameter itself is null, too, the method returns false as well, which allows to check with null values, too.</returns>
        public static bool Is<T>(this T value, params T[] candidates)
        {
            if (candidates == null)
            {
                return false;
            }

            foreach (var t in candidates)
            {
                if (value.Equals(t))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the <see cref="FrameworkElement.DataContextProperty"/> is bound or not.
        /// </summary>
        /// <param name="element">The element to be checked.</param>
        /// <returns>True if the data context property is being managed by a binding expression.</returns>
        public static bool IsDataContextDataBound(this FrameworkElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return element.GetBindingExpression(FrameworkElement.DataContextProperty) != null;
        }

        /// <summary>
        /// Checks if a given <see cref="PopupActivationMode"/> is a match for an effectively pressed mouse button.
        /// </summary>
        /// <param name="me">The me.</param>
        /// <param name="activationMode">The activation Mode.</param>
        /// <returns>The is match.</returns>
        public static bool IsMatch(this MouseEvent me, PopupActivationMode activationMode)
        {
            switch (activationMode)
            {
                case PopupActivationMode.LeftClick:
                    return me == MouseEvent.IconLeftMouseUp;
                case PopupActivationMode.RightClick:
                    return me == MouseEvent.IconRightMouseUp;
                case PopupActivationMode.LeftOrRightClick:
                    return me.Is(MouseEvent.IconLeftMouseUp, MouseEvent.IconRightMouseUp);
                case PopupActivationMode.LeftOrDoubleClick:
                    return me.Is(MouseEvent.IconLeftMouseUp, MouseEvent.IconDoubleClick);
                case PopupActivationMode.DoubleClick:
                    return me.Is(MouseEvent.IconDoubleClick);
                case PopupActivationMode.MiddleClick:
                    return me == MouseEvent.IconMiddleMouseUp;
                case PopupActivationMode.All:

                    // return true for everything except mouse movements
                    return me != MouseEvent.MouseMove;
                default:
                    throw new ArgumentOutOfRangeException("activationMode");
            }
        }

        /// <summary>
        /// Reads a given image resource into a WinForms icon.
        /// </summary>
        /// <param name="imageSource">Image source pointing to an icon file (*.ico).</param>
        /// <returns>An icon object that can be used with the taskbar area.</returns>
        public static Icon ToIcon(this ImageSource imageSource)
        {
            if (imageSource == null)
            {
                return null;
            }

            var uri = new Uri(imageSource.ToString());
            var streamInfo = Application.GetResourceStream(uri);

            if (streamInfo == null)
            {
                var msg = string.Format(CultureInfo.CurrentUICulture, Resources.TheSuppliedImageSource_CouldNotBeResolved, imageSource);
                throw new ArgumentException(msg);
            }

            return new Icon(streamInfo.Stream);
        }

        /// <summary>
        /// Updates the taskbar icons with data provided by a given <see cref="NotifyIconData"/> instance.
        /// </summary>
        /// <param name="data">Configuration settings for the NotifyIcon.</param>
        /// <param name="command">Operation on the icon (e.g. delete the icon).</param>
        /// <returns>True if the data was successfully written.</returns>
        /// <remarks>See Shell_NotifyIcon documentation on MSDN for details.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", Justification = "We decided to keep this design here.")]
        public static bool WriteIconData(ref NotifyIconData data, NotifyCommand command)
        {
            return WriteIconData(ref data, command, data.ValidMembers);
        }

        /// <summary>
        /// Updates the taskbar icons with data provided by a given <see cref="NotifyIconData"/> instance.
        /// </summary>
        /// <param name="data">Configuration settings for the NotifyIcon.</param>
        /// <param name="command">Operation on the icon (e.g. delete the icon).</param>
        /// <param name="validMembers">Defines which members of the <paramref name="data"/> structure are set.</param>
        /// <returns>True if the data was successfully written.</returns>
        /// <remarks>See Shell_NotifyIcon documentation on MSDN for details.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", Justification = "We decided to keep this design here.")]
        public static bool WriteIconData(ref NotifyIconData data, NotifyCommand command, IconDataMembers validMembers)
        {
            // do nothing if in design mode
            if (IsDesignMode)
            {
                return true;
            }

            data.ValidMembers = validMembers;
            lock (SyncRoot)
            {
                return NativeMethods.Shell_NotifyIcon(command, ref data);
            }
        }

        #endregion
    }
}
