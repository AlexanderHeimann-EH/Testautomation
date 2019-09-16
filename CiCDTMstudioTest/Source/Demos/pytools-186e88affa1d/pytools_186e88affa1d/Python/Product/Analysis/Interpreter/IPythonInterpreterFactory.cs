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

namespace Microsoft.PythonTools.Interpreter {
    /// <summary>
    /// Provides a factory for creating IPythonInterpreters for a specific
    /// Python implementation.
    /// 
    /// The factory includes information about what type of interpreter will be
    /// created - this is used for displaying information to the user and for
    /// tracking per-interpreter settings.
    /// 
    /// It also contains a method for creating an interpreter. This allows for
    /// stateful interpreters that participate in analysis or track other state.
    /// </summary>
    public interface IPythonInterpreterFactory {
        /// <summary>
        /// A user friendly description of the interpreter.
        /// </summary>
        string Description {
            get;
        }

        /// <summary>
        /// Configuration settings for the interpreter.
        /// </summary>
        InterpreterConfiguration Configuration {
            get;
        }

        /// <summary>
        /// A stable ID for the interpreter used to track settings.
        /// </summary>
        Guid Id {
            get;
        }

        /// <summary>
        /// Creates an IPythonInterpreter instance.
        /// </summary>
        IPythonInterpreter CreateInterpreter();
    }
}
