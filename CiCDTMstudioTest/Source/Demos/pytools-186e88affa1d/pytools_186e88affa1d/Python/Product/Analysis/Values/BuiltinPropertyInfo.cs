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

using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    internal class BuiltinPropertyInfo : BuiltinNamespace<IPythonType> {
        private readonly IBuiltinProperty _value;
        private string _doc;

        public BuiltinPropertyInfo(IBuiltinProperty value, PythonAnalyzer projectState)
            : base(value.Type, projectState) {
            _value = value;
            _doc = null;
        }

        public override IPythonType PythonType {
            get { return _type; }
        }

        public override IAnalysisSet GetDescriptor(Node node, AnalysisValue instance, AnalysisValue context, AnalysisUnit unit) {
            if (instance == ProjectState._noneInst) {
                return base.GetDescriptor(node, instance, context, unit);
            }

            return ProjectState.GetAnalysisValueFromObjects(_value.Type).GetInstanceType();
        }

        public override IAnalysisSet GetStaticDescriptor(AnalysisUnit unit) {
            if (_value.IsStatic) {
                return ProjectState.GetAnalysisValueFromObjects(_value.Type).GetInstanceType();
            }

            return base.GetStaticDescriptor(unit);
        }

        public override string Description {
            get {
                return _value.Description;
            }
        }

        public override PythonMemberType MemberType {
            get {
                return _value.MemberType;
            }
        }

        public override string Documentation {
            get {
                if (_doc == null) {
                    _doc = _value.Documentation;
                }
                return _doc;
            }
        }

        public override ILocatedMember GetLocatedMember() {
            return _value as ILocatedMember;
        }
    }
}
