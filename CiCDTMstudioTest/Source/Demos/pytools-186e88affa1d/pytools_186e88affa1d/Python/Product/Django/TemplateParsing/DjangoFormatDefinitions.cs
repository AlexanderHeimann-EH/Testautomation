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

using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.PythonTools.Django.Intellisense;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.PythonTools.Django.TemplateParsing {
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = DjangoPredefinedClassificationTypeNames.TemplateTag)]
    [Name(DjangoPredefinedClassificationTypeNames.TemplateTag)]
    [DisplayName(DjangoPredefinedClassificationTypeNames.TemplateTag)]
    [UserVisible(true)]
    [Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
    internal sealed class OperatorFormat : ClassificationFormatDefinition {
        public OperatorFormat() {
            ForegroundColor = Color.FromRgb(0x00, 0x80, 0x80);
        }
    }
}
