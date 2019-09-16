//------------------------------------------------------------------------------
// <copyright file="ISetParameter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Execution
{
    using Ranorex.Core;

    /// <summary>
    /// The SetParameter interface.
    /// </summary>
    public interface ISetParameter
    {
        /// <summary>
        ///     Set a specific control to a specific value
        /// </summary>
        /// <param name="element">control to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        bool SetParameterValue(Element element, string value);

        /// <summary>
        ///     Get value of a specific control
        /// </summary>
        /// <param name="element">control to get the value from</param>
        /// <returns>
        ///     <br>String: if everything worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        string GetParameterValue(Element element);
    }
}