// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDtmConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDtmConnected.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class IsDtmConnected : IIsDtmConnected
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determines whether DTM is online
        /// </summary>
        /// <returns>
        ///     true: if DTM is online
        ///     false: if DTM is offline or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusbarElements().ConnectionState;
            if (state.Equals(string.Empty))
            {
                return false;
            }

            watch.Start();

            // timeout needed, state can be "going online" for several seconds depending on communication and whether Historom module or another module are already open 
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusbarElements().ConnectionState;
                if (!state.Equals("Online"))
                {
                    continue;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is connected " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                return true;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not connected after " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }

        #endregion
    }
}