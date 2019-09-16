// ***********************************************************************
// <copyright file="Delegates.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.FisCommunication.Delegates
{
    using EH.ImsOpcBridge.Service.FisCommunication.EventArguments;

    /// <summary>
    /// Delegate HttpResponseEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="HttpResponseEventArgs"/> instance containing the event data.</param>
    public delegate void HttpResponseEventHandler(object sender, HttpResponseEventArgs e);
}
