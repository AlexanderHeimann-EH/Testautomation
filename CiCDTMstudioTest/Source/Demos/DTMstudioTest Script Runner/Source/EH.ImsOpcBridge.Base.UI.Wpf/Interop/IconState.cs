// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconState.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The state of the icon - can be set to hide the icon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
  /// <summary>
  /// The state of the icon - can be set to hide the icon.
  /// </summary>
  public enum IconState
  {
    /// <summary>
    ///   The icon is visible.
    /// </summary>
    Visible = 0x00, 

    /// <summary>
    ///   Hide the icon.
    /// </summary>
    Hidden = 0x01, 

    //// <summary>
    //// The icon is shared - currently not supported, thus commented out.
    //// </summary>
    //// Shared = 0x02
  }
}
