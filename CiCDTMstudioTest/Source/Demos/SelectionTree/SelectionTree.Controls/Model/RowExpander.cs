using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelectionTree.Controls.Tree
{
	public class RowExpander : Control
    {
        #region Properties

        /// <summary>
        /// MenuButton background colour
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor",
                                                                                                        typeof(Brush),
                                                                                                        typeof(RowExpander));
        /// <summary>
        /// The background colour value
        /// </summary>
        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        #endregion Properties

        static RowExpander()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RowExpander), new FrameworkPropertyMetadata(typeof(RowExpander)));

            //InitializeComponent();
		}
	}
}
