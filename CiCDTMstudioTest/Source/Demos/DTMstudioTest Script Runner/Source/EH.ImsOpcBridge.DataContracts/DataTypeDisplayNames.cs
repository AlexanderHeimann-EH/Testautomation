// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTypeDisplayNames.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The authentication.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.DataContracts
{
    /// <summary>
    /// Defines the data type display names.
    /// </summary>
    public class DataTypeDisplayNames
    {
        #region Fields

        /// <summary>
        /// The display names.
        /// </summary>
        private static readonly string[] Values = new[]
                                             {
                                                 "byte", "short", "unsignedShort", "int",
                                                 "unsignedInt", "long", "unsignedLong", "float",
                                                 "double", "IEEE754-32", "IEEE754-64", "decimal",
                                                 "boolean", "string", "dateTime"
                                             };

        #endregion

        #region Properties

        /// <summary>
        /// The indexed property to get a display name.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        /// The display name of the selected enumerated value.
        /// </returns>
        public string this[int index]
        {
            get
            {
                var result = "unknown";
                if (index >= 0 && index < Values.Length)
                {
                    result = Values[index];
                }

                return result;
            }
        }

        #endregion
    }
}
