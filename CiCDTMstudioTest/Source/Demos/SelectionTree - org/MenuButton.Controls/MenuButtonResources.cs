using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MenuButton.Controls
{
    /// <summary>
    /// Class used for the ComponentResourceKey
    /// </summary>
    public class MenuButtonResources
    {
        public static ComponentResourceKey MenuButtonButtonStyleKey
        {
            get { return new ComponentResourceKey(typeof(MenuButtonResources), "MenuButtonButtonStyle"); }
        }
    }
}
