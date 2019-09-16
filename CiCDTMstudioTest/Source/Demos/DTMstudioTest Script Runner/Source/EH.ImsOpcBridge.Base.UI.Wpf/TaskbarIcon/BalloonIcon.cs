// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalloonIcon.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Supported icons for the tray's ballon messages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.TaskbarIcon
{
  /// <summary>
  /// Supported icons for the tray's balloon messages.
  /// </summary>
  public enum BalloonIcon
  {
    /// <summary>
    ///   The balloon message is displayed without an icon.
    /// </summary>
    None, 

    /// <summary>
    ///   An information is displayed.
    /// </summary>
    Info, 

    /// <summary>
    ///   A warning is displayed.
    /// </summary>
    Warning, 

    /// <summary>
    ///   An error is displayed.
    /// </summary>
    Error
  }
}
