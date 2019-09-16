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

using System.Collections.Generic;
using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    class BoundBuiltinMethodInfo : BuiltinNamespace<IPythonType> {
        private readonly BuiltinMethodInfo _method;
        private OverloadResult[] _overloads;

        public BoundBuiltinMethodInfo(BuiltinMethodInfo method)
            : base(method.PythonType, method.ProjectState) {
            _method = method;
        }

        public override PythonMemberType MemberType {
            get {
                return _method.MemberType;
            }
        }

        public BuiltinMethodInfo Method {
            get {
                return _method;
            }
        }

        public override string Documentation {
            get {
                return _method.Documentation;
            }
        }

        public override string Description {
            get {
                if (_method.Function.IsBuiltin) {
                    return "bound built-in method " + _method.Name;
                }
                return "bound method " + _method.Name;
            }
        }

        public override IAnalysisSet Call(Node node, AnalysisUnit unit, IAnalysisSet[] args, NameExpression[] keywordArgNames) {
            return _method.ReturnTypes.GetInstanceType();
        }

        public override IEnumerable<OverloadResult> Overloads {
            get {
                if (_overloads == null) {
                    var overloads = _method.Function.Overloads;
                    var result = new OverloadResult[overloads.Count];
                    for (int i = 0; i < result.Length; i++) {
                        result[i] = new BuiltinFunctionOverloadResult(_method.ProjectState, _method.Name, overloads[i], _method._fromFunction ? 1 : 0);
                    }
                    _overloads = result;
                }
                return _overloads;
            }
        }
    }
}
