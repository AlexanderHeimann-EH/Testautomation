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

#if DEV12_OR_LATER

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

#if DEV14_OR_LATER
using Microsoft.Web.Editor.Controller;
using Microsoft.Web.Editor.Services;
#else
using Microsoft.Web.Editor;
#endif

namespace Microsoft.PythonTools.Django.Intellisense {
    internal class TemplateMainController : ViewController {
        public TemplateMainController(ITextView textView, ITextBuffer textBuffer)
            : base(textView, textBuffer) {
            ServiceManager.AddService<TemplateMainController>(this, textView);
        }

        protected override void Dispose(bool disposing) {
            ServiceManager.RemoveService<TemplateMainController>(TextView);
            base.Dispose(disposing);
        }
    }
}

#endif