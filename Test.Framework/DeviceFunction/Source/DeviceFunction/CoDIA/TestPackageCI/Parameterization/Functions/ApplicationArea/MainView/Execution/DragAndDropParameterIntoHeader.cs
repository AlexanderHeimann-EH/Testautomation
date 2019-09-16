// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragAndDropParameterIntoHeader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class DragAndDropParameterIntoHeader.
    /// </summary>
    public class DragAndDropParameterIntoHeader : IDragAndDropParameterIntoHeader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs the specified item identifier.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns><c>true</c> if executed, <c>false</c> otherwise.</returns>
        public bool Run(string itemId, string source, string destination)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not available with standard Parameterization. Use HMI instead.");
            return false;
        }

        #endregion
    }
}