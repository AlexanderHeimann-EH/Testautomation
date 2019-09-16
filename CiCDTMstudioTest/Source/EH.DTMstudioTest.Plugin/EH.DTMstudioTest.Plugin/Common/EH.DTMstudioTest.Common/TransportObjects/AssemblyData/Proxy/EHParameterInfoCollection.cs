// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHParameterInfoCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh parameter info collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The eh parameter info collection.
    /// </summary>
    [Serializable]
    public class EhParameterInfoCollection : List<EhParameterInfo>
    {
        public EhParameterInfoCollection()
        {
        }

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        public EhParameterInfoCollection Copy()
        {
            var result = new EhParameterInfoCollection();

            result.AddRange(this.Select(ehParameterInfo => ehParameterInfo.Copy()));

            return result;
        }

        #endregion
    }
}