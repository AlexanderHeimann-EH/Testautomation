// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryMonitor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Registry
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using EH.ImsOpcBridge.Properties;

    using Microsoft.Win32;

    /// <summary>
    /// The registry monitor.
    /// </summary>
    public class RegistryMonitor : IRegistryMonitor
    {
        #region Constants and Fields

        /// <summary>
        /// The KeyNotify.
        /// </summary>
        private const int KeyNotify = 0x0010;

        /// <summary>
        /// The KeyQueryValue.
        /// </summary>
        private const int KeyQueryValue = 0x0001;

        /// <summary>
        /// The StandardRightsRead.
        /// </summary>
        private const int StandardRightsRead = 0x00020000;

        /// <summary>
        /// The HkeyClassesRoot.
        /// </summary>
        private static readonly UIntPtr HkeyClassesRoot = new UIntPtr(0x80000000);

        /// <summary>
        /// The HkeyCurrentConfig.
        /// </summary>
        private static readonly UIntPtr HkeyCurrentConfig = new UIntPtr(0x80000005);

        /// <summary>
        /// The HkeyCurrentUser.
        /// </summary>
        private static readonly UIntPtr HkeyCurrentUser = new UIntPtr(0x80000001);

        /// <summary>
        /// The HkeyDynData.
        /// </summary>
        private static readonly UIntPtr HkeyDynData = new UIntPtr(0x80000006);

        /// <summary>
        /// The HkeyLocalMachine.
        /// </summary>
        private static readonly UIntPtr HkeyLocalMachine = new UIntPtr(0x80000002);

        /// <summary>
        /// The HkeyPerformanceData.
        /// </summary>
        private static readonly UIntPtr HkeyPerformanceData = new UIntPtr(0x80000004);

        /// <summary>
        /// The HkeyUsers.
        /// </summary>
        private static readonly UIntPtr HkeyUsers = new UIntPtr(0x80000003);

        /// <summary>
        /// The terminate event.
        /// </summary>
        private readonly ManualResetEvent eventTerminate = new ManualResetEvent(false);

        /// <summary>
        /// The event, which is set when start monitoring is finished.
        /// </summary>
        private readonly AutoResetEvent startUpEvent = new AutoResetEvent(false);

        /// <summary>
        /// The _thread lock.
        /// </summary>
        private readonly object threadLock = new object();

        /// <summary>
        /// The _disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The regFilter.
        /// </summary>
        private RegChangeNotifyFilter regFilter = RegChangeNotifyFilter.Key | RegChangeNotifyFilter.Attribute | RegChangeNotifyFilter.Value | RegChangeNotifyFilter.Security;

        /// <summary>
        /// The _registry hive.
        /// </summary>
        private UIntPtr registryHive;

        /// <summary>
        /// The _registry sub name.
        /// </summary>
        private string registrySubName;

        /// <summary>
        /// The _thread.
        /// </summary>
        private Thread thread;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryMonitor"/> class.
        /// </summary>
        /// <param name="registryKey">The registry key.</param>
        public RegistryMonitor(RegistryKey registryKey)
        {
            if (registryKey == null)
            {
                throw new ArgumentNullException(@"registryKey");
            }
            
            this.InitRegistryKey(registryKey.Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryMonitor"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public RegistryMonitor(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.InitRegistryKey(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryMonitor"/> class.
        /// </summary>
        /// <param name="registryHive">The registry hive.</param>
        /// <param name="subkey">The subkey.</param>
        public RegistryMonitor(RegistryHive registryHive, string subkey)
        {
            this.InitRegistryKey(registryHive, subkey);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RegistryMonitor"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="RegistryMonitor"/> is reclaimed by garbage collection.
        /// </summary>
        ~RegistryMonitor()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when the specified registry key has changed.
        /// </summary>
        public event EventHandler RegChanged;

        /// <summary>
        /// Occurs when the access to the registry fails.
        /// </summary>
        public event ErrorEventHandler ReportError;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether IsMonitoring.
        /// </summary>
        public bool IsMonitoring
        {
            get
            {
                return this.thread != null;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="RegChangeNotifyFilter">RegChangeNotifyFilter</see>.
        /// </summary>
        /// <value>The reg change notify filter.</value>
        public RegChangeNotifyFilter RegChangeNotifyFilter
        {
            get
            {
                return this.regFilter;
            }

            set
            {
                lock (this.threadLock)
                {
                    if (this.IsMonitoring)
                    {
                        throw new InvalidOperationException(Resources.RegistryMonitoringThreadIsAlreadyRunning);
                    }

                    this.regFilter = value;
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Starts monitoring.
        /// </summary>
        public void StartMonitoring()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(null, Resources.RegistryMonitoringInstanceIsAlreadyDisposed);
            }

            lock (this.threadLock)
            {
                if (!this.IsMonitoring)
                {
                    this.startUpEvent.Reset();
                    this.eventTerminate.Reset();
                    this.thread = new Thread(this.MonitorThread) { IsBackground = true };
                    this.thread.Start();
                    this.startUpEvent.WaitOne(5000);
                }
            }
        }

        /// <summary>
        /// Stops the monitoring thread.
        /// </summary>
        public void StopMonitoring()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(null, Resources.RegistryMonitoringInstanceIsAlreadyDisposed);
            }

            lock (this.threadLock)
            {
                var localThread = this.thread;
                if (localThread != null)
                {
                    this.eventTerminate.Set();
                    localThread.Join();
                    this.startUpEvent.Reset();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="ReportError"/> event.
        /// </summary>
        /// <param name="ex">The <see cref="EH.ImsOpcBridge.Exception"/> which occurred while watching the registry.</param>
        protected virtual void OnError(Exception ex)
        {
            var handler = this.ReportError;
            if (handler != null)
            {
                handler(this, new ErrorEventArgs(ex));
            }
        }

        /// <summary>
        /// Raises the <see cref="RegChanged"/> event.
        /// </summary>
        protected virtual void OnRegChanged()
        {
            var handler = this.RegChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                this.StopMonitoring();
                this.eventTerminate.Dispose();
                this.startUpEvent.Dispose();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// The init registry key.
        /// </summary>
        /// <param name="hive">The hive.</param>
        /// <param name="name">The name.</param>
        private void InitRegistryKey(RegistryHive hive, string name)
        {
            switch (hive)
            {
                case RegistryHive.ClassesRoot:
                    this.registryHive = HkeyClassesRoot;
                    break;

                case RegistryHive.CurrentConfig:
                    this.registryHive = HkeyCurrentConfig;
                    break;

                case RegistryHive.CurrentUser:
                    this.registryHive = HkeyCurrentUser;
                    break;

                case RegistryHive.DynData:
                    this.registryHive = HkeyDynData;
                    break;

                case RegistryHive.LocalMachine:
                    this.registryHive = HkeyLocalMachine;
                    break;

                case RegistryHive.PerformanceData:
                    this.registryHive = HkeyPerformanceData;
                    break;

                case RegistryHive.Users:
                    this.registryHive = HkeyUsers;
                    break;

                default:
                    throw new InvalidEnumArgumentException("hive", (int)hive, typeof(RegistryHive));
            }

            this.registrySubName = name;
        }

        /// <summary>
        /// The init registry key.
        /// </summary>
        /// <param name="name">The name.</param>
        private void InitRegistryKey(string name)
        {
            var nameParts = name.Split('\\');

            switch (nameParts[0])
            {
                case "HKEY_CLASSES_ROOT":
                case "HKCR":
                    this.registryHive = HkeyClassesRoot;
                    break;

                case "HKEY_CURRENT_USER":
                case "HKCU":
                    this.registryHive = HkeyCurrentUser;
                    break;

                case "HKEY_LOCAL_MACHINE":
                case "HKLM":
                    this.registryHive = HkeyLocalMachine;
                    break;

                case "HKEY_USERS":
                    this.registryHive = HkeyUsers;
                    break;

                case "HKEY_CURRENT_CONFIG":
                    this.registryHive = HkeyCurrentConfig;
                    break;

                default:
                    this.registryHive = UIntPtr.Zero;
                    throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.TheRegistryHive_IsNotSupported, nameParts[0]), "name");
            }

            // ReSharper disable LocalizableElement
            this.registrySubName = string.Join("\\", nameParts, 1, nameParts.Length - 1);

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// The monitor thread.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        private void MonitorThread()
        {
            try
            {
                this.ThreadLoop();
            }
            catch (Exception e)
            {
                this.OnError(e);
            }

            this.thread = null;
        }

        /// <summary>
        /// The thread loop.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here."), SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "OK here.")]
        private void ThreadLoop()
        {
            var registryKey = new UIntPtr();
            int result;

            try
            {
                result = NativeMethods.RegOpenKeyEx(this.registryHive, this.registrySubName, 0, StandardRightsRead | KeyQueryValue | KeyNotify, ref registryKey);
                if (result != 0)
                {
                    throw new Win32Exception(result);
                }
            }
            finally
            {
                this.startUpEvent.Set();
            }

            try
            {
                var eventNotify = new AutoResetEvent(false);
                var waitHandles = new WaitHandle[] { eventNotify, this.eventTerminate };
                while (!this.eventTerminate.WaitOne(0, true))
                {
                    result = NativeMethods.RegNotifyChangeKeyValue(registryKey, true, this.regFilter, eventNotify.SafeWaitHandle, true);

                    this.startUpEvent.Set();

                    if (result != 0)
                    {
                        throw new Win32Exception(result);
                    }

                    if (WaitHandle.WaitAny(waitHandles) == 0)
                    {
                        if (!this.eventTerminate.WaitOne(0))
                        {
                            this.OnRegChanged();
                        }
                    }
                }
            }
            finally
            {
                if (registryKey != UIntPtr.Zero)
                {
                    NativeMethods.RegCloseKey(registryKey);
                }

                this.startUpEvent.Set();
            }
        }

        #endregion
    }
}
