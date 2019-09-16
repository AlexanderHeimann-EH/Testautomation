// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetNamurStatusFromHeader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetNamurStatusFromHeader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class GetNamurStatusFromHeader.
    /// </summary>
    public class GetNamurStatusFromHeader : IGetNamurStatusFromHeader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current Namur-Status from the identification area of the DTM.
        /// </summary>
        /// <returns>Current Namur-Status. E.g. 'OK', 'Function check (C)'.</returns>
        public string Run()
        {
            try
            {
                string result;
                string guiHelpString = CommonFlows.GetDtmContainerPath.Run();
                string buffer = guiHelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmIdentificationArea']" + @"/descendant::element[@controlname~'SPV_CurrentEventCategorySeparated_1']";
                Element element;
                Host.Local.TryFindSingle(buffer, DefaultValues.iTimeoutModules, out element);
                if (element == null)
                {
                    result = "Namur status not available";
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Namur status icon is null.");
                }
                else
                {
                    result = element.GetAttributeValueText("Text");
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return "Namur status not available";
            }
        }

        #endregion
    }
}