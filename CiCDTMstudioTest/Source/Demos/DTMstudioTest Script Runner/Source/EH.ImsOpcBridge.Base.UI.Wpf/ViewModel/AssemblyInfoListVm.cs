// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoListVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for assembly info list
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// View model for assembly info list
    /// </summary>
    public class AssemblyInfoListVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The assembly infos property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty AssemblyInfosProperty = DependencyProperty.Register("AssemblyInfos", typeof(ObservableCollection<IAssemblyInformation>), typeof(AssemblyInfoListVm), new PropertyMetadata(default(ObservableCollection<IAssemblyInformation>)));

        /// <summary>
        /// The header property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(AssemblyInfoListVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The is header visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsHeaderVisibleProperty = DependencyProperty.Register("IsHeaderVisible", typeof(bool), typeof(AssemblyInfoListVm), new PropertyMetadata(true));

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyInfoListVm"/> class. 
        /// </summary>
        /// <param name="assemblyInfos">
        /// collection of assembly information to be handled
        /// </param>
        public AssemblyInfoListVm(IEnumerable<IAssemblyInformation> assemblyInfos)
        {
            // set default values
            this.Header = Resources.AssemblyInfoListHeader;
            this.IsHeaderVisible = true;

            // apply the passed value
            if (assemblyInfos == null)
            {
                if (Logger.IsDebugEnabled)
                {
                    Logger.Error(Resources.AssemblyInfoListViewModelInitializedWithNullPleasePassEmptyListInstead);
                }

                this.AssemblyInfos = new ObservableCollection<IAssemblyInformation>();
            }
            else
            {
                this.AssemblyInfos = new ObservableCollection<IAssemblyInformation>(assemblyInfos);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets AssemblyInfos.
        /// </summary>
        public ObservableCollection<IAssemblyInformation> AssemblyInfos
        {
            get
            {
                return (ObservableCollection<IAssemblyInformation>)this.GetValue(AssemblyInfosProperty);
            }

            private set
            {
                this.SetValue(AssemblyInfosProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets header text.
        /// </summary>
        public string Header
        {
            get
            {
                return (string)this.GetValue(HeaderProperty);
            }

            set
            {
                this.SetValue(HeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the header is visible
        /// </summary>
        public bool IsHeaderVisible
        {
            get
            {
                return (bool)this.GetValue(IsHeaderVisibleProperty);
            }

            set
            {
                this.SetValue(IsHeaderVisibleProperty, value);
            }
        }

        #endregion
    }
}
