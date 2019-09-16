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
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Microsoft.PythonTools.Interpreter {
    class MockExportProvider : ExportProvider {
        readonly Dictionary<ExportDefinition, Export> _exports;

        private static ExportDefinition MakeDefinition(Type type) {
            return new ExportDefinition(
                type.FullName,
                new Dictionary<string, object> {
                        { "ExportTypeIdentity", type.FullName }
                    }
            );
        }

        public MockExportProvider() {
            _exports = new Dictionary<ExportDefinition, Export>();
        }

        public void SetExport(Type identity, Func<object> getter) {
            var definition = MakeDefinition(identity);
            _exports[definition] = new Export(definition, getter);
        }

        protected override IEnumerable<Export> GetExportsCore(
            ImportDefinition definition,
            AtomicComposition atomicComposition
        ) {

            return from kv in _exports
                   where definition.IsConstraintSatisfiedBy(kv.Key)
                   select kv.Value;
        }
    }
}
