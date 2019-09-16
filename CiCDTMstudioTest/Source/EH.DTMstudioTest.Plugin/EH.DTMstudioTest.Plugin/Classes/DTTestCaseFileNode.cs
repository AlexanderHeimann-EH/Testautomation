// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTTestCaseFileNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Defines the DTTestCaseNode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// Class DTTestCaseFileNode.
    /// </summary>
    public class DTTestCaseFileNode : HierarchyNode
    {
        // ReferenceContainerNode 
        #region Static Fields

        /// <summary>
        /// The image index
        /// </summary>
        internal static int imageIndex;

        /// <summary>
        /// The image list
        /// </summary>
        private static readonly ImageList imageList;

        #endregion

        #region Fields

        /// <summary>
        /// The compiler variable
        /// </summary>
        public readonly string CompilerVariable;

        /// <summary>
        /// The title
        /// </summary>
        private readonly string title;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="DTTestCaseFileNode"/> class.
        /// </summary>
        static DTTestCaseFileNode()
        {
            imageList = Utilities.GetImageList(typeof(DTDeviceFunctionNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Template.Resources.DTTestCaseFileNode.png"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTTestCaseFileNode"/> class.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="compilerVariable">
        /// The compiler variable.
        /// </param>
        public DTTestCaseFileNode(ProjectNode root, string title, string compilerVariable)
            : base(root)
        {
            this.title = title;
            this.CompilerVariable = compilerVariable;

            imageIndex = this.ProjectMgr.ImageHandler.ImageList.Images.Count;

            foreach (Image img in imageList.Images)
            {
                this.ProjectMgr.ImageHandler.AddImage(img);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Caption of the node.
        /// </summary>
        /// <value>The caption.</value>
        public override string Caption
        {
            get
            {
                return this.title;
            }
        }

        /// <summary>
        /// Return an imageindex
        /// </summary>
        /// <value>The index of the image.</value>
        public override int ImageIndex
        {
            get
            {
                return imageIndex;
            }
        }

        /// <summary>
        /// The item type guid associated to a node.
        /// </summary>
        /// <value>The item type unique identifier.</value>
        public override Guid ItemTypeGuid
        {
            get
            {
                return VSConstants.GUID_ItemType_PhysicalFile;
            }
        }

        /// <summary>
        /// The URL of the node.
        /// </summary>
        /// <value>The URL.</value>
        public override string Url
        {
            get
            {
                return this.VirtualNodeName;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Return an iconhandle
        /// </summary>
        /// <param name="open">
        /// if set to <c>true</c> [open].
        /// </param>
        /// <returns>
        /// System.Object.
        /// </returns>
        public override object GetIconHandle(bool open)
        {
            return this.ProjectMgr.ImageHandler.GetIconHandle(38);
        }

        #endregion
    }
}