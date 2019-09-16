// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTTestSuiteNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The dt test suite node.
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
    /// The dt test suite node.
    /// </summary>
    internal class DTTestSuiteNode : HierarchyNode
    {
        // ReferenceContainerNode 
        #region Static Fields

        /// <summary>
        /// The image index.
        /// </summary>
        internal static int imageIndex;

        /// <summary>
        /// The image list.
        /// </summary>
        private static readonly ImageList imageList;

        #endregion

        #region Fields

        /// <summary>
        /// The title.
        /// </summary>
        private readonly string title;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="DTTestSuiteNode"/> class.
        /// </summary>
        static DTTestSuiteNode()
        {
            imageList = Utilities.GetImageList(typeof(DTTestSuiteNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Plugin.Resources.DTTestSuiteNode.png"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTTestSuiteNode"/> class.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public DTTestSuiteNode(ProjectNode root, string title)
            : base(root)
        {
            this.title = title;

            imageIndex = this.ProjectMgr.ImageHandler.ImageList.Images.Count;

            foreach (Image img in imageList.Images)
            {
                this.ProjectMgr.ImageHandler.AddImage(img);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the caption.
        /// </summary>
        public override string Caption
        {
            get
            {
                string caption = this.title;
                return caption;
            }
        }

        /// <summary>
        /// Gets the image index.
        /// </summary>
        public override int ImageIndex
        {
            get
            {
                return imageIndex;
            }
        }

        /// <summary>
        /// Gets the item type guid.
        /// </summary>
        public override Guid ItemTypeGuid
        {
            get
            {
                return VSConstants.GUID_ItemType_VirtualFolder;
            }
        }

        /// <summary>
        /// Gets the url.
        /// </summary>
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
        /// The get icon handle.
        /// </summary>
        /// <param name="open">
        /// The open.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object GetIconHandle(bool open)
        {
            return this.ProjectMgr.ImageHandler.GetIconHandle(imageIndex);
        }

        #endregion

        ///// <summary>
        ///// Returns command Id for context menu
        ///// </summary>
        // public override int MenuCommandId
        // {
        // get
        // {
        // //return PkgCmdIDList.CmdIdPreDefineNodeContextMenu;
        // return -1; 
        // }
        // }
    }
}