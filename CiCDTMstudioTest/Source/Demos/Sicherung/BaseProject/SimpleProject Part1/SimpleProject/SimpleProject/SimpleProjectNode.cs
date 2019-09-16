// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleProjectNode.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SimpleProjectNode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleProject
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// The simple project node.
    /// </summary>
    public class SimpleProjectNode : ProjectNode
    {
        /// <summary>
        /// The package.
        /// </summary>
        private SimpleProjectPackage package;
        private static ImageList imageList;


        internal static int imageIndex;
        public override int ImageIndex
        {
            get { return imageIndex; }
        }


        static SimpleProjectNode()
        {
            imageList = Utilities.GetImageList(typeof(SimpleProjectNode).Assembly.GetManifestResourceStream("SimpleProject.Resources.SimpleProjectNode.bmp"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleProjectNode"/> class.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public SimpleProjectNode(SimpleProjectPackage package)
        {
            this.package = package;

            imageIndex = this.ImageHandler.ImageList.Images.Count;

            foreach (Image img in imageList.Images)
            {
                this.ImageHandler.AddImage(img);
            }
        }

        /// <summary>
        /// Gets the project guid.
        /// </summary>
        public override Guid ProjectGuid
        {
            get { return GuidList.guidSimpleProjectFactory; }
        }

        /// <summary>
        /// Gets the project type.
        /// </summary>
        public override string ProjectType
        {
            get { return "SimpleProjectType"; }
        }

        /// <summary>
        /// The add file from template.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public override void AddFileFromTemplate(
            string source, string target)
        {
            string nameSpace = this.FileTemplateProcessor.GetFileNamespace(target, this);
            string className = Path.GetFileNameWithoutExtension(target);

            this.FileTemplateProcessor.AddReplace("$nameSpace$", nameSpace);
            this.FileTemplateProcessor.AddReplace("$className$", className);

            this.FileTemplateProcessor.UntokenFile(source, target);
            this.FileTemplateProcessor.Reset();
        }
    }
}