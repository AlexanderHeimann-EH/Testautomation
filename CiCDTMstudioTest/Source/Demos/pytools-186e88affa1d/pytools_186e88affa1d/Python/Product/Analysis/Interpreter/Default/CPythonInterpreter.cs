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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PythonTools.Analysis;
using Microsoft.VisualStudioTools;

namespace Microsoft.PythonTools.Interpreter.Default {
    class CPythonInterpreter : IPythonInterpreter, IPythonInterpreterWithProjectReferences2, IDisposable {
        readonly Version _langVersion;
        private PythonInterpreterFactoryWithDatabase _factory;
        private PythonTypeDatabase _typeDb;
        private HashSet<ProjectReference> _references;

        public CPythonInterpreter(PythonInterpreterFactoryWithDatabase factory) {
            _langVersion = factory.Configuration.Version;
            _factory = factory;
            _typeDb = _factory.GetCurrentDatabase();
            _factory.NewDatabaseAvailable += OnNewDatabaseAvailable;
        }

        private async void OnNewDatabaseAvailable(object sender, EventArgs e) {
            var factory = _factory;
            if (factory == null) {
                // We have been disposed already, so ignore this event
                return;
            }

            _typeDb = factory.GetCurrentDatabase();
            
            if (_references != null) {
                _typeDb = _typeDb.Clone();
                foreach (var reference in _references) {
                    string modName;
                    try {
                        modName = Path.GetFileNameWithoutExtension(reference.Name);
                    } catch (ArgumentException) {
                        continue;
                    }
                    try {
                        await _typeDb.LoadExtensionModuleAsync(modName, reference.Name);
                    } catch (Exception ex) {
                        try {
                            Directory.CreateDirectory(factory.DatabasePath);
                        } catch (IOException) {
                        } catch (UnauthorizedAccessException) {
                        }
                        if (Directory.Exists(factory.DatabasePath)) {
                            var analysisLog = Path.Combine(factory.DatabasePath, "AnalysisLog.txt");
                            for (int retries = 10; retries > 0; --retries) {
                                try {
                                    File.AppendAllText(analysisLog, string.Format(
                                        "Exception while loading extension module {0}{1}{2}{1}",
                                        reference.Name,
                                        Environment.NewLine,
                                        ex
                                    ));
                                    break;
                                } catch (Exception ex2) {
                                    if (ex2.IsCriticalException()) {
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            var evt = ModuleNamesChanged;
            if (evt != null) {
                evt(this, EventArgs.Empty);
            }
        }

        #region IPythonInterpreter Members

        public IPythonType GetBuiltinType(BuiltinTypeId id) {
            if (id == BuiltinTypeId.Unknown) {
                return null;
            }

            if (_typeDb == null) {
                throw new KeyNotFoundException(string.Format("{0} ({1})", id, (int)id));
            }

            var name = SharedDatabaseState.GetBuiltinTypeName(id, _typeDb.LanguageVersion);
            var res = _typeDb.BuiltinModule.GetAnyMember(name) as IPythonType;
            if (res == null) {
                throw new KeyNotFoundException(string.Format("{0} ({1})", id, (int)id));
            }
            return res;
        }


        public IList<string> GetModuleNames() {
            if (_typeDb == null) {
                return new string[0];
            }
            return new List<string>(_typeDb.GetModuleNames());
        }

        public IPythonModule ImportModule(string name) {
            if (_typeDb == null) {
                return null;
            }
            return _typeDb.GetModule(name);
        }

        public IModuleContext CreateModuleContext() {
            return null;
        }

        public void Initialize(PythonAnalyzer state) {
        }

        public event EventHandler ModuleNamesChanged;

        public Task AddReferenceAsync(ProjectReference reference, CancellationToken cancellationToken = default(CancellationToken)) {
            if (reference == null) {
                return MakeExceptionTask(new ArgumentNullException("reference"));
            }

            if (_references == null) {
                _references = new HashSet<ProjectReference>();
                // If we needed to set _references, then we also need to clone
                // _typeDb to avoid adding modules to the shared database.
                if (_typeDb != null) {
                    _typeDb = _typeDb.Clone();
                }
            }

            switch (reference.Kind) {
                case ProjectReferenceKind.ExtensionModule:
                    _references.Add(reference);
                    string filename;
                    try {
                        filename = Path.GetFileNameWithoutExtension(reference.Name);
                    } catch (Exception e) {
                        return MakeExceptionTask(e);
                    }

                    if (_typeDb != null) {
                        return _typeDb.LoadExtensionModuleAsync(filename,
                            reference.Name,
                            cancellationToken).ContinueWith(RaiseModulesChanged);
                    }
                    break;
            }

            return Task.Factory.StartNew(EmptyTask);
        }

        public void RemoveReference(ProjectReference reference) {
            switch (reference.Kind) {
                case ProjectReferenceKind.ExtensionModule:
                    if (_references != null && _references.Remove(reference) && _typeDb != null) {
                        _typeDb.UnloadExtensionModule(Path.GetFileNameWithoutExtension(reference.Name));
                        RaiseModulesChanged(null);
                    }
                    break;
            }
        }

        public IEnumerable<ProjectReference> GetReferences() {
            return _references != null ? _references : Enumerable.Empty<ProjectReference>();
        }

        private static Task MakeExceptionTask(Exception e) {
            var res = new TaskCompletionSource<Task>();
            res.SetException(e);
            return res.Task;
        }

        private static void EmptyTask() {
        }

        private void RaiseModulesChanged(Task task) {
            if (task != null && task.Exception != null) {
                throw task.Exception;
            }
            var modNamesChanged = ModuleNamesChanged;
            if (modNamesChanged != null) {
                modNamesChanged(this, EventArgs.Empty);
            }
        }

        #endregion


        public void Dispose() {
            _typeDb = null;

            var factory = _factory;
            _factory = null;
            if (factory != null) {
                factory.NewDatabaseAvailable -= OnNewDatabaseAvailable;
            }
        }
    }
}
