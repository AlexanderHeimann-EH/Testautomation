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
using System.Linq;
using System.Text;
using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    internal class BuiltinMethodInfo : BuiltinNamespace<IPythonType> {
        private readonly IPythonFunction _function;
        private readonly PythonMemberType _memberType;
        internal readonly bool _fromFunction;
        private string _doc;
        private readonly IAnalysisSet _returnTypes;
        private BoundBuiltinMethodInfo _boundMethod;

        public BuiltinMethodInfo(IPythonMethodDescriptor method, PythonAnalyzer projectState)
            : base(projectState.Types[BuiltinTypeId.BuiltinMethodDescriptor], projectState) {
            var function = method.Function;
            _memberType = method.MemberType;
            _function = function;
            _returnTypes = Utils.GetReturnTypes(function, projectState);
        }

        public BuiltinMethodInfo(IPythonFunction function, PythonMemberType memType, PythonAnalyzer projectState)
            : base(projectState.Types[BuiltinTypeId.BuiltinMethodDescriptor], projectState) {
            _memberType = memType;
            _function = function;
            _returnTypes = Utils.GetReturnTypes(function, projectState);
            _fromFunction = true;
        }

        public override IPythonType PythonType {
            get { return _type; }
        }

        public override IAnalysisSet Call(Node node, AnalysisUnit unit, IAnalysisSet[] args, NameExpression[] keywordArgNames) {
            return _returnTypes.GetInstanceType();
        }

        public override IAnalysisSet GetDescriptor(Node node, AnalysisValue instance, AnalysisValue context, AnalysisUnit unit) {
            if (instance == ProjectState._noneInst) {
                return base.GetDescriptor(node, instance, context, unit);
            }

            if (_boundMethod == null) {
                _boundMethod = new BoundBuiltinMethodInfo(this);
            }

            return _boundMethod.SelfSet;
        }

        public override string Description {
            get {
                if (_function.IsBuiltin) {
                    return "built-in method " + _function.Name;
                }
                return "method " + _function.Name;
            }
        }

        public IAnalysisSet ReturnTypes {
            get {
                return _returnTypes;
            }
        }

        public IPythonFunction Function {
            get {
                return _function;
            }
        }

        public override IEnumerable<OverloadResult> Overloads {
            get {
                return Function.Overloads.Select(overload => 
                    new BuiltinFunctionOverloadResult(
                        ProjectState,
                        _function.Name,
                        overload,
                        0,
                        new ParameterResult("self")
                    )
                );
            }
        }

        public override string Documentation {
            get {
                if (_doc == null) {
                    var doc = new StringBuilder();
                    foreach (var overload in Function.Overloads) {
                        doc.Append(Utils.StripDocumentation(overload.Documentation));
                    }
                    _doc = doc.ToString();
                    if (string.IsNullOrWhiteSpace(_doc)) {
                        _doc = Utils.StripDocumentation(Function.Documentation);
                    }
                }
                return _doc;
            }
        }

        public override PythonMemberType MemberType {
            get {
                return _memberType;
            }
        }

        public override string Name { get { return _function.Name; } }

        public override ILocatedMember GetLocatedMember() {
            return _function as ILocatedMember;
        }
    }
}
