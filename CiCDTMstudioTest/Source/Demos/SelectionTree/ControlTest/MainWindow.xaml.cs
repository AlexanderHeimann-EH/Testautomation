using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SelectionTree;

namespace ControlTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ListType { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ListType = 0;
            FeatureModel model = new FeatureModel();
            PrepareModel(model);
            FeatureSelectList.DataContext = model;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //PrepareFeatureList();
            //FeatureSelectList.DataContext = featureList;
        }


        private void PrepareModel(FeatureModel model)
        {
            model.FeatureList.Clear();

            switch (ListType)
            {
                case 0:
                    model.FeatureList.Add(new Feature("Flow"));
                    model.FeatureList.Add(new Feature("Level"));
                    model.FeatureList.Add(new Feature("Pressure"));
                    model.FeatureList.Add(new Feature("Temperature"));
                    model.FeatureList.Add(new Feature("Analysis"));
                    break;
                case 1:
                    model.FeatureList.Add(new Feature("HART"));
                    model.FeatureList.Add(new Feature("Modbus"));
                    model.FeatureList.Add(new Feature("Profibus"));
                    break;
                case 2:
                    model.FeatureList.Add(new Feature("All"));
                    break;
                default:
                    break;
            }

            if (model.FeatureList.Count > 0)
            {
                FeatureCollection List_1 = model.FeatureList[0].Children;
                if (ListType == 0)
                {
                    List_1.Add(new Feature("HART"));
                    List_1.Add(new Feature("Modbus"));
                    FeatureCollection List_1_1 = List_1[0].Children;
                    FeatureCollection List_1_2 = List_1[1].Children;
                    List_1_1.Add(new Feature("Promas 100 HART", "12.1.8", "12.2.0", false, -1, InstallType.eUpdate));
                    List_1_1.Add(new Feature("Promag 400 HART", "", "13.4.1", false, -1, InstallType.eInstall));
                    List_1_2.Add(new Feature("Levelflex FMP5x PA", "", "8.12.2", false, -1, InstallType.eInstall));
                    List_1_2.Add(new Feature("Micropilot TMR5x PA", "", "8.12.3", false, -1, InstallType.eInstall));
                }
                else if (ListType == 1)
                {
                    List_1.Add(new Feature("Flow"));
                    List_1.Add(new Feature("Level"));
                    FeatureCollection List_1_1 = List_1[0].Children;
                    FeatureCollection List_1_2 = List_1[1].Children;
                    List_1_1.Add(new Feature("Promas 100 HART", "12.1.8", "12.2.0", false, -1, InstallType.eUpdate));
                    List_1_1.Add(new Feature("Promag 400 HART", "", "13.4.1", false, -1, InstallType.eInstall));
                    List_1_2.Add(new Feature("Levelflex FMP5x PA", "", "8.12.2", false, -1, InstallType.eInstall));
                    List_1_2.Add(new Feature("Micropilot TMR5x PA", "", "8.12.3", false, -1, InstallType.eInstall));
                }
                else
                {
                    List_1.Add(new Feature("Promas 100 HART", "12.1.8", "12.2.0", false, -1, InstallType.eUpdate));
                    List_1.Add(new Feature("Promag 400 HART", "", "13.4.1", false, -1, InstallType.eInstall));
                }
                model.FeatureList[0].Initialize();
            }

            if (model.FeatureList.Count > 1)
            {
                model.FeatureList[1].Children.Add(new Feature("Levelflex FMP5x PA", "", "8.12.2", false, -1, InstallType.eInstall));
                model.FeatureList[1].Children.Add(new Feature("Micropilot TMR5x PA", "", "8.12.3", false, -1, InstallType.eInstall));
                model.FeatureList[1].Initialize();
            }

            if (model.FeatureList.Count > 2)
            {
                model.FeatureList[2].Children.Add(new Feature("Cerabar S", "9.2.5", "11.4.1", false, -1, InstallType.eUpdate));
                model.FeatureList[2].Children.Add(new Feature("Deltabar S", "", "11.4.3", false, -1, InstallType.eInstall));
                model.FeatureList[2].Initialize();
            }

            if (model.FeatureList.Count > 3)
            {
                model.FeatureList[3].Children.Add(new Feature("iTEMP TMT82 HART", "", "7.5.8", false, -1, InstallType.eInstall));
                model.FeatureList[3].Initialize();
            }

            if (model.FeatureList.Count > 4)
            {
                model.FeatureList[4].Initialize();
            }


            // Feature List headers

            model.ColumnHeader1 = "Produkt";
            model.ColumnHeader2 = "Installierte Version";
            model.ColumnHeader3 = "Verfügbare Version";


            // Context Menu
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Übergehen" });
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Installieren" });
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Aktualisieren" });
            //model.ContextMenuEntries.Add(new MenuLabel { Text = "Bereitstellen" });
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Deinstallieren" });
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Migrieren" });
            // Entry "Indeterminate" must be the last one. It will not be displayed.
            // It's used for the MenuButton icon.
            model.ContextMenuEntries.Add(new MenuLabel { Text = "Indeterminate" });
        }


        private void OnChangeClick(object sender, RoutedEventArgs e)
        {
            if (++ListType > 2)
                ListType = 0;

            FeatureModel model = FeatureSelectList.DataContext as FeatureModel;
            PrepareModel(model);
            //FeatureModel model = new FeatureModel();
            //PrepareModel(model);
            FeatureSelectList.DataContext = null;
            FeatureSelectList.DataContext = model;
        }

    }
}
