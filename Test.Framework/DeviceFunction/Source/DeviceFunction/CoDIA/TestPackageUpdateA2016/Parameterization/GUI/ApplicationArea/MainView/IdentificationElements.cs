//------------------------------------------------------------------------------
// <copyright file="IdentificationElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.03.2012
 * Time: 10:26 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Ranorex;
    using Ranorex.Core;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     IdentificationElements provides functions to gain access to several GUI elements
    /// </summary>
    public class IdentificationElements
    {
        /// <summary>
        ///     Get internal control name of header parameter
        /// </summary>
        /// <returns>
        ///     <br>List of string: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public static List<string> GetHeaderParameterControlNames()
        {
            try
            {
                var controlNameList = new List<string>();
                IList<Element> elementList = Host.Local.Find(IdentificationPaths.StrIdenAreaParameterEdit, DefaultValues.iTimeoutDefault);
                if (elementList.Count > 0)
                {
                    foreach (Element element in elementList)
                    {
                        Control control = new Control(element);
                        controlNameList.Add(control.Name);
                    }
                }
                return controlNameList;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}