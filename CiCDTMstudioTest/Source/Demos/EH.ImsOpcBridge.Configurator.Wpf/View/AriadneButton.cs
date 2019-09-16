// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AriadneButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The ariadne button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf.View;

    /// <summary>
    /// The ariadne button.
    /// </summary>
    internal class AriadneButton : ImageRadioButton
    {
        #region Static Fields

        /// <summary>
        /// The is first step property.
        /// </summary>
        public static readonly DependencyProperty IsFirstStepProperty = DependencyProperty.Register("IsFirstStep", typeof(bool), typeof(AriadneButton), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is ticked property.
        /// </summary>
        public static readonly DependencyProperty IsTickedProperty = DependencyProperty.Register("IsTicked", typeof(bool), typeof(AriadneButton), new PropertyMetadata(default(bool)));

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether is first step.
        /// </summary>
        /// <value><c>true</c> if this instance is first step; otherwise, <c>false</c>.</value>
        public bool IsFirstStep
        {
            get
            {
                return (bool)this.GetValue(IsFirstStepProperty);
            }

            set
            {
                this.SetValue(IsFirstStepProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is ticked.
        /// </summary>
        /// <value><c>true</c> if this instance is ticked; otherwise, <c>false</c>.</value>
        public bool IsTicked
        {
            get
            {
                return (bool)this.GetValue(IsTickedProperty);
            }

            set
            {
                this.SetValue(IsTickedProperty, value);
            }
        }

        #endregion
    }
}
