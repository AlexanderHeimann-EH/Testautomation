// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingletonApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// The singleton application.
    /// </summary>
    public class SingletonApplication : IDisposable
    {
        #region Fields

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// My mutex.
        /// </summary>
        private Mutex myMutex;

        /// <summary>
        /// The running process id.
        /// </summary>
        private long? runningProcessId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonApplication" /> class.
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier.</param>
        public SingletonApplication(string uniqueIdentifier)
        {
            this.UniqueIdentifier = uniqueIdentifier;
            this.CheckForRunningProcess();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SingletonApplication" /> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="SingletonApplication" /> is reclaimed by garbage collection.
        /// </summary>
        ~SingletonApplication()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance is process running.
        /// </summary>
        /// <value><c>true</c> if this instance is process running; otherwise, <c>false</c>.</value>
        public bool IsProcessRunning
        {
            get
            {
                return this.runningProcessId.HasValue;
            }
        }

        /// <summary>
        /// Gets the running process id.
        /// </summary>
        /// <value>The running process unique identifier.</value>
        public long? RunningProcessId
        {
            get
            {
                return this.runningProcessId;
            }
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueIdentifier { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Brings the running application automatic front.
        /// </summary>
        /// <returns><c>true</c> if the running application could be brought to front, <c>false</c> otherwise.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        public bool BringRunningApplicationToFront()
        {
            if (!this.runningProcessId.HasValue)
            {
                return false;
            }

            try
            {
                var process = Process.GetProcessById((int)this.runningProcessId.Value);
                var winHandle = process.MainWindowHandle;
                if (winHandle != IntPtr.Zero)
                {
                    // ReSharper disable InconsistentNaming
                    const int SW_RESTORE = 9;
                    int result;

                    if (NativeMethods.IsIconic(winHandle) != 0)
                    {
                        result = NativeMethods.ShowWindow(winHandle, SW_RESTORE);
                        if (result != 0)
                        {
                        }
                    }

                    result = NativeMethods.SetForegroundWindow(winHandle);
                    if (result != 0)
                    {
                    }

                    return true;

                    // ReSharper restore InconsistentNaming
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

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

        #endregion

        #region Methods

        /// <summary>
        /// Checks for running process.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        private void CheckForRunningProcess()
        {
            // ReSharper disable EmptyGeneralCatchClause
            var runningProcesses = Process.GetProcesses();
            var myProcessName = Process.GetCurrentProcess().ProcessName;

            foreach (var runningProcess in runningProcesses)
            {
                if (myProcessName == runningProcess.ProcessName)
                {
                    try
                    {
                        using (var mutex = Mutex.OpenExisting(@"Local\" + this.UniqueIdentifier + runningProcess.Id))
                        {
                            // if the upper Mutex.OpenExisting succeeds, a mutex is already created, so
                            // an instance signaling the searched mutex is already running
                            this.runningProcessId = runningProcess.Id;
                            break;
                        }
                    }
                    catch (WaitHandleCannotBeOpenedException)
                    {
                    }
                    catch (IOException)
                    {
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }

            if (!this.runningProcessId.HasValue)
            {
                this.myMutex = new Mutex(true, @"Local\" + this.UniqueIdentifier + Process.GetCurrentProcess().Id);
            }

            // ReSharper restore EmptyGeneralCatchClause
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

                if (this.myMutex != null)
                {
                    this.myMutex.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        #endregion
    }
}
