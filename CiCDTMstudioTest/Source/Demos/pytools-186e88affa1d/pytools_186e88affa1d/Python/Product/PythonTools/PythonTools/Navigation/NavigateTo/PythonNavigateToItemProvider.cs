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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PythonTools.Intellisense;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Language.NavigateTo.Interfaces;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Navigation;

namespace Microsoft.PythonTools.Navigation.NavigateTo {
    internal class PythonNavigateToItemProvider : INavigateToItemProvider {
        private readonly IServiceProvider _serviceProvider;
        private readonly IGlyphService _glyphService;
        private Task _searchTask;
        private CancellationTokenSource _searchCts;

        // Used to propagate information to PythonNavigateToItemDisplay inside NavigateToItem.Tag.
        internal class ItemTag {
            public LibraryNode Node { get; set; }
            public IGlyphService GlyphService { get; set; }
        }

        private class LibraryNodeVisitor : ILibraryNodeVisitor {
            private static readonly Dictionary<StandardGlyphGroup, string> _sggToNavItemKind = new Dictionary<StandardGlyphGroup, string>() {
                { StandardGlyphGroup.GlyphGroupClass, NavigateToItemKind.Class },
                { StandardGlyphGroup.GlyphGroupMethod, NavigateToItemKind.Method },
                { StandardGlyphGroup.GlyphGroupField, NavigateToItemKind.Field }
            };

            private readonly PythonNavigateToItemProvider _itemProvider;
            private readonly INavigateToCallback _navCallback;
            private readonly string _searchValue;
            private readonly Stack<LibraryNode> _path = new Stack<LibraryNode>();
            private readonly FuzzyStringMatcher _comparer, _regexComparer;
            private readonly PythonToolsService _pyService;

            public LibraryNodeVisitor(PythonToolsService pyService, PythonNavigateToItemProvider itemProvider, INavigateToCallback navCallback, string searchValue) {
                _pyService = pyService;
                _itemProvider = itemProvider;
                _navCallback = navCallback;
                _searchValue = searchValue;
                _path.Push(null);
                _comparer = new FuzzyStringMatcher(_pyService.AdvancedOptions.SearchMode);
                _regexComparer = new FuzzyStringMatcher(FuzzyMatchMode.RegexIgnoreCase);
            }

            public bool EnterNode(LibraryNode node, CancellationToken ct) {
                if (ct.IsCancellationRequested) {
                    _navCallback.Invalidate();
                    return false;
                }

                var parentNode = _path.Peek();
                _path.Push(node);

                // We don't want to report modules, since they map 1-to-1 to files, and those are already reported by the standard item provider
                if (node.NodeType.HasFlag(LibraryNodeType.Package)) {
                    return true;
                }

                // Match name against search string.
                string name = node.Name ?? "";
                MatchKind matchKind;
                if (_searchValue.Length > 2 && _searchValue.StartsWith("/") && _searchValue.EndsWith("/")) {
                    if (!_regexComparer.IsCandidateMatch(name, _searchValue.Substring(1, _searchValue.Length - 2))) {
                        return true;
                    }
                    matchKind = MatchKind.Regular;
                } else if (name.Equals(_searchValue, StringComparison.Ordinal)) {
                    matchKind = MatchKind.Exact;
                } else if (_comparer.IsCandidateMatch(name, _searchValue)) {
                    matchKind = MatchKind.Regular;
                } else {
                    return true;
                }

                string kind;
                if (!_sggToNavItemKind.TryGetValue(node.GlyphType, out kind)) {
                    kind = "";
                }
                
                var text = node.GetTextRepresentation(VSTREETEXTOPTIONS.TTO_DISPLAYTEXT);
                if (parentNode != null) {
                    switch (parentNode.GlyphType) {
                        case StandardGlyphGroup.GlyphGroupModule:
                            text += string.Format(" [of module {0}]", parentNode.Name);
                            break;
                        case StandardGlyphGroup.GlyphGroupClass:
                            text += string.Format(" [of class {0}]", parentNode.Name);
                            break;
                        case StandardGlyphGroup.GlyphGroupMethod:
                            text += string.Format(" [nested in function {0}]", parentNode.Name);
                            break;
                    }
                }

                var tag = new ItemTag { Node = node, GlyphService = _itemProvider._glyphService };
                _navCallback.AddItem(new NavigateToItem(text, kind, "Python", "", tag, matchKind, PythonNavigateToItemDisplayFactory.Instance));
                return true;
            }

            public void LeaveNode(LibraryNode node, CancellationToken ct) {
                _path.Pop();
            }
        }

        public PythonNavigateToItemProvider(IServiceProvider serviceProvider, IGlyphService glyphService) {
            _serviceProvider = serviceProvider;
            _glyphService = glyphService;
        }

        public void StartSearch(INavigateToCallback callback, string searchValue) {
            var libraryManager = (LibraryManager)_serviceProvider.GetService(typeof(IPythonLibraryManager));
            var library = libraryManager.Library;

            if (_searchCts != null) {
                _searchCts.Dispose();
            }
            _searchCts = new CancellationTokenSource();
            var pyService = (PythonToolsService)_serviceProvider.GetService(typeof(PythonToolsService));
            _searchTask = Task.Factory.StartNew(() => library.VisitNodes(new LibraryNodeVisitor(pyService, this, callback, searchValue), _searchCts.Token), _searchCts.Token);
        }

        public void StopSearch() {
            _searchCts.Cancel();
        }

        public void Dispose() {
            if (_searchCts != null) {
                _searchCts.Dispose();
            }
        }
    }
}
