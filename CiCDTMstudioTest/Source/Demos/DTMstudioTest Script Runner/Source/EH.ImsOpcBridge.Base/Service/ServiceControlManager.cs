// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceControlManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service
{
    using System;
    using System.Linq;
    using System.Net;
    using System.ServiceProcess;

    /// <summary>
    /// The service control manager.
    /// </summary>
    public static class ServiceControlManager
    {
        #region Public Properties

        /// <summary>
        /// Gets the name of the host
        /// </summary>
        public static string DnsHostName
        {
            get
            {
                var dnsHostName = Dns.GetHostName();
                var localIp = Dns.GetHostEntry(dnsHostName);
                return localIp.HostName;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the SFG500 Comm Server Service is running.
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True when the service is started. Otherwise false.</returns>
        public static bool IsServiceRunning(string hostName, string serviceName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(@"hostName");
            }
            
            var serviceHostName = hostName;

            // ReSharper disable LocalizableElement
            if (serviceHostName.ToUpperInvariant() == @"LOCALHOST")
            {
                // ReSharper restore LocalizableElement
                serviceHostName = DnsHostName;
            }

            using (var service = new ServiceController(serviceName, serviceHostName))
            {
                try
                {
                    return service.Status == ServiceControllerStatus.Running;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Determines whether the service is installed.
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True when the service is installed. Otherwise false.</returns>
        public static bool IsServiceInstalled(string hostName, string serviceName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(@"hostName");
            }

            var serviceHostName = hostName;

            // ReSharper disable LocalizableElement
            if (serviceHostName.ToUpperInvariant() == @"LOCALHOST")
            {
                // ReSharper restore LocalizableElement
                serviceHostName = DnsHostName;
            }

            return ServiceController.GetServices(serviceHostName).Any(s => s.ServiceName == serviceName);
        }

        /// <summary>
        /// Starts the SFG500 Comm Server Service
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True when the service is started. Otherwise false.</returns>
        public static bool StartService(string hostName, string serviceName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(@"hostName");
            }
            
            var serviceHostName = hostName;

            // ReSharper disable LocalizableElement
            if (serviceHostName.ToUpperInvariant() == @"LOCALHOST")
            {
                // ReSharper restore LocalizableElement
                serviceHostName = DnsHostName;
            }

            using (var service = new ServiceController(serviceName, serviceHostName))
            {
                try
                {
                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        var timeout = TimeSpan.FromMilliseconds(45000);

                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    }

                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        return true;
                    }
                }
                catch (InvalidOperationException)
                {
                    return false;
                }

                return false;
            }
        }

        /// <summary>
        /// Stops the SFG500 Comm Server Service
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True when the service is stopped. Otherwise false.</returns>
        public static bool StopService(string hostName, string serviceName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(@"hostName");
            }

            var serviceHostName = hostName;

            // ReSharper disable LocalizableElement
            if (serviceHostName.ToUpperInvariant() == @"LOCALHOST")
            {
                // ReSharper restore LocalizableElement
                serviceHostName = DnsHostName;
            }

            using (var service = new ServiceController(serviceName, serviceHostName))
            {
                var timeout = TimeSpan.FromMilliseconds(45000);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion
    }
}
