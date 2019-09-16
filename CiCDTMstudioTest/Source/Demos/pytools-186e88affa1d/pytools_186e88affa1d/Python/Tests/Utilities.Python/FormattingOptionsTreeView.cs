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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace TestUtilities.UI.Python {
    class FormattingOptionsTreeView : TreeView {
        public FormattingOptionsTreeView(AutomationElement element)
            : base(element) {
        }

        public static FormattingOptionsTreeView FromDialog(ToolsOptionsDialog dialog) {
            dialog.WaitForInputIdle();
            var spacingViewElement = dialog.FindByAutomationId("_optionsTree");
            for (int retries = 10; retries > 0 && spacingViewElement == null; retries -= 1) {
                Thread.Sleep(100);
                dialog.WaitForInputIdle();
                spacingViewElement = dialog.FindByAutomationId("_optionsTree");
            }

            return new FormattingOptionsTreeView(spacingViewElement);
        }
    }
}
