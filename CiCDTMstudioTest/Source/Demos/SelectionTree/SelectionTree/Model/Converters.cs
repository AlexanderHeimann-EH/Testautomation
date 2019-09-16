using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using MenuButton.Controls;


namespace SelectionTree
{
    internal class InstallActionConverter : IValueConverter
    {
        public object Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            Feature feature = o as Feature;
            return feature != null ? (InstallType)feature.InstallAction : InstallType.eIndeterminate;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
