// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenEdge.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The screen edge.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
  /// <summary>
  /// The screen edge.
  /// </summary>
  public enum ScreenEdge
  {
    /// <summary>
    ///   The undefined.
    /// </summary>
    Undefined = -1, 

    /// <summary>
    ///   The left.
    /// </summary>
    Left = AppBarInfo.AbeLeft, 

    /// <summary>
    ///   The top.
    /// </summary>
    Top = AppBarInfo.AbeTop, 

    /// <summary>
    ///   The right.
    /// </summary>
    Right = AppBarInfo.AbeRight, 

    /// <summary>
    ///   The bottom.
    /// </summary>
    Bottom = AppBarInfo.AbeBottom
  }
}
