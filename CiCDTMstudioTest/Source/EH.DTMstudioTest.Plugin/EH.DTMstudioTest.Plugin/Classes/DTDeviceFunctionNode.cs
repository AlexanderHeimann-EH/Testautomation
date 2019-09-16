// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTDeviceFunctionNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Class DTDeviceFunctionNode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    #region

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;
    using Microsoft.VisualStudio.Shell.Interop;

    #endregion

    /// <summary>
    /// Class DTDeviceFunctionNode.
    /// </summary>
    public class DTDeviceFunctionNode : HierarchyNode
    {
        #region Static Fields

        /// <summary>
        /// The image list
        /// </summary>
        private static readonly ImageList ImageList;

        #endregion

        #region Fields

        /// <summary>
        /// The image index
        /// </summary>
        public int imageIndex;

        /// <summary>
        /// The act image index
        /// </summary>
        private readonly int actImageIndex;

        /// <summary>
        /// The dt test project node
        /// </summary>
        private readonly DTTestProjectNode dtTestProjectNode;

        /// <summary>
        /// The title
        /// </summary>
        private readonly string title;

        /// <summary>
        /// The compiler variable
        /// </summary>
        private string compilerVariable;

        /// <summary>
        /// The node enabled
        /// </summary>
        private bool nodeEnabled;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="DTDeviceFunctionNode"/> class.
        /// </summary>
        static DTDeviceFunctionNode()
        {
            ImageList = Utilities.GetImageList(typeof(DTDeviceFunctionNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Template.Resources.DeviceFunction_Available.png"));

            var bitmap = new Bitmap(typeof(DTDeviceFunctionNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Template.Resources.DeviceFunction_NotAvailable.png"));
            ImageList.Images.AddStrip(bitmap);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTDeviceFunctionNode"/> class.
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
        /// if set to <c>true</c> [bode enabled].
        /// </param>
        public DTDeviceFunctionNode(DTTestProjectNode root, string title, string compilerVariable, bool bodeEnabled)
            : base(root)
        {
            this.nodeEnabled = bodeEnabled;
            this.dtTestProjectNode = root;
            this.title = title;
            this.compilerVariable = compilerVariable;
            this.actImageIndex = this.ProjectMgr.ImageHandler.ImageList.Images.Count;
            this.imageIndex = this.GetImageIndex(this.nodeEnabled);

            foreach (Image img in ImageList.Images)
            {
                this.ProjectMgr.ImageHandler.AddImage(img);
            }
        }

        #endregion

        ///// <summary>
        ///// Gets the caption.
        ///// </summary>
        // public override string Caption
        // {
        // get
        // {
        // string caption = this.title;
        // var projectProperty = this.ProjectMgr.GetProjectProperty(ConstStrings.BuildDefineConstantsProperty);

        // if (this.NodeEnabled)
        // {
        // // caption += " (Enabled)";
        // this.ProjectMgr.SetProjectProperty(ConstStrings.BuildDefineConstantsProperty, this.dtTestProjectNode.EHDataManager.IncCompileVariable(projectProperty, this.compilerVariable));
        // }
        // else
        // {
        // // caption += " (Disabled)";
        // this.ProjectMgr.SetProjectProperty(ConstStrings.BuildDefineConstantsProperty, this.dtTestProjectNode.EHDataManager.DecCompileVariable(projectProperty, this.compilerVariable));
        // }

        // return caption;
        // }
        // }
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
        /// Gets or sets the compiler variable.
        /// </summary>
        /// <value>The compiler variable.</value>
        public string CompilerVariable
        {
            get
            {
                return this.compilerVariable;
            }

            set
            {
                this.compilerVariable = value;
                this.OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_Caption, 0);
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
                return this.imageIndex;
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
                return VSConstants.GUID_ItemType_VirtualFolder;
            }
        }

        /// <summary>
        /// Gets the menu command identifier.
        /// </summary>
        /// <value>The menu command identifier.</value>
        public override int MenuCommandId
        {
            get
            {
                // return PkgCmdIDList.CmdIdPreDefineNodeContextMenu;
                return -1;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [node enabled].
        /// </summary>
        /// <value><c>true</c> if [node enabled]; otherwise, <c>false</c>.</value>
        public bool NodeEnabled
        {
            get
            {
                return this.nodeEnabled;
            }

            set
            {
                this.nodeEnabled = value;

                this.imageIndex = this.GetImageIndex(this.nodeEnabled);

                this.OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_Caption, 0);
                this.OnPropertyChanged(this, (int)__VSHPROPID.VSHPROPID_IconIndex, 0);
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

        #region Methods

        /// <summary>
        /// Gets the index of the image.
        /// </summary>
        /// <param name="nodeEnabled">
        /// if set to <c>true</c> [node enabled].
        /// </param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        private int GetImageIndex(bool nodeEnabled)
        {
            if (nodeEnabled)
            {
                return this.actImageIndex;
            }
            else
            {
                return this.actImageIndex + 1;
            }
        }

        #endregion
    }
}