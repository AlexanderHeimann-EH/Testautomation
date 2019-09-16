// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHMethodInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh method infos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The eh method infos.
    /// </summary>
    [Serializable]
    public class EhMethodInfo : MarshalByRefObject
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EhMethodInfo"/> class.
        /// </summary>
        public EhMethodInfo()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the location.
        /// declaringType.Assembly.Location
        /// </summary>
        public string AssemblyFullPath { get; set; }

        /// <summary>
        /// Gets or sets the reflected type name.
        /// ReflectedType.Name
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the attribut guid.
        /// </summary>
        public string CustomAttributGuid { get; set; }

        /// <summary>
        /// Gets or sets the attribut test definition.
        /// </summary>
        public string CustomAttributTestDefinition { get; set; }

        /// <summary>
        /// Gets or sets the attribut test script.
        /// </summary>
        public TestScript CustomAttributTestScript { get; set; }

        /// <summary>
        /// Gets or sets the type of the member.
        /// </summary>
        /// <value>The type of the member.</value>
        public string MemberType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string MethodDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// methodInfo.DeclaringType.FullName 
        /// </summary>
        public string MethodFullName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the parameter info.
        /// </summary>
        public EhParameterInfoCollection ParameterInfo { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="EhMethodInfo"/>.
        /// </returns>
        public EhMethodInfo Copy()
        {
            var result = new EhMethodInfo();

            result.AssemblyFullPath = this.AssemblyFullPath;
            result.ClassName = this.AssemblyFullPath;
            //result.CustomAttributes = this.CustomAttributes;
            result.MemberType = this.MemberType;
            result.MethodDisplayName = this.MethodDisplayName;
            result.MethodFullName = this.MethodFullName;
            result.MethodName = this.MethodName;
            result.Namespace = this.Namespace;
            result.ParameterInfo = this.ParameterInfo.Copy();

            return result;
        }

        #endregion
    }
}