// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandViewFactory.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    /// <summary>
    /// The CommandViewFactory interface.
    /// </summary>
    public interface ICommandViewFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds the provider command to the command view (this might not add it or move it to a new structure)
        /// </summary>
        /// <param name="providerCommandItem">The provider command item.</param>
        /// <param name="commandView">The command view.</param>
        void AddProviderCommand(ICommandItem providerCommandItem, ICommandProvider commandView);

        /// <summary>
        /// Removes the provider command.
        /// </summary>
        /// <param name="providerCommandItem">The provider command item.</param>
        /// <param name="commandView">The command view.</param>
        void RemoveProviderCommand(ICommandItem providerCommandItem, ICommandProvider commandView);

        #endregion
    }
}
