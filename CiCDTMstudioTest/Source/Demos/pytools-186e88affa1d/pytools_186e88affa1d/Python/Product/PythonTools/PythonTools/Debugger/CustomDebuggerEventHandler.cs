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
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.PythonTools.DkmDebugger;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;
using NativeMethods = Microsoft.VisualStudioTools.Project.NativeMethods;

namespace Microsoft.PythonTools.Debugger {
    [Guid("996D22BD-D117-4611-88F2-2832CB7D9517")]
    public class CustomDebuggerEventHandler : IVsCustomDebuggerEventHandler110 {
        private readonly IServiceProvider _serviceProvider;
        
        public CustomDebuggerEventHandler(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public int OnCustomDebugEvent(ref Guid ProcessId, VsComponentMessage message) {
            switch ((VsPackageMessage)message.MessageCode) {
                case VsPackageMessage.WarnAboutPythonSymbols:
                    WarnAboutPythonSymbols((string)message.Parameter1);
                    return 0;
                case VsPackageMessage.WarnAboutPGO:
                    WarnAboutPGO((string)message.Parameter1);
                    return 0;
                default:
                    return 0;
            }
        }

        private void WarnAboutPythonSymbols(string moduleName) {
            const string content =
                "Python/native mixed-mode debugging requires symbol files for the Python interpreter that is being debugged. Please add the folder " +
                "containing those symbol files to your symbol search path, and force a reload of symbols for {0}.";

            var dialog = new TaskDialog(_serviceProvider);

            var openSymbolSettings = new TaskDialogButton("Open symbol settings dialog");
            var downloadSymbols = new TaskDialogButton("Download symbols for my interpreter");
            dialog.Buttons.Add(openSymbolSettings);
            dialog.Buttons.Add(downloadSymbols);

            dialog.Buttons.Add(TaskDialogButton.Close);
            dialog.UseCommandLinks = true;
            dialog.Title = "Python Symbols Required";
            dialog.Content = string.Format(content, moduleName);
            dialog.Width = 0;

            dialog.ShowModal();

            if (dialog.SelectedButton == openSymbolSettings) {
                var cmdId = new CommandID(VSConstants.GUID_VSStandardCommandSet97, VSConstants.cmdidToolsOptions);
                _serviceProvider.GlobalInvoke(cmdId,  "1F5E080F-CBD2-459C-8267-39fd83032166");
            } else if (dialog.SelectedButton == downloadSymbols) {
                PythonToolsPackage.OpenWebBrowser(
                    string.Format("http://go.microsoft.com/fwlink/?LinkId=308954&clcid=0x{0:X}", CultureInfo.CurrentCulture.LCID));
            }
        }

        private void WarnAboutPGO(string moduleName) {
            const string content =
                "Python/native mixed-mode debugging does not support Python interpreters that are built with PGO (profile-guided optimization) enabled. " +
                "If you are using a stock Python interpreter, you should upgrade to a more recent version of it. If you're using a custom built " +
                "interpreter, please disable PGO.";
            MessageBox.Show(content, "PGO Is Not Supported", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
