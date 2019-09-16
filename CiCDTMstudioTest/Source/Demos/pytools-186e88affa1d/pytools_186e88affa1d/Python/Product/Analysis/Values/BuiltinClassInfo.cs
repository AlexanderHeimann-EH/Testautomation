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
using System.Linq;
using Microsoft.PythonTools.Analysis.Analyzer;
using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    internal class BuiltinClassInfo : BuiltinNamespace<IPythonType>, IReferenceableContainer {
        private BuiltinInstanceInfo _inst;
        private string _doc;
        private readonly MemberReferences _referencedMembers = new MemberReferences();
        private ReferenceDict _references;

        internal static string[] EmptyStrings = new string[0];

        public BuiltinClassInfo(IPythonType classObj, PythonAnalyzer projectState)
            : base(classObj, projectState) {
            // TODO: Get parameters from ctor
            // TODO: All types should be shared via projectState
            _doc = null;
        }

        public override IPythonType PythonType {
            get { return _type; }
        }

        internal override bool IsOfType(IAnalysisSet klass) {
            return klass.Contains(ProjectState.ClassInfos[BuiltinTypeId.Type]);
        }

        internal override BuiltinTypeId TypeId {
            get { return _type.TypeId; }
        }

        public override IAnalysisSet Call(Node node, AnalysisUnit unit, IAnalysisSet[] args, NameExpression[] keywordArgNames) {
            // TODO: More Type propagation
            IAdvancedPythonType advType = _type as IAdvancedPythonType;
            if (advType != null) {
                var types = advType.GetTypesPropagatedOnCall();
                if (types != null) {
                    IAnalysisSet[] propagating = new IAnalysisSet[types.Count];
                    for (int i = 0; i < propagating.Length; i++) {
                        propagating[i] = unit.ProjectState.GetInstance(types[i]).SelfSet;
                    }
                    foreach (var arg in args) {
                        arg.Call(node, unit, propagating, ExpressionEvaluator.EmptyNames);
                    }
                }
            }

            return Instance.SelfSet;
        }

        public override string Name {
            get {
                return _type.Name;
            }
        }

        public override IEnumerable<IAnalysisSet> Mro {
            get {
                var mro = _type.Mro;
                if (mro != null) {
                    return mro.Where(t => t != null).Select(t => ProjectState.GetBuiltinType(t));
                }
                return Enumerable.Empty<IAnalysisSet>();
            }
        }

        public BuiltinInstanceInfo Instance {
            get {
                return _inst ?? (_inst = MakeInstance());
            }
        }

        public override IAnalysisSet GetInstanceType() {
            return Instance;
        }

        private BuiltinInstanceInfo MakeInstance() {
            if (_type.TypeId == BuiltinTypeId.Int || _type.TypeId == BuiltinTypeId.Long || _type.TypeId == BuiltinTypeId.Float || _type.TypeId == BuiltinTypeId.Complex) {
                return new NumericInstanceInfo(this);
            } else if (_type.TypeId == BuiltinTypeId.Str || _type.TypeId == BuiltinTypeId.Unicode || _type.TypeId == BuiltinTypeId.Bytes) {
                return new SequenceBuiltinInstanceInfo(this, true, true);
            } else if (_type.TypeId == BuiltinTypeId.Tuple || _type.TypeId == BuiltinTypeId.List) {
                return new SequenceBuiltinInstanceInfo(this, false, false);
            }

            return new BuiltinInstanceInfo(this);
        }

        /// <summary>
        /// Returns the overloads available for calling the constructor of the type.
        /// </summary>
        public override IEnumerable<OverloadResult> Overloads {
            get {
                // TODO: sometimes might have a specialized __init__.
                // This just covers typical .NET types
                var ctors = _type.GetConstructors();

                if (ctors != null) {
                    return ctors.Overloads.Select(ctor => new BuiltinFunctionOverloadResult(ProjectState, ctor, 1, _type.Name, GetDoc));
                }
                return new OverloadResult[0];
            }
        }

        // can't create delegate to property...
        private string GetDoc() {
            return Documentation;
        }

        public override IAnalysisSet GetMember(Node node, AnalysisUnit unit, string name) {
            // Must unconditionally call the base implementation of GetMember
            var res = base.GetMember(node, unit, name);
            if (res.Count > 0) {
                _referencedMembers.AddReference(node, unit, name);
                return res.GetStaticDescriptor(unit);
            }
            return res;
        }

        public override void SetMember(Node node, AnalysisUnit unit, string name, IAnalysisSet value) {
            base.SetMember(node, unit, name, value);
            _referencedMembers.AddReference(node, unit, name);
        }

        public override IAnalysisSet GetIndex(Node node, AnalysisUnit unit, IAnalysisSet index) {
            // TODO: Needs to actually do indexing on type
            var clrType = _type as IAdvancedPythonType;
            if (clrType == null || !clrType.IsGenericTypeDefinition) {
                return AnalysisSet.Empty;
            }

            var result = AnalysisSet.Create();
            foreach (var indexType in index) {
                if (indexType is BuiltinClassInfo) {
                    var clrIndexType = indexType.PythonType;
                    try {
                        var klass = ProjectState.MakeGenericType(clrType, clrIndexType);
                        result = result.Add(klass);
                    } catch {
                        // wrong number of type args, violated constraint, etc...
                    }
                } else if (indexType is SequenceInfo) {
                    List<IPythonType>[] types = GetSequenceTypes(indexType as SequenceInfo);

                    if (!MissingType(types)) {
                        foreach (IPythonType[] indexTypes in GetTypeCombinations(types)) {
                            try {
                                var klass = ProjectState.MakeGenericType(clrType, indexTypes);
                                result = result.Add(klass);
                            } catch {
                                // wrong number of type args, violated constraint, etc...
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static IEnumerable<IPythonType[]> GetTypeCombinations(List<IPythonType>[] types) {
            List<IPythonType> res = new List<IPythonType>();
            for (int i = 0; i < types.Length; i++) {
                res.Add(null);
            }

            return GetTypeCombinationsWorker(types, res, 0);
        }

        private static IEnumerable<IPythonType[]> GetTypeCombinationsWorker(List<IPythonType>[] types, List<IPythonType> res, int curIndex) {
            if (curIndex == types.Length) {
                yield return res.ToArray();
            } else {
                foreach (IPythonType t in types[curIndex]) {
                    res[curIndex] = t;

                    foreach (var finalRes in GetTypeCombinationsWorker(types, res, curIndex + 1)) {
                        yield return finalRes;
                    }
                }
            }
        }

        private static List<IPythonType>[] GetSequenceTypes(SequenceInfo seq) {
            List<IPythonType>[] types = new List<IPythonType>[seq.IndexTypes.Length];
            for (int i = 0; i < types.Length; i++) {
                foreach (var seqIndexType in seq.IndexTypes[i].TypesNoCopy) {
                    if (seqIndexType is BuiltinClassInfo) {
                        if (types[i] == null) {
                            types[i] = new List<IPythonType>();
                        }

                        types[i].Add(seqIndexType.PythonType);
                    }
                }
            }
            return types;
        }

        private static bool MissingType(List<IPythonType>[] types) {
            for (int i = 0; i < types.Length; i++) {
                if (types[i] == null) {
                    return true;
                }
            }
            return false;
        }

        public override string Description {
            get {
                var res = ShortDescription;
                if (!String.IsNullOrEmpty(Documentation)) {
                    res += Environment.NewLine + Documentation;
                }
                return res;
            }
        }

        public override string ShortDescription {
            get {
                return (_type.IsBuiltin ? "type " : "class ") + _type.Name;
            }
        }

        public override string Documentation {
            get {
                if (_doc == null) {
                    try {
                        var doc = _type.Documentation;
                        _doc = Utils.StripDocumentation(doc.ToString());
                    } catch {
                        _doc = String.Empty;
                    }
                }
                return _doc;
            }
        }

        public override PythonMemberType MemberType {
            get {
                return _type.MemberType;
            }
        }

        public override string ToString() {
            return "Class " + _type.Name;
        }

        internal override AnalysisValue UnionMergeTypes(AnalysisValue ns, int strength) {
            if (strength >= MergeStrength.ToObject) {
                AnalysisValue type;
                if (TypeId == ns.TypeId && (type = ProjectState.ClassInfos[TypeId]) != null) {
                    return type;
                }
                return ProjectState.ClassInfos[BuiltinTypeId.Type];

            } else if (strength >= MergeStrength.ToBaseClass) {
                return ProjectState.ClassInfos[TypeId] ?? this;

            }

            return base.UnionMergeTypes(ns, strength);
        }

        internal override bool UnionEquals(AnalysisValue ns, int strength) {
            if (strength >= MergeStrength.ToObject) {
                var type = ProjectState.ClassInfos[BuiltinTypeId.Type];
                return ns is ClassInfo || ns is BuiltinClassInfo || ns == type || ns == type.Instance;

            } else if (strength >= MergeStrength.ToBaseClass) {
                if (this == ProjectState.ClassInfos[BuiltinTypeId.Type]) {
                    return false;
                }
                
                var bci = ns as BuiltinClassInfo;
                if (bci != null) {
                    return TypeId == bci.TypeId;
                }

                var ci = ns as ClassInfo;
                if (ci != null && TypeId != BuiltinTypeId.Object) {
                    return ci.Mro.AnyContains(this);
                }
            }

            return base.UnionEquals(ns, strength);
        }

        internal override int UnionHashCode(int strength) {
            if (strength < MergeStrength.ToBaseClass) {
                return base.UnionHashCode(strength);
            } else {
                return ProjectState.ClassInfos[BuiltinTypeId.Type].GetHashCode();
            }
        }

        #region IReferenceableContainer Members

        public IEnumerable<IReferenceable> GetDefinitions(string name) {
            return _referencedMembers.GetDefinitions(name, PythonType, ProjectState._defaultContext);
        }

        #endregion

        internal void AddMemberReference(Node node, AnalysisUnit unit, string name) {
            _referencedMembers.AddReference(node, unit, name);
        }

        internal override void AddReference(Node node, AnalysisUnit unit) {
            if (!unit.ForEval) {
                if (_references == null) {
                    _references = new ReferenceDict();
                }
                _references.GetReferences(unit.DeclaringModule.ProjectEntry).AddReference(new EncodedLocation(unit.Tree, node));
            }
        }

        internal override IEnumerable<LocationInfo> References {
            get {
                if (_references != null) {
                    return _references.AllReferences;
                }
                return new LocationInfo[0];
            }
        }

        public override ILocatedMember GetLocatedMember() {
            return _type as ILocatedMember;
        }
    }
}
