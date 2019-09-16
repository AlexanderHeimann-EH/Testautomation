// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the OPC manager
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using System;
    using System.Linq;

    using EH.ImsOpcBridge.Common.Data;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Diagnostics;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    using OpcLabs.EasyOpc;
    using OpcLabs.EasyOpc.DataAccess;

    /// <summary>
    /// Class OpcManager
    /// </summary>
    internal class OpcManager
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcManager"/> class.
        /// </summary>
        public OpcManager()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Reads the local opc servers.
        /// </summary>
        /// <param name="servers">The servers.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise</returns>
        public bool ReadLocalOpcServers(out OpcServerItems servers, out uint error, out Exception exception)
        {
            servers = new OpcServerItems();
            error = ResultCodes.Success;
            exception = null;
            var result = true;

            try
            {
                var opc = OpcMonitor.CreateOpcClient();
                var opcServers = opc.BrowseServers(string.Empty);

                // The IP address is not used anymore...
                servers.AddRange(opcServers.Select(server => new OpcServerItem(false) { Name = server.Description, ClassId = server.ServerClass, IpAddress = "127.0.0.1" }));

                opc.Dispose();
            }
            catch (Exception ex)
            {
                Logger.FatalException(this, "Error browsing local OPC servers.", exception);
                servers.Clear();
                error = ResultCodes.CannotBrowseOpcServers;
                exception = ex;
                DiagnosticsCollection.Instance.AddMessage("Error browsing local OPC servers.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Reads the opc address space.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="opcItem">The opc item.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the operation succeeds, <c>false</c> otherwise</returns>
        public bool ReadOpcAddressSpace(string serverName, out OpcItem opcItem, out uint error, out Exception exception)
        {
            // The root of our tree. This is only to have a unique root in the tree.
            // OPC servers do not always have a unique root.
            opcItem = new OpcItem(true) { Name = "OPC Address Space" };
            error = ResultCodes.Success;
            exception = null;
            var result = true;

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrWhiteSpace(serverName))
            {
                error = ResultCodes.MissingArgument;
                return false;
            }

            try
            {
                var opc = OpcMonitor.CreateOpcClient();
                var serverDescriptor = new ServerDescriptor(serverName);
                this.BrowseRecursive(opc, serverDescriptor, null, opcItem);

                opc.Dispose();
            }
            catch (Exception ex)
            {
                Logger.FatalException(this, "Error browsing OPC servers.", exception);
                error = ResultCodes.BrowseAddressSpaceError;
                exception = ex;
                DiagnosticsCollection.Instance.AddMessage(string.Format("Error browsing OPC server: {0}", serverName));
                DiagnosticsCollection.Instance.AddMessage(exception);
                result = false;
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Process a new node.
        /// </summary>
        /// <param name="nodeElement">The node element.</param>
        /// <param name="opcParentItem">The opc parent item.</param>
        /// <returns>
        /// The <see cref="OpcItem"/>.
        /// </returns>
        private static OpcItem ProcessNode(DANodeElement nodeElement, OpcItem opcParentItem)
        {
            var opcItem = new OpcItem(true) { Name = nodeElement.Name };

            // We mark with a valid ItemId only the items that can be read, written or subscribed.
            if (!string.IsNullOrEmpty(nodeElement.ItemId) && nodeElement.IsItem)
            {
                opcItem.ItemId = nodeElement.ItemId;
            }

            opcParentItem.Children.Add(opcItem);
            return opcItem;
        }

        /// <summary>
        /// Browse recursively the address space of an OPC server.
        /// </summary>
        /// <param name="opc">The opc client.</param>
        /// <param name="serverDescriptor">The server descriptor.</param>
        /// <param name="nodeElement">The node element.</param>
        /// <param name="opcParentItem">The opc parent item.</param>
        private void BrowseRecursive(EasyDAClient opc, ServerDescriptor serverDescriptor, DANodeElement nodeElement, OpcItem opcParentItem)
        {
            if (nodeElement == null)
            {
                var branches = opc.BrowseBranches(serverDescriptor);
                var leaves = opc.BrowseLeaves(serverDescriptor);

                foreach (var branch in branches)
                {
                    this.BrowseRecursive(opc, serverDescriptor, branch, opcParentItem);
                }

                foreach (var leaf in leaves)
                {
                    this.BrowseRecursive(opc, serverDescriptor, leaf, opcParentItem);
                }
            }
            else
            {
                // A node element is processed only here.
                var newOpcItem = ProcessNode(nodeElement, opcParentItem);

                // Go on recursively if the node element has children.
                if (nodeElement.HasChildren)
                {
                    var nodeDescriptor = new DANodeDescriptor(nodeElement);
                    var branches = opc.BrowseBranches(serverDescriptor, nodeDescriptor);
                    var leaves = opc.BrowseLeaves(serverDescriptor, nodeDescriptor);

                    foreach (var branch in branches)
                    {
                        this.BrowseRecursive(opc, serverDescriptor, branch, newOpcItem);
                    }

                    foreach (var leaf in leaves)
                    {
                        this.BrowseRecursive(opc, serverDescriptor, leaf, newOpcItem);
                    }
                }
            }
        }

        #endregion
    }
}