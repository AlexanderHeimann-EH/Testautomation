// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectInstaller.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The project installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service
{
    using System;
    using System.ComponentModel;
    using System.ServiceProcess;

    /// <summary>
    /// Class ProjectInstaller
    /// </summary>
    [RunInstaller(true)]
    public class ProjectInstaller : System.Configuration.Install.Installer
    {
        #region Fields

        /// <summary>
        /// The process
        /// </summary>
        private ServiceProcessInstaller process;

        /// <summary>
        /// The service installer
        /// </summary>
        private ServiceInstaller serviceInstaller;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectInstaller"/> class.
        /// </summary>
        /// <exception cref="System.Exception">Exception Failed</exception>
        public ProjectInstaller()
        {
            // InitializeComponent();
            try
            {
                this.process = new ServiceProcessInstaller();
                this.process.Account = ServiceAccount.LocalSystem;

                this.serviceInstaller = new ServiceInstaller();
                this.serviceInstaller.ServiceName = Constants.ServiceName;
                this.serviceInstaller.DisplayName = Constants.DisplayName;
                this.serviceInstaller.Description = Constants.Description;
                this.serviceInstaller.StartType = ServiceStartMode.Manual;

                this.process.Password = null;
                this.process.Username = null;

                this.Installers.Add(this.process);
                this.Installers.Add(this.serviceInstaller);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed", ex);
            }
        }

        #endregion
    }
}