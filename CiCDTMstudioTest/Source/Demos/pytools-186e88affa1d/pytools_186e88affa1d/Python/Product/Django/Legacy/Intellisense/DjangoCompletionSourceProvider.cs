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

#if !DEV12_OR_LATER

using System.ComponentModel.Composition;
using Microsoft.PythonTools.Django.TemplateParsing;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.PythonTools.Django.Intellisense {
    [Export(typeof(ICompletionSourceProvider)), ContentType(TemplateContentType.ContentTypeName), Order, Name("DjangoCompletionSourceProvider")]
    internal class DjangoCompletionSourceProvider : ICompletionSourceProvider {
        internal readonly IGlyphService _glyphService;

        [ImportingConstructor]
        public DjangoCompletionSourceProvider(IGlyphService glyphService) {
            _glyphService = glyphService;
        }

        public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer) {
            var filename = TemplateProjectionBuffer.GetFilePath(textBuffer);
            if (filename != null) {
                var project = DjangoPackage.GetProject(filename);
                return new DjangoCompletionSource(_glyphService, project.Analyzer, textBuffer);
            }
            return null;
        }
    }
}

#endif