// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskbarIconClass.Declarations.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.TaskbarIcon
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.ImsOpcBridge.UI.Wpf.Interop;

    /// <summary>
    /// Contains declarations of WPF dependency properties and events.
    /// </summary>
    public partial class TaskbarIconClass
    {
        #region Constants and Fields

        /// <summary>
        /// Category name that is set on designer properties.
        /// </summary>
        public const string CategoryName = "NotifyIcon";

        /// <summary>
        /// BalloonClosing Attached Routed Event
        /// </summary>
        // ReSharper disable LocalizableElement
        public static readonly RoutedEvent BalloonClosingEvent = EventManager.RegisterRoutedEvent("BalloonClosing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        // ReSharper restore LocalizableElement

        /// <summary>
        /// BalloonShowing Attached Routed Event
        /// </summary>
        // ReSharper disable LocalizableElement
        public static readonly RoutedEvent BalloonShowingEvent = EventManager.RegisterRoutedEvent("BalloonShowing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        // ReSharper restore LocalizableElement

        // POPUP CONTROLS

        /// <summary>
        /// The custom balloon property.
        /// </summary>
        public static readonly DependencyProperty CustomBalloonProperty;

        /// <summary>
        /// Command parameter for the <see cref="DoubleClickCommand"/> .
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty DoubleClickCommandParameterProperty = DependencyProperty.Register("DoubleClickCommandParameter", typeof(object), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Associates a command that is being executed if the tray icon is being double clicked.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The target of the command that is fired if the notify icon is double clicked.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty DoubleClickCommandTargetProperty = DependencyProperty.Register("DoubleClickCommandTarget", typeof(IInputElement), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Resolves an image source and updates the <see cref="TaskbarIconClass"/> property accordingly.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null, IconSourcePropertyChanged));

        /// <summary>
        /// Command parameter for the <see cref="LeftClickCommand"/> .
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty LeftClickCommandParameterProperty = DependencyProperty.Register("LeftClickCommandParameter", typeof(object), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Associates a command that is being executed if the tray icon is being double clicked.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty LeftClickCommandProperty = DependencyProperty.Register("LeftClickCommand", typeof(ICommand), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The target of the command that is fired if the notify icon is clicked.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty LeftClickCommandTargetProperty = DependencyProperty.Register("LeftClickCommandTarget", typeof(IInputElement), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Defines what mouse events display the context menu. Defaults to <see cref="PopupActivationMode.RightClick"/> .
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty MenuActivationProperty = DependencyProperty.Register("MenuActivation", typeof(PopupActivationMode), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(PopupActivationMode.RightClick));

        /// <summary>
        /// An attached property that is assigned to
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ParentIconProperty = DependencyProperty.RegisterAttached("ParentIcon", typeof(TaskbarIconClass), typeof(TaskbarIconClass));

        /// <summary>
        /// Defines what mouse events trigger the <see cref="TrayPopup"/> . Default is <see cref="PopupActivationMode.LeftClick"/> .
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty PopupActivationProperty = DependencyProperty.Register("PopupActivation", typeof(PopupActivationMode), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(PopupActivationMode.LeftClick));

        /// <summary>
        /// PopupOpened Attached Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// PreviewTrayContextMenuOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent PreviewTrayContextMenuOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayContextMenuOpen", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// PreviewTrayPopupOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent PreviewTrayPopupOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayPopupOpen", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// PreviewTrayToolTipClose Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent PreviewTrayToolTipCloseEvent = EventManager.RegisterRoutedEvent("PreviewTrayToolTipClose", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// PreviewTrayToolTipOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent PreviewTrayToolTipOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayToolTipOpen", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// ToolTipClose Attached Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent ToolTipCloseEvent = EventManager.RegisterRoutedEvent("ToolTipClose", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// ToolTipOpened Attached Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent ToolTipOpenedEvent = EventManager.RegisterRoutedEvent("ToolTipOpened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// A tooltip text that is being displayed if no custom <see cref="ToolTip"/> was set or if custom tooltips are not supported.S
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ToolTipTextProperty = DependencyProperty.Register("ToolTipText", typeof(string), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(string.Empty, ToolTipTextPropertyChanged));

        /// <summary>
        /// TrayBalloonTipClicked Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayBalloonTipClickedEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayBalloonTipClosed Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayBalloonTipClosedEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipClosed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayBalloonTipShown Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayBalloonTipShownEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipShown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayContextMenuOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayContextMenuOpenEvent = EventManager.RegisterRoutedEvent("TrayContextMenuOpen", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayLeftMouseDown Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayLeftMouseDownEvent = EventManager.RegisterRoutedEvent("TrayLeftMouseDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayLeftMouseUp Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayLeftMouseUpEvent = EventManager.RegisterRoutedEvent("TrayLeftMouseUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayMiddleMouseDown Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayMiddleMouseDownEvent = EventManager.RegisterRoutedEvent("TrayMiddleMouseDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayMiddleMouseUp Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayMiddleMouseUpEvent = EventManager.RegisterRoutedEvent("TrayMiddleMouseUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayMouseDoubleClick Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayMouseDoubleClickEvent = EventManager.RegisterRoutedEvent("TrayMouseDoubleClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayMouseMove Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayMouseMoveEvent = EventManager.RegisterRoutedEvent("TrayMouseMove", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayPopupOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayPopupOpenEvent = EventManager.RegisterRoutedEvent("TrayPopupOpen", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// A control that is displayed as a popup when the taskbar icon is clicked.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TrayPopupProperty = DependencyProperty.Register("TrayPopup", typeof(UIElement), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null, TrayPopupPropertyChanged));

        /// <summary>
        /// A read-only dependency property that returns the <see cref="Popup"/> that is being displayed in the taskbar area based on a user action.
        /// </summary>
        public static readonly DependencyProperty TrayPopupResolvedProperty;

        /// <summary>
        /// TrayRightMouseDown Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayRightMouseDownEvent = EventManager.RegisterRoutedEvent("TrayRightMouseDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayRightMouseUp Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayRightMouseUpEvent = EventManager.RegisterRoutedEvent("TrayRightMouseUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayToolTipClose Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayToolTipCloseEvent = EventManager.RegisterRoutedEvent("TrayToolTipClose", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// TrayToolTipOpen Routed Event
        /// </summary>
        [Localizable(false)]
        public static readonly RoutedEvent TrayToolTipOpenEvent = EventManager.RegisterRoutedEvent("TrayToolTipOpen", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskbarIconClass));

        /// <summary>
        /// A custom UI element that is displayed as a tooltip if the user hovers over the taskbar icon. Works only with Vista and above. Accordingly, you should make sure that the <see cref="ToolTipText"/> property is set as well.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TrayToolTipProperty = DependencyProperty.Register("TrayToolTip", typeof(UIElement), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null, TrayToolTipPropertyChanged));

        /// <summary>
        /// A read-only dependency property that returns the <see cref="ToolTip"/> that is being displayed.
        /// </summary>
        public static readonly DependencyProperty TrayToolTipResolvedProperty;

        /// <summary>
        /// CustomBalloon Read-Only Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey CustomBalloonPropertyKey;

        /// <summary>
        /// TrayPopupResolved Read-Only Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey TrayPopupResolvedPropertyKey;

        /// <summary>
        /// TrayToolTipResolved Read-Only Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey TrayToolTipResolvedPropertyKey;

        /// <summary>
        /// The icon.
        /// </summary>
        private Icon icon;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="TaskbarIconClass"/> class. Initializes static members of the <see cref="TaskbarIconClass"/> class. Registers properties.
        /// </summary>
        static TaskbarIconClass()
        {
            // register change listener for the Visibility property
            var md = new PropertyMetadata(Visibility.Visible, VisibilityPropertyChanged);
            VisibilityProperty.OverrideMetadata(typeof(TaskbarIconClass), md);

            // register change listener for the DataContext property
            md = new FrameworkPropertyMetadata(DataContextPropertyChanged);
            DataContextProperty.OverrideMetadata(typeof(TaskbarIconClass), md);

            // register change listener for the ContextMenu property
            md = new FrameworkPropertyMetadata(ContextMenuPropertyChanged);
            ContextMenuProperty.OverrideMetadata(typeof(TaskbarIconClass), md);

            // ReSharper disable LocalizableElement
            CustomBalloonPropertyKey = DependencyProperty.RegisterReadOnly("CustomBalloon", typeof(Popup), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));
            TrayPopupResolvedPropertyKey = DependencyProperty.RegisterReadOnly("TrayPopupResolved", typeof(Popup), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));
            TrayToolTipResolvedPropertyKey = DependencyProperty.RegisterReadOnly("TrayToolTipResolved", typeof(ToolTip), typeof(TaskbarIconClass), new FrameworkPropertyMetadata(null));

            // ReSharper restore LocalizableElement
            TrayToolTipResolvedProperty = TrayToolTipResolvedPropertyKey.DependencyProperty;
            TrayPopupResolvedProperty = TrayPopupResolvedPropertyKey.DependencyProperty;
            CustomBalloonProperty = CustomBalloonPropertyKey.DependencyProperty;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Tunneled event that occurs when the context menu of the taskbar icon is being displayed.
        /// </summary>
        public event RoutedEventHandler PreviewTrayContextMenuOpen
        {
            add
            {
                this.AddHandler(PreviewTrayContextMenuOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(PreviewTrayContextMenuOpenEvent, value);
            }
        }

        /// <summary>
        /// Tunneled event that occurs when the custom popup is being opened.
        /// </summary>
        public event RoutedEventHandler PreviewTrayPopupOpen
        {
            add
            {
                this.AddHandler(PreviewTrayPopupOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(PreviewTrayPopupOpenEvent, value);
            }
        }

        /// <summary>
        /// Tunneled event that occurs when a custom tooltip is being closed.
        /// </summary>
        public event RoutedEventHandler PreviewTrayToolTipClose
        {
            add
            {
                this.AddHandler(PreviewTrayToolTipCloseEvent, value);
            }

            remove
            {
                this.RemoveHandler(PreviewTrayToolTipCloseEvent, value);
            }
        }

        /// <summary>
        /// Tunneled event that occurs when the custom ToolTip is being displayed.
        /// </summary>
        public event RoutedEventHandler PreviewTrayToolTipOpen
        {
            add
            {
                this.AddHandler(PreviewTrayToolTipOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(PreviewTrayToolTipOpenEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user clicks on a balloon ToolTip.
        /// </summary>
        public event RoutedEventHandler TrayBalloonTipClicked
        {
            add
            {
                this.AddHandler(TrayBalloonTipClickedEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayBalloonTipClickedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a balloon ToolTip was closed.
        /// </summary>
        public event RoutedEventHandler TrayBalloonTipClosed
        {
            add
            {
                this.AddHandler(TrayBalloonTipClosedEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayBalloonTipClosedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a balloon ToolTip is displayed.
        /// </summary>
        public event RoutedEventHandler TrayBalloonTipShown
        {
            add
            {
                this.AddHandler(TrayBalloonTipShownEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayBalloonTipShownEvent, value);
            }
        }

        /// <summary>
        /// Bubbled event that occurs when the context menu of the taskbar icon is being displayed.
        /// </summary>
        public event RoutedEventHandler TrayContextMenuOpen
        {
            add
            {
                this.AddHandler(TrayContextMenuOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayContextMenuOpenEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user presses the left mouse button.
        /// </summary>
        [Category(CategoryName)]
        public event RoutedEventHandler TrayLeftMouseDown
        {
            add
            {
                this.AddHandler(TrayLeftMouseDownEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayLeftMouseDownEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user releases the left mouse button.
        /// </summary>
        public event RoutedEventHandler TrayLeftMouseUp
        {
            add
            {
                this.AddHandler(TrayLeftMouseUpEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayLeftMouseUpEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user presses the middle mouse button.
        /// </summary>
        public event RoutedEventHandler TrayMiddleMouseDown
        {
            add
            {
                this.AddHandler(TrayMiddleMouseDownEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayMiddleMouseDownEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user releases the middle mouse button.
        /// </summary>
        public event RoutedEventHandler TrayMiddleMouseUp
        {
            add
            {
                this.AddHandler(TrayMiddleMouseUpEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayMiddleMouseUpEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user double-clicks the taskbar icon.
        /// </summary>
        public event RoutedEventHandler TrayMouseDoubleClick
        {
            add
            {
                this.AddHandler(TrayMouseDoubleClickEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayMouseDoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user moves the mouse over the taskbar icon.
        /// </summary>
        public event RoutedEventHandler TrayMouseMove
        {
            add
            {
                this.AddHandler(TrayMouseMoveEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayMouseMoveEvent, value);
            }
        }

        /// <summary>
        /// Bubbled event that occurs when the custom popup is being opened.
        /// </summary>
        public event RoutedEventHandler TrayPopupOpen
        {
            add
            {
                this.AddHandler(TrayPopupOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayPopupOpenEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the presses the right mouse button.
        /// </summary>
        public event RoutedEventHandler TrayRightMouseDown
        {
            add
            {
                this.AddHandler(TrayRightMouseDownEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayRightMouseDownEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the user releases the right mouse button.
        /// </summary>
        public event RoutedEventHandler TrayRightMouseUp
        {
            add
            {
                this.AddHandler(TrayRightMouseUpEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayRightMouseUpEvent, value);
            }
        }

        /// <summary>
        /// Bubbled event that occurs when a custom tooltip is being closed.
        /// </summary>
        public event RoutedEventHandler TrayToolTipClose
        {
            add
            {
                this.AddHandler(TrayToolTipCloseEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayToolTipCloseEvent, value);
            }
        }

        /// <summary>
        /// Bubbled event that occurs when the custom ToolTip is being displayed.
        /// </summary>
        public event RoutedEventHandler TrayToolTipOpen
        {
            add
            {
                this.AddHandler(TrayToolTipOpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(TrayToolTipOpenEvent, value);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a custom popup that is being displayed in the tray area in order to display messages to the user.
        /// </summary>
        public Popup CustomBalloon
        {
            get
            {
                return (Popup)this.GetValue(CustomBalloonProperty);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="DoubleClickCommandProperty"/> dependency property: <br/> Associates a command that is being executed if the tray icon is being double clicked.
        /// </summary>
        /// <value>The double click command.</value>
        public ICommand DoubleClickCommand
        {
            get
            {
                return (ICommand)this.GetValue(DoubleClickCommandProperty);
            }

            set
            {
                this.SetValue(DoubleClickCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="DoubleClickCommandParameterProperty"/> dependency property: <br/> Command parameter for the <see cref="DoubleClickCommand"/> .
        /// </summary>
        /// <value>The double click command parameter.</value>
        public object DoubleClickCommandParameter
        {
            get
            {
                return this.GetValue(DoubleClickCommandParameterProperty);
            }

            set
            {
                this.SetValue(DoubleClickCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="DoubleClickCommandTargetProperty"/> dependency property: <br/> The target of the command that is fired if the notify icon is double clicked.
        /// </summary>
        /// <value>The double click command target.</value>
        public IInputElement DoubleClickCommandTarget
        {
            get
            {
                return (IInputElement)this.GetValue(DoubleClickCommandTargetProperty);
            }

            set
            {
                this.SetValue(DoubleClickCommandTargetProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the icon to be displayed. This is not a dependency property - if you want to assign the property through XAML, please use the <see cref="IconSource"/> dependency property.
        /// </summary>
        /// <value>The icon.</value>
        [Browsable(false)]
        public Icon Icon
        {
            get
            {
                return this.icon;
            }

            set
            {
                this.icon = value;
                this.iconData.IconHandle = value == null ? IntPtr.Zero : this.icon.Handle;

                Utilities.WriteIconData(ref this.iconData, NotifyCommand.Modify, IconDataMembers.Icon);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="IconSourceProperty"/> dependency property: <br/> Resolves an image source and updates the <see cref="Icon"/> property accordingly.
        /// </summary>
        /// <value>The icon source.</value>
        [Category(CategoryName)]
        [Description("Sets the displayed taskbar icon.")]
        public ImageSource IconSource
        {
            get
            {
                return (ImageSource)this.GetValue(IconSourceProperty);
            }

            set
            {
                this.SetValue(IconSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="LeftClickCommandProperty"/> dependency property: <br/> Associates a command that is being executed if the tray icon is being double clicked.
        /// </summary>
        /// <value>The left click command.</value>
        public ICommand LeftClickCommand
        {
            get
            {
                return (ICommand)this.GetValue(LeftClickCommandProperty);
            }

            set
            {
                this.SetValue(LeftClickCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="LeftClickCommandParameterProperty"/> dependency property: <br/> Command parameter for the <see cref="LeftClickCommand"/> .
        /// </summary>
        /// <value>The left click command parameter.</value>
        public object LeftClickCommandParameter
        {
            get
            {
                return this.GetValue(LeftClickCommandParameterProperty);
            }

            set
            {
                this.SetValue(LeftClickCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="LeftClickCommandTargetProperty"/> dependency property: <br/> The target of the command that is fired if the notify icon is clicked.
        /// </summary>
        /// <value>The left click command target.</value>
        public IInputElement LeftClickCommandTarget
        {
            get
            {
                return (IInputElement)this.GetValue(LeftClickCommandTargetProperty);
            }

            set
            {
                this.SetValue(LeftClickCommandTargetProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="MenuActivationProperty"/> dependency property: <br/> Defines what mouse events display the context menu. Defaults to <see cref="PopupActivationMode.RightClick"/> .
        /// </summary>
        /// <value>The menu activation.</value>
        [Category(CategoryName)]
        [Description("Defines what mouse events display the context menu.")]
        public PopupActivationMode MenuActivation
        {
            get
            {
                return (PopupActivationMode)this.GetValue(MenuActivationProperty);
            }

            set
            {
                this.SetValue(MenuActivationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="PopupActivationProperty"/> dependency property: <br/> Defines what mouse events trigger the <see cref="TrayPopup"/> . Default is <see cref="PopupActivationMode.LeftClick"/> .
        /// </summary>
        /// <value>The popup activation.</value>
        [Category(CategoryName)]
        [Description("Defines what mouse events display the IconPopup.")]
        public PopupActivationMode PopupActivation
        {
            get
            {
                return (PopupActivationMode)this.GetValue(PopupActivationProperty);
            }

            set
            {
                this.SetValue(PopupActivationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="ToolTipTextProperty"/> dependency property: <br/> A tooltip text that is being displayed if no custom <see cref="ToolTip"/> was set or if custom tooltips are not supported.
        /// </summary>
        /// <value>The tool tip text.</value>
        [Category(CategoryName)]
        [Description("Alternative to a fully blown ToolTip, which is only displayed on Vista and above.")]
        public string ToolTipText
        {
            get
            {
                return (string)this.GetValue(ToolTipTextProperty);
            }

            set
            {
                this.SetValue(ToolTipTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="TrayPopupProperty"/> dependency property: <br/> A control that is displayed as a popup when the taskbar icon is clicked.
        /// </summary>
        /// <value>The tray popup.</value>
        [Category(CategoryName)]
        [Description("Displayed as a Popup if the user clicks on the taskbar icon.")]
        public UIElement TrayPopup
        {
            get
            {
                return (UIElement)this.GetValue(TrayPopupProperty);
            }

            set
            {
                this.SetValue(TrayPopupProperty, value);
            }
        }

        /// <summary>
        /// Gets the TrayPopupResolved property. Returns a <see cref="Popup"/> which is either the <see cref="TrayPopup"/> control itself or a <see cref="Popup"/> control that contains the <see cref="TrayPopup"/> .
        /// </summary>
        [Category(CategoryName)]
        public Popup TrayPopupResolved
        {
            get
            {
                return (Popup)this.GetValue(TrayPopupResolvedProperty);
            }
        }

        /// <summary>
        /// Gets or sets a property wrapper for the <see cref="TrayToolTipProperty"/> dependency property: <br/> A custom UI element that is displayed as a tooltip if the user hovers over the taskbar icon. Works only with Vista and above. Accordingly, you should make sure that the <see cref="ToolTipText"/> property is set as well.
        /// </summary>
        /// <value>The tray tool tip.</value>
        [Category(CategoryName)]
        [Description("Custom UI element that is displayed as a tooltip. Only on Vista and above")]
        public UIElement TrayToolTip
        {
            get
            {
                return (UIElement)this.GetValue(TrayToolTipProperty);
            }

            set
            {
                this.SetValue(TrayToolTipProperty, value);
            }
        }

        /// <summary>
        /// Gets the TrayToolTipResolved property. Returns a <see cref="ToolTip"/> control that was created in order to display either <see cref="TrayToolTip"/> or <see cref="ToolTipText"/> .
        /// </summary>
        [Category(CategoryName)]
        [Browsable(true)]
        [Bindable(true)]
        public ToolTip TrayToolTipResolved
        {
            get
            {
                return (ToolTip)this.GetValue(TrayToolTipResolvedProperty);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a handler for the BalloonClosing attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be added</param>
        public static void AddBalloonClosingHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.AddHandler(element, BalloonClosingEvent, handler);
        }

        /// <summary>
        /// Adds a handler for the BalloonShowing attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be added</param>
        public static void AddBalloonShowingHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.AddHandler(element, BalloonShowingEvent, handler);
        }

        /// <summary>
        /// Adds a handler for the PopupOpened attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be added</param>
        public static void AddPopupOpenedHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.AddHandler(element, PopupOpenedEvent, handler);
        }

        /// <summary>
        /// Adds a handler for the ToolTipClose attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be added</param>
        public static void AddToolTipCloseHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.AddHandler(element, ToolTipCloseEvent, handler);
        }

        /// <summary>
        /// Adds a handler for the ToolTipOpened attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be added</param>
        public static void AddToolTipOpenedHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.AddHandler(element, ToolTipOpenedEvent, handler);
        }

        /// <summary>
        /// Gets the ParentIcon property. This dependency property indicates ....
        /// </summary>
        /// <param name="dependencyObject">The dependencyObject.</param>
        /// <returns>The args. The Icon.</returns>
        public static TaskbarIconClass GetParentIcon(DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                throw new ArgumentNullException(@"dependencyObject");
            }
            
            return (TaskbarIconClass)dependencyObject.GetValue(ParentIconProperty);
        }

        /// <summary>
        /// Removes a handler for the BalloonClosing attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be removed</param>
        public static void RemoveBalloonClosingHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.RemoveHandler(element, BalloonClosingEvent, handler);
        }

        /// <summary>
        /// Removes a handler for the BalloonShowing attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be removed</param>
        public static void RemoveBalloonShowingHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.RemoveHandler(element, BalloonShowingEvent, handler);
        }

        /// <summary>
        /// Removes a handler for the PopupOpened attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be removed</param>
        public static void RemovePopupOpenedHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.RemoveHandler(element, PopupOpenedEvent, handler);
        }

        /// <summary>
        /// Removes a handler for the ToolTipClose attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be removed</param>
        public static void RemoveToolTipCloseHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.RemoveHandler(element, ToolTipCloseEvent, handler);
        }

        /// <summary>
        /// Removes a handler for the ToolTipOpened attached event
        /// </summary>
        /// <param name="element">UIElement or ContentElement that listens to the event</param>
        /// <param name="handler">Event handler to be removed</param>
        public static void RemoveToolTipOpenedHandler(DependencyObject element, RoutedEventHandler handler)
        {
            RoutedEventHelper.RemoveHandler(element, ToolTipOpenedEvent, handler);
        }

        /// <summary>
        /// Sets the ParentIcon property. This dependency property indicates ....
        /// </summary>
        /// <param name="dependencyObject">The dependencyObject.</param>
        /// <param name="value">The value.</param>
        public static void SetParentIcon(DependencyObject dependencyObject, TaskbarIconClass value)
        {
            if (dependencyObject == null)
            {
                throw new ArgumentNullException(@"dependencyObject");
            }
            
            dependencyObject.SetValue(ParentIconProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// A static helper method to raise the BalloonClosing event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <param name="source">The <see cref="TaskbarIconClass"/> instance that manages the balloon.</param>
        /// <returns>The args. The RaiseBalloon.</returns>
        internal static RoutedEventArgs RaiseBalloonClosingEvent(DependencyObject target, TaskbarIconClass source)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs(BalloonClosingEvent, source);
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the BalloonShowing event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <param name="source">The <see cref="TaskbarIconClass.Icon"/> instance that manages the balloon.</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseBalloonShowingEvent(DependencyObject target, TaskbarIconClass source)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs(BalloonShowingEvent, source);
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the PopupOpened event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaisePopupOpenedEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = PopupOpenedEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the PreviewTrayContextMenuOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaisePreviewTrayContextMenuOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = PreviewTrayContextMenuOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the PreviewTrayPopupOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaisePreviewTrayPopupOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = PreviewTrayPopupOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the PreviewTrayToolTipClose event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaisePreviewTrayToolTipCloseEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = PreviewTrayToolTipCloseEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the PreviewTrayToolTipOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaisePreviewTrayToolTipOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = PreviewTrayToolTipOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the ToolTipClose event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseToolTipCloseEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = ToolTipCloseEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the ToolTipOpened event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseToolTipOpenedEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = ToolTipOpenedEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayBalloonTipClicked event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayBalloonTipClickedEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayBalloonTipClickedEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayBalloonTipClosed event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayBalloonTipClosedEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayBalloonTipClosedEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayBalloonTipShown event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayBalloonTipShownEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayBalloonTipShownEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayContextMenuOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayContextMenuOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayContextMenuOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        // EVENTS

        /// <summary>
        /// A static helper method to raise the TrayLeftMouseDown event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayLeftMouseDownEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayLeftMouseDownEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayLeftMouseUp event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayLeftMouseUpEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayLeftMouseUpEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayMiddleMouseDown event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayMiddleMouseDownEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayMiddleMouseDownEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayMiddleMouseUp event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayMiddleMouseUpEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayMiddleMouseUpEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayMouseDoubleClick event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayMouseDoubleClickEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayMouseDoubleClickEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayMouseMove event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayMouseMoveEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayMouseMoveEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayPopupOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayPopupOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayPopupOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayRightMouseDown event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayRightMouseDownEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayRightMouseDownEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayRightMouseUp event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayRightMouseUpEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayRightMouseUpEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayToolTipClose event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayToolTipCloseEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayToolTipCloseEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A static helper method to raise the TrayToolTipOpen event on a target element.
        /// </summary>
        /// <param name="target">UIElement or ContentElement on which to raise the event</param>
        /// <returns>The args.</returns>
        internal static RoutedEventArgs RaiseTrayToolTipOpenEvent(DependencyObject target)
        {
            if (target == null)
            {
                return null;
            }

            var args = new RoutedEventArgs();
            args.RoutedEvent = TrayToolTipOpenEvent;
            RoutedEventHelper.RaiseEvent(target, args);
            return args;
        }

        /// <summary>
        /// A helper method to raise the PreviewTrayContextMenuOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaisePreviewTrayContextMenuOpenEvent()
        {
            return RaisePreviewTrayContextMenuOpenEvent(this);
        }

        /// <summary>
        /// A helper method to raise the PreviewTrayPopupOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaisePreviewTrayPopupOpenEvent()
        {
            return RaisePreviewTrayPopupOpenEvent(this);
        }

        /// <summary>
        /// A helper method to raise the PreviewTrayToolTipClose event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaisePreviewTrayToolTipCloseEvent()
        {
            return RaisePreviewTrayToolTipCloseEvent(this);
        }

        /// <summary>
        /// A helper method to raise the PreviewTrayToolTipOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaisePreviewTrayToolTipOpenEvent()
        {
            return RaisePreviewTrayToolTipOpenEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayBalloonTipClicked event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayBalloonTipClickedEvent()
        {
            return RaiseTrayBalloonTipClickedEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayBalloonTipClosed event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayBalloonTipClosedEvent()
        {
            return RaiseTrayBalloonTipClosedEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayBalloonTipShown event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayBalloonTipShownEvent()
        {
            return RaiseTrayBalloonTipShownEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayContextMenuOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayContextMenuOpenEvent()
        {
            return RaiseTrayContextMenuOpenEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayLeftMouseDown event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayLeftMouseDownEvent()
        {
            var args = RaiseTrayLeftMouseDownEvent(this);
            return args;
        }

        /// <summary>
        /// A helper method to raise the TrayLeftMouseUp event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayLeftMouseUpEvent()
        {
            return RaiseTrayLeftMouseUpEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayMiddleMouseDown event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayMiddleMouseDownEvent()
        {
            return RaiseTrayMiddleMouseDownEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayMiddleMouseUp event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayMiddleMouseUpEvent()
        {
            return RaiseTrayMiddleMouseUpEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayMouseDoubleClick event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayMouseDoubleClickEvent()
        {
            var args = RaiseTrayMouseDoubleClickEvent(this);
            this.DoubleClickCommand.ExecuteIfEnabled(this.DoubleClickCommandParameter, this.DoubleClickCommandTarget ?? this);
            return args;
        }

        /// <summary>
        /// A helper method to raise the TrayMouseMove event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayMouseMoveEvent()
        {
            return RaiseTrayMouseMoveEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayPopupOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayPopupOpenEvent()
        {
            return RaiseTrayPopupOpenEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayRightMouseDown event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayRightMouseDownEvent()
        {
            return RaiseTrayRightMouseDownEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayRightMouseUp event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayRightMouseUpEvent()
        {
            return RaiseTrayRightMouseUpEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayToolTipClose event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayToolTipCloseEvent()
        {
            return RaiseTrayToolTipCloseEvent(this);
        }

        /// <summary>
        /// A helper method to raise the TrayToolTipOpen event.
        /// </summary>
        /// <returns>The args.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We decided to keep this design here.")]
        protected RoutedEventArgs RaiseTrayToolTipOpenEvent()
        {
            return RaiseTrayToolTipOpenEvent(this);
        }

        /// <summary>
        /// Provides a secure method for setting the <see cref="CustomBalloon"/> property.
        /// </summary>
        /// <param name="value">The new value for the property.</param>
        protected void SetCustomBalloon(Popup value)
        {
            this.SetValue(CustomBalloonPropertyKey, value);
        }

        /// <summary>
        /// Provides a secure method for setting the TrayPopupResolved property. This dependency property indicates ....
        /// </summary>
        /// <param name="value">The new value for the property.</param>
        protected void SetTrayPopupResolved(Popup value)
        {
            this.SetValue(TrayPopupResolvedPropertyKey, value);
        }

        /// <summary>
        /// Provides a secure method for setting the <see cref="TrayToolTipResolved"/> property.
        /// </summary>
        /// <param name="value">The new value for the property.</param>
        protected void SetTrayToolTipResolved(ToolTip value)
        {
            this.SetValue(TrayToolTipResolvedPropertyKey, value);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="FrameworkElement.ContextMenuProperty"/> dependency property has been changed. Invokes the <see cref="OnContextMenuPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void ContextMenuPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnContextMenuPropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="FrameworkElement.DataContextProperty"/> dependency property has been changed. Invokes the <see cref="OnDataContextPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void DataContextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnDataContextPropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="IconSourceProperty"/> dependency property has been changed. Invokes the <see cref="OnIconSourcePropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void IconSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnIconSourcePropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="ToolTipTextProperty"/> dependency property has been changed. Invokes the <see cref="OnToolTipTextPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void ToolTipTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnToolTipTextPropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="TrayPopupProperty"/> dependency property has been changed. Invokes the <see cref="OnTrayPopupPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void TrayPopupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnTrayPopupPropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="TrayToolTipProperty"/> dependency property has been changed. Invokes the <see cref="OnTrayToolTipPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void TrayToolTipPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnTrayToolTipPropertyChanged(e);
        }

        /// <summary>
        /// A static callback listener which is being invoked if the <see cref="UIElement.VisibilityProperty"/> dependency property has been changed. Invokes the <see cref="OnVisibilityPropertyChanged"/> instance method of the changed instance.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void VisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (TaskbarIconClass)d;
            owner.OnVisibilityPropertyChanged(e);
        }

        /// <summary>
        /// Releases the old and updates the new <see cref="ContextMenu"/> property in order to reflect both the NotifyIcon's <see cref="FrameworkElement.DataContext"/> property and have the <see cref="ParentIconProperty"/> assigned.
        /// </summary>
        /// <param name="e">Provides information about the updated property.</param>
        private void OnContextMenuPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                // remove the taskbar icon reference from the previously used element
                SetParentIcon((DependencyObject)e.OldValue, null);
            }

            if (e.NewValue != null)
            {
                // set this taskbar icon as a reference to the new tooltip element
                SetParentIcon((DependencyObject)e.NewValue, this);
            }

            this.UpdateDataContext((ContextMenu)e.NewValue, null, this.DataContext);
        }

        /// <summary>
        /// The on data context property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnDataContextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue;
            var oldValue = e.OldValue;

            // replace custom data context for ToolTips, Popup, and
            // ContextMenu
            this.UpdateDataContext(this.TrayPopupResolved, oldValue, newValue);
            this.UpdateDataContext(this.TrayToolTipResolved, oldValue, newValue);
            this.UpdateDataContext(this.ContextMenu, oldValue, newValue);
        }

        /// <summary>
        /// The on icon source property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnIconSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var newValue = (ImageSource)e.NewValue;

            // resolving the ImageSource at design time is unlikely to work
            if (!Utilities.IsDesignMode)
            {
                this.Icon = newValue.ToIcon();
            }
        }

        /// <summary>
        /// The on tool tip text property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        // ReSharper disable UnusedParameter.Local
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Is OK here.")]
        private void OnToolTipTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            // ReSharper restore UnusedParameter.Local
            // only recreate tooltip if we're not using a custom control
            if (this.TrayToolTipResolved == null || this.TrayToolTipResolved.Content is string)
            {
                this.CreateCustomToolTip();
            }

            this.WriteToolTipSettings();
        }

        /// <summary>
        /// The on tray popup property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnTrayPopupPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                // remove the taskbar icon reference from the previously used element
                SetParentIcon((DependencyObject)e.OldValue, null);
            }

            if (e.NewValue != null)
            {
                // set this taskbar icon as a reference to the new tooltip element
                SetParentIcon((DependencyObject)e.NewValue, this);
            }

            // create a pop
            this.CreatePopup();
        }

        /// <summary>
        /// The on tray tool tip property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnTrayToolTipPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            // recreate tooltip control
            this.CreateCustomToolTip();

            if (e.OldValue != null)
            {
                // remove the taskbar icon reference from the previously used element
                SetParentIcon((DependencyObject)e.OldValue, null);
            }

            if (e.NewValue != null)
            {
                // set this taskbar icon as a reference to the new tooltip element
                SetParentIcon((DependencyObject)e.NewValue, this);
            }

            // update tooltip settings - needed to make sure a string is set, even
            // if the ToolTipText property is not set. Otherwise, the event that
            // triggers tooltip display is never fired.
            this.WriteToolTipSettings();
        }

        /// <summary>
        /// The on visibility property changed.
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnVisibilityPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var newValue = (Visibility)e.NewValue;

            // update
            if (newValue == Visibility.Visible)
            {
                this.CreateIcon();
            }
            else
            {
                this.RemoveIcon();
            }
        }

        /// <summary>
        /// Updates the <see cref="FrameworkElement.DataContextProperty"/> of a given <see cref="FrameworkElement"/> . This method only updates target elements that do not already have a data context of their own, and either assigns the <see cref="FrameworkElement.DataContext"/> of the NotifyIcon, or the NotifyIcon itself, if no data context was assigned at all.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="oldDataContextValue">The old Data Context Value.</param>
        /// <param name="newDataContextValue">The new Data Context Value.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void UpdateDataContext(FrameworkElement target, object oldDataContextValue, object newDataContextValue)
        {
            // if there is no target or it's data context is determined through a binding
            // of its own, keep it
            if (target == null || target.IsDataContextDataBound())
            {
                return;
            }

            // if the target's data context is the NotifyIcon's old DataContext or the NotifyIcon itself,
            // update it
            if (ReferenceEquals(this, target.DataContext) || Equals(oldDataContextValue, target.DataContext))
            {
                // assign own data context, if available. If there is no data
                // context at all, assign NotifyIcon itself.
                target.DataContext = newDataContextValue ?? this;
            }
        }

        #endregion
    }
}
