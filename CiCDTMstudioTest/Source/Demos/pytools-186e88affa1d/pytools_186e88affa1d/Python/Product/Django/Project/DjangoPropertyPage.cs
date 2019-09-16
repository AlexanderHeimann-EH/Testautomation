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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Django.Project {
    [Guid(GuidList.guidDjangoPropertyPageString)]
    class DjangoPropertyPage : CommonPropertyPage {
        private readonly DjangoPropertyPageControl _control;

        public const string SettingModulesSetting = "DjangoSettingsModule";
        public const string StaticUriPatternSetting = "StaticUriPattern";

        public DjangoPropertyPage() {
            _control = new DjangoPropertyPageControl(this);
        }
        
        public override Control Control {
            get { return _control; }
        }

        public override void Apply() {
            SetProjectProperty(SettingModulesSetting, _control.SettingsModule);
            SetProjectProperty(StaticUriPatternSetting, _control.StaticUriPattern);
            IsDirty = false;
        }

        public override void LoadSettings() {
            Loading = true;
            try {
                _control.SettingsModule = GetProjectProperty(SettingModulesSetting);
                _control.StaticUriPattern = GetProjectProperty(StaticUriPatternSetting);
                IsDirty = false;
            } finally {
                Loading = false;
            }
        }

        public override string Name {
            get { return Resources.DjangoPropertyPageTitle; }
        }
    }
}
