// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelProc.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The definition of the delegate to be called, when the progress should be canceled.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Delegates
{
    /// <summary>
    /// The definition of the delegate to be called, when the progress should be canceled.
    /// </summary>
    /// <returns>
    /// <c>true</c> when the cancel has been successful. Otherwise <c>false</c>.
    /// </returns>
    public delegate bool CancelProc();
}
