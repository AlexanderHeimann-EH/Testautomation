// -----------------------------------------------------------------------
// <copyright file="SimpleProjectFactory.cs" company="Endress+Hauser Process Solutions AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SimpleProject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Project;
    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Guid(GuidList.guidSimpleProjectFactoryString)]
    public class SimpleProjectFactory : ProjectFactory
    {
        private SimpleProjectPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleProjectFactory"/> class.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public SimpleProjectFactory(SimpleProjectPackage package)
            : base(package)
        {
            this.package = package;
        }

        /// <summary>
        /// The create project.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectNode"/>.
        /// </returns>
        protected override ProjectNode CreateProject()
        {
            SimpleProjectNode project = new SimpleProjectNode(this.package);

            project.SetSite((IOleServiceProvider)((IServiceProvider)this.package).GetService(typeof(IOleServiceProvider)));
            return project;
        }
    }
}
