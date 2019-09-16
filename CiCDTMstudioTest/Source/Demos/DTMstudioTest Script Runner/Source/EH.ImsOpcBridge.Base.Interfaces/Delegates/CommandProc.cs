// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandProc.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The delegate, which is used by the command item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Delegates
{
    /// <summary>
    /// The delegate, which is used by the command item.
    /// </summary>
    /// <param name="commandItem">The command item to be executed.</param>
    /// <returns>The result of the command.</returns>
    public delegate ICommandResult CommandProc(ICommandItemBase commandItem);
}
