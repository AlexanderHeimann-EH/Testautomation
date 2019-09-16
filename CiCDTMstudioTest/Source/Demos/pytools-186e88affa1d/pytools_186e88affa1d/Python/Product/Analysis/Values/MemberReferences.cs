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
using Microsoft.PythonTools.Analysis.Analyzer;
using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Parsing.Ast;

namespace Microsoft.PythonTools.Analysis.Values {
    /// <summary>
    /// Maintains a list of references keyed off of name.
    /// </summary>
    class MemberReferences {
        private Dictionary<string, ReferenceDict> _references;
        
        public void AddReference(Node node, AnalysisUnit unit, string name) {
            if (!unit.ForEval) {
                if (_references == null) {
                    _references = new Dictionary<string, ReferenceDict>();
                }
                ReferenceDict refs;
                if (!_references.TryGetValue(name, out refs)) {
                    _references[name] = refs = new ReferenceDict();
                }
                refs.GetReferences(unit.DeclaringModule.ProjectEntry).AddReference(new EncodedLocation(unit.Tree, node));
            }
        }

        public IEnumerable<IReferenceable> GetDefinitions(string name, IMemberContainer innerContainer, IModuleContext context) {
            IEnumerable<IReferenceable> refs = null;
            ReferenceDict references;
            if (_references != null && _references.TryGetValue(name, out references)) {
                refs = references.Values;
            }

            var member = innerContainer.GetMember(context, name);
            if (member != null) {
                List<IReferenceable> res;
                if (refs == null) {
                    res = new List<IReferenceable>();
                } else {
                    res = new List<IReferenceable>(refs);
                }

                ILocatedMember locatedMember = member as ILocatedMember;
                if (locatedMember != null) {
                    foreach(var location in locatedMember.Locations) {
                        res.Add(new DefinitionList(location));
                    }
                }
                return res;
            }

            return new IReferenceable[0];
        }
    }

    /// <summary>
    /// A collection of references which are keyd off of project entry.
    /// </summary>
    class ReferenceDict : Dictionary<IProjectEntry, ReferenceList> {
        public ReferenceList GetReferences(ProjectEntry project) {
            ReferenceList builtinRef;
            if (!TryGetValue(project, out builtinRef) || builtinRef.Version != project.AnalysisVersion) {
                this[project] = builtinRef = new ReferenceList(project);
            }
            return builtinRef;
        }

        public IEnumerable<LocationInfo> AllReferences {
            get {
                foreach (var keyValue in this) {
                    if (keyValue.Value.References != null) {
                        foreach (var reference in keyValue.Value.References) {
                            yield return reference.GetLocationInfo(keyValue.Key);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// A list of references as stored for a single project entry.
    /// </summary>
    class ReferenceList : IReferenceable {
        public readonly int Version;
        public readonly IProjectEntry Project;
        public ISet<EncodedLocation> References;

        public ReferenceList(IProjectEntry project) {
            Version = project.AnalysisVersion;
            Project = project;
            References = new HashSet<EncodedLocation>();
        }

        public void AddReference(EncodedLocation location) {
            HashSetExtensions.AddValue(ref References, location);
        }

        #region IReferenceable Members

        public IEnumerable<KeyValuePair<IProjectEntry, EncodedLocation>> Definitions {
            get { yield break; }
        }

        IEnumerable<KeyValuePair<IProjectEntry, EncodedLocation>> IReferenceable.References {
            get {
                if (References != null) {
                    foreach (var location in References) {
                        yield return new KeyValuePair<IProjectEntry, EncodedLocation>(Project, location);
                    }
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// A list of references as stored for a single project entry.
    /// </summary>
    class DefinitionList : IReferenceable {
        public readonly LocationInfo _location;

        public DefinitionList(LocationInfo location) {
            _location = location;
        }

        #region IReferenceable Members

        public IEnumerable<KeyValuePair<IProjectEntry, EncodedLocation>> Definitions {
            get { yield return new KeyValuePair<IProjectEntry, EncodedLocation>(_location.ProjectEntry, new EncodedLocation(_location, null)); }
        }

        IEnumerable<KeyValuePair<IProjectEntry, EncodedLocation>> IReferenceable.References {
            get { yield break; }
        }

        #endregion
    }

}
