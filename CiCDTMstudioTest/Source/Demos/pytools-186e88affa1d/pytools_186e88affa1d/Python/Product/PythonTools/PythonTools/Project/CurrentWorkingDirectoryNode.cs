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

using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Project {
    /// <summary>
    /// Represents Current Working Directory node.
    /// </summary>
    internal class CurrentWorkingDirectoryNode : BaseSearchPathNode {

        public CurrentWorkingDirectoryNode(PythonProjectNode project, string path)
            : base(project, path, new VirtualProjectElement(project)) { }

        public override string Caption {
            get {
                return "Working Directory (" + base.Caption + ")";
            }
        }

        //Working Directory node cannot be deleted
        internal override bool CanDeleteItem(Microsoft.VisualStudio.Shell.Interop.__VSDELETEITEMOPERATION deleteOperation) {
            return false;
        }

        public override int SortPriority {
            get {
                return CommonConstants.WorkingDirectorySortPriority;
            }
        }
    }
}
