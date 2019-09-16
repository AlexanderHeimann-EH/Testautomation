using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MenuButton.Controls;

namespace MenuButton
{
    class MenuButtonControlModel : DependencyObject
    {
        /// <summary>
        /// The dependency property of the Install Action to display in the GUI
        /// </summary>
        public static DependencyProperty ActionProperty = DependencyProperty.Register("Action", typeof(InstallType), typeof(MenuButtonControl));
        /// <summary>
        /// The Install Action value
        /// </summary>
        public InstallType Action
        {
            get { return (InstallType)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }
    }
}
