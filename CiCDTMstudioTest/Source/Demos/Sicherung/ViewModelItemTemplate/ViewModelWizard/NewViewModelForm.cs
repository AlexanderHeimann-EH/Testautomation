using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViewModelWizard
{
    public partial class NewViewModelForm : Form
    {
        public NewViewModelForm()
        {
            InitializeComponent();
        }

        public bool IncludeExample
        {
            get { return checkBoxIncludeExample.Checked; }
        }

        public string PropertyName
        {
            get { return textBoxPropertyName.Text; }
        }

        public string PropertyType
        {
            get { return textBoxPropertyType.Text; }
        }
    }
}
