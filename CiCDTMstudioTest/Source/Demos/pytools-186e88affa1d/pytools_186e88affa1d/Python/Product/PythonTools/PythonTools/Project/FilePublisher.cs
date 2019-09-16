﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Project {
    /// <summary>
    /// Publishes files to a file share
    /// </summary>
    [Export(typeof(IProjectPublisher))]
    class FilePublisher : IProjectPublisher {
        private readonly IServiceProvider _serviceProvider;

        [ImportingConstructor]
        public FilePublisher([Import(typeof(SVsServiceProvider))]IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        #region IProjectPublisher Members

        public void PublishFiles(IPublishProject project, Uri destination) {
            var files = project.Files;

            for (int i = 0; i < files.Count; i++) {
                var item = files[i];

                try {
                    // try copying without impersonating first...
                    CopyOneFile(destination, item);
                } catch (UnauthorizedAccessException) {
                    var resource = new NativeMethods._NETRESOURCE();
                    resource.dwType = NativeMethods.RESOURCETYPE_DISK;
                    resource.lpRemoteName = Path.GetPathRoot(destination.LocalPath);

                    NetworkCredential creds = null;
                    var res = VsCredentials.PromptForCredentials(
                        _serviceProvider,
                        destination,
                        new[] { "NTLM" }, "", out creds);

                    if (res != DialogResult.OK) {
                        throw;
                    }

                    var netAddRes = NativeMethods.WNetAddConnection3(
                        Process.GetCurrentProcess().MainWindowHandle,
                        ref resource,
                        creds.Password,
                        creds.Domain + "\\" + creds.UserName,
                        0
                    );

                    if (netAddRes != 0) {
                        string msg = Marshal.GetExceptionForHR((int)(((uint)0x80070000) | netAddRes)).Message;
                        throw new Exception("Incorrect user name or password: " + msg);
                    }

                    // re-try the file copy now that we're authenticated
                    CopyOneFile(destination, item);
                }

                project.Progress = (int)(((double)i / (double)files.Count) * 100);
            }
        }

        private static void CopyOneFile(Uri destination, IPublishFile item) {
            var destFile = CommonUtils.GetAbsoluteFilePath(destination.LocalPath, item.DestinationFile);
            Debug.WriteLine("CopyingOneFile: " + destFile);
            string destDir = Path.GetDirectoryName(destFile);
            if (!Directory.Exists(destDir)) {
                // don't create a file share (\\fob\oar)
                if (!Path.IsPathRooted(destDir) || Path.GetPathRoot(destDir) != destDir) {
                    Directory.CreateDirectory(destDir);
                    Debug.WriteLine("Created dir: " + destDir);
                }
            }

            File.Copy(item.SourceFile, destFile, true);
            Debug.WriteLine("Copied file: " + destFile);

            // Attempt to remove read-only attribute from the destination file.
            try {
                var attr = File.GetAttributes(destFile);

                if (attr.HasFlag(FileAttributes.ReadOnly)) {
                    File.SetAttributes(destFile, attr & ~FileAttributes.ReadOnly);
                    Debug.WriteLine("Removed read-only attribute.");
                }
            } catch (IOException) {
            } catch (UnauthorizedAccessException) {
            }
        }

        public string DestinationDescription {
            get { return "file path"; }
        }

        public string Schema {
            get { return "file"; }
        }

        #endregion
    }
}
