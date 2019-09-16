// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTTestProjectFactory.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The dt test project factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// Class DTTestProjectFactory.
    /// </summary>
    [Guid(GuidList.guidDTTestProjectFactoryString)]
    internal class DTTestProjectFactory : ProjectFactory
    {
        #region Fields

        /// <summary>
        /// The package
        /// </summary>
        private readonly DTMstudioTestPackage package;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DTTestProjectFactory"/> class.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public DTTestProjectFactory(DTMstudioTestPackage package)
            : base(package)
        {
            this.package = package;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <returns>ProjectNode.</returns>
        protected override ProjectNode CreateProject()
        {
            var project = new DTTestProjectNode(this.package);
            project.SetSite((IOleServiceProvider)((IServiceProvider)this.package).GetService(typeof(IOleServiceProvider)));
            return project;
        }

        #endregion
    }
}