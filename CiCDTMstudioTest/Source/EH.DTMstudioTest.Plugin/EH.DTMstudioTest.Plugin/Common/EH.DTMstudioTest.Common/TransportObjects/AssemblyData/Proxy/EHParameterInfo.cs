// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHParameterInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh method infos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;

    /// <summary>
    /// The eh parameter info.
    /// </summary>
    [Serializable]
    public class EhParameterInfo : MarshalByRefObject
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EhParameterInfo"/> class.
        /// </summary>
        public EhParameterInfo()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parameter type.
        /// </summary>
        public string ParameterType { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="EhParameterInfo"/>.
        /// </returns>
        public EhParameterInfo Copy()
        {
            var result = new EhParameterInfo();

            result.Name = this.Name;
            result.ParameterType = this.ParameterType;

            return result;
        }

        #endregion
    }
}