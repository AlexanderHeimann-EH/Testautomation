// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyTypeConvertert.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// The my type converter.
    /// </summary>
    public class MyTypeConverter : StringConverter
    {

        private List<string> values;

        public MyTypeConverter()
        {
            this.values = new List<string>();
            this.values.Add("first");
            this.values.Add("second");
        }

        /// <summary>
        /// The get standard values supported.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// The get standard values.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="TypeConverter.StandardValuesCollection"/>.
        /// </returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(this.values);
        }

        /// <summary>
        /// The can convert from.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="sourceType">
        /// The source type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// The convert from.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                foreach (string item in this.values)
                {
                    if (item == (string)value)
                    {
                        return item;
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}


