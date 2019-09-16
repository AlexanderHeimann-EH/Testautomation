// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template.Attributes
{
    using System;

    /// <summary>
    /// The string value.
    /// </summary>
    public class StringValue : Attribute
    {
        /// <summary>
        /// The internal value.
        /// </summary>
        private readonly string internalValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValue"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public StringValue(string value)
        {
            this.internalValue = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.internalValue;
            }
        }
    }
}
