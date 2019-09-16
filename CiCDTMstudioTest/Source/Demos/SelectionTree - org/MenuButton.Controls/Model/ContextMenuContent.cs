using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace MenuButton.Controls
{
    //public class ContextMenuItemContent : INotifyPropertyChanged
    public class ContextMenuItemContent : DependencyObject
    {
        #region Properties

        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
        }

        private Image _iconDisabled;
        public Image IconDisabled
        {
            get { return _iconDisabled; }
        }

        private string _label;
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private string _iconPath;
        public string IconPath
        {
            get { return _iconPath; }
            set 
            {
                if (_iconPath != value)
                {
                    _iconPath = value;
                    this.LoadIcon(_iconPath);
                }
            }
        }

        private string _iconPathDisabled;
        public string IconPathDisabled
        {
            get { return _iconPathDisabled; }
            set
            {
                if (_iconPathDisabled != value)
                {
                    _iconPathDisabled = value;
                    this.LoadIcon(_iconPathDisabled);
                }
            }
        }

        //private bool _isEnabled;
        //public bool IsEnabled
        //{
        //    get { return _isEnabled; }
        //    set { _isEnabled = value; }
        //}

        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //public ICommand ContextMenuCommand { get; set; }

        #endregion Properties

        #region Constructors

        public ContextMenuItemContent(int index, string lableText, string imagePath, string imagePathDisabled)
        {
            this._index = index;
            this._label = lableText;
            this._iconPath = imagePath;
            this._iconPathDisabled = imagePathDisabled;
            this._icon = LoadIcon(this._iconPath);
            this._iconDisabled = LoadIcon(this._iconPathDisabled);
        }
         
        public ContextMenuItemContent()
        {
        }

        #endregion Constructors

        #region Privates

        private Image LoadIcon(string ImagePath)
        {
            return new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/MenuButton;component/" + ImagePath)),
                Height = 24,
                Width = 24
            };
        }

        #endregion Privates

        #region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(string name)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //}

        #endregion
    
    }

    public class ContextMenuContent
    {
        private ObservableCollection<ContextMenuItemContent> _itemList;
        public ObservableCollection<ContextMenuItemContent> ItemList
        {
            get { return _itemList; }
            set { _itemList = value; }
        }

        public ContextMenuContent()
        {
            _itemList = new ObservableCollection<ContextMenuItemContent>();
        }
    }
}
