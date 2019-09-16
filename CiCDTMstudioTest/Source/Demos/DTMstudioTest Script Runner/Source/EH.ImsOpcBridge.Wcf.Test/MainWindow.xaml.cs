// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Wcf.Test
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;

    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Wcf.Interfaces;
    using EH.ImsOpcBridge.Wcf.Test.Wcf;

    /// <summary>
    /// Class MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants

        /// <summary>
        /// The client URI
        /// </summary>
        private const string ClientUri = @"http://localhost:8091/ServiceModel/EH/ImsOpcBridge/ServiceCallback";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.ServiceHostContainer = new ServiceHostContainer(new Uri(ClientUri), typeof(ICommServerCallback), typeof(CommServerCallback));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the service host container.
        /// </summary>
        /// <value>The service host container.</value>
        private ServiceHostContainer ServiceHostContainer { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Buttons the test export configuration request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestExportConfigurationRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                var configuration = new Configuration(true);
                configuration.Gateway.SerialNumber = "ExportedGateway";
                client.ExportConfigurationRequest(ClientUri, Guid.NewGuid(), configuration, @"D:\1Data\public\Temp\ImsOpcBridgeConfiguration.xml");
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test import configuration request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestImportConfigurationRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                client.ImportConfigurationRequest(ClientUri, Guid.NewGuid(), @"D:\1Data\public\Temp\ImsOpcBridgeConfiguration.xml");
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test load configuration request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestLoadConfigurationRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                client.LoadConfigurationRequest(ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test read local opc servers request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestReadLocalOpcServersRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                client.ReadLocalOpcServersRequest(ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test read opc address space request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestReadOpcAddressSpaceRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                client.ReadOpcAddressSpaceRequest(ClientUri, Guid.NewGuid(), "Endress.OpcDa.Promag800.1");
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test save configuration request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestSaveConfigurationRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                var configuration = new Configuration(true);
                configuration.Gateway.SerialNumber = "1234567890";
                client.SaveConfigurationRequest(ClientUri, Guid.NewGuid(), configuration);
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test start monitor request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestStartMonitorRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                var measurements = new ConfiguredMeasurements();

                for (int i = 0; i < 5; i++)
                {
                    Random rnd = new Random();
                    var randomNumber = rnd.Next(100);
                    var measurement = new ConfiguredMeasurement(true);
                    measurement.DeviceId = new ConfiguredMeasurementItem(true) { Value = "DeviceId_" + randomNumber.ToString(CultureInfo.InvariantCulture), MappingType = MappingTypes.StaticType };
                    measurement.SensorId = new ConfiguredMeasurementItem(true) { Value = "SensorId_" + randomNumber.ToString(CultureInfo.InvariantCulture), MappingType = MappingTypes.StaticType };
                    measurement.Unit = new ConfiguredMeasurementItem(true) { Value = "m3", MappingType = MappingTypes.StaticType };
                    measurement.DataType = CommonFormatDataTypes.FloatType;
                    measurement.Timestamp = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcTimestampType };
                    measurement.Quality = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcQualityType };
                    measurement.Value = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcValueType };
                    measurement.Active = true;
                    measurements.Add(measurement);
                }

                client.StartMonitorRequest(ClientUri, Guid.NewGuid(), measurements);
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Buttons the test stop monitor request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonTestStopMonitorRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new CommServerClient();
                client.StopMonitorRequest(ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                this.ServiceHostContainer.Stop();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ServiceHostContainer.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        #endregion
    }
}