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
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Project {
    [ComVisible(true)]
    [Guid(PythonConstants.InterpretersPackagePropertiesGuid)]
    public class InterpretersPackageNodeProperties : NodeProperties {
        internal InterpretersPackageNodeProperties(HierarchyNode node)
            : base(node) { }

        [SRCategoryAttribute(SR.Misc)]
        [SRDisplayName(SR.PackageFullName)]
        [SRDescriptionAttribute(SR.PackageFullNameDescription)]
        [AutomationBrowsable(true)]
        public string FullPath {
            get {
                return this.HierarchyNode.Url;
            }
        }

        public override string GetClassName() {
            return "Python Package Properties";
        }
    }
}
