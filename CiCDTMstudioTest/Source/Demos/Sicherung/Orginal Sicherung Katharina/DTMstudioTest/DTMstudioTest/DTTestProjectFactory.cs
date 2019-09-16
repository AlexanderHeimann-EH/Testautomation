using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace EndressHauser.DTMstudioTest
{
    [Guid(GuidList.guidDTTestProjectFactoryString)]
    class DTTestProjectFactory : ProjectFactory
    {
        private DTMstudioTestPackage package;

        public DTTestProjectFactory(DTMstudioTestPackage package)
            : base(package)
        {
            this.package = package;
        }

        protected override ProjectNode CreateProject()
        {
            DTTestProjectNode project = new DTTestProjectNode(this.package);

            project.SetSite((IOleServiceProvider)((IServiceProvider)this.package).GetService(typeof(IOleServiceProvider)));
            return project;
        }
    }
}
