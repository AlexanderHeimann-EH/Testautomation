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
using Microsoft.PythonTools;
using Microsoft.PythonTools.Interpreter;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudioTools.VSTestHost;

namespace TestUtilities.UI {
    public class DefaultInterpreterSetter : IDisposable {
        public readonly IPythonInterpreterFactory OriginalInterpreter;
        public readonly IPythonInterpreterFactory CurrentDefault;
        private bool _isDisposed;

        public DefaultInterpreterSetter(IPythonInterpreterFactory factory) {
            var model = (IComponentModel)VSTestContext.ServiceProvider.GetService(typeof(SComponentModel));
            var interpreterService = model.GetService<IInterpreterOptionsService>();
            Assert.IsNotNull(interpreterService);

            OriginalInterpreter = interpreterService.DefaultInterpreter;
            CurrentDefault = factory;
            interpreterService.DefaultInterpreter = factory;
        }

        public void Dispose() {
            if (!_isDisposed) {
                _isDisposed = true;

                var model = (IComponentModel)VSTestContext.ServiceProvider.GetService(typeof(SComponentModel));
                var interpreterService = model.GetService<IInterpreterOptionsService>();
                Assert.IsNotNull(interpreterService);
                interpreterService.DefaultInterpreter = OriginalInterpreter;
            }
        }
    }
}
