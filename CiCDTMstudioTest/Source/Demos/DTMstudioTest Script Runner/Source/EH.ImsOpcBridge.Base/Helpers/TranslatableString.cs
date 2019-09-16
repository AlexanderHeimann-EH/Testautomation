// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TranslatableString.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Text;

    using EH.ImsOpcBridge.Information;

    /// <summary>
    /// The translatable string.
    /// </summary>
    public class TranslatableString : ITranslatableString
    {
        #region Fields

        /// <summary>
        /// The args
        /// </summary>
        private readonly string[] args;

        /// <summary>
        /// The assembly name
        /// </summary>
        private readonly string assemblyName;

        /// <summary>
        /// The base name
        /// </summary>
        private readonly string baseName;

        /// <summary>
        /// The cache lock
        /// </summary>
        private readonly object cacheLock = new object();

        /// <summary>
        /// The format resource name
        /// </summary>
        private readonly string formatResourceName;

        /// <summary>
        /// The cached culture
        /// </summary>
        private CultureInfo cachedCulture;

        /// <summary>
        /// The cached string
        /// </summary>
        private string cachedString = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatableString" /> class.
        /// </summary>
        /// <param name="formatResourceName">Name of the format resource.</param>
        /// <param name="baseName">Name of the base.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="args">The args.</param>
        public TranslatableString([Localizable(false)] string formatResourceName, [Localizable(false)] string baseName, [Localizable(false)] string assemblyName, params string[] args)
        {
            this.formatResourceName = formatResourceName;
            this.baseName = baseName;
            this.assemblyName = assemblyName;
            this.args = args;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatableString" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public TranslatableString(ITranslatableString source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(@"source");
            }

            this.formatResourceName = source.FormatResourceName;
            this.baseName = source.BaseName;
            this.assemblyName = source.AssemblyName;
            this.args = source.Args;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the args.
        /// </summary>
        /// <value>The args.</value>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = @"OK here.")]
        public string[] Args
        {
            get
            {
                return this.args;
            }
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>The name of the assembly.</value>
        public string AssemblyName
        {
            get
            {
                return this.assemblyName;
            }
        }

        /// <summary>
        /// Gets the name of the base.
        /// </summary>
        /// <value>The name of the base.</value>
        public string BaseName
        {
            get
            {
                return this.baseName;
            }
        }

        /// <summary>
        /// Gets the name of the format resource.
        /// </summary>
        /// <value>The name of the format resource.</value>
        public string FormatResourceName
        {
            get
            {
                return this.formatResourceName;
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
                stringBuilder.Append(this.formatResourceName);

                if (this.args.Length > 0)
                {
                    var pos = 0;

                    stringBuilder.Append("(");

                    foreach (var arg in this.args)
                    {
                        stringBuilder.Append(arg);

                        pos++;
                        if (pos < this.args.Length)
                        {
                            stringBuilder.Append(@", ");
                        }
                    }

                    stringBuilder.Append(")");
                }

                stringBuilder.Append("]");

                return stringBuilder.ToString();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public override string ToString()
        {
            lock (this.cacheLock)
            {
                if ((this.cachedCulture != null) && (this.cachedCulture.LCID == CultureInfo.CurrentCulture.LCID))
                {
                    return this.cachedString;
                }

                if ((this.assemblyName == null) && (this.baseName == null))
                {
                    this.cachedString = this.formatResourceName;
                    this.cachedCulture = CultureInfo.CurrentCulture;
                    return this.cachedString;
                }

                var assemblyQuery = from assemblyInfo in AssemblyManagement.LoadedAssemblies where assemblyInfo.FullName == this.assemblyName select assemblyInfo.Assembly;
                var assembly = assemblyQuery.FirstOrDefault();

                if (assembly == null)
                {
                    this.cachedString = this.MissingString;
                    this.cachedCulture = CultureInfo.CurrentCulture;
                    return this.cachedString;
                }

                var resourceManager = new ResourceManager(this.baseName, assembly);

                // ReSharper disable EmptyGeneralCatchClause
                try
                {
                    var formatString = resourceManager.GetString(this.formatResourceName, CultureInfo.CurrentCulture);
                    if (formatString != null)
                    {
                        this.cachedString = string.Format(CultureInfo.CurrentCulture, formatString, this.args);
                        this.cachedCulture = CultureInfo.CurrentCulture;
                        return this.cachedString;
                    }
                }
                catch (Exception)
                {
                }

                // ReSharper restore EmptyGeneralCatchClause
                this.cachedString = this.MissingString;
                this.cachedCulture = CultureInfo.CurrentCulture;
                return this.cachedString;
            }
        }

        #endregion
    }
}
