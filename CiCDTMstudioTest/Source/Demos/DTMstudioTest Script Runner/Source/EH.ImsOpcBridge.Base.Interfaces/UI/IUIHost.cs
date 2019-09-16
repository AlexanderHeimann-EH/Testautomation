// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.Interfaces
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 04-16-2013
// ***********************************************************************
// <copyright file="IUIHost.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.UI
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// The interface of the handler for user interface callbacks to the hosting application.
    /// </summary>
    [CLSCompliant(false)]
    public interface IUIHost
    {
        #region Public Events

        /// <summary>
        /// The toggle message agent.
        /// </summary>
        event EventHandler<MessageAgentEventArgs> ToggleMessageAgent;

        /// <summary>
        /// Occurs when the application should fade out or in because of a message box
        /// </summary>
        event EventHandler<MessageBoxShadowEventArgs> ToggleMessageBoxShadow;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates the busy indicator.
        /// </summary>
        /// <returns>The interface to the busy indicator.</returns>
        IBusyIndicator CreateBusyIndicator();

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        [Localizable(true)]
        ResultMessage DisplayMessage(string message, string caption, MessageButton button, MessageType messageType);

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <param name="defaultResult">Default result.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        [Localizable(true)]
        ResultMessage DisplayMessage(string message, string caption, MessageButton button, MessageType messageType, DefaultMessageButton defaultResult);

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="owner">Owner window</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <param name="defaultResult">Default result.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        [Localizable(true)]
        ResultMessage DisplayMessage(Window owner, string message, string caption, MessageButton button, MessageType messageType, DefaultMessageButton defaultResult);

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="owner">Owner window</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        [Localizable(true)]
        ResultMessage DisplayMessage(Window owner, string message, string caption, MessageButton button, MessageType messageType);

        /// <summary>
        /// Process the UI events.
        /// </summary>
        void DoEvents();

        /// <summary>
        /// Waits for event and performs the UI events.
        /// </summary>
        /// <param name="autoResetEvent">The auto reset event to wait for.</param>
        /// <param name="timeSpan">The time span to wait until timeout occurs.</param>
        /// <returns>True, if event has been set in time. False if timeout occurred.</returns>
        bool WaitForEventAndDoEvents(AutoResetEvent autoResetEvent, TimeSpan timeSpan);

        /// <summary>
        /// Waits and performs the UI events.
        /// </summary>
        /// <param name="waitWhileTrue">If set to true, the function still waits.</param>
        /// <param name="timeSpan">The time span to wait until timeout occurs.</param>
        /// <returns>True, if event has been set in time. False if timeout occurred.</returns>
        bool WaitWhileTrueAndDoEvents(Func<bool> waitWhileTrue, TimeSpan timeSpan);

        #endregion
    }
}
