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
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PythonTools.Parsing;

namespace Microsoft.PythonTools.Debugger {
    class PythonStackFrame {
        private int _lineNo;    // mutates on set next line
        private readonly string _frameName, _filename;
        private readonly int _argCount, _frameId;
        private readonly int _startLine, _endLine;
        private PythonEvaluationResult[] _variables;
        private readonly PythonThread _thread;
        private readonly FrameKind _kind;

        public PythonStackFrame(PythonThread thread, string frameName, string filename, int startLine, int endLine, int lineNo, int argCount, int frameId, FrameKind kind) {
            _thread = thread;
            _frameName = frameName;
            _filename = filename;
            _argCount = argCount;
            _lineNo = lineNo;
            _frameId = frameId;
            _startLine = startLine;
            _endLine = endLine;
            _kind = kind;
        }

        /// <summary>
        /// The line nubmer where the current function/class/module starts
        /// </summary>
        public int StartLine {
            get {
                return _startLine;
            }
        }

        /// <summary>
        /// The line number where the current function/class/module ends.
        /// </summary>
        public int EndLine {
            get {
                return _endLine;
            }
        }

        public PythonThread Thread {
            get {
                return _thread;
            }
        }

        public int LineNo {
            get {
                return _lineNo;
            }
            set {
                _lineNo = value;
            }
        }

        public string FunctionName {
            get {
                return _frameName;
            }
        }

        public string FileName {
            get {
                return _thread.Process.MapFile(_filename, toDebuggee: false);
            }
        }

        public FrameKind Kind {
            get {
                return _kind;
            }
        }

        /// <summary>
        /// Gets the ID of the frame.  Frame 0 is the currently executing frame, 1 is the caller of the currently executing frame, etc...
        /// </summary>
        public int FrameId {
            get {
                return _frameId;
            }
        }

        internal void SetVariables(PythonEvaluationResult[] variables) {
            _variables = variables;
        }

        public IList<PythonEvaluationResult> Locals {
            get {
                PythonEvaluationResult[] res = new PythonEvaluationResult[_variables.Length - _argCount];
                for (int i = _argCount; i < _variables.Length; i++) {
                    res[i - _argCount] = _variables[i];
                }
                return res;
            }
        }

        public IList<PythonEvaluationResult> Parameters {
            get {
                PythonEvaluationResult[] res = new PythonEvaluationResult[_argCount];
                for (int i = 0; i < _argCount; i++) {
                    res[i] = _variables[i];
                }
                return res;
            }
        }

        /// <summary>
        /// Attempts to parse the given text.  Returns true if the text is a valid expression.  Returns false if the text is not
        /// a valid expression and assigns the error messages produced to errorMsg.
        /// </summary>
        public virtual bool TryParseText(string text, out string errorMsg) {
            CollectingErrorSink errorSink = new CollectingErrorSink();
            Parser parser = Parser.CreateParser(new StringReader(text), _thread.Process.LanguageVersion, new ParserOptions() { ErrorSink = errorSink });
            var ast = parser.ParseSingleStatement();
            if (errorSink.Errors.Count > 0) {
                StringBuilder msg = new StringBuilder();
                foreach (var error in errorSink.Errors) {
                    msg.Append(error.Message);
                    msg.Append(Environment.NewLine);
                }

                errorMsg = msg.ToString();
                return false;
            }

            errorMsg = null;
            return true;
        }

        /// <summary>
        /// Executes the given text against this stack frame.
        /// </summary>
        /// <param name="text"></param>
        public void ExecuteText(string text, Action<PythonEvaluationResult> completion) {
            ExecuteText(text, PythonEvaluationResultReprKind.Normal, completion);
        }

        public void ExecuteText(string text, PythonEvaluationResultReprKind reprKind, Action<PythonEvaluationResult> completion) {
            _thread.Process.ExecuteText(text, reprKind, this, completion);
        }

        public Task<PythonEvaluationResult> ExecuteTextAsync(string text, PythonEvaluationResultReprKind reprKind = PythonEvaluationResultReprKind.Normal) {
            var tcs = new TaskCompletionSource<PythonEvaluationResult>();

            EventHandler<ProcessExitedEventArgs> processExited = delegate {
                tcs.TrySetCanceled();
            };
            tcs.Task.ContinueWith(_ => _thread.Process.ProcessExited -= processExited);
            _thread.Process.ProcessExited += processExited;

            ExecuteText(text, reprKind, result => {
                tcs.TrySetResult(result);
            });

            return tcs.Task;
        }

        /// <summary>
        /// Sets the line number that this current frame is executing.  Returns true
        /// if the line was successfully set or false if the line number cannot be changed
        /// to this line.
        /// </summary>
        public bool SetLineNumber(int lineNo) {
            return _thread.Process.SetLineNumber(this, lineNo);
        }
    }

    class DjangoStackFrame : PythonStackFrame {
        private readonly string _sourceFile;
        private readonly int _sourceLine;

        public DjangoStackFrame(PythonThread thread, string frameName, string filename, int startLine, int endLine, int lineNo, int argCount, int frameId, string sourceFile, int sourceLine) 
            : base(thread, frameName, filename, startLine, endLine, lineNo, argCount, frameId, FrameKind.Django) {
            _sourceFile = sourceFile;
            _sourceLine = sourceLine;
        }

        /// <summary>
        /// The source .py file which implements the template logic.  The normal filename is the
        /// name of the template it's self.
        /// </summary>
        public string SourceFile {
            get {
                return _sourceFile;
            }
        }

        /// <summary>
        /// The line in the source .py file which implements the template logic.
        /// </summary>
        public int SourceLine {
            get {
                return _sourceLine;
            }
        }
    }

}
