// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandViewFactoryBase.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Commands
{
    using System;

    /// <summary>
    /// Class CommandViewFactoryBase.
    /// </summary>
    public class CommandViewFactoryBase : ICommandViewFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds the provider command to the command view (this might not add it or move it to a new structure)
        /// </summary>
        /// <param name="providerCommandItem">The provider command item.</param>
        /// <param name="commandView">The command view.</param>
        public virtual void AddProviderCommand(ICommandItem providerCommandItem, ICommandProvider commandView)
        {
            if (providerCommandItem == null)
            {
                throw new ArgumentNullException(@"providerCommandItem");
            }

            if (commandView == null)
            {
                throw new ArgumentNullException(@"commandView");
            }

            if (providerCommandItem.ParentCommand != null)
            {
                var parentCommandInView = commandView.FindCommand(providerCommandItem.ParentCommand.Id);

                if (parentCommandInView != null)
                {
                    parentCommandInView.AddCommand(providerCommandItem);
                    return;
                }
            }

            commandView.AddCommand(providerCommandItem);
        }

        /// <summary>
        /// Removes the provider command.
        /// </summary>
        /// <param name="providerCommandItem">The provider command item.</param>
        /// <param name="commandView">The command view.</param>
        public virtual void RemoveProviderCommand(ICommandItem providerCommandItem, ICommandProvider commandView)
        {
            if (providerCommandItem == null)
            {
                throw new ArgumentNullException(@"providerCommandItem");
            }

            if (commandView == null)
            {
                throw new ArgumentNullException(@"commandView");
            }

            var commandToRemoveInView = commandView.FindCommand(providerCommandItem.Id);
            var parentCommandViewItem = commandToRemoveInView.ParentCommand;

            if (parentCommandViewItem != null)
            {
                parentCommandViewItem.RemoveCommand(commandToRemoveInView);
            }
            else
            {
                commandView.RemoveCommand(commandToRemoveInView);
            }
        }

        #endregion
    }
}
