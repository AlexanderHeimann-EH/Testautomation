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

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Microsoft.PythonTools.Logging {
    /// <summary>
    /// Keeps track of logged events and makes them available for display in the diagnostics window.
    /// </summary>
    [Export(typeof(IPythonToolsLogger))]
    [Export(typeof(InMemoryLogger))]
    class InMemoryLogger : IPythonToolsLogger {
        private int _installedInterpreters;
        private int _configuredInterpreters;
        private int _debugLaunchCount, _normalLaunchCount;
        private List<PackageInstallDetails> _packageInstalls = new List<PackageInstallDetails>();

        #region IPythonToolsLogger Members

        public void LogEvent(PythonLogEvent logEvent, object argument) {
            switch (logEvent) {
                case PythonLogEvent.Launch:
                    if ((int)argument != 0) {
                        _debugLaunchCount++;
                    } else {
                        _normalLaunchCount++;
                    }
                    break;
                case PythonLogEvent.InstalledInterpreters:
                    _installedInterpreters = (int)argument;
                    break;
                case PythonLogEvent.ConfiguredInterpreters:
                    _configuredInterpreters = (int)argument;
                    break;
                case PythonLogEvent.PackageInstalled:
                    var packageInstallDetails = argument as PackageInstallDetails;
                    if (packageInstallDetails != null) {
                        _packageInstalls.Add(packageInstallDetails);
                    }
                    break;
            }
        }

        #endregion

        public override string ToString() {
            StringBuilder res = new StringBuilder();
            res.AppendLine("Installed Interpreters: " + _installedInterpreters);
            res.AppendLine("Configured Interpreters: " + _configuredInterpreters);
            res.AppendLine("Debug Launches: " + _debugLaunchCount);
            res.AppendLine("Normal Launches: " + _normalLaunchCount);

            res.AppendLine();
            if (_packageInstalls.Count > 0) {
                res.AppendLine("Installed Packages:");
                res.AppendLine(PackageInstallDetails.Header());
                res.AppendLine("  Successful Installations");
                foreach (PackageInstallDetails pd in _packageInstalls.Where(p => p.InstallResult == 0)) {
                    res.AppendLine("    " + pd.ToString());
                }
                res.AppendLine();
                res.AppendLine("  Failed Installations");
                foreach (PackageInstallDetails pd in _packageInstalls.Where(p => p.InstallResult != 0)) {
                    res.AppendLine("    " + pd.ToString());
                }
            }

            return res.ToString();
        }
    }
}
