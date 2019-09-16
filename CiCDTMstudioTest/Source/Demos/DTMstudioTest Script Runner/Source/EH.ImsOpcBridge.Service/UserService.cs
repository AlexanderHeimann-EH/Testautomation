// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserService.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The user service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service
{
    using EH.ImsOpcBridge.Service.Implementation;

    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : System.ServiceProcess.ServiceBase
    {
        #region Fields

        /// <summary>
        /// The service launcher.
        /// </summary>
        private ServiceLauncher serviceLauncher;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {
            this.ServiceName = Constants.ServiceName;
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            if (args != null && args.Length == 1 && args[0].Length > 1 && (args[0][0] == '-' || args[0][0] == '/'))
            {
                switch (args[0].Substring(1).ToLower())
                {
                    default:
                        break;
                    case "install":
                    case "i":
                        SelfInstaller.InstallMe();
                        break;
                    case "uninstall":
                    case "u":
                        SelfInstaller.UninstallMe();
                        break;
                }
            }
            else
            {
                System.ServiceProcess.ServiceBase.Run(new UserService());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on start.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        protected override void OnStart(string[] args)
        {
            this.serviceLauncher = new ServiceLauncher();
            this.serviceLauncher.Start();
        }

        /// <summary>
        /// The on stop.
        /// </summary>
        protected override void OnStop()
        {
            this.serviceLauncher.Stop();
            this.serviceLauncher = null;
        }

        #endregion
    }
}