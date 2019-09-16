// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnConfigurationInformationControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class OwnConfigurationInformationControlVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Windows;

    /// <summary>
    /// Class OwnConfigurationInformationControlVm
    /// </summary>
    public class OwnConfigurationInformationControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(OwnConfigurationInformationControlVm), new PropertyMetadata(default(string)));

        #endregion
    }
}
