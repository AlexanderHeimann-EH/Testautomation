// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISplashScreen.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Splash screen interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator
{
    /// <summary>
    /// Splash screen interface.
    /// </summary>
    public interface ISplashScreen
    {
        /// <summary>
        /// Shows this instance.
        /// </summary>
        void ShowScreen();

        /// <summary>
        /// Shuts down.
        /// </summary>
        void LoadComplete();
    }
}
