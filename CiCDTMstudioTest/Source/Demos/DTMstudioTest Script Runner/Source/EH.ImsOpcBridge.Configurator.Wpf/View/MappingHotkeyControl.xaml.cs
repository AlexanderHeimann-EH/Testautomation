// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingHotkeyControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MappingHotkeyControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class MappingHotkeyControl
    /// </summary>
    public partial class MappingHotkeyControl
    {
        #region Static Fields

        /// <summary>
        /// The export configuration command property
        /// </summary>
        public static readonly DependencyProperty DetailsCommandProperty = DependencyProperty.Register("DetailsCommand", typeof(DelegateCommand), typeof(MappingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The load configuration command property
        /// </summary>
        public static readonly DependencyProperty InsertRowCommandProperty = DependencyProperty.Register("InsertRowCommand", typeof(DelegateCommand), typeof(MappingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The save configuration command property
        /// </summary>
        public static readonly DependencyProperty DeleteRowCommandProperty = DependencyProperty.Register("DeleteRowCommand", typeof(DelegateCommand), typeof(MappingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));
           
        /// <summary>
        /// The tool tip insert measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipInsertMeasurementProperty = DependencyProperty.Register("ToolTipInsertMeasurement", typeof(string), typeof(MappingHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip delete measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipDeleteMeasurementProperty = DependencyProperty.Register("ToolTipDeleteMeasurement", typeof(string), typeof(MappingHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip edit measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipEditMeasurementProperty = DependencyProperty.Register("ToolTipEditMeasurement", typeof(string), typeof(MappingHotkeyControl), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingHotkeyControl"/> class.
        /// </summary>
        public MappingHotkeyControl()
        {
            this.ToolTipInsertMeasurement = Properties.Resources.InsertMeasurement;
            this.ToolTipDeleteMeasurement = Properties.Resources.DeleteMeasurement;
            this.ToolTipEditMeasurement = Properties.Resources.EditMeasurement;

            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the export configuration command.
        /// </summary>
        /// <value>The export configuration command.</value>
        public DelegateCommand DetailsCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(DetailsCommandProperty);
            }

            set
            {
                this.SetValue(DetailsCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the load configuration command.
        /// </summary>
        /// <value>The load configuration command.</value>
        public DelegateCommand InsertRowCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(InsertRowCommandProperty);
            }

            set
            {
                this.SetValue(InsertRowCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the save configuration command.
        /// </summary>
        /// <value>The save configuration command.</value>
        public DelegateCommand DeleteRowCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(DeleteRowCommandProperty);
            }

            set
            {
                this.SetValue(DeleteRowCommandProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the tool tip insert measurement.
        /// </summary>
        /// <value>The tool tip insert measurement.</value>
        public string ToolTipInsertMeasurement
        {
            get
            {
                return (string)this.GetValue(ToolTipInsertMeasurementProperty);
            }

            set
            {
                this.SetValue(ToolTipInsertMeasurementProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip delete measurement.
        /// </summary>
        /// <value>The tool tip delete measurement.</value>
        public string ToolTipDeleteMeasurement
        {
            get
            {
                return (string)this.GetValue(ToolTipDeleteMeasurementProperty);
            }

            set
            {
                this.SetValue(ToolTipDeleteMeasurementProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip edit measurement.
        /// </summary>
        /// <value>The tool tip edit measurement.</value>
        public string ToolTipEditMeasurement
        {
            get
            {
                return (string)this.GetValue(ToolTipEditMeasurementProperty);
            }

            set
            {
                this.SetValue(ToolTipEditMeasurementProperty, value);
            }
        }
        
        #endregion
    }
}