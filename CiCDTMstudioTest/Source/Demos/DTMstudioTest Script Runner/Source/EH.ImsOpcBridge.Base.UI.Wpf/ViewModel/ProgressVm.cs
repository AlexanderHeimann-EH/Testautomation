// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.UI.Wpf
// Author           : I02423401
// Created          : 08-27-2012
//
// Last Modified By : I02423401
// Last Modified On : 08-27-2012
// ***********************************************************************
// <copyright file="ProgressVm.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf.EventArguments;

    /// <summary>
    /// View model for progress bar
    /// </summary>
    public class ProgressVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The is busy property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(ProgressVm), new PropertyMetadata(false));

        /// <summary>
        /// The items property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<ProgressItemVm>), typeof(ProgressVm), new PropertyMetadata(default(ObservableCollection<ProgressItemVm>)));

        /// <summary>
        /// The percentage property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("Percentage", typeof(int), typeof(ProgressVm), new PropertyMetadata(0));

        /// <summary>
        /// The subtitle property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Subtitle", typeof(string), typeof(ProgressVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ProgressVm), new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressVm" /> class.
        /// </summary>
        public ProgressVm()
        {
            this.Items = new ObservableCollection<ProgressItemVm>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the there is a progress running.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (bool)this.GetValue(IsBusyProperty);
                }

                return (bool)this.Dispatcher.Invoke((Func<bool>)(() => this.IsBusy));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(IsBusyProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.IsBusy = value; });
                }
            }
        }

        /// <summary>
        /// Gets Items.
        /// </summary>
        /// <value>The items.</value>
        public ObservableCollection<ProgressItemVm> Items
        {
            get
            {
                return (ObservableCollection<ProgressItemVm>)this.GetValue(ItemsProperty);
            }

            private set
            {
                this.SetValue(ItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the percentage of reached progress
        /// </summary>
        /// <value>The percentage.</value>
        public int Percentage
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (int)this.GetValue(PercentageProperty);
                }

                return (int)this.Dispatcher.Invoke((Func<int>)(() => this.Percentage));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(PercentageProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.Percentage = value; });
                }
            }
        }

        /// <summary>
        /// Gets or sets the control title text
        /// </summary>
        /// <value>The subtitle.</value>
        public string Subtitle
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (string)this.GetValue(SubtitleProperty);
                }

                return (string)this.Dispatcher.Invoke((Func<string>)(() => this.Subtitle));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(SubtitleProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.Subtitle = value; });
                }
            }
        }

        /// <summary>
        /// Gets or sets the control title text
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (string)this.GetValue(TitleProperty);
                }

                return (string)this.Dispatcher.Invoke((Func<string>)(() => this.Title));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(TitleProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.Title = value; });
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Add a progress item.
        /// </summary>
        /// <param name="progItem">The progress item.</param>
        public void Add(IProgressItem progItem)
        {
            var progressItemViewModel = new ProgressItemVm(progItem);

            this.Title = progressItemViewModel.Title;
            this.Subtitle = progressItemViewModel.Text;
            this.Percentage = progressItemViewModel.Percentage;

            progressItemViewModel.Completed += this.ProgressItemCompletedHandler;

            if (progressItemViewModel.IsBusy)
            {
                this.Items.Add(progressItemViewModel);
                this.IsBusy = true;
            }
            else
            {
                progressItemViewModel.Completed -= this.ProgressItemCompletedHandler;
            }
        }

        /// <summary>
        /// Removes a progress item.
        /// </summary>
        /// <param name="progItem">The progress item.</param>
        public void Remove(IProgressItem progItem)
        {
            foreach (var progressItemViewModel in this.Items)
            {
                if (progressItemViewModel.ProgressItem == progItem)
                {
                    progressItemViewModel.Completed -= this.ProgressItemCompletedHandler;
                    this.Items.Remove(progressItemViewModel);

                    this.IsBusy = this.Items.Count > 0;

                    return;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The progress item completed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgressItemCompletedHandler(object sender, ProgressItemEventArgs e)
        {
            if (this.Dispatcher.CheckAccess())
            {
                if (e.CompletedItem != null)
                {
                    e.CompletedItem.Completed -= this.ProgressItemCompletedHandler;
                    this.Items.Remove(e.CompletedItem);
                }

                this.IsBusy = this.Items.Count > 0;
            }
            else
            {
                this.Dispatcher.Invoke((Action)delegate { this.ProgressItemCompletedHandler(sender, e); });
            }
        }

        #endregion
    }
}
