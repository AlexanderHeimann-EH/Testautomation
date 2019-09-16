// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHResourceInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh test suite info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;

    /// <summary>
    /// The eh test suite info.
    /// </summary>
    [Serializable]
    public class EhResourceInfo : MarshalByRefObject
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EhResourceInfo"/> class.
        /// </summary>
        public EhResourceInfo()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        public string ResourceNameFullPath { get; set; }

        /// <summary>
        /// Gets or sets the test suite path.
        /// </summary>
        public string ResourceName { get; set; }

        #endregion
    }
}