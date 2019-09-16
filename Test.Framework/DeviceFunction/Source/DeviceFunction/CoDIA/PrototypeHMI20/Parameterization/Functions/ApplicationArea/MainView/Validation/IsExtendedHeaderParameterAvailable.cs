﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsExtendedHeaderParameterAvailable.
    /// </summary>
    public class IsExtendedHeaderParameterAvailable : IIsExtendedHeaderParameterAvailable
    {
        /// <summary>
        /// Determines whether an extended header parameter exists in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns><c>true</c> if parameter exists, <c>false</c> otherwise.</returns>
        public bool Run(string parameterId)
        {
            try
            {
                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var listPageList = listPage?.Element("List");
                    
                    var extendedHeaderParams = listPageList?.Elements("ExtendedDeviceHeaderDTM")?.Elements("FloatValueItem").Where(e => e.Attribute("id")?.Value == parameterId);


                    if (extendedHeaderParams != null && extendedHeaderParams.Any())
                    {
                        result = true;
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter " + parameterId + " is available in current display content extended header.");
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter " + parameterId + " is not available in current display content extended header.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}
