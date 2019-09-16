// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System.Reflection;

    /// <summary>
    /// The log info.
    /// </summary>
    public static class LogInfo
    {
        /// <summary>
        /// The namespace.
        /// </summary>
        /// <param name="methodBase">
        /// The method base.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Namespace(MethodBase methodBase)
        {
            string namespacePath = string.Empty;
            if (methodBase.DeclaringType != null)
            {
                namespacePath = methodBase.DeclaringType.Namespace + "." + /*Namespace*/ methodBase.DeclaringType.Name
                                + "." + /*Class*/ methodBase.Name; /*Method name*/
            }

            return namespacePath.Replace(".", ". ");
        }
    }
}

// class                 - this.GetType().Name
// namespace             - this.GetType().FullName
// method                - System.Reflection.MethodInfo.GetCurrentMethod().Name
// namespace der Methode - System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Namespace