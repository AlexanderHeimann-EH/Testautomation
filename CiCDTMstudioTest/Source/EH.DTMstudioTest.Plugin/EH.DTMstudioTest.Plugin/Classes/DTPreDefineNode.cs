// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTPreDefineNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The DeviceType pre define node.
    /// </summary>
    public class DTPreDefineNode : HierarchyNode
    {
        #region Static Fields

        /// <summary>
        /// The image list.
        /// </summary>
        protected static ImageList imageList;

        #endregion

        #region Fields

        /// <summary>
        /// The image index.
        /// </summary>
        private readonly int actImageIndex;

        /// <summary>
        /// The title.
        /// </summary>
        private readonly string title;

        /// <summary>
        /// The compiler switch.
        /// </summary>
        private string compilerVariable;

        /// <summary>
        /// The dt test project node.
        /// </summary>
        private DTTestProjectNode dtTestProjectNode;

        /// <summary>
        /// The image index.
        /// </summary>
        private int imageIndex;

        /// <summary>
        /// The enabled.
        /// </summary>
        private bool nodeEnabled;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="DTPreDefineNode"/> class.
        /// </summary>
        static DTPreDefineNode()
        {
            imageList = Utilities.GetImageList(typeof(DTPreDefineNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Template.Resources.DTPreDefinesNode_Available.png"));

            var bitmap = new Bitmap(typeof(DTPreDefineNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Template.Resources.DTPreDefinesNode_NotAvailable.png"));
            imageList.Images.AddStrip(bitmap);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTPreDefineNode"/> class.
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
        /// <param name="bodeEnabled">
        /// The bode enabled.
        /// </param>
        public DTPreDefineNode(DTTestProjectNode root, string title, string compilerVariable, bool bodeEnabled)
            : base(root)
        {
            this.nodeEnabled = bodeEnabled;
            this.dtTestProjectNode = root;
            this.title = title;
            this.compilerVariable = compilerVariable;
            this.actImageIndex = this.imageIndex = this.ProjectMgr.ImageHandler.ImageList.Images.Count;

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

                // var projectProperty = this.ProjectMgr.GetProjectProperty(ConstStrings.BuildDefineConstantsProperty);
                if (this.NodeEnabled)
                {
                    caption += " (Enabled)";

                    // this.ProjectMgr.SetProjectProperty(ConstStrings.BuildDefineConstantsProperty, this.dtTestProjectNode.EHDataManager.IncCompileVariable(projectProperty, this.compilerVariable));
                }
                else
                {
                    caption += " (Disabled)";

                    // this.ProjectMgr.SetProjectProperty(ConstStrings.BuildDefineConstantsProperty, this.dtTestProjectNode.EHDataManager.DecCompileVariable(projectProperty, this.compilerVariable));
                }

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
                return this.imageIndex;
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
        /// Returns command Id for context menu
        /// </summary>
        public override int MenuCommandId
        {
            get
            {
                // return PkgCmdIDList.CmdIdPreDefineNodeContextMenu;
                return -1;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether node enabled.
        /// </summary>
        public bool NodeEnabled
        {
            get
            {
                return this.nodeEnabled;
            }

            set
            {
                this.nodeEnabled = value;

                if (this.nodeEnabled)
                {
                    this.imageIndex = this.actImageIndex - 1;
                }
                else
                {
                    this.imageIndex = this.actImageIndex;
                }

                this.OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_Caption, 0);
                this.OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_IconIndex, 0);
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
    }
}