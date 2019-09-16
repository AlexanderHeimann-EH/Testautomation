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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Editor.OptionsExtensionMethods;
using Microsoft.PythonTools.Repl;

namespace Microsoft.VisualStudio.Repl {
#if INTERACTIVE_WINDOW
    using IReplCommand = IInteractiveWindowCommand;
    using IReplWindow = IInteractiveWindow;
#endif
    
    [Export(typeof(IReplCommand))]
    [ReplRole("Execution")]
    class AttachDebuggerReplCommand : IReplCommand {
        #region IReplCommand Members

        public Task<ExecutionResult> Execute(IReplWindow window, string arguments) {
            var eval = window.Evaluator as PythonReplEvaluator;
            if (eval != null) {
                if (eval.AttachEnabled) {
                    string error = eval.AttachDebugger();
                    if (error != null) {
                        window.WriteError("Failed to attach: " + error);
                    }
                } else {
                    window.WriteError(
"Attaching to an interactive window requires enabling attach " +
"support in Tools->Options->Python Tools->Interactive Windows." +
Environment.NewLine + Environment.NewLine +
"This will cause the debugger to track necessary state to enable " +
"debugging until the attach is requested.  Once enabled the " +
"interactive window will need to be reset for the change to take " +
"effect.");
                }
            } else {
                window.WriteError("attach only supports Python interactive windows");
            }

            return ExecutionResult.Succeeded;
        }

        public string Description {
            get { return "Attaches the Visual Studio debugger to the REPL window process to enable debugging"; }
        }

        public string Command {
            get { return "attach"; }
        }

        public object ButtonContent {
            get {
                return null;
            }
        }

        #endregion
    }
}
