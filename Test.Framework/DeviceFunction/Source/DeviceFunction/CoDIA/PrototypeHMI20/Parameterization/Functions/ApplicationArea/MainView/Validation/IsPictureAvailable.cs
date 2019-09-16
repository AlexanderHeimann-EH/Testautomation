﻿namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsPictureAvailable.
    /// </summary>
    public class IsPictureAvailable : IIsPictureAvailable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether a picture is displayed (on help page) for a parameter in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter id.</param>
        /// <returns><c>true</c> if picture available, <c>false</c> otherwise.</returns>
        public bool ViaParameterId(string parameterId)
        {
            try
            {
                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var helpPage = displayContent?.Element("HelpPage");
                    var helpPageList = helpPage?.Element("List");
                    var parameterWeAreLookingFor = helpPageList?.Elements().Where(e => e.Attribute("id")?.Value == parameterId);
                    var images = parameterWeAreLookingFor?.Elements("ListColumn").Elements("SVGImage");

                    if (images != null && images.Any())
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Picture for parameter '" + parameterId + "' is available.");
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Picture for parameter '" + parameterId + "' is not available.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks whether a picture is displayed (on help page) for a parameter in current display content.
        /// </summary>
        /// <param name="pictureId">The picture id.</param>
        /// <returns><c>true</c> if picture available, <c>false</c> otherwise.</returns>
        public bool ViaPictureId(string pictureId)
        {
            try
            {
                bool result = false;
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var helpPage = displayContent?.Element("HelpPage");
                    var helpPageList = helpPage?.Element("List");                    
                    var imageWeAreLookingFor = helpPageList?.Elements("ListItem")?.Elements("ListColumn").Elements("SVGImage").Where(e => e.Attribute("name")?.Value == pictureId);

                    if (imageWeAreLookingFor != null)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Picture '" + pictureId + "' is available.");
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Picture '" + pictureId + "' is not available.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}