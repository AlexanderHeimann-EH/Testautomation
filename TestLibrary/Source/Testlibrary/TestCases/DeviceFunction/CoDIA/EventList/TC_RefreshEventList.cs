// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_RefreshEventList.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.EventList
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.EventList;

    /// <summary>
    /// Opens module Event List, refreshes and closes the module afterwards.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_RefreshEventList
// ReSharper restore InconsistentNaming
    {
        #region Public Methods and Operators

        /// <summary>
        /// Refreshes the EventList
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("9A2DF940-99F6-43BC-892A-3DAB4934A9F9", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            bool isPassed = Flows.Refresh.Run();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_RefreshEventList passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_RefreshEventList failed.");
                Log.Screenshot();
            }

            return isPassed;
        }

        #endregion
    }
}