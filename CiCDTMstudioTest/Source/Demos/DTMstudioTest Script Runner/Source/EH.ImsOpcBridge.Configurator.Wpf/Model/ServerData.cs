// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The event log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class ServerData
    /// </summary>
    public class ServerData : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The class id property
        /// </summary>
        public static readonly DependencyProperty ClassIdProperty = DependencyProperty.Register("ClassId", typeof(string), typeof(ServerData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The ip address property
        /// </summary>
        public static readonly DependencyProperty IpAddressProperty = DependencyProperty.Register("IpAddress", typeof(string), typeof(ServerData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The name property
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ServerData), new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerData"/> class.
        /// </summary>
        /// <param name="opcServerItem">The opc server item.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ServerData(OpcServerItem opcServerItem)
        {
            this.Name = opcServerItem.Name;
            this.IpAddress = opcServerItem.IpAddress;
            this.ClassId = opcServerItem.ClassId;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the connected server.
        /// </summary>
        /// <value>The connected server.</value>
        public OpcServerItem ConnectedServer { get; set; }

        /// <summary>
        /// Gets or sets the class id.
        /// </summary>
        /// <value>The class id.</value>
        public string ClassId
        {
            get
            {
                return (string)this.GetValue(ClassIdProperty);
            }

            set
            {
                this.SetValue(ClassIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        public string IpAddress
        {
            get
            {
                return (string)this.GetValue(IpAddressProperty);
            }

            set
            {
                this.SetValue(IpAddressProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return (string)this.GetValue(NameProperty);
            }

            set
            {
                this.SetValue(NameProperty, value);
            }
        }

        #endregion
    }
}