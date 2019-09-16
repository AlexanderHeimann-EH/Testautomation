// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for command control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// View model for command control.
    /// </summary>
    public class CommandControlVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        ///   The commands property.
        /// </summary>
        public static readonly DependencyProperty CommandsProperty = DependencyProperty.Register("Commands", typeof(ObservableCollection<CommandVm>), typeof(CommandControlVm), new PropertyMetadata(default(ObservableCollection<CommandVm>)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandControlVm"/> class.
        /// </summary>
        public CommandControlVm()
        {
            this.Commands = new ObservableCollection<CommandVm>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets Commands.
        /// </summary>
        /// <value>The commands.</value>
        public ObservableCollection<CommandVm> Commands
        {
            get
            {
                return (ObservableCollection<CommandVm>)this.GetValue(CommandsProperty);
            }

            private set
            {
                this.SetValue(CommandsProperty, value);
            }
        }

        #endregion
    }
}
