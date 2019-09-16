// -----------------------------------------------------------------------
// <copyright file="IIsSavingActive.cs" company="Endress+Hauser Process Solutions AG">
// Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.SaveProjectState.Validation
{
    /// <summary>
    /// Interface for IIsSavingActive
    /// </summary>
    public interface IIsSavingActive
    {
        /// <summary>
        ///     Check if saving message is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        bool Run();
    }
}
