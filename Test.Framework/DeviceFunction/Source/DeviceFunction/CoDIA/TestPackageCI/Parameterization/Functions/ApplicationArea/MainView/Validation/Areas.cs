//------------------------------------------------------------------------------
// <copyright file="Areas.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    ///     Provides validations methods which validate whether the module is ready or not
    /// </summary>
    public class Areas : MarshalByRefObject, IAreas
    {
        /// <summary>
        ///     Check if main dtm areas are available
        /// </summary>
        /// <returns>
        ///     <br>True: if areas are available</br>
        ///     <br>False: if if areas are not available</br>
        /// </returns>
        public bool AreAreasAvailable()
        {
            return this.IsNavigationAreaAvailable() && this.IsApplicationAreaAvailable() && this.IsIdentificationAreaAvailable();
        }

        /// <summary>
        ///     Check if identifikation area is available
        /// </summary>
        /// <returns>
        ///     <br>True: if identification area is available</br>
        ///     <br>False: if identification area is not available</br>
        /// </returns>
        public bool IsIdentificationAreaAvailable()
        {
            Container container;
            if (Host.Local.TryFindSingle(IdentificationPaths.Area, DefaultValues.GeneralTimeout, out container))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Check if display area is available
        /// </summary>
        /// <returns>
        ///     <br>True: if application area is available</br>
        ///     <br>False: if application area is not available</br>
        /// </returns>
        public bool IsApplicationAreaAvailable()
        {
            Container container;
            if (Host.Local.TryFindSingle(ApplicationPaths.Area, DefaultValues.GeneralTimeout, out container))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Check if navigation area is available
        /// </summary>
        /// <returns>
        ///     <br>True: if navigation area is available</br>
        ///     <br>False: if navigation area is not available</br>
        /// </returns>
        public bool IsNavigationAreaAvailable()
        {
            Container container;
            if (Host.Local.TryFindSingle(NavigationPaths.Area, DefaultValues.GeneralTimeout, out container))
            {
                return true;
            }
            return false;
        }
    }
}