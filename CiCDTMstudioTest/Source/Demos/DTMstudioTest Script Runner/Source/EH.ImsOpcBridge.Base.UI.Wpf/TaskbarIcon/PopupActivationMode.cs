// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopupActivationMode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Defines flags that define when a popup is being displyed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.TaskbarIcon
{
  /// <summary>
  /// Defines flags that define when a popup is being displayed.
  /// </summary>
  public enum PopupActivationMode
  {
    /// <summary>
    ///   The item is displayed if the user clicks the tray icon with the left mouse button.
    /// </summary>
    LeftClick, 

    /// <summary>
    ///   The item is displayed if the user clicks the tray icon with the right mouse button.
    /// </summary>
    RightClick, 

    /// <summary>
    ///   The item is displayed if the user double-clicks the tray icon.
    /// </summary>
    DoubleClick, 

    /// <summary>
    ///   The item is displayed if the user clicks the tray icon with the left or the right mouse button.
    /// </summary>
    LeftOrRightClick, 

    /// <summary>
    ///   The item is displayed if the user clicks the tray icon with the left mouse button or if a double-click is being performed.
    /// </summary>
    LeftOrDoubleClick, 

    /// <summary>
    ///   The item is displayed if the user clicks the tray icon with the middle mouse button.
    /// </summary>
    MiddleClick, 

    /// <summary>
    ///   The item is displayed whenever a click occurs.
    /// </summary>
    All
  }
}
