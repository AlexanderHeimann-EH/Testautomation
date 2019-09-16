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

namespace Microsoft.PythonTools.Parsing {
    public sealed class ParserOptions {
        internal static ParserOptions Default = new ParserOptions();
        public ParserOptions() {
            ErrorSink = ErrorSink.Null;
        }

        public ErrorSink ErrorSink { get; set; }

        public Severity IndentationInconsistencySeverity { set; get; }

        public bool Verbatim { get; set; }

        /// <summary>
        /// True if references to variables should be bound in the AST.  The root node must be
        /// held onto to access the references via GetReference/GetReferences APIs on various 
        /// nodes which reference variables.
        /// </summary>
        public bool BindReferences { get; set; }

        /// <summary>
        /// Specifies the class name the parser starts off with for name mangling name expressions.
        /// 
        /// For example __fob would turn into _C__fob if PrivatePrefix is set to C.
        /// </summary>
        public string PrivatePrefix { get; set; }

        /// <summary>
        /// An event that is raised for every comment in the source as it is parsed.
        /// </summary>
        public event EventHandler<CommentEventArgs> ProcessComment;

        internal void RaiseProcessComment(object sender, CommentEventArgs e) {
            var handler = ProcessComment;
            if (handler != null) {
                handler(sender, e);
            }
        }
    }

    public class CommentEventArgs : EventArgs {
        public SourceSpan Span { get; private set; }
        public string Text { get; private set; }

        public CommentEventArgs(SourceSpan span, string text) {
            Span = span;
            Text = text;
        }
    }
}
