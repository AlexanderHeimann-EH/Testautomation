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
using Microsoft.PythonTools.Analysis.Values;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis {
    /// <summary>
    /// Provides information about a call for call specialization.
    /// 
    /// New in 1.5.
    /// </summary>
    public struct CallInfo {
        private readonly INamespaceSet[] _args;
        private readonly NameExpression[] _names;

        internal CallInfo(INamespaceSet[] args, NameExpression[] names) {
            _args = args;
            _names = names;
        }

        public int NormalArgumentCount {
            get {
                return _args.Length - _names.Length;
            }
        }
        /*
        public int NamedArgumentCount {
            get {
                return _names.Length;
            }
        }
        */
        public IEnumerable<AnalysisValue> GetArgument(int arg) {
            if (arg >= _args.Length) {
                throw new ArgumentOutOfRangeException("arg");
            }

            foreach (var value in _args[arg]) {
                if (value is ExternalNamespace) {
                    yield return (AnalysisValue)((ExternalNamespace)value).Value;
                } else {
                    yield return value;
                }
            }
        }
        /*
        public IEnumerable<AnalysisValue> GetNamedArgument(int arg) {
            if (arg >= _names.Length) {
                throw new ArgumentOutOfRangeException("arg");
            }

            foreach (var value in _args[_args.Length - _names.Length + arg]) {
                if (value is ExternalNamespace) {
                    yield return (AnalysisValue)((ExternalNamespace)value).Value;
                } else {
                    yield return value;
                }
            }
        }*/
    }
}
