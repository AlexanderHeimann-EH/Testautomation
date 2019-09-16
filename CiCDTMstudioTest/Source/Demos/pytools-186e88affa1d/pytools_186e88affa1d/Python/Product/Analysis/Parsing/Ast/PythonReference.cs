/* ****************************************************************************
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

namespace Microsoft.PythonTools.Parsing.Ast {
    /// <summary>
    /// Represents a reference to a name.  A PythonReference is created for each locatio
    /// where a name is referred to in a scope (global, class, or function).  
    /// </summary>
    public class PythonReference {
        private readonly string/*!*/ _name;
        private PythonVariable _variable;

        public PythonReference(string/*!*/ name) {
            _name = name;
        }

        public string/*!*/ Name {
            get { return _name; }
        }

        public PythonVariable Variable {
            get { return _variable; }
            set { _variable = value; }
        }
    }
}
