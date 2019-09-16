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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Project {
    public partial class DefaultPythonLauncherOptions : UserControl, IPythonLauncherOptions {
        private readonly IPythonProject _properties;
        private bool _loadingSettings;

        public DefaultPythonLauncherOptions(IPythonProject properties) {
            _properties = properties;
            InitializeComponent();

#if DEV11_OR_LATER
            _debugGroup.Visible = true;
            _mixedMode.Visible = true;
#endif
        }

        #region ILauncherOptionsControl Members

        public void SaveSettings() {
            _properties.SetProperty(PythonConstants.SearchPathSetting, SearchPaths);
            _properties.SetProperty(CommonConstants.CommandLineArguments, Arguments);
            _properties.SetProperty(PythonConstants.InterpreterPathSetting, InterpreterPath);
            _properties.SetProperty(PythonConstants.InterpreterArgumentsSetting, InterpreterArguments);
            _properties.SetProperty(PythonConstants.EnableNativeCodeDebugging, EnableNativeCodeDebugging.ToString());
            _properties.SetProperty(PythonConstants.EnvironmentSetting, Environment);
            RaiseIsSaved();
        }

        public void LoadSettings() {
            _loadingSettings = true;
            SearchPaths = _properties.GetUnevaluatedProperty(PythonConstants.SearchPathSetting);
            InterpreterPath = _properties.GetUnevaluatedProperty(PythonConstants.InterpreterPathSetting);
            Arguments = _properties.GetUnevaluatedProperty(CommonConstants.CommandLineArguments);
            InterpreterArguments = _properties.GetUnevaluatedProperty(PythonConstants.InterpreterArgumentsSetting);
            Environment = _properties.GetUnevaluatedProperty(PythonConstants.EnvironmentSetting);

            bool enableNativeCodeDebugging;
            bool.TryParse(_properties.GetUnevaluatedProperty(PythonConstants.EnableNativeCodeDebugging), out enableNativeCodeDebugging);
            EnableNativeCodeDebugging = enableNativeCodeDebugging;

            _loadingSettings = false;
        }

        public void ReloadSetting(string settingName) {
            switch (settingName) {
                case PythonConstants.SearchPathSetting:
                    SearchPaths = _properties.GetUnevaluatedProperty(PythonConstants.SearchPathSetting);
                    break;
                case PythonConstants.EnvironmentSetting:
                    Environment = _properties.GetUnevaluatedProperty(PythonConstants.EnvironmentSetting);
                    break;
            }
        }

        public event EventHandler<DirtyChangedEventArgs> DirtyChanged;

        Control IPythonLauncherOptions.Control {
            get { return this; }
        }

        #endregion

        public string SearchPaths {
            get { return _searchPaths.Text; }
            set { _searchPaths.Text = value; }
        }

        public string Arguments {
            get { return _arguments.Text; }
            set { _arguments.Text = value; }
        }

        public string InterpreterPath {
            get { return _interpreterPath.Text; }
            set { _interpreterPath.Text = value; }
        }

        public string InterpreterArguments {
            get { return _interpArgs.Text; }
            set { _interpArgs.Text = value; }
        }

        private static Regex lfToCrLfRegex = new Regex(@"(?<!\r)\n");

        public string Environment {
            get { return _envVars.Text; }
            set {
                // TextBox requires \r\n for line separators, but XML can have either \n or \r\n, and we should treat those equally.
                // (It will always have \r\n when we write it out, but users can edit it by other means.)
                _envVars.Text = lfToCrLfRegex.Replace(value ?? String.Empty, "\r\n");
            }
        }

        public bool EnableNativeCodeDebugging {
            get { return _mixedMode.Checked; }
            set { _mixedMode.Checked = value; }
        }

        private void RaiseIsDirty() {
            if (!_loadingSettings) {
                var isDirty = DirtyChanged;
                if (isDirty != null) {
                    DirtyChanged(this, DirtyChangedEventArgs.DirtyValue);
                }
            }
        }

        private void RaiseIsSaved() {
            var isDirty = DirtyChanged;
            if (isDirty != null) {
                DirtyChanged(this, DirtyChangedEventArgs.SavedValue);
            }
        }

        private void SearchPathsTextChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }

        private void ArgumentsTextChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }

        private void InterpreterPathTextChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }

        private void InterpreterArgumentsTextChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }

        private void _mixedMode_CheckedChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }

        private void _envVars_TextChanged(object sender, EventArgs e) {
            RaiseIsDirty();
        }
    }
}
