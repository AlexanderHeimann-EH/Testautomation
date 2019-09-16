using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MenuButton.Controls;


namespace MenuButton
{
    /// <summary>
    /// Interaction logic for MenuButtonControl.xaml
    /// </summary>
    public partial class MenuButtonControl : UserControl
    {
        #region Properties

        /// <summary>
        /// The dependency property of the InstallAction to display in the GUI
        /// </summary>
        public static DependencyProperty ActionProperty = DependencyProperty.Register("Action", 
                                                                                      typeof(InstallType), 
                                                                                      typeof(MenuButtonControl),
                                                                                      new FrameworkPropertyMetadata(InstallType.eIndeterminate));
        /// <summary>
        /// The InstallAction value
        /// </summary>
        public InstallType Action
        {
            get { return (InstallType)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        /// <summary>
        /// The context menu items
        /// </summary>
        private List<ContextMenuItemContent> contextMenuItems = new List<ContextMenuItemContent>();
        public List<ContextMenuItemContent> ContextMenuItems
        {
            get { return (List<ContextMenuItemContent>)contextMenuItems; }
            set { contextMenuItems = value; }
        }

        /// <summary>
        /// The installed version
        /// Installed version and available version are used to determin 
        /// the enable state of the context menue items
        /// </summary>
        public static DependencyProperty InstalledVersionProperty = DependencyProperty.Register("InstalledVersion",
                                                                                                typeof(string),
                                                                                                typeof(MenuButtonControl),
                                                                                                new FrameworkPropertyMetadata(""));
        /// <summary>
        /// The InstalledVersion value
        /// </summary>
        public string InstalledVersion
        {
            get { return (string)GetValue(InstalledVersionProperty); }
            set { SetValue(InstalledVersionProperty, value); }
        }

        /// <summary>
        /// The available version
        /// Installed version and available version are used to determin 
        /// the enable state of the context menue items
        /// </summary>
        public static DependencyProperty AvailableVersionProperty = DependencyProperty.Register("AvailableVersion",
                                                                                                typeof(string),
                                                                                                typeof(MenuButtonControl),
                                                                                                new FrameworkPropertyMetadata(""));
        /// <summary>
        /// The AvailableVersion value
        /// </summary>
        public string AvailableVersion
        {
            get { return (string)GetValue(AvailableVersionProperty); }
            set { SetValue(AvailableVersionProperty, value); }
        }

        /// <summary>
        /// The Feature name used to identify the Button and its context menu.
        /// </summary>
        public static DependencyProperty FeatureNameProperty = DependencyProperty.Register("FeatureName",
                                                                                           typeof(string),
                                                                                           typeof(MenuButtonControl),
                                                                                           new FrameworkPropertyMetadata(""));
        /// <summary>
        /// The Feature name value
        /// </summary>
        public string FeatureName
        {
            get { return (string)GetValue(FeatureNameProperty); }
            set { SetValue(FeatureNameProperty, value); }
        }

        /// <summary>
        /// The migration flag
        /// Tells the menue button whether to enable the context menue item "Migrate" or not 
        /// </summary>
        public static DependencyProperty EnableMigrationProperty = DependencyProperty.Register("EnableMigration",
                                                                                               typeof(bool),
                                                                                               typeof(MenuButtonControl),
                                                                                               new FrameworkPropertyMetadata(false));
        /// <summary>
        /// The EnableMigration value
        /// </summary>
        public bool EnableMigration
        {
            get { return (bool)GetValue(EnableMigrationProperty); }
            set { SetValue(EnableMigrationProperty, value); }
        }

        /// <summary>
        /// MenuButton background colour without focus
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor",
                                                typeof(Brush),
                                                typeof(MenuButtonControl));
        /// <summary>
        /// The background colour value
        /// </summary>
        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// MenuButton background colour with focus
        /// </summary>
        public static readonly DependencyProperty BackgroundFocusColorProperty = DependencyProperty.Register("BackgroundFocusColor",
                                                                                                             typeof(Brush),
                                                                                                             typeof(MenuButtonControl));
        /// <summary>
        /// The background colour value
        /// </summary>
        public Brush BackgroundFocusColor
        {
            get { return (Brush)GetValue(BackgroundFocusColorProperty); }
            set { SetValue(BackgroundFocusColorProperty, value); }
        }

        /// <summary>
        /// MenuButton foreground colour
        /// </summary>
        public static readonly DependencyProperty ForegroundColorProperty = DependencyProperty.Register("ForegroundColor",
                                                typeof(Brush),
                                                typeof(MenuButtonControl));
        /// <summary>
        /// The foreground colour value
        /// </summary>
        public Brush ForegroundColor
        {
            get { return (Brush)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        /// <summary>
        /// The dependency property of the localised context menu item labels
        /// </summary>
        public static readonly DependencyProperty LocalisedMenuLabelsProperty = DependencyProperty.Register("LocalisedMenuLabels",
                                                                                                            typeof(MenuLabelCollection),
                                                                                                            typeof(MenuButtonControl),
                                                                                                            new FrameworkPropertyMetadata(new MenuLabelCollection(),
                                                                                                                                          new PropertyChangedCallback(OnMenuLabelsChanged)));
        /// <summary>
        /// The localised labels of the context menu
        /// </summary>
        public MenuLabelCollection LocalisedMenuLabels
        {
            get { return (MenuLabelCollection)GetValue(LocalisedMenuLabelsProperty); }
            set { SetValue(LocalisedMenuLabelsProperty, value); }
        }

        #endregion Properties

        #region Contructor

        public MenuButtonControl()
        {
            InitializeComponent();

            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eSkip, 
            //                                                  Label = "Skip", 
            //                                                  IconPath = "Resources/Skip.png", 
            //                                                  IconPathDisabled = "Resources/Disabled/Skip.png" });
            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eInstall, 
            //                                                  Label = "Install",
            //                                                  IconPath = "Resources/Install.png",
            //                                                  IconPathDisabled = "Resources/Disabled/Install.png" });
            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eUpdate, 
            //                                                  Label = "Update",
            //                                                  IconPath = "Resources/Update.png",
            //                                                  IconPathDisabled = "Resources/Disabled/Update.png" });
            ////ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eInstallLayout, 
            ////                                                  Label = "Install Layout",
            ////                                                  IconPath = "Resources/InstallLayout.png",
            ////                                                  IconPathDisabled = "Resources/Disabled/InstallLayout.png" });
            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eUninstall, 
            //                                                  Label = "Uninstall",
            //                                                  IconPath = "Resources/Uninstall.png",
            //                                                  IconPathDisabled = "Resources/Disabled/Uninstall.png" });
            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eMigrate, 
            //                                                  Label = "Migrate",
            //                                                  IconPath = "Resources/Migrate.png",
            //                                                  IconPathDisabled = "Resources/Disabled/Migrate.png" });
            //ContextMenuItems.Add(new ContextMenuItemContent { Index = (int)InstallType.eIndeterminate, 
            //                                                  Label = "Indeterminate",
            //                                                  IconPath = "Resources/Indefinite.png",
            //                                                  IconPathDisabled = "Resources/Disabled/Indefinite.png" });
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eSkip,          "Skip",           "Resources/Skip.png",          "Resources/Disabled/Skip.png"));
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eInstall,       "Install",        "Resources/Install.png",       "Resources/Disabled/Install.png"));
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eUpdate,        "Update",         "Resources/Update.png",        "Resources/Disabled/Update.png"));
            //ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eInstallLayout, "Install Layout", "Resources/InstallLayout.png", "Resources/Disabled/InstallLayout.png"));
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eUninstall,     "Uninstall",      "Resources/Uninstall.png",     "Resources/Disabled/Uninstall.png"));
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eMigrate,       "Migrate",        "Resources/Migrate.png",       "Resources/Disabled/Migrate.png"));
            ContextMenuItems.Add(new ContextMenuItemContent((int)InstallType.eIndeterminate, "Indeterminate",  "Resources/Indefinite.png",    "Resources/Disabled/Indefinite.png"));
        }

        #endregion Contructor

        #region Eventhandling

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            MenuButton.LocalisedMenuLabels = LocalisedMenuLabels;
            MenuButton.CmItemList = ContextMenuItems;
            MenuButton.ApplyMenuButtonContent();
        }

        private static void OnMenuLabelsChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MenuButtonControl button = (MenuButtonControl)sender;

            var oldCollection = e.OldValue as MenuLabelCollection;
            if (oldCollection != null)
                oldCollection.CollectionChanged -= button.OnMenuLabelChanged;

            var newCollection = e.NewValue as MenuLabelCollection;
            if (newCollection != null)
                newCollection.CollectionChanged += button.OnMenuLabelChanged;
        }

        private void OnMenuLabelChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
			//TODO: handle other cases!

			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					foreach (var MenuLabel in e.NewItems)
					{
						//connects the parent to the child, AND the child to the parent
						AddLogicalChild(MenuLabel);
					}

					break;
				default:
					break;
			}
        }

        #endregion Eventhandling
    }

}
