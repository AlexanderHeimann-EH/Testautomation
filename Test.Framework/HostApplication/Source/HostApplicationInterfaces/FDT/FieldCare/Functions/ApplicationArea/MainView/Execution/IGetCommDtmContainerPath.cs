// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetCommDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The GetCommDtmContainerPath interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    /// The GetCommDtmContainerPath interface.
    /// </summary>
    public interface IGetCommDtmContainerPath
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Gets the path of the CommDtm Container of the actually used frame
        /// </summary>
        /// <returns>
        ///     string: with the absolute path of the CommDtm Container
        ///     null: if an error occurred
        /// </returns>
        string Run();

        #endregion
    }
}