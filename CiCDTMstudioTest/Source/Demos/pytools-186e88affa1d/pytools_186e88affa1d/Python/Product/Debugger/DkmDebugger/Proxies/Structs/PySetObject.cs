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
using Microsoft.PythonTools.Parsing;
using Microsoft.VisualStudio.Debugger;
using Microsoft.VisualStudio.Debugger.Evaluation;

namespace Microsoft.PythonTools.DkmDebugger.Proxies.Structs {
    internal class PySetObject : PyObject {
        public class setentry : StructProxy {
            private class Fields {
                public StructField<PointerProxy<PyObject>> key;
            }

            private readonly Fields _fields;

            public setentry(DkmProcess process, ulong address)
                : base(process, address) {
                InitializeStruct(this, out _fields);
            }

            public PointerProxy<PyObject> key {
                get { return GetFieldProxy(_fields.key); }
            }
        }

        private class DummyHolder : DkmDataItem {
            public readonly PointerProxy<PyObject> Dummy;

            public DummyHolder(DkmProcess process) {
                var pyrtInfo = process.GetPythonRuntimeInfo();
                Dummy = 
                    pyrtInfo.LanguageVersion >= PythonLanguageVersion.V34 ? 
                    pyrtInfo.DLLs.Python.GetStaticVariable<PointerProxy<PyObject>>("_PySet_Dummy") :
                    pyrtInfo.DLLs.Python.GetStaticVariable<PointerProxy<PyObject>>("dummy", "setobject.obj");
            }
        }

        private class Fields {
            public StructField<SSizeTProxy> mask;
            public StructField<PointerProxy<ArrayProxy<setentry>>> table;
        }

        private readonly Fields _fields;
        private readonly PyObject _dummy;

        public PySetObject(DkmProcess process, ulong address)
            : base(process, address) {
            InitializeStruct(this, out _fields);
            CheckPyType<PySetObject>();

            _dummy = Process.GetOrCreateDataItem(() => new DummyHolder(Process)).Dummy.TryRead();
        }

        public SSizeTProxy mask {
            get { return GetFieldProxy(_fields.mask); }
        }

        public PointerProxy<ArrayProxy<setentry>> table {
            get { return GetFieldProxy(_fields.table); }
        }

        public IEnumerable<PyObject> ReadElements() {
            if (table.IsNull) {
                return Enumerable.Empty<PyObject>();
            }

            var count = mask.Read() + 1;
            var entries = table.Read().Take((int)count);
            var items = from entry in entries
                        let key = entry.key.TryRead()
                        where key != null && key != _dummy
                        select entry.key.Read();
            return items;
        }

        public override void Repr(ReprBuilder builder) {
            var count = ReadElements().Count();
            if (count == 0) {
                builder.Append(builder.Options.LanguageVersion >= PythonLanguageVersion.V30 ? "set()" : "set([])");
                return;
            }

            if (builder.IsTopLevel) {
                if (count > ReprBuilder.MaxJoinedItems) {
                    builder.AppendFormat("<set, len() = {0}>", count);
                    return;
                }
            }

            builder.Append(builder.Options.LanguageVersion >= PythonLanguageVersion.V30 ? "{" : "set([");
            builder.AppendJoined(", ", ReadElements(), obj => builder.AppendRepr(obj));
            builder.Append(builder.Options.LanguageVersion >= PythonLanguageVersion.V30 ? "}" : "])");
        }

        public override IEnumerable<PythonEvaluationResult> GetDebugChildren(ReprOptions reprOptions) {
            yield return new PythonEvaluationResult(new ValueStore<long>(ReadElements().Count()), "len()") {
                Category = DkmEvaluationResultCategory.Method
            };

            foreach (var item in ReadElements()) {
                yield return new PythonEvaluationResult(item);
            }
        }
    }
}
