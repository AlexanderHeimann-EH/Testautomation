// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReadOnlyImsOpcBridgeSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface IReadOnlyImsOpcBridgeSettings
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System.Diagnostics.CodeAnalysis;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Interface IReadOnlyImsOpcBridgeSettings
    /// </summary>
    public interface IReadOnlyImsOpcBridgeSettings
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [allow culture change].
        /// </summary>
        /// <value><c>true</c> if [allow culture change]; otherwise, <c>false</c>.</value>
        bool AllowCultureChange { get; }

        /// <summary>
        /// Gets the allow execution on machine.
        /// </summary>
        /// <value>The allow execution on machine.</value>
        string AllowExecutionOnMachine { get; }

        /// <summary>
        /// Gets the command alignment.
        /// </summary>
        /// <value>The command alignment.</value>
        CommandAlignment CommandAlignment { get; }

        /// <summary>
        /// Gets the name of the culture.
        /// </summary>
        /// <value>The name of the culture.</value>
        string CultureName { get; }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        string Manufacturer { get; }

        /// <summary>
        /// Gets the height of the windows pos.
        /// </summary>
        /// <value>The height of the windows pos.</value>
        double WindowsPosHeight { get; }

        /// <summary>
        /// Gets the windows pos left.
        /// </summary>
        /// <value>The windows pos left.</value>
        double WindowsPosLeft { get; }

        /// <summary>
        /// Gets the windows pos top.
        /// </summary>
        /// <value>The windows pos top.</value>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PosTop", Justification = @"OK here")]
        double WindowsPosTop { get; }

        /// <summary>
        /// Gets the width of the windows pos.
        /// </summary>
        /// <value>The width of the windows pos.</value>
        double WindowsPosWidth { get; }

        #endregion
    }
}