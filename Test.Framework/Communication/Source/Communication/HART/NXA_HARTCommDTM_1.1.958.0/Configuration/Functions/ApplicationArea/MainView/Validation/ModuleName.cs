//------------------------------------------------------------------------------
// <copyright file="ModuleName.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.Functions.ApplicationArea.MainView.Validation
{
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Description of ModuleName.
    /// </summary>
    public class ModuleName : IModuleName
    {
        /// <summary>
        /// Gets Returns name of actual module
        /// </summary>
        public string Name
        {
            get { return "Configuration"; }
        }
    }
}