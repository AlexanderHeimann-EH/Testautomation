// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TranslatableDisplayName.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Model
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Text;

    /// <summary>
    /// The translatable display name.
    /// </summary>
    internal sealed class TranslatableDisplayName : DisplayNameAttribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatableDisplayName" /> class.
        /// </summary>
        /// <param name="formatResourceName">Name of the format resource.</param>
        public TranslatableDisplayName([Localizable(false)] string formatResourceName)
            : base(formatResourceName)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the display name for a property, event, or public void method that takes no arguments stored in this attribute.
        /// </summary>
        /// <returns>The display name.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        public override string DisplayName
        {
            get
            {
                var displayName = base.DisplayName;
                var assembly = Assembly.GetExecutingAssembly();

                var resourceManager = new ResourceManager(@"EH.ImsOpcBridge.UI.Wpf.Properties.Resources", assembly);

                // ReSharper disable EmptyGeneralCatchClause
                try
                {
                    var resourceString = resourceManager.GetString(displayName, CultureInfo.CurrentCulture);
                    if (resourceString != null)
                    {
                        return resourceString;
                    }
                }
                catch (Exception)
                {
                }

                // ReSharper restore EmptyGeneralCatchClause
                return this.MissingString;
            }
        }

        /// <summary>
        /// Gets the missing string.
        /// </summary>
        /// <value>The missing string.</value>
        public string MissingString
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append("[");
                stringBuilder.Append(base.DisplayName);
                stringBuilder.Append("]");

                return stringBuilder.ToString();
            }
        }

        #endregion
    }
}
