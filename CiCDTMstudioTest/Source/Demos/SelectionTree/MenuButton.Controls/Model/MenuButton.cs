using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MenuButton.Controls
{
    /// <summary>
    /// Implemetation of a Menu Button
    /// </summary>
    [TemplatePart(Name = "PART_DropDown", Type = typeof (Button))]
    [ContentProperty("Items")]
    [DefaultProperty("Items")]
    public class MenuButton : Button
    {
        // AddOwner Dependency properties
        public static readonly DependencyProperty HorizontalOffsetProperty;
        public static readonly DependencyProperty IsContextMenuOpenProperty;
        public static readonly DependencyProperty PlacementProperty;
        public static readonly DependencyProperty PlacementRectangleProperty;
        public static readonly DependencyProperty VerticalOffsetProperty;
        public static readonly DependencyProperty MenuButtonActionProperty;
        public static readonly DependencyProperty InstalledVersionProperty;
        public static readonly DependencyProperty AvailableVersionProperty;
        public static readonly DependencyProperty FeatureNameProperty;
        public static readonly DependencyProperty CanMigrateProperty;
        public static readonly DependencyProperty BackgroundColorProperty;
        public static readonly DependencyProperty BackgroundFocusColorProperty;
        public static readonly DependencyProperty ForegroundColorProperty;

        #region Constructors

        /// <summary>
        /// Static Constructor
        /// </summary>
        static MenuButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));

            IsContextMenuOpenProperty = DependencyProperty.Register("IsContextMenuOpen", 
                                                                    typeof(bool), 
                                                                    typeof(MenuButton), 
                                                                    new FrameworkPropertyMetadata(false, 
                                                                                                  new PropertyChangedCallback(OnIsContextMenuOpenChanged)));
            MenuButtonActionProperty = DependencyProperty.Register("MenuButtonAction", 
                                                                   typeof(InstallType), 
                                                                   typeof(MenuButton), 
                                                                   new FrameworkPropertyMetadata(InstallType.eIndeterminate, 
                                                                                                 new PropertyChangedCallback(OnIsMenuButtonActionChanged)));
            InstalledVersionProperty = DependencyProperty.Register("InstalledVersion",
                                                                    typeof(string),
                                                                    typeof(MenuButton),
                                                                    new FrameworkPropertyMetadata(""));
            AvailableVersionProperty = DependencyProperty.Register("AvailableVersion",
                                                                    typeof(string),
                                                                    typeof(MenuButton),
                                                                    new FrameworkPropertyMetadata(""));
            FeatureNameProperty = DependencyProperty.Register("FeatureName",
                                                               typeof(string),
                                                               typeof(MenuButton),
                                                               new FrameworkPropertyMetadata(""));
            CanMigrateProperty = DependencyProperty.Register("CanMigrate",
                                                             typeof(bool),
                                                             typeof(MenuButton),
                                                             new FrameworkPropertyMetadata(false));
            BackgroundColorProperty = DependencyProperty.Register("BackgroundColor",
                                                                  typeof(Brush),
                                                                  typeof(MenuButton));
            BackgroundFocusColorProperty = DependencyProperty.Register("BackgroundFocusColor",
                                                                       typeof(Brush),
                                                                       typeof(MenuButton));
            ForegroundColorProperty = DependencyProperty.Register("ForegroundColor",
                                                                   typeof(Brush),
                                                                   typeof(MenuButton));

            // AddOwner properties from the ContextMenuService class, we need callbacks from these properties
            // to update the Buttons ContextMenu properties
            PlacementProperty = ContextMenuService.PlacementProperty.AddOwner(typeof(MenuButton), 
                                                                              new FrameworkPropertyMetadata(PlacementMode.Bottom, 
                                                                                                            new PropertyChangedCallback(OnPlacementChanged)));
            PlacementRectangleProperty = ContextMenuService.PlacementRectangleProperty.AddOwner(typeof(MenuButton),
                                                                                                new FrameworkPropertyMetadata(Rect.Empty, 
                                                                                                                              new PropertyChangedCallback(OnPlacementRectangleChanged)));
            HorizontalOffsetProperty = ContextMenuService.HorizontalOffsetProperty.AddOwner(typeof(MenuButton), 
                                                                                            new FrameworkPropertyMetadata(0.0, 
                                                                                                                          new PropertyChangedCallback(OnHorizontalOffsetChanged)));
            VerticalOffsetProperty = ContextMenuService.VerticalOffsetProperty.AddOwner(typeof(MenuButton), 
                                                                                        new FrameworkPropertyMetadata(0.0, 
                                                                                                                      new PropertyChangedCallback(OnVerticalOffsetChanged)));
        }

        #endregion Constructors

        #region Overrides

        /// <summary>
        /// OnApplyTemplate override, set up the click event for the dropdown if present in the template
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // set up the click event handler for the dropdown button
            ButtonBase dropDown = this.Template.FindName("PART_DropDown", this) as ButtonBase;
            if (dropDown != null)
                dropDown.Click += Dropdown_Click;
        }

        /// <summary>
        ///     Handles the Base Buttons OnClick event
        /// </summary>
        protected override void OnClick()
        {
            OnDropdown();
        }

        #endregion Overrides

        #region Properties

        /// <summary>
        /// The Split Button's Items property maps to the base classes ContextMenu.Items property
        /// </summary>
        public ItemCollection Items
        {
            get
            {
                EnsureContextMenuIsValid();
                return this.ContextMenu.Items;
            }
        }

        /// <summary>
        /// Gets or sets the ButtonLabel property. 
        /// </summary>
        public InstallType MenuButtonAction
        {
            get { return (InstallType)GetValue(MenuButtonActionProperty); }
            set { SetValue(MenuButtonActionProperty, value); }
        }

        /// <summary>
        /// The Items of the Context Menu. 
        /// </summary>
        private List<ContextMenuItemContent> cmItemList = new List<ContextMenuItemContent>();
        public List<ContextMenuItemContent> CmItemList
        {
            get { return cmItemList; }
            set { cmItemList = value; }
        }

        /// <summary>
        /// Gets or sets the InstalledVersion property. 
        /// </summary>
        public string InstalledVersion
        {
            get { return (string)GetValue(InstalledVersionProperty); }
            set { SetValue(InstalledVersionProperty, value); }
        }

        /// <summary>
        /// Gets or sets the AvailableVersion property. 
        /// </summary>
        public string AvailableVersion
        {
            get { return (string)GetValue(AvailableVersionProperty); }
            set { SetValue(AvailableVersionProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FeatureName property used to identify the Button and its context menu. 
        /// </summary>
        public string FeatureName
        {
            get { return (string)GetValue(FeatureNameProperty); }
            set { SetValue(FeatureNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the CanMigrate property. 
        /// </summary>
        public bool CanMigrate
        {
            get { return (bool)GetValue(CanMigrateProperty); }
            set { SetValue(CanMigrateProperty, value); }
        }

        /// <summary>
        /// Button background colour without focus
        /// </summary>
        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// Button background colour with focus
        /// </summary>
        public Brush BackgroundFocusColor
        {
            get { return (Brush)GetValue(BackgroundFocusColorProperty); }
            set { SetValue(BackgroundFocusColorProperty, value); }
        }

        /// <summary>
        /// Button foreground colour
        /// </summary>
        public Brush ForegroundColor
        {
            get { return (Brush)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        /// <summary>
        /// The localised labels of the context menu
        /// </summary>
        public MenuLabelCollection LocalisedMenuLabels { get; set; }

        /// <summary>
        /// The IsContextMenuOpen property. 
        /// </summary>
        public bool IsContextMenuOpen
        {
            get { return (bool)GetValue(IsContextMenuOpenProperty); }
            set { SetValue(IsContextMenuOpenProperty, value); }
        }

        /// <summary>
        /// Placement of the Context menu
        /// </summary>
        public PlacementMode Placement
        {
            get { return PlacementMode.Bottom; }
            //get { return (PlacementMode)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        /// <summary>
        /// PlacementRectangle of the Context menu
        /// </summary>
        public Rect PlacementRectangle
        {
            get { return (Rect)GetValue(PlacementRectangleProperty); }
            set { SetValue(PlacementRectangleProperty, value); }
        }

        /// <summary>
        /// HorizontalOffset of the Context menu
        /// </summary>
        public double HorizontalOffset
        {
            get { return (double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty, value); }
        }

        /// <summary>
        /// VerticalOffset of the Context menu
        /// </summary>
        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        #endregion Properties

        #region Callbacks

        private static void OnIsMenuButtonActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((InstallType)e.OldValue != (InstallType)e.NewValue)
            {
                ((MenuButton)d).ApplyMenuButtonContent();
            }
        }
        
        private static void OnCmItemListChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MenuButton button = (MenuButton)sender;

            var oldCollection = e.OldValue as ObservableCollection<ContextMenuItemContent>;
            if (oldCollection != null)
                oldCollection.CollectionChanged -= button.OnCmCollectionChanged;
            
            var newCollection = e.NewValue as ObservableCollection<ContextMenuItemContent>;
            if (newCollection != null)
                newCollection.CollectionChanged += button.OnCmCollectionChanged; 
        }

        private void OnCmCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // Clear and update entire collection
            }

            if (e.NewItems != null)
            {
                foreach (ContextMenuItemContent item in e.NewItems)
                {
                    // Subscribe for changes on item
                    //item.PropertyChanged += OnCmItemChanged;
                    //LocalCmItemList.Add(item);
                }
            }
            
            if (e.OldItems != null)
            {
                foreach (ContextMenuItemContent item in e.OldItems)
                {
                    // Unsubscribe for changes on item
                    //item.PropertyChanged -= OnCmItemChanged;
                    // Remove item from internal collection
                }
            }
        } 

        private void OnCmItemChanged(object sender, PropertyChangedEventArgs e)
        {
            // Modify existing item in internal collection
        }

        private static void OnIsContextMenuOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton s = (MenuButton) d;
            s.EnsureContextMenuIsValid();

            if (!s.ContextMenu.HasItems)
                return;

            bool value = (bool) e.NewValue;

            if (value && !s.ContextMenu.IsOpen)
                s.ContextMenu.IsOpen = true;
            else if (!value && s.ContextMenu.IsOpen)
                s.ContextMenu.IsOpen = false;
        }

        /// <summary>
        /// Placement Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton s = d as MenuButton;
            if (s == null) return;

            s.EnsureContextMenuIsValid();
            s.ContextMenu.Placement = (PlacementMode) e.NewValue;
        }

        /// <summary>
        /// PlacementRectangle Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnPlacementRectangleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton s = d as MenuButton;
            if (s == null) return;

            s.EnsureContextMenuIsValid();
            s.ContextMenu.PlacementRectangle = (Rect) e.NewValue;
        }

        /// <summary>
        /// HorizontalOffset Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton s = d as MenuButton;
            if (s == null) return;

            s.EnsureContextMenuIsValid();
            s.ContextMenu.HorizontalOffset = (double) e.NewValue;
        }

        /// <summary>
        /// VerticalOffset Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton s = d as MenuButton;
            if (s == null) return;

            s.EnsureContextMenuIsValid();
            s.ContextMenu.VerticalOffset = (double) e.NewValue;
        }

        #endregion Callbacks

        #region Public methods

        /// <summary>
        /// Sets Icon (and Text) of the Menu Button
        /// </summary>
        public void ApplyMenuButtonContent()
        {
            // Set the AutomationID
            this.SetValue(AutomationProperties.AutomationIdProperty, "SelectionTreeControl.MenuButton." + FeatureName);

            // Refresh the menu button content
            if (CmItemList.Count > 0)
            {
                ContextMenuItemContent item = CmItemList[(int)MenuButtonAction];
                // Create a new image because the image in item.Icon is already uses within
                // the visual tree of the context menu.
                Image image = LoadIcon(item.IconPath);
                image.Height = 32;
                image.Width = 32;
                //Label text = new Label { Content = item.Label, Margin = new Thickness(6, 0, 0, 0) };
                //Label text = new Label { Content = "", Margin = new Thickness(6, 0, 0, 0) };
                //Label text = new Label { Content = "" };
                TextBlock text = new TextBlock { Text = "" };
                StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Left };
                sp.Children.Add(image);
                sp.Children.Add(text);
                this.Content = sp;
                //this.Background = BackgroundColor;
                //this.Foreground = ForegroundColor;
                //this.BorderBrush = BackgroundColor;
            }
        }

        #endregion Publics methods

        #region Private methods

        /// <summary>
        /// Loads an image from the specified resource
        /// </summary>
        private Image LoadIcon(string ImagePath)
        {
            return new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/MenuButton;component/" + ImagePath)),
                Height = 24,
                Width = 24
            };
        }

        /// <summary>
        /// Get Action of selected ContextMenuItem
        /// </summary>
        private InstallType GetMenuButtonAction(string label)
        {
            InstallType type = InstallType.eSkip;

            foreach (ContextMenuItemContent item in CmItemList)
            {
                if (item.Label == label)
                {
                    type = (InstallType)item.Index;
                    break;
                }
            }

            return type;
        }

        /// <summary>
        /// Get the enable state of a context menu entry
        /// </summary>
        private bool GetContextMenuEnableState(InstallType type, string instVersion, string availVersion, bool canMigrate)
        {
            bool isEnabled = false;

            if (canMigrate)
            {
                switch (type)
                {
                    case InstallType.eInstall:
                    case InstallType.eUpdate:
                    //case InstallType.eInstallLayout:
                    case InstallType.eSkip:
                        break;
                    case InstallType.eMigrate:
                    case InstallType.eUninstall:
                        isEnabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    // Diese Unterscheidung gilt nicht für Gruppen
                    // Da der Button nicht weiss, ob er eine Gruppe darstellt,
                    // wird das alles erstmal weggelassen
                    //case InstallType.eInstall:
                    //    if (string.IsNullOrEmpty(instVersion) && !string.IsNullOrEmpty(availVersion))
                    //        isEnabled = true;
                    //    break;
                    //case InstallType.eUpdate:
                    //    if (!string.IsNullOrEmpty(instVersion) && !string.IsNullOrEmpty(availVersion))
                    //    {
                    //        Version installed = new Version(instVersion);
                    //        Version available = new Version(availVersion);
                    //        if (available > installed)
                    //            isEnabled = true;
                    //    }
                    //    break;
                    //case InstallType.eMigrate:
                    //    break;
                    //case InstallType.eUninstall:
                    //    if (!string.IsNullOrEmpty(instVersion))
                    //        isEnabled = true;
                    //    break;
                    //case InstallType.eInstallLayout:
                    //case InstallType.eSkip:
                    //    isEnabled = true;
                    //    break;
                    case InstallType.eInstall:
                    case InstallType.eUpdate:
                    //case InstallType.eInstallLayout:
                    case InstallType.eUninstall:
                    case InstallType.eSkip:
                        isEnabled = true;
                        break;
                    case InstallType.eMigrate:
                        break;
                    default:
                        break;
                }
            }

            return isEnabled;
        }

        /// <summary>
        /// Make sure the Context menu is not null
        /// </summary>
        private void EnsureContextMenuIsValid()
        {
            if (this.ContextMenu == null)
            {
                this.CreateContextMenu();
            }
        }

        /// <summary>
        /// Creates the context menu from CmItemList
        /// </summary>
        private void CreateContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            this.ContextMenu = contextMenu;
            this.ContextMenu.PlacementTarget = this;
            this.ContextMenu.Placement = Placement;
            this.ContextMenu.SetValue(AutomationProperties.AutomationIdProperty, (string)this.GetValue(AutomationProperties.AutomationIdProperty) + ".ContextMenu");

            this.ContextMenu.Opened += ((sender, routedEventArgs) => IsContextMenuOpen = true);
            this.ContextMenu.Closed += ((sender, routedEventArgs) => IsContextMenuOpen = false);

            // Replace the context menu labels by the localised labels
            if (LocalisedMenuLabels.Count > 0)
                for (int i = 0; i < CmItemList.Count; i++)
                    CmItemList[i].Label = LocalisedMenuLabels[i].Text;

            foreach (ContextMenuItemContent item in CmItemList)
            {
                if (item.Label != "Indeterminate")
                {
                    InstallType type = (InstallType)item.Index;
                    string instVersion = InstalledVersion;
                    string availVersion = AvailableVersion;
                    bool canMigrate = CanMigrate;
                    bool isEnabled = GetContextMenuEnableState(type, instVersion, availVersion, canMigrate);

                    var menuItem = new MenuItem();
                    menuItem.Header = item.Label;
                    menuItem.VerticalAlignment = VerticalAlignment.Center;
                    menuItem.Icon = isEnabled ? item.Icon : item.IconDisabled;
                    menuItem.IsEnabled = isEnabled;
                    menuItem.SetValue(AutomationProperties.AutomationIdProperty, "SelectionTreeControl.MenuButton.ContextMenu." + type.ToString());
                    menuItem.Click += new RoutedEventHandler(OnContextMenuItem_Clicked);
                    contextMenu.Items.Add(menuItem);
                }
            }
        }

        private void OnDropdown()
        {
            EnsureContextMenuIsValid();
            if (!this.ContextMenu.HasItems)
                return;

            this.ContextMenu.IsOpen = !IsContextMenuOpen; // open it if closed, close it if open
        }

        #endregion Private methods

        #region Events

        /*
         * Events
         * 
        */

        /// <summary>
        /// Event Handler for the Drop Down Button's Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dropdown_Click(object sender, RoutedEventArgs e)
        {
            OnDropdown();
            e.Handled = true;
        }

        /// <summary>
        /// Event Handler for the MenuItem's Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnContextMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            this.MenuButtonAction = GetMenuButtonAction(item.Header.ToString());
            e.Handled = true;
        }

        #endregion Events
    }


    public class MenuLabel
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }


    public sealed class MenuLabelCollection : ObservableCollection<MenuLabel>
    {
    }
}